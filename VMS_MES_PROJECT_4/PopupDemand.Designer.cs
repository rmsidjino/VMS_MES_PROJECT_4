
namespace VMS_MES_PROJECT_4
{
    partial class PopupDemand
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PopupDemand));
            this.txtDemand_Ver = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDemandID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDemand_Qty = new System.Windows.Forms.TextBox();
            this.dtpDueDate = new System.Windows.Forms.DateTimePicker();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cboProductID = new System.Windows.Forms.ComboBox();
            this.cboCustomerID = new System.Windows.Forms.ComboBox();
            this.txtModDate = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMod = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtDemand_Ver
            // 
            this.txtDemand_Ver.Location = new System.Drawing.Point(169, 40);
            this.txtDemand_Ver.Name = "txtDemand_Ver";
            this.txtDemand_Ver.Size = new System.Drawing.Size(163, 21);
            this.txtDemand_Ver.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(38, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "* 수주버전";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(38, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "* 수주ID";
            // 
            // txtDemandID
            // 
            this.txtDemandID.Location = new System.Drawing.Point(169, 78);
            this.txtDemandID.Name = "txtDemandID";
            this.txtDemandID.Size = new System.Drawing.Size(163, 21);
            this.txtDemandID.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(38, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "* 제품ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(38, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "* 회사ID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(38, 191);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "* 납기일";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(38, 229);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "* 수주수량";
            // 
            // txtDemand_Qty
            // 
            this.txtDemand_Qty.Location = new System.Drawing.Point(169, 224);
            this.txtDemand_Qty.Name = "txtDemand_Qty";
            this.txtDemand_Qty.Size = new System.Drawing.Size(163, 21);
            this.txtDemand_Qty.TabIndex = 5;
            // 
            // dtpDueDate
            // 
            this.dtpDueDate.CustomFormat = "yyyy-MM-dd";
            this.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDueDate.Location = new System.Drawing.Point(169, 187);
            this.dtpDueDate.Name = "dtpDueDate";
            this.dtpDueDate.Size = new System.Drawing.Size(163, 21);
            this.dtpDueDate.TabIndex = 4;
            this.dtpDueDate.Value = new System.DateTime(2022, 1, 17, 20, 53, 47, 0);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(105, 358);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(202, 358);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cboProductID
            // 
            this.cboProductID.FormattingEnabled = true;
            this.cboProductID.Location = new System.Drawing.Point(169, 115);
            this.cboProductID.Name = "cboProductID";
            this.cboProductID.Size = new System.Drawing.Size(163, 20);
            this.cboProductID.TabIndex = 2;
            // 
            // cboCustomerID
            // 
            this.cboCustomerID.FormattingEnabled = true;
            this.cboCustomerID.Location = new System.Drawing.Point(169, 151);
            this.cboCustomerID.Name = "cboCustomerID";
            this.cboCustomerID.Size = new System.Drawing.Size(163, 20);
            this.cboCustomerID.TabIndex = 3;
            // 
            // txtModDate
            // 
            this.txtModDate.Enabled = false;
            this.txtModDate.Location = new System.Drawing.Point(169, 299);
            this.txtModDate.Name = "txtModDate";
            this.txtModDate.Size = new System.Drawing.Size(163, 21);
            this.txtModDate.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(38, 303);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 12);
            this.label7.TabIndex = 28;
            this.label7.Text = "  수정일자";
            // 
            // txtMod
            // 
            this.txtMod.Enabled = false;
            this.txtMod.Location = new System.Drawing.Point(169, 263);
            this.txtMod.Name = "txtMod";
            this.txtMod.Size = new System.Drawing.Size(163, 21);
            this.txtMod.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(38, 267);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 12);
            this.label8.TabIndex = 26;
            this.label8.Text = "  최종수정자";
            // 
            // PopupDemand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(377, 403);
            this.Controls.Add(this.txtModDate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtMod);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cboCustomerID);
            this.Controls.Add(this.cboProductID);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.dtpDueDate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDemand_Qty);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDemandID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDemand_Ver);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PopupDemand";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "수주 등록";
            this.Load += new System.EventHandler(this.PopupDemand_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDemand_Ver;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDemandID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDemand_Qty;
        private System.Windows.Forms.DateTimePicker dtpDueDate;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cboProductID;
        private System.Windows.Forms.ComboBox cboCustomerID;
        private System.Windows.Forms.TextBox txtModDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMod;
        private System.Windows.Forms.Label label8;
    }
}