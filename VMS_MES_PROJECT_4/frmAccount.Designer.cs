
namespace VMS_MES_PROJECT_4
{
    partial class frmAccount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAccount));
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCreate = new System.Windows.Forms.Button();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtRepeatPwd = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.btnIDCheck = new System.Windows.Forms.Button();
            this.btnPwdCheck = new System.Windows.Forms.Button();
            this.lblRepeatPwd = new System.Windows.Forms.Label();
            this.lblSignIn = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(51, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(214, 19);
            this.label4.TabIndex = 14;
            this.label4.Text = "Create a New Account";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 12);
            this.label3.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(53, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 19);
            this.label2.TabIndex = 12;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(53, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 19);
            this.label1.TabIndex = 7;
            this.label1.Text = "ID(Email)";
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(55, 350);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(119, 45);
            this.btnCreate.TabIndex = 10;
            this.btnCreate.Text = "Create Account";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // txtPwd
            // 
            this.txtPwd.Font = new System.Drawing.Font("굴림", 12F);
            this.txtPwd.Location = new System.Drawing.Point(170, 160);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(197, 26);
            this.txtPwd.TabIndex = 9;
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("굴림", 12F);
            this.txtEmail.Location = new System.Drawing.Point(170, 112);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(197, 26);
            this.txtEmail.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(53, 260);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 19);
            this.label5.TabIndex = 18;
            this.label5.Text = "First Name :";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(53, 212);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 19);
            this.label6.TabIndex = 15;
            this.label6.Text = "Repeat Password";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Font = new System.Drawing.Font("굴림", 12F);
            this.txtFirstName.Location = new System.Drawing.Point(170, 256);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(262, 26);
            this.txtFirstName.TabIndex = 17;
            // 
            // txtRepeatPwd
            // 
            this.txtRepeatPwd.Font = new System.Drawing.Font("굴림", 12F);
            this.txtRepeatPwd.Location = new System.Drawing.Point(170, 208);
            this.txtRepeatPwd.Name = "txtRepeatPwd";
            this.txtRepeatPwd.PasswordChar = '*';
            this.txtRepeatPwd.Size = new System.Drawing.Size(262, 26);
            this.txtRepeatPwd.TabIndex = 16;
            this.txtRepeatPwd.Leave += new System.EventHandler(this.txtRepeatPwd_Leave);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(53, 308);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 19);
            this.label8.TabIndex = 19;
            this.label8.Text = "Last Name";
            // 
            // txtLastName
            // 
            this.txtLastName.Font = new System.Drawing.Font("굴림", 12F);
            this.txtLastName.Location = new System.Drawing.Point(170, 304);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(261, 26);
            this.txtLastName.TabIndex = 20;
            // 
            // btnIDCheck
            // 
            this.btnIDCheck.Location = new System.Drawing.Point(373, 112);
            this.btnIDCheck.Name = "btnIDCheck";
            this.btnIDCheck.Size = new System.Drawing.Size(58, 26);
            this.btnIDCheck.TabIndex = 23;
            this.btnIDCheck.Text = "check";
            this.btnIDCheck.UseVisualStyleBackColor = true;
            this.btnIDCheck.Click += new System.EventHandler(this.btnIDCheck_Click);
            // 
            // btnPwdCheck
            // 
            this.btnPwdCheck.Location = new System.Drawing.Point(374, 160);
            this.btnPwdCheck.Name = "btnPwdCheck";
            this.btnPwdCheck.Size = new System.Drawing.Size(58, 26);
            this.btnPwdCheck.TabIndex = 24;
            this.btnPwdCheck.Text = "check";
            this.btnPwdCheck.UseVisualStyleBackColor = true;
            this.btnPwdCheck.Click += new System.EventHandler(this.btnPwdCheck_Click);
            // 
            // lblRepeatPwd
            // 
            this.lblRepeatPwd.AutoSize = true;
            this.lblRepeatPwd.ForeColor = System.Drawing.Color.Red;
            this.lblRepeatPwd.Location = new System.Drawing.Point(171, 237);
            this.lblRepeatPwd.Name = "lblRepeatPwd";
            this.lblRepeatPwd.Size = new System.Drawing.Size(179, 12);
            this.lblRepeatPwd.TabIndex = 25;
            this.lblRepeatPwd.Text = "* 비밀번호가 일치하지 않습니다";
            // 
            // lblSignIn
            // 
            this.lblSignIn.AutoSize = true;
            this.lblSignIn.Location = new System.Drawing.Point(273, 366);
            this.lblSignIn.Name = "lblSignIn";
            this.lblSignIn.Size = new System.Drawing.Size(44, 12);
            this.lblSignIn.TabIndex = 26;
            this.lblSignIn.Text = "Sign In";
            this.lblSignIn.Click += new System.EventHandler(this.lblSignIn_Click);
            // 
            // frmAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 427);
            this.Controls.Add(this.lblSignIn);
            this.Controls.Add(this.lblRepeatPwd);
            this.Controls.Add(this.btnPwdCheck);
            this.Controls.Add(this.btnIDCheck);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.txtRepeatPwd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.txtEmail);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAccount";
            this.Text = "Create";
            this.Load += new System.EventHandler(this.frmAccount_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtRepeatPwd;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Button btnIDCheck;
        private System.Windows.Forms.Button btnPwdCheck;
        private System.Windows.Forms.Label lblRepeatPwd;
        private System.Windows.Forms.Label lblSignIn;
    }
}