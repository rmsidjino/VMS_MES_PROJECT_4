
namespace VMS_MES_PROJECT_4
{
    partial class frmLoad_Stat
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
            this.dgvLoadStat = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblEqpPlan = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboEQP = new System.Windows.Forms.ComboBox();
            this.cboLine = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoadStat)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvLoadStat
            // 
            this.dgvLoadStat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLoadStat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoadStat.Location = new System.Drawing.Point(12, 124);
            this.dgvLoadStat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvLoadStat.Name = "dgvLoadStat";
            this.dgvLoadStat.RowHeadersVisible = false;
            this.dgvLoadStat.RowTemplate.Height = 23;
            this.dgvLoadStat.Size = new System.Drawing.Size(1346, 562);
            this.dgvLoadStat.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(3, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "가동률 분석";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSearch.Location = new System.Drawing.Point(1248, 4);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(84, 44);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(205, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "￭ 장비ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(20, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "￭ 라인ID";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblEqpPlan);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(12, 75);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1346, 41);
            this.panel2.TabIndex = 4;
            // 
            // lblEqpPlan
            // 
            this.lblEqpPlan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEqpPlan.AutoSize = true;
            this.lblEqpPlan.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblEqpPlan.ForeColor = System.Drawing.Color.Blue;
            this.lblEqpPlan.Location = new System.Drawing.Point(1209, 14);
            this.lblEqpPlan.Name = "lblEqpPlan";
            this.lblEqpPlan.Size = new System.Drawing.Size(130, 17);
            this.lblEqpPlan.TabIndex = 10;
            this.lblEqpPlan.Text = "설비가동률 분석차트";
            this.lblEqpPlan.Click += new System.EventHandler(this.lblEqpPlan_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.cboEQP);
            this.panel1.Controls.Add(this.cboLine);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 15);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1346, 52);
            this.panel1.TabIndex = 3;
            // 
            // cboEQP
            // 
            this.cboEQP.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cboEQP.FormattingEnabled = true;
            this.cboEQP.Location = new System.Drawing.Point(271, 14);
            this.cboEQP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboEQP.Name = "cboEQP";
            this.cboEQP.Size = new System.Drawing.Size(148, 25);
            this.cboEQP.TabIndex = 1;
            // 
            // cboLine
            // 
            this.cboLine.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cboLine.FormattingEnabled = true;
            this.cboLine.Location = new System.Drawing.Point(84, 14);
            this.cboLine.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboLine.Name = "cboLine";
            this.cboLine.Size = new System.Drawing.Size(100, 25);
            this.cboLine.TabIndex = 0;
            // 
            // frmLoad_Stat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 701);
            this.Controls.Add(this.dgvLoadStat);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmLoad_Stat";
            this.Text = "가동률 분석";
            this.Load += new System.EventHandler(this.frmLoad_Stat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoadStat)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvLoadStat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cboEQP;
        private System.Windows.Forms.ComboBox cboLine;
        private System.Windows.Forms.Label lblEqpPlan;
    }
}