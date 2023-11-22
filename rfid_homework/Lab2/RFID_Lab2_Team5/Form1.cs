using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RFID_Lab2_Team5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            lblMessage.Text = "";
        }

        private void btnReadData_Click(object sender, EventArgs e)
        {
            // reading RFID card value from user selection
            UInt16 sectorID = (ushort)combSector.SelectedIndex;
            UInt16 blockID = (ushort)combBlock.SelectedIndex;
            String keyAB = combKeyab.GetItemText(combKeyab.SelectedItem);
            String key = txtLoadkey.Text;

            txtIdenity.Text = read_rfid_value(sectorID, blockID, keyAB, key);

            return;
        }

        private void btnWriteData_Click(object sender, EventArgs e)
        {

        }

        private void btnCreateCard_Issue_Click(object sender, EventArgs e)
        {
            //init
            string memberNo = "";
            string memberNm = "";
            DateTime memberApplydate;
            int memberCredit = 0;
            #region// validation
            if (string.IsNullOrEmpty(txtMemberNo_Issue.Text))
            {
                ShowMsg("會員編號必填"); return;
            }
            if (string.IsNullOrEmpty(txtMemberName_Issue.Text))
            {
                ShowMsg("會員姓名必填"); return;
            }
            if (string.IsNullOrEmpty(txtMemberApplyDate_Issue.Text))
            {
                ShowMsg("時間必填"); return;
            }
            if (string.IsNullOrEmpty(txtMemberCredit_Issue.Text))
            {
                ShowMsg("點數必填"); return;
            }
            if (!DateTime.TryParse(txtMemberApplyDate_Issue.Text, out memberApplydate))
            {
                ShowMsg("時間格式錯誤"); return;
            }
            if (!int.TryParse(txtMemberCredit_Issue.Text, out memberCredit))
            {
                ShowMsg("點數格式錯誤"); return;
            }
            #endregion

            //asign value
            memberNo = txtMemberNo_Issue.Text;
            memberNm = txtMemberName_Issue.Text;
            if (MakeCard(memberNo, memberNm, memberApplydate, memberCredit))
            {
                ShowMsg("寫入完成");
            }
        }
        public bool MakeCard(string memberNo, string memberNm, DateTime memberApplydate, int memberCredit)
        {
            return true;
        }
        
        

        private void btnClearCard_Issue_Click(object sender, EventArgs e)
        {
            if (ClearCard() == true)
            {
                ShowMsg("清空完成");
            }
        }
        public bool ClearCard()
        {
            txtMemberApplyDate_Issue.Text = "";
            txtMemberCredit_Issue.Text = "";
            txtMemberName_Issue.Text = "";
            txtMemberNo_Issue.Text = "";

            return true;
        }

        private void btnReadCard_Inquery_Click(object sender, EventArgs e)
        {
            if (ReadCard())
            {
                ShowMsg("讀取完成");
            }
        }

        public bool ReadCard()
        {
            return true;
        }
        private void btnRecharge_Click(object sender, EventArgs e)
        {

        }

        private void btnConsume_Click(object sender, EventArgs e)
        {

        }

        private void ShowMsg(string msg, Color color = default(Color))
        {
            lblMessage.Text = msg;
            lblMessage.ForeColor = color;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        unsafe private String read_rfid_value(UInt16 sector, UInt16 block, String keyAB, String key)
        {
            UInt32 uiLength, uiRead, uiResult, uiWritten;
            byte[] ReadBuffer = new byte[0x40];
            byte[] WriteBuffer = build_cmd(sector, block, keyAB, key);

            byte[] sResponse = null;
            sResponse = new byte[21];

            EasyPODClass.VID = 0xe6a;
            EasyPODClass.PID = 0x317;
            Index = 1;
            uiLength = 64;

            String resultStr = "";

            fixed (MW_EasyPOD* pPOD = &EasyPOD)
            {

                dwResult = PODfuncs.ConnectPOD(pPOD, Index);

                if ((dwResult != 0))
                {
                    MessageBox.Show("Not connected yet");
                }
                else
                {
                    EasyPODClass.ReadTimeOut = 200;
                    EasyPODClass.WriteTimeOut = 200;

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
    }
}
