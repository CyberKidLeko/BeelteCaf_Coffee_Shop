namespace BeelteCaf__assignment1_40966402_43706355
{
    partial class SfaffLogin
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtStaffnumber = new System.Windows.Forms.TextBox();
            this.txtStaffPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Staff Number:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password:";
            // 
            // txtStaffnumber
            // 
            this.txtStaffnumber.Location = new System.Drawing.Point(162, 52);
            this.txtStaffnumber.Name = "txtStaffnumber";
            this.txtStaffnumber.Size = new System.Drawing.Size(160, 22);
            this.txtStaffnumber.TabIndex = 2;
            // 
            // txtStaffPassword
            // 
            this.txtStaffPassword.Location = new System.Drawing.Point(162, 96);
            this.txtStaffPassword.Name = "txtStaffPassword";
            this.txtStaffPassword.Size = new System.Drawing.Size(160, 22);
            this.txtStaffPassword.TabIndex = 3;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(172, 175);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // SfaffLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 248);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtStaffPassword);
            this.Controls.Add(this.txtStaffnumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SfaffLogin";
            this.Text = "SfaffLogin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtStaffnumber;
        private System.Windows.Forms.TextBox txtStaffPassword;
        private System.Windows.Forms.Button btnLogin;
    }
}