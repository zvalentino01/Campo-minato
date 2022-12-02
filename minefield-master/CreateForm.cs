using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Minefield_Online
{
    public partial class CreateForm : Form
    {
        Main mainForm;
        public CreateForm()
        {
            InitializeComponent();
        }
        public CreateForm(Main _mainForm)
        {
            mainForm = _mainForm;
            InitializeComponent();
        }

        private void CreateForm_Load(object sender, EventArgs e)
        {
            this.Icon = System.Drawing.Icon.FromHandle(global::Minefield_Online.Properties.Resources.server_cast.GetHicon());
        }

        private void port_TextChanged(object sender, EventArgs e)
        {

        }

        private void Create_Click(object sender, EventArgs e)
        {
            mainForm.playerName = nickname.Text;
            mainForm.settings.ServerPort = ushort.Parse(port.Text);
            mainForm.settings.Players = (ushort)players.Value;
            mainForm.settings.Horizontal = (ushort)horizontal.Value;
            mainForm.settings.Vertical = (ushort)vertical.Value;
            mainForm.settings.Bombs = (ushort)bombs.Value;

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

     
    }
}
