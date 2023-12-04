using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
//using System.BitConverter;

namespace WindowsFormsApplication6
{
    public partial class Form1 : Form
    {
        
        UInt16 LOADKEY_LENGTH  = 12;
        static string key = "FFFFFFFFFFFF";
        EasyPodLib easyPodLib = new EasyPodLib();

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            txtLoadkey.Text = key;
            txtMemberApplyDate_Issue.Text = DateTime.Now.ToShortDateString();
            string val = "王1";
            var ss = val.ToCharArray();
            var s1 = Encoding.UTF8.GetBytes("王");
            var s2 = Encoding.UTF8.GetBytes("王王");
            var s3 = Encoding.UTF8.GetBytes("王大王");
            var s4 = Encoding.UTF8.GetBytes("123");
            var b1 = BitConverter.ToString(s1);
            var b2 = BitConverter.ToString(s2);
            var b3 = BitConverter.ToString(s3);
            var b4 = BitConverter.ToString(s4);

            List<string> list = new List<string>();
            foreach (var v in new string[] { "王", "王王", "王大王", "123" })
            {
                var b = easyPodLib.ConvertStringToByteArray(v);
                var bs = BitConverter.ToString(b);
                var s = easyPodLib.ConvertByteArrayToString(b);
                Console.Write(b);
                Console.Write(bs);
                Console.WriteLine(s);
            }
            foreach (var s in ss)
            {
                var si = Convert.ToInt32(s);
                var sxx = BitConverter.GetBytes(si);

                var sss = BitConverter.ToString(sxx);
                //easyPodLib.ConvertStringToByteArray(s);

                Console.WriteLine(BitConverter.ToString(sxx));
            }
        }
        private void btnReaddata_Click(object sender, EventArgs e)
        {
            // reading RFID card value from user selection
            UInt16 sectorID = (ushort)combSector.SelectedIndex;
            UInt16 blockID = (ushort)combBlock.SelectedIndex;
            String keyAB = combKeyab.GetItemText(combKeyab.SelectedItem);
            String key = txtLoadkey.Text;
            try
            {
                
                txtIdenity.Text = easyPodLib.read_rfid_value(sectorID, blockID, keyAB, key);
                MessageBox.Show("Read Data完成");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void valueChangeCheck(object sender, EventArgs e)
        {
            
            Boolean isSectorSelected = combSector.SelectedItem != null;
            Boolean isBlockSelected = combBlock.SelectedItem != null;
            Boolean isKeyabSelected = combKeyab.SelectedItem != null;
            Boolean isLoadkeyLen12 = txtLoadkey.Text.Length == LOADKEY_LENGTH;
            Boolean isInputValid = isSectorSelected && isBlockSelected && isKeyabSelected && isLoadkeyLen12;

            if (isInputValid)
            {
                btnReaddata.Enabled = true;
                btnWritedata.Enabled = true;
            }
            else
            {
                btnWritedata.Enabled = false;
                btnReaddata.Enabled = false;
            }
        }


        private void btnWritedata_Click(object sender, EventArgs e)
        {
            try
            {
                #region//Validation
                if (string.IsNullOrEmpty(txtWriteHexData.Text))
                {
                    MessageBox.Show("文字必填"); return;
                }
                #endregion
                //txtWriteHexData.text = 31 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00

                byte[] byteArray = easyPodLib.ConvertHexStringToByteArray(txtWriteHexData.Text);
               
                UInt16 sectorID = (ushort)combSector.SelectedIndex;
                UInt16 blockID = (ushort)combBlock.SelectedIndex;
                String keyAB = combKeyab.GetItemText(combKeyab.SelectedItem);
                String key = txtLoadkey.Text;

                easyPodLib.write_rfid_value(sectorID, blockID, keyAB, key, byteArray);
                //throw new NotImplementedException();
                MessageBox.Show("Write Data完成");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// 卡片製作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateCard_Issue_Click(object sender, EventArgs e)
        {
            #region//Validation
            if (string.IsNullOrEmpty(txtMemberNo_Issue.Text))
            {
                MessageBox.Show("會員編號必填"); return;
            }
            if (string.IsNullOrEmpty(txtMemberName_Issue.Text))
            {
                MessageBox.Show("會員姓名必填"); return;
            }
            if (string.IsNullOrEmpty(txtMemberApplyDate_Issue.Text))
            {
                MessageBox.Show("會員日期必填"); return;
            }
            if (string.IsNullOrEmpty(txtMemberCredit_Issue.Text))
            {
                MessageBox.Show("會員點數必填"); return;
            }
            if (!int.TryParse(txtMemberCredit_Issue.Text, out int intMemberCredit))
            {
                MessageBox.Show("會員點數格式錯誤, " + txtMemberCredit_Issue.Text); return;
            }
            if (!DateTime.TryParse(txtMemberApplyDate_Issue.Text, out DateTime dtApplyDate))
            {
                MessageBox.Show("會員日期格式錯誤, " + txtMemberApplyDate_Issue.Text); return;
            }
            #endregion

            try
            {
                EasyPodLib easyPodLib = new EasyPodLib();
                //Write data
                easyPodLib.Create_Card(txtMemberNo_Issue.Text, txtMemberName_Issue.Text, dtApplyDate, intMemberCredit, txtLoadkey.Text);
                
                MessageBox.Show("寫入完成");
            }
            catch (Exception ex)
            {
                MessageBox.Show("發生錯誤! " + ex.Message);
            }
        }
        /// <summary>
        ///  清空卡片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearCard_Issue_Click(object sender, EventArgs e)
        {
            try
            {
                easyPodLib.Clear_Card(txtLoadkey.Text);
                txtMemberNo_Issue.Text = "";
                txtMemberName_Issue.Text = "";
                txtMemberApplyDate_Issue.Text = "";
                txtMemberApplyDate_Issue.Text = "";
                MessageBox.Show("清空完成");
            }
            catch (Exception ex)
            {
                MessageBox.Show("發生錯誤! " + ex.Message);
            }
        }

        /// <summary>
        /// 查詢卡片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadCard_Inquery_Click(object sender, EventArgs e)
        {
            try
            {
                var result = easyPodLib.Read_Card(txtLoadkey.Text);
                txtMemberNo_Inquery.Text = result.no;
                txtMemberName_Inquery.Text = result.name;
                txtMemberApplyDate_Inquery.Text = result.applydate.ToShortDateString();
                txtMemberCredit_Inquery.Text = result.credit.ToString();
                MessageBox.Show("讀取完成");
            }
            catch (Exception ex)
            {
                MessageBox.Show("發生錯誤! " + ex.Message);
            }
        }

        private void btnRecharge_Click(object sender, EventArgs e)
        {
            #region // validation
            int credit_plus = 0;
            if(!int.TryParse(txtMemberCredit_Recharge.Text, out credit_plus))
            {
                MessageBox.Show("點數格式錯誤, " + txtMemberCredit_Recharge.Text); return;
            }
            if (credit_plus <= 0)
            {
                MessageBox.Show("點數不得<=0, " + txtMemberCredit_Recharge.Text); return;
            }
            #endregion
            try
            {
                var result = easyPodLib.Charge_Card(credit_plus, txtLoadkey.Text);
                MessageBox.Show("儲值:" + result.credit_plus + "; 可用餘額:" + result.credit_after);
            }
            catch (Exception ex)
            {
                MessageBox.Show("發生錯誤! " + ex.Message);
            }
        }

        private void btnConsume_Click(object sender, EventArgs e)
        {
            #region // validation
            int credit_plus = 0;
            if (!int.TryParse(txtMemberCredit_Recharge.Text, out credit_plus))
            {
                MessageBox.Show("點數格式錯誤, " + txtMemberCredit_Recharge.Text); return;
            }
            if (credit_plus <= 0)
            {
                MessageBox.Show("點數不得<=0, " + txtMemberCredit_Recharge.Text); return;
            }
            #endregion
            
            try
            {
                var result = easyPodLib.Charge_Card(credit_plus * -1, txtLoadkey.Text);
                MessageBox.Show("消費:" + Math.Abs(result.credit_plus) + "; 可用餘額:" + result.credit_after);
            }
            catch (Exception ex)
            {
                MessageBox.Show("發生錯誤! " + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
