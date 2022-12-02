namespace Minefield_Online
{
    partial class CreateForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.nickname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.port = new System.Windows.Forms.TextBox();
            this.Create = new System.Windows.Forms.Button();
            this.players = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.horizontal = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.vertical = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.bombs = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.players)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.horizontal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vertical)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bombs)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nickname :";
            // 
            // nickname
            // 
            this.nickname.Location = new System.Drawing.Point(106, 7);
            this.nickname.MaxLength = 128;
            this.nickname.Name = "nickname";
            this.nickname.Size = new System.Drawing.Size(100, 20);
            this.nickname.TabIndex = 1;
            this.nickname.Text = "Server";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Port :";
            // 
            // port
            // 
            this.port.Location = new System.Drawing.Point(106, 32);
            this.port.MaxLength = 5;
            this.port.Name = "port";
            this.port.Size = new System.Drawing.Size(46, 20);
            this.port.TabIndex = 2;
            this.port.Text = "1821";
            this.port.TextChanged += new System.EventHandler(this.port_TextChanged);
            // 
            // Create
            // 
            this.Create.Location = new System.Drawing.Point(131, 168);
            this.Create.Name = "Create";
            this.Create.Size = new System.Drawing.Size(75, 23);
            this.Create.TabIndex = 7;
            this.Create.Text = "Create";
            this.Create.UseVisualStyleBackColor = true;
            this.Create.Click += new System.EventHandler(this.Create_Click);
            // 
            // players
            // 
            this.players.Location = new System.Drawing.Point(106, 58);
            this.players.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.players.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.players.Name = "players";
            this.players.Size = new System.Drawing.Size(46, 20);
            this.players.TabIndex = 3;
            this.players.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Players :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Minefield :";
            // 
            // horizontal
            // 
            this.horizontal.Location = new System.Drawing.Point(106, 98);
            this.horizontal.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.horizontal.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.horizontal.Name = "horizontal";
            this.horizontal.Size = new System.Drawing.Size(46, 20);
            this.horizontal.TabIndex = 4;
            this.horizontal.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Horizontal :";
            // 
            // vertical
            // 
            this.vertical.Location = new System.Drawing.Point(106, 120);
            this.vertical.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.vertical.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.vertical.Name = "vertical";
            this.vertical.Size = new System.Drawing.Size(46, 20);
            this.vertical.TabIndex = 5;
            this.vertical.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Vertical :";
            // 
            // bombs
            // 
            this.bombs.Location = new System.Drawing.Point(106, 142);
            this.bombs.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.bombs.Name = "bombs";
            this.bombs.Size = new System.Drawing.Size(46, 20);
            this.bombs.TabIndex = 6;
            this.bombs.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 144);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Bombs :";
            // 
            // CreateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(213, 196);
            this.Controls.Add(this.bombs);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.vertical);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.horizontal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.players);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Create);
            this.Controls.Add(this.port);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nickname);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CreateForm";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.CreateForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.players)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.horizontal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vertical)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bombs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nickname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox port;
        private System.Windows.Forms.Button Create;
        private System.Windows.Forms.NumericUpDown players;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown horizontal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown vertical;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown bombs;
        private System.Windows.Forms.Label label7;
    }
}