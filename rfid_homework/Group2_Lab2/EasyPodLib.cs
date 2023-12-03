﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Linq;
using System.Windows.Forms;

public class EasyPodLib
{
    MW_EasyPOD EasyPOD;
    AddressStruct AddressNo = new AddressStruct(0, 1, "A");
    AddressStruct AddressName = new AddressStruct(0, 2, "A");
    AddressStruct AddressApplyDate = new AddressStruct(0, 3, "A");
    AddressStruct AddressCredit = new AddressStruct(0, 4, "A");


    public void Create_Card(string no, string name, DateTime applydate, int credit, string loadKey)
    {
        var sNo = write_rfid_value(0, 1, "A", loadKey, ConvertStringToByteArray(no));
        var sNm = write_rfid_value(0, 2, "A", loadKey, ConvertStringToByteArray(name));
        var sAd = write_rfid_value(1, 0, "A", loadKey, ConvertStringToByteArray(applydate.ToShortDateString()));
        var sCt = write_rfid_value(1, 1, "A", loadKey, ConvertStringToByteArray(credit.ToString()));
    }
    public void Clear_Card(string loadKey)
    {
        var s1 = write_rfid_value(0, 1, "A", loadKey, new byte[16]);
        var s2 = write_rfid_value(0, 2, "A", loadKey, new byte[16]);
        var s3 = write_rfid_value(1, 0, "A", loadKey, new byte[16]);
        var s4 = write_rfid_value(1, 1, "A", loadKey, new byte[16]);
    }
    public (string no, string name, DateTime applydate, int credit) Read_Card(string loadKey)
    {
        var result = (no: "", name: "", applydate: DateTime.MinValue, credit: 0);
        var byteNo = read_rfid_value_byte(0, 1, "A", loadKey);
        var byteNm = read_rfid_value_byte(0, 2, "A", loadKey);
        var byteAd = read_rfid_value_byte(1, 0, "A", loadKey);
        var byteCt = read_rfid_value_byte(1, 1, "A", loadKey);
        result.no = ConvertByteArrayToString(byteNo);
        result.name = ConvertByteArrayToString(byteNm);
        result.applydate = Convert.ToDateTime(ConvertByteArrayToString(byteAd));
        result.credit = int.Parse(ConvertByteArrayToString(byteCt));
        return result;
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

                dwResult = PODfuncs.WriteData(pPOD, WriteBuffer, Convert.ToUInt32(WriteBuffer.Length), &uiWritten);    //Send a request command to reader
                uiResult = PODfuncs.ReadData(pPOD, ReadBuffer, uiLength, &uiRead);  //Read the response data from reader

                // decode result to HEX format
                resultStr = BitConverter.ToString(ReadBuffer, 4, (Int32)uiRead).Replace("-", " ");
            }
            dwResult = PODfuncs.ClearPODBuffer(pPOD);
            dwResult = PODfuncs.DisconnectPOD(pPOD);
        }

        return resultStr;
    }
    public unsafe byte[] read_rfid_value_byte(UInt16 sector, UInt16 block, String keyAB, String key)
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
        byte[] resultBytes = null;

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

                dwResult = PODfuncs.WriteData(pPOD, WriteBuffer, Convert.ToUInt32(WriteBuffer.Length), &uiWritten);    //Send a request command to reader
                uiResult = PODfuncs.ReadData(pPOD, ReadBuffer, uiLength, &uiRead);  //Read the response data from reader
                resultBytes = new byte[uiRead];
                Array.Copy(ReadBuffer, 4, resultBytes, 0, (int)uiRead - 4);
                // decode result to HEX format
                resultStr = BitConverter.ToString(ReadBuffer, 4, (Int32)uiRead).Replace("-", " ");
            }
            dwResult = PODfuncs.ClearPODBuffer(pPOD);
            dwResult = PODfuncs.DisconnectPOD(pPOD);
        }

        return resultBytes;
    }
   
    unsafe public String write_rfid_value(UInt16 sector, UInt16 block, String keyAB, String key, byte[] val)
    {
        UInt32 dwResult, Index;
        UInt32 uiLength, uiRead, uiResult, uiWritten;
        byte[] ReadBuffer = new byte[0x40];
        byte[] WriteBuffer = build_write_cmd(sector, block, keyAB, key);
        WriteBuffer = WriteBuffer.Concat((val)).ToArray();

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
            }
            else
            {
                EasyPOD.ReadTimeOut = 200;
                EasyPOD.WriteTimeOut = 200;

                //dwResult = PODfuncs.WriteData(pPOD, WriteBuffer, 4, &uiWritten);    //Send a request command to reader
                dwResult = PODfuncs.WriteData(pPOD, WriteBuffer, Convert.ToUInt32(WriteBuffer.Length), &uiWritten);    //Send a request command to reader
                uiResult = PODfuncs.ReadData(pPOD, ReadBuffer, uiLength, &uiRead);  //Read the response data from reader

                // decode result to HEX format
                resultStr = BitConverter.ToString(ReadBuffer, 4, (Int32)uiRead).Replace("-", " ");
            }
            dwResult = PODfuncs.ClearPODBuffer(pPOD);
            dwResult = PODfuncs.DisconnectPOD(pPOD);
        }

        return resultStr;
    }
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
        Console.WriteLine(BitConverter.ToString(WriteBuffer));
        return WriteBuffer;
    }
    private byte[] build_write_cmd(UInt16 sector, UInt16 block, String keyAB, String key)
    {
        // convert hex string to byte array
        byte[] key_bytes = new byte[key.Length / 2];

        for (int i = 0; i < key.Length; i += 2)
            key_bytes[i / 2] = Convert.ToByte(key.Substring(i, 2), 16);

        // build up command
        byte[] WriteBuffer = new byte[] {
            0x2,  // STX
            0x1A,  // LEN
            0x16, // CMD
            (byte)((keyAB == "A")? 0x60: 0x61), // KEY Type
            key_bytes[0], // KEY most left
            key_bytes[2], // KEY 
            key_bytes[1], // KEY 
            key_bytes[3], // KEY 
            key_bytes[4], // KEY 
            key_bytes[5], // KEY most right
            (byte)sector, // Sector
            (byte)block   // Block
        };
        var result = WriteBuffer;
        Console.WriteLine(BitConverter.ToString(WriteBuffer));
        Console.WriteLine(BitConverter.ToString(result));

        return result;
    }
    public byte[] ConvertStringToByteArray(string text)
    {
        // 使用 UTF-8 編碼將字符串轉換成 byte[]
        byte[] byteArray = Encoding.UTF8.GetBytes(text);

        // 如果長度小於16，則補零
        if (byteArray.Length < 16)
        {
            byte[] paddedArray = new byte[16];
            Array.Copy(byteArray, paddedArray, byteArray.Length);
            return paddedArray;
        }

        return byteArray;
    }
    public string ConvertByteArrayToString(byte[] byteArray)
    {
        // 使用 UTF-8 解碼將 byte[] 轉換成字符串
        string resultString = Encoding.UTF8.GetString(byteArray);

        // 去除尾部的零
        resultString = resultString.TrimEnd('\0');

        return resultString;
    }
    
    public byte[] ConvertHexStringToByteArray(string val)
    {
        string[] hexValues = val.Split(' ');
        byte[] byteArray = new byte[hexValues.Length];
        for (int i = 0; i < hexValues.Length; i++)
        {
            if (!byte.TryParse(hexValues[i], out byte byteVal))
            {
                throw new Exception("必須為數字組成");
            }
            byteArray[i] = Convert.ToByte(hexValues[i], 16);
        }
        return byteArray;
    }
}
public class MemberRfid
{
    public AddressStruct AddressNo;
    public AddressStruct AddressName;
    public AddressStruct AddressApplyDate;
    public AddressStruct AddressCredit;
    public string ValueNo;
    public string ValueName;
    public string ValueApplyDate;
    public string ValueCredit;
}
public struct AddressStruct
{
    public UInt16 Sector;
    public UInt16 Block;
    public String KeyAB;
    public AddressStruct(UInt16 Sector, UInt16 Block, String KeyAB)
    {
        this.Sector = Sector;
        this.Block = Block;
        this.KeyAB = KeyAB;
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


