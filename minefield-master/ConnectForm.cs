using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Minefield_Online {
    public partial class ConnectForm : Form {

        Main mainForm;
        public ConnectForm() {
            InitializeComponent();
        }
        public ConnectForm(Main _mainForm)
        {
            mainForm = _mainForm;
            InitializeComponent();
        }


        private void Create_Click(object sender, EventArgs e) {
            mainForm.playerName = nickname.Text;
            mainForm.serverAddress = address.Text;
            mainForm.serverPort = ushort.Parse(port.Text);

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void ConnectForm_Load(object sender, EventArgs e) {
            this.Icon = System.Drawing.Icon.FromHandle(global::Minefield_Online.Properties.Resources.server__plus.GetHicon());
        }
    }
}
