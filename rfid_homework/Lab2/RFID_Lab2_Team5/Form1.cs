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
    }
}
