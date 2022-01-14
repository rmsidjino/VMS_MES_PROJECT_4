
namespace VMS_MES_PROJECT_4
{
    partial class frmDemand
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtDemandVer = new System.Windows.Forms.TextBox();
            this.cboProduct = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvDemand = new System.Windows.Forms.DataGridView();
            this.ExcelMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.iMPORTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eXPORTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDemand)).BeginInit();
            this.ExcelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AllowDrop = true;
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.txtDemandVer);
            this.panel1.Controls.Add(this.cboProduct);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1346, 42);
            this.panel1.TabIndex = 0;
            // 
            // txtDemandVer
            // 
            this.txtDemandVer.Location = new System.Drawing.Point(101, 10);
            this.txtDemandVer.Name = "txtDemandVer";
            this.txtDemandVer.Size = new System.Drawing.Size(123, 21);
            this.txtDemandVer.TabIndex = 0;
            // 
            // cboProduct
            // 
            this.cboProduct.FormattingEnabled = true;
            this.cboProduct.Location = new System.Drawing.Point(304, 11);
            this.cboProduct.Name = "cboProduct";
            this.cboProduct.Size = new System.Drawing.Size(148, 20);
            this.cboProduct.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(240, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "￭ 제품ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "￭ 수주버전";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(1258, 9);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.btnCreate);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(12, 60);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1346, 33);
            this.panel2.TabIndex = 1;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Font = new System.Drawing.Font("굴림", 7F);
            this.btnDelete.Location = new System.Drawing.Point(1293, 7);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(40, 20);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "삭제";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreate.Font = new System.Drawing.Font("굴림", 7F);
            this.btnCreate.Location = new System.Drawing.Point(1247, 7);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(40, 20);
            this.btnCreate.TabIndex = 4;
            this.btnCreate.Text = "등록";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "수주관리";
            // 
            // dgvDemand
            // 
            this.dgvDemand.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDemand.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDemand.Location = new System.Drawing.Point(12, 99);
            this.dgvDemand.Name = "dgvDemand";
            this.dgvDemand.RowHeadersVisible = false;
            this.dgvDemand.RowTemplate.Height = 23;
            this.dgvDemand.Size = new System.Drawing.Size(1346, 450);
            this.dgvDemand.TabIndex = 2;
            this.dgvDemand.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDemand_CellClick);
            // 
            // ExcelMenu
            // 
            this.ExcelMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iMPORTToolStripMenuItem,
            this.eXPORTToolStripMenuItem});
            this.ExcelMenu.Name = "ExcelMenu";
            this.ExcelMenu.Size = new System.Drawing.Size(118, 48);
            // 
            // iMPORTToolStripMenuItem
            // 
            this.iMPORTToolStripMenuItem.Name = "iMPORTToolStripMenuItem";
            this.iMPORTToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.iMPORTToolStripMenuItem.Text = "IMPORT";
            // 
            // eXPORTToolStripMenuItem
            // 
            this.eXPORTToolStripMenuItem.Name = "eXPORTToolStripMenuItem";
            this.eXPORTToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.eXPORTToolStripMenuItem.Text = "EXPORT";
            // 
            // frmDemand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 561);
            this.Controls.Add(this.dgvDemand);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmDemand";
            this.Text = "수주관리";
            this.Load += new System.EventHandler(this.frmDemand_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDemand)).EndInit();
            this.ExcelMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvDemand;
        private System.Windows.Forms.ComboBox cboProduct;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip ExcelMenu;
        private System.Windows.Forms.ToolStripMenuItem iMPORTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eXPORTToolStripMenuItem;
        private System.Windows.Forms.TextBox txtDemandVer;
    }
}

