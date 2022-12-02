namespace Minefield_Online
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._mainMenu = new System.Windows.Forms.ToolStrip();
            this._menu_createServer = new System.Windows.Forms.ToolStripButton();
            this._menu_connect = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this._menu_toogleChat = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._menu_exit = new System.Windows.Forms.ToolStripButton();
            this.info_group = new System.Windows.Forms.GroupBox();
            this.info_player4 = new System.Windows.Forms.Label();
            this.info_player2 = new System.Windows.Forms.Label();
            this.info_player3 = new System.Windows.Forms.Label();
            this.info_player1 = new System.Windows.Forms.Label();
            this.info_label_points = new System.Windows.Forms.Label();
            this.info_turn = new System.Windows.Forms.Label();
            this.info_players = new System.Windows.Forms.Label();
            this.info_label_turn = new System.Windows.Forms.Label();
            this.info_label_players = new System.Windows.Forms.Label();
            this.field_group = new System.Windows.Forms.GroupBox();
            this.chat_group = new System.Windows.Forms.GroupBox();
            this.chat = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chat_send = new System.Windows.Forms.Button();
            this.chat_text = new System.Windows.Forms.TextBox();
            this._mainMenu.SuspendLayout();
            this.info_group.SuspendLayout();
            this.chat_group.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _mainMenu
            // 
            this._mainMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this._mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menu_createServer,
            this._menu_connect,
            this.toolStripSeparator2,
            this._menu_toogleChat,
            this.toolStripSeparator1,
            this._menu_exit});
            this._mainMenu.Location = new System.Drawing.Point(0, 0);
            this._mainMenu.Name = "_mainMenu";
            this._mainMenu.Size = new System.Drawing.Size(344, 25);
            this._mainMenu.TabIndex = 0;
            this._mainMenu.Text = "toolStrip1";
            // 
            // _menu_createServer
            // 
            this._menu_createServer.Image = global::Minefield_Online.Properties.Resources.server_cast;
            this._menu_createServer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._menu_createServer.Name = "_menu_createServer";
            this._menu_createServer.Size = new System.Drawing.Size(96, 22);
            this._menu_createServer.Text = "Create Server";
            this._menu_createServer.Click += new System.EventHandler(this._menu_createServer_Click);
            // 
            // _menu_connect
            // 
            this._menu_connect.Image = global::Minefield_Online.Properties.Resources.server__plus;
            this._menu_connect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._menu_connect.Name = "_menu_connect";
            this._menu_connect.Size = new System.Drawing.Size(75, 22);
            this._menu_connect.Text = "Connect ";
            this._menu_connect.Click += new System.EventHandler(this._menu_connect_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // _menu_toogleChat
            // 
            this._menu_toogleChat.Image = global::Minefield_Online.Properties.Resources.mail_send_receive;
            this._menu_toogleChat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._menu_toogleChat.Name = "_menu_toogleChat";
            this._menu_toogleChat.Size = new System.Drawing.Size(92, 22);
            this._menu_toogleChat.Text = "Toogle Chat";
            this._menu_toogleChat.Click += new System.EventHandler(this._menu_toogleChat_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // _menu_exit
            // 
            this._menu_exit.Image = global::Minefield_Online.Properties.Resources.cross;
            this._menu_exit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._menu_exit.Name = "_menu_exit";
            this._menu_exit.Size = new System.Drawing.Size(45, 22);
            this._menu_exit.Text = "Exit";
            this._menu_exit.Click += new System.EventHandler(this._menu_exit_Click);
            // 
            // info_group
            // 
            this.info_group.Controls.Add(this.info_player4);
            this.info_group.Controls.Add(this.info_player2);
            this.info_group.Controls.Add(this.info_player3);
            this.info_group.Controls.Add(this.info_player1);
            this.info_group.Controls.Add(this.info_label_points);
            this.info_group.Controls.Add(this.info_turn);
            this.info_group.Controls.Add(this.info_players);
            this.info_group.Controls.Add(this.info_label_turn);
            this.info_group.Controls.Add(this.info_label_players);
            this.info_group.Dock = System.Windows.Forms.DockStyle.Top;
            this.info_group.Location = new System.Drawing.Point(0, 25);
            this.info_group.Name = "info_group";
            this.info_group.Size = new System.Drawing.Size(344, 48);
            this.info_group.TabIndex = 1;
            this.info_group.TabStop = false;
            this.info_group.Visible = false;
            // 
            // info_player4
            // 
            this.info_player4.AutoSize = true;
            this.info_player4.Location = new System.Drawing.Point(277, 30);
            this.info_player4.Name = "info_player4";
            this.info_player4.Size = new System.Drawing.Size(57, 13);
            this.info_player4.TabIndex = 8;
            this.info_player4.Text = "Player4 (0)";
            this.info_player4.Visible = false;
            // 
            // info_player2
            // 
            this.info_player2.AutoSize = true;
            this.info_player2.Location = new System.Drawing.Point(277, 10);
            this.info_player2.Name = "info_player2";
            this.info_player2.Size = new System.Drawing.Size(57, 13);
            this.info_player2.TabIndex = 7;
            this.info_player2.Text = "Player2 (0)";
            // 
            // info_player3
            // 
            this.info_player3.AutoSize = true;
            this.info_player3.Location = new System.Drawing.Point(172, 30);
            this.info_player3.Name = "info_player3";
            this.info_player3.Size = new System.Drawing.Size(57, 13);
            this.info_player3.TabIndex = 6;
            this.info_player3.Text = "Player3 (0)";
            this.info_player3.Visible = false;
            // 
            // info_player1
            // 
            this.info_player1.AutoSize = true;
            this.info_player1.Location = new System.Drawing.Point(172, 10);
            this.info_player1.Name = "info_player1";
            this.info_player1.Size = new System.Drawing.Size(57, 13);
            this.info_player1.TabIndex = 5;
            this.info_player1.Text = "Player1 (0)";
            // 
            // info_label_points
            // 
            this.info_label_points.AutoSize = true;
            this.info_label_points.Location = new System.Drawing.Point(119, 10);
            this.info_label_points.Name = "info_label_points";
            this.info_label_points.Size = new System.Drawing.Size(42, 13);
            this.info_label_points.TabIndex = 4;
            this.info_label_points.Text = "Points :";
            // 
            // info_turn
            // 
            this.info_turn.AutoSize = true;
            this.info_turn.Location = new System.Drawing.Point(71, 30);
            this.info_turn.Name = "info_turn";
            this.info_turn.Size = new System.Drawing.Size(31, 13);
            this.info_turn.TabIndex = 3;
            this.info_turn.Text = "none";
            // 
            // info_players
            // 
            this.info_players.AutoSize = true;
            this.info_players.Location = new System.Drawing.Point(71, 10);
            this.info_players.Name = "info_players";
            this.info_players.Size = new System.Drawing.Size(24, 13);
            this.info_players.TabIndex = 2;
            this.info_players.Text = "0/0";
            // 
            // info_label_turn
            // 
            this.info_label_turn.AutoSize = true;
            this.info_label_turn.Location = new System.Drawing.Point(6, 30);
            this.info_label_turn.Name = "info_label_turn";
            this.info_label_turn.Size = new System.Drawing.Size(35, 13);
            this.info_label_turn.TabIndex = 1;
            this.info_label_turn.Text = "Turn :";
            // 
            // info_label_players
            // 
            this.info_label_players.AutoSize = true;
            this.info_label_players.Location = new System.Drawing.Point(6, 10);
            this.info_label_players.Name = "info_label_players";
            this.info_label_players.Size = new System.Drawing.Size(47, 13);
            this.info_label_players.TabIndex = 0;
            this.info_label_players.Text = "Players :";
            // 
            // field_group
            // 
            this.field_group.Dock = System.Windows.Forms.DockStyle.Fill;
            this.field_group.Location = new System.Drawing.Point(0, 73);
            this.field_group.Name = "field_group";
            this.field_group.Size = new System.Drawing.Size(344, 12);
            this.field_group.TabIndex = 2;
            this.field_group.TabStop = false;
            // 
            // chat_group
            // 
            this.chat_group.Controls.Add(this.chat);
            this.chat_group.Controls.Add(this.panel1);
            this.chat_group.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.chat_group.Location = new System.Drawing.Point(0, 85);
            this.chat_group.Name = "chat_group";
            this.chat_group.Size = new System.Drawing.Size(344, 135);
            this.chat_group.TabIndex = 4;
            this.chat_group.TabStop = false;
            this.chat_group.Text = " ";
            // 
            // chat
            // 
            this.chat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chat.Location = new System.Drawing.Point(3, 16);
            this.chat.Name = "chat";
            this.chat.ReadOnly = true;
            this.chat.Size = new System.Drawing.Size(211, 116);
            this.chat.TabIndex = 0;
            this.chat.Text = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chat_send);
            this.panel1.Controls.Add(this.chat_text);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(214, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(127, 116);
            this.panel1.TabIndex = 1;
            // 
            // chat_send
            // 
            this.chat_send.Enabled = false;
            this.chat_send.Location = new System.Drawing.Point(43, 29);
            this.chat_send.Name = "chat_send";
            this.chat_send.Size = new System.Drawing.Size(75, 23);
            this.chat_send.TabIndex = 4;
            this.chat_send.Text = "Send";
            this.chat_send.UseVisualStyleBackColor = true;
            this.chat_send.Click += new System.EventHandler(this.chat_send_Click);
            // 
            // chat_text
            // 
            this.chat_text.Enabled = false;
            this.chat_text.Location = new System.Drawing.Point(3, 3);
            this.chat_text.MaxLength = 256;
            this.chat_text.Name = "chat_text";
            this.chat_text.Size = new System.Drawing.Size(121, 20);
            this.chat_text.TabIndex = 3;
            this.chat_text.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chat_text_KeyDown);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 220);
            this.Controls.Add(this.field_group);
            this.Controls.Add(this.info_group);
            this.Controls.Add(this._mainMenu);
            this.Controls.Add(this.chat_group);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Minefield Online";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this._mainMenu.ResumeLayout(false);
            this._mainMenu.PerformLayout();
            this.info_group.ResumeLayout(false);
            this.info_group.PerformLayout();
            this.chat_group.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip _mainMenu;
        private System.Windows.Forms.ToolStripButton _menu_createServer;
        private System.Windows.Forms.ToolStripButton _menu_connect;
        private System.Windows.Forms.ToolStripButton _menu_exit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton _menu_toogleChat;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.GroupBox info_group;
        private System.Windows.Forms.Label info_player4;
        private System.Windows.Forms.Label info_player2;
        private System.Windows.Forms.Label info_player3;
        private System.Windows.Forms.Label info_player1;
        private System.Windows.Forms.Label info_label_points;
        private System.Windows.Forms.Label info_turn;
        private System.Windows.Forms.Label info_players;
        private System.Windows.Forms.Label info_label_turn;
        private System.Windows.Forms.Label info_label_players;
        private System.Windows.Forms.GroupBox field_group;
        private System.Windows.Forms.GroupBox chat_group;
        private System.Windows.Forms.RichTextBox chat;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button chat_send;
        private System.Windows.Forms.TextBox chat_text;
    }
}

