namespace Minefield_Online {
    partial class ConnectForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.Create = new System.Windows.Forms.Button();
            this.port = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.address = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nickname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Create
            // 
            this.Create.Location = new System.Drawing.Point(131, 83);
            this.Create.Name = "Create";
            this.Create.Size = new System.Drawing.Size(75, 23);
            this.Create.TabIndex = 20;
            this.Create.Text = "Connect";
            this.Create.UseVisualStyleBackColor = true;
            this.Create.Click += new System.EventHandler(this.Create_Click);
            // 
            // port
            // 
            this.port.Location = new System.Drawing.Point(106, 32);
            this.port.MaxLength = 5;
            this.port.Name = "port";
            this.port.Size = new System.Drawing.Size(46, 20);
            this.port.TabIndex = 19;
            this.port.Text = "1821";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Port :";
            // 
            // address
            // 
            this.address.Location = new System.Drawing.Point(106, 7);
            this.address.MaxLength = 128;
            this.address.Name = "address";
            this.address.Size = new System.Drawing.Size(100, 20);
            this.address.TabIndex = 17;
            this.address.Text = "localhost";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Address";
            // 
            // nickname
            // 
            this.nickname.Location = new System.Drawing.Point(106, 57);
            this.nickname.MaxLength = 128;
            this.nickname.Name = "nickname";
            this.nickname.Size = new System.Drawing.Size(100, 20);
            this.nickname.TabIndex = 22;
            this.nickname.Text = "Player";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Nickname :";
            // 
            // ConnectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(215, 113);
            this.Controls.Add(this.nickname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Create);
            this.Controls.Add(this.port);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.address);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConnectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Connect";
            this.Load += new System.EventHandler(this.ConnectForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Create;
        private System.Windows.Forms.TextBox port;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox address;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nickname;
        private System.Windows.Forms.Label label2;
    }
}