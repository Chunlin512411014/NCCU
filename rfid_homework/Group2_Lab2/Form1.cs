using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using System.BitConverter;

namespace WindowsFormsApplication6
{
    public partial class Form1 : Form
    {
        EasyPodLib easyPodLib = new EasyPodLib();
        UInt16 LOADKEY_LENGTH  = 12;

        public Form1()
        {
            InitializeComponent();
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return;
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
    
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnWritedata_Click(object sender, EventArgs e)
        {

        }

        private void btnCreateCard_Issue_Click(object sender, EventArgs e)
        {

        }

        private void btnClearCard_Issue_Click(object sender, EventArgs e)
        {

        }

        private void btnReadCard_Inquery_Click(object sender, EventArgs e)
        {

        }

        private void btnRecharge_Click(object sender, EventArgs e)
        {

        }

        private void btnConsume_Click(object sender, EventArgs e)
        {

        }



    }
}
