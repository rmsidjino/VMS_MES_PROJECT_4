
namespace VMS_MES_PROJECT_4
{
    partial class PopupStdStepInfo
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
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtStep_Setup = new System.Windows.Forms.TextBox();
            this.txtStep_Yield = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtStep_Tat = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtModDate = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMod = new System.Windows.Forms.TextBox();
            this.cboStd_Step_Id = new System.Windows.Forms.ComboBox();
            this.cboStd_Step_Name = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(40, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 12);
            this.label5.TabIndex = 34;
            this.label5.Text = "* 공정준비시간";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(40, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 12);
            this.label4.TabIndex = 33;
            this.label4.Text = "* 공정수율";
            // 
            // txtStep_Setup
            // 
            this.txtStep_Setup.Location = new System.Drawing.Point(177, 183);
            this.txtStep_Setup.Name = "txtStep_Setup";
            this.txtStep_Setup.Size = new System.Drawing.Size(163, 21);
            this.txtStep_Setup.TabIndex = 31;
            // 
            // txtStep_Yield
            // 
            this.txtStep_Yield.Location = new System.Drawing.Point(177, 145);
            this.txtStep_Yield.Name = "txtStep_Yield";
            this.txtStep_Yield.Size = new System.Drawing.Size(163, 21);
            this.txtStep_Yield.TabIndex = 32;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(40, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 12);
            this.label3.TabIndex = 30;
            this.label3.Text = "* 공정시간";
            // 
            // txtStep_Tat
            // 
            this.txtStep_Tat.Location = new System.Drawing.Point(177, 108);
            this.txtStep_Tat.Name = "txtStep_Tat";
            this.txtStep_Tat.Size = new System.Drawing.Size(163, 21);
            this.txtStep_Tat.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(40, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 12);
            this.label2.TabIndex = 28;
            this.label2.Text = "* 표준공정이름";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(40, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 12);
            this.label1.TabIndex = 26;
            this.label1.Text = "* 표준공정ID";
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCancel.Location = new System.Drawing.Point(219, 313);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 23);
            this.btnCancel.TabIndex = 35;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOK.Location = new System.Drawing.Point(86, 313);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(86, 23);
            this.btnOK.TabIndex = 36;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(52, 264);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 12);
            this.label8.TabIndex = 40;
            this.label8.Text = "수정일자";
            // 
            // txtModDate
            // 
            this.txtModDate.Location = new System.Drawing.Point(177, 258);
            this.txtModDate.Name = "txtModDate";
            this.txtModDate.Size = new System.Drawing.Size(163, 21);
            this.txtModDate.TabIndex = 39;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(52, 226);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 12);
            this.label7.TabIndex = 38;
            this.label7.Text = "최종수정자";
            // 
            // txtMod
            // 
            this.txtMod.Location = new System.Drawing.Point(177, 220);
            this.txtMod.Name = "txtMod";
            this.txtMod.Size = new System.Drawing.Size(163, 21);
            this.txtMod.TabIndex = 37;
            // 
            // cboStd_Step_Id
            // 
            this.cboStd_Step_Id.FormattingEnabled = true;
            this.cboStd_Step_Id.Location = new System.Drawing.Point(177, 36);
            this.cboStd_Step_Id.Name = "cboStd_Step_Id";
            this.cboStd_Step_Id.Size = new System.Drawing.Size(163, 20);
            this.cboStd_Step_Id.TabIndex = 41;
            // 
            // cboStd_Step_Name
            // 
            this.cboStd_Step_Name.FormattingEnabled = true;
            this.cboStd_Step_Name.Location = new System.Drawing.Point(177, 73);
            this.cboStd_Step_Name.Name = "cboStd_Step_Name";
            this.cboStd_Step_Name.Size = new System.Drawing.Size(163, 20);
            this.cboStd_Step_Name.TabIndex = 41;
            // 
            // PopupStdStepInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(384, 366);
            this.Controls.Add(this.cboStd_Step_Name);
            this.Controls.Add(this.cboStd_Step_Id);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtModDate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtMod);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtStep_Setup);
            this.Controls.Add(this.txtStep_Yield);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtStep_Tat);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Name = "PopupStdStepInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "표준공정정보 등록";
            this.Load += new System.EventHandler(this.PopupStd_step_info_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtStep_Setup;
        private System.Windows.Forms.TextBox txtStep_Yield;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtStep_Tat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtModDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMod;
        private System.Windows.Forms.ComboBox cboStd_Step_Id;
        private System.Windows.Forms.ComboBox cboStd_Step_Name;
    }
}