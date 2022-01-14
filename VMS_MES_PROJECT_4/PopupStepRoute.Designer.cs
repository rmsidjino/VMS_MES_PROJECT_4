
namespace VMS_MES_PROJECT_4
{
    partial class PopupStepRoute
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
            System.Windows.Forms.Label label7;
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtStepSeq = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cboStepID = new System.Windows.Forms.ComboBox();
            this.cboStdStepID = new System.Windows.Forms.ComboBox();
            this.cboStepType = new System.Windows.Forms.ComboBox();
            this.cboProcessType = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtInStock = new System.Windows.Forms.TextBox();
            this.txtOutStock = new System.Windows.Forms.TextBox();
            this.txtProcessID = new System.Windows.Forms.TextBox();
            this.txtModDate = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMod = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            label7.ForeColor = System.Drawing.SystemColors.ControlText;
            label7.Location = new System.Drawing.Point(35, 260);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(54, 12);
            label7.TabIndex = 25;
            label7.Text = "  투입량";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(35, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "* 프로세스ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(35, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "* 공정ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(35, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "* 공정단계";
            // 
            // txtStepSeq
            // 
            this.txtStepSeq.Location = new System.Drawing.Point(166, 113);
            this.txtStepSeq.Name = "txtStepSeq";
            this.txtStepSeq.Size = new System.Drawing.Size(163, 21);
            this.txtStepSeq.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(35, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "* 표준공정ID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(35, 189);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "* 공정유형";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(202, 426);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(105, 426);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 9;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(35, 225);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 12);
            this.label6.TabIndex = 18;
            this.label6.Text = "* 프로세스유형";
            // 
            // cboStepID
            // 
            this.cboStepID.FormattingEnabled = true;
            this.cboStepID.Location = new System.Drawing.Point(166, 77);
            this.cboStepID.Name = "cboStepID";
            this.cboStepID.Size = new System.Drawing.Size(163, 20);
            this.cboStepID.TabIndex = 0;
            // 
            // cboStdStepID
            // 
            this.cboStdStepID.FormattingEnabled = true;
            this.cboStdStepID.Location = new System.Drawing.Point(166, 149);
            this.cboStdStepID.Name = "cboStdStepID";
            this.cboStdStepID.Size = new System.Drawing.Size(163, 20);
            this.cboStdStepID.TabIndex = 2;
            // 
            // cboStepType
            // 
            this.cboStepType.FormattingEnabled = true;
            this.cboStepType.Location = new System.Drawing.Point(166, 185);
            this.cboStepType.Name = "cboStepType";
            this.cboStepType.Size = new System.Drawing.Size(163, 20);
            this.cboStepType.TabIndex = 3;
            // 
            // cboProcessType
            // 
            this.cboProcessType.FormattingEnabled = true;
            this.cboProcessType.Location = new System.Drawing.Point(166, 221);
            this.cboProcessType.Name = "cboProcessType";
            this.cboProcessType.Size = new System.Drawing.Size(163, 20);
            this.cboProcessType.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(35, 295);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 12);
            this.label8.TabIndex = 27;
            this.label8.Text = "  산출량";
            // 
            // txtInStock
            // 
            this.txtInStock.Location = new System.Drawing.Point(166, 256);
            this.txtInStock.Name = "txtInStock";
            this.txtInStock.Size = new System.Drawing.Size(163, 21);
            this.txtInStock.TabIndex = 5;
            // 
            // txtOutStock
            // 
            this.txtOutStock.Location = new System.Drawing.Point(166, 291);
            this.txtOutStock.Name = "txtOutStock";
            this.txtOutStock.Size = new System.Drawing.Size(163, 21);
            this.txtOutStock.TabIndex = 6;
            // 
            // txtProcessID
            // 
            this.txtProcessID.Location = new System.Drawing.Point(166, 41);
            this.txtProcessID.Name = "txtProcessID";
            this.txtProcessID.Size = new System.Drawing.Size(163, 21);
            this.txtProcessID.TabIndex = 30;
            // 
            // txtModDate
            // 
            this.txtModDate.Enabled = false;
            this.txtModDate.Location = new System.Drawing.Point(166, 365);
            this.txtModDate.Name = "txtModDate";
            this.txtModDate.Size = new System.Drawing.Size(163, 21);
            this.txtModDate.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(35, 369);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 12);
            this.label9.TabIndex = 33;
            this.label9.Text = "  수정일자";
            // 
            // txtMod
            // 
            this.txtMod.Enabled = false;
            this.txtMod.Location = new System.Drawing.Point(166, 329);
            this.txtMod.Name = "txtMod";
            this.txtMod.Size = new System.Drawing.Size(163, 21);
            this.txtMod.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(35, 333);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 12);
            this.label10.TabIndex = 31;
            this.label10.Text = "  최종수정자";
            // 
            // PopupStepRoute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(380, 476);
            this.Controls.Add(this.txtModDate);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtMod);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtProcessID);
            this.Controls.Add(this.txtOutStock);
            this.Controls.Add(this.txtInStock);
            this.Controls.Add(this.label8);
            this.Controls.Add(label7);
            this.Controls.Add(this.cboProcessType);
            this.Controls.Add(this.cboStepType);
            this.Controls.Add(this.cboStdStepID);
            this.Controls.Add(this.cboStepID);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtStepSeq);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "PopupStepRoute";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "작업공정 등록";
            this.Load += new System.EventHandler(this.PopupStepRoute_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtStepSeq;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboStepID;
        private System.Windows.Forms.ComboBox cboStdStepID;
        private System.Windows.Forms.ComboBox cboStepType;
        private System.Windows.Forms.ComboBox cboProcessType;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtInStock;
        private System.Windows.Forms.TextBox txtOutStock;
        private System.Windows.Forms.TextBox txtProcessID;
        private System.Windows.Forms.TextBox txtModDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMod;
        private System.Windows.Forms.Label label10;
    }
}