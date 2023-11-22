﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;



public class EasyPodLib
{
    MW_EasyPOD EasyPOD;
   
    private byte[] build_cmd(UInt16 sector, UInt16 block, String keyAB, String key)
    {
        // convert hex string to byte array
        byte[] key_bytes = new byte[key.Length / 2];

        for (int i = 0; i < key.Length; i += 2)
            key_bytes[i / 2] = Convert.ToByte(key.Substring(i, 2), 16);

        // build up command
        byte[] WriteBuffer = new byte[] {
                0x2,  // STX
                0xA,  // LEN
                0x15, // CMD
                (byte)((keyAB == "A")? 0x60: 0x61), // KEY Type
                key_bytes[0], // KEY most left
                key_bytes[1], // KEY 
                key_bytes[2], // KEY 
                key_bytes[3], // KEY 
                key_bytes[4], // KEY 
                key_bytes[5], // KEY most right
                (byte)sector, // Sector
                (byte)block   // Block
            };

        //Console.WriteLine(BitConverter.ToString(WriteBuffer));

        return WriteBuffer;
    }

    public unsafe String read_rfid_value(UInt16 sector, UInt16 block, String keyAB, String key)
    {
        UInt32 dwResult, Index;
        UInt32 uiLength, uiRead, uiResult, uiWritten;
        byte[] ReadBuffer = new byte[0x40];
        byte[] WriteBuffer = build_cmd(sector, block, keyAB, key);

        byte[] sResponse = null;
        sResponse = new byte[21];

        EasyPOD.VID = 0xe6a;
        EasyPOD.PID = 0x317;
        Index = 1;
        uiLength = 64;

        String resultStr = "";

        fixed (MW_EasyPOD* pPOD = &EasyPOD)
        {

            dwResult = PODfuncs.ConnectPOD(pPOD, Index);

            if ((dwResult != 0))
            {
                throw new Exception("Not connected yet");
                //MessageBox.Show("Not connected yet");
            }
            else
            {
                EasyPOD.ReadTimeOut = 200;
                EasyPOD.WriteTimeOut = 200;

                dwResult = PODfuncs.WriteData(pPOD, WriteBuffer, 4, &uiWritten);    //Send a request command to reader
                uiResult = PODfuncs.ReadData(pPOD, ReadBuffer, uiLength, &uiRead);  //Read the response data from reader

                // decode result to HEX format
                resultStr = BitConverter.ToString(ReadBuffer, 4, (Int32)uiRead).Replace("-", " ");
            }
            dwResult = PODfuncs.ClearPODBuffer(pPOD);
            dwResult = PODfuncs.DisconnectPOD(pPOD);
        }

        return resultStr;
    }
}

public struct RFIDParameter
{
    public UInt16 Sector;
    public UInt16 Block;
    public String KeyAB;
    public String Key;
    public RFIDParameter(UInt16 Sector, UInt16 Block, String KeyAB, String Key)
    {
        this.Sector = Sector;
        this.Block = Block;
        this.KeyAB = KeyAB;
        this.Key = Key;
    }
}

[StructLayout(LayoutKind.Sequential)]
public struct MW_EasyPOD
{
    public uint VID;			        // Need to match user device's "Vendor ID".
    public uint PID;			        // Need to match user device's "Product ID".
    public uint ReadTimeOut;		    // Specifies the read data time-out interval, in milliseconds.
    public uint WriteTimeOut;		    // Specifies the write data time-out interval, in milliseconds.    
    public uint Handle;                 // Do not modify this value, reserved for DLL
    public uint FeatureReportSize;      // Do not modify this value, reserved for DLL
    public uint InputReportSize;        // Do not modify this value, reserved for DLL
    public uint OutputReportSize;       // Do not modify this value, reserved for DLL   
}

class PODfuncs
{
    [DllImport("EasyPOD.dll", CallingConvention = CallingConvention.StdCall)]
    unsafe public static extern uint ConnectPOD(MW_EasyPOD* pEasyPOD, uint Index);

    [DllImport("EasyPOD.dll", CallingConvention = CallingConvention.StdCall)]
    unsafe public static extern uint WriteData(MW_EasyPOD* pEasyPOD, byte[] lpBuffer, uint nNumberOfBytesToWrite, uint* lpNumberOfBytesWritten);

    [DllImport("EasyPOD.dll", CallingConvention = CallingConvention.StdCall)]
    unsafe public static extern uint ReadData(MW_EasyPOD* pEasyPOD, byte[] lpBuffer, uint nNumberOfBytesToRead, uint* lpNumberOfBytesRead);

    [DllImport("EasyPOD.dll", CallingConvention = CallingConvention.StdCall)]
    unsafe public static extern uint DisconnectPOD(MW_EasyPOD* pEasyPOD);

    [DllImport("EasyPOD.dll", CallingConvention = CallingConvention.StdCall)]
    unsafe public static extern uint ClearPODBuffer(MW_EasyPOD* pEasyPOD);
}


