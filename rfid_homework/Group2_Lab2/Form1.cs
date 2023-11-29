﻿using System;
using System.Windows.Forms;
//using System.BitConverter;

namespace WindowsFormsApplication6
{
    public partial class Form1 : Form
    {
        EasyPodLib easyPodLib = new EasyPodLib();
        UInt16 LOADKEY_LENGTH  = 12;
        static string key = "FFFFFFFFFFFF";
        
        //定義會員資料的位置
        MemberRfid memberRfid = new MemberRfid
        {
            AddressNo = new AddressStruct(0, 1, "A", key),
            AddressName = new AddressStruct(0, 2, "A", key),
            AddressApplyDate = new AddressStruct(0, 3, "A", key),
            AddressCredit = new AddressStruct(0, 4, "A", key),
        };
        public Form1()
        {
            InitializeComponent();
            txtLoadkey.Text = key;
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
                throw new NotImplementedException();
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
                MessageBox.Show("會員點數格式錯誤, " + txtMemberApplyDate_Issue.Text); return;
            }
            if (!DateTime.TryParse(txtMemberApplyDate_Issue.Text, out DateTime dtApplyDate))
            {
                MessageBox.Show("會員日期格式錯誤, " + txtMemberApplyDate_Issue.Text); return;
            }
            #endregion

            try
            {
                #region//Write data
               
                #endregion
                MessageBox.Show("寫入完成");
            }
            catch (Exception ex)
            {
                MessageBox.Show("發生錯誤!" + ex.Message);
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
                #region//Write data
              
                #endregion
                MessageBox.Show("清空完成");
            }
            catch (Exception ex)
            {
                MessageBox.Show("發生錯誤!" + ex.Message);
            }
        }

        /// <summary>
        /// 查詢卡片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadCard_Inquery_Click(object sender, EventArgs e)
        {

        }

        private void btnRecharge_Click(object sender, EventArgs e)
        {

        }

        private void btnConsume_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}