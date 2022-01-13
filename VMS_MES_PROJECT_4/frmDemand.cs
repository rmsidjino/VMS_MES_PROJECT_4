using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MESDTO;

namespace VMS_MES_PROJECT_4
{
    public partial class frmDemand : Form
    {
        ServiceHelp srv = new ServiceHelp("");
        int editIndex;
        List<DemandVO> dlist;
        List<CommonVO> com;

        public frmDemand()
        {
            InitializeComponent();
        }

        private async void LoadData()
        {
            dlist = null;
            dlist = await srv.GetListAsync("api/Demand/Demands", dlist);
            dgvDemand.DataSource = dlist;

            com = null;
            com = await srv.GetListAsync($"api/Common/All", com);

            CommonUtil.ComboBinding(cboDemandVer, com, "DEMAND_VER", blankText: "선택");
            CommonUtil.ComboBinding(cboProduct, com, "PRODUCT_ID", blankText: "선택");

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            PopupDemand frm = new PopupDemand();
            frm.ShowDialog();
            LoadData();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvDemand.SelectedRows.Count < 1)
            {
                MessageBox.Show("삭제할 수주를 선택하여 주십시오.");
                return;
            }

            string demand_ver = dgvDemand.SelectedRows[0].Cells["DEMAND_VER"].Value.ToString();

            if (MessageBox.Show("정말 삭제하실겁니까?", "수주 삭제", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MESDTO.Message msg = await srv.GetAsync($"api/Demand/DeleteDemand/{demand_ver}");
                if (msg.IsSuccess)
                {
                    LoadData();
                }
                MessageBox.Show(msg.ResultMessage);
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string demand_ver = " ";
            if (cboDemandVer.SelectedIndex > 0)
                demand_ver = cboDemandVer.SelectedValue.ToString();

            string productID = " ";
            if (cboProduct.SelectedIndex > 0)
                productID = cboProduct.SelectedValue.ToString();

            string url = $"api/Demand/SearchDemandList?demand_ver={demand_ver}&productID={productID}";
            dlist = null;
            dlist = await srv.GetListAsync(url, dlist);
            dgvDemand.DataSource = null;
            dgvDemand.DataSource = dlist;
        }

        private void frmDemand_Load(object sender, EventArgs e)
        {
            DataGridViewUtil.SetInitGridView(dgvDemand);
            DataGridViewUtil.AddGridTextColumn(dgvDemand, "수주버전", "DEMAND_VER", DataGridViewContentAlignment.MiddleCenter, colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvDemand, "수주ID", "DEMAND_ID", DataGridViewContentAlignment.MiddleCenter, colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvDemand, "제품ID", "PRODUCT_ID", DataGridViewContentAlignment.MiddleCenter, colWidth: 180);
            DataGridViewUtil.AddGridTextColumn(dgvDemand, "회사ID", "CUSTOMER_ID", DataGridViewContentAlignment.MiddleCenter, colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvDemand, "납기일", "DUE_DATE", DataGridViewContentAlignment.MiddleRight, colWidth: 90);
            DataGridViewUtil.AddGridTextColumn(dgvDemand, "수주수량", "DEMAND_QTY", DataGridViewContentAlignment.MiddleRight, colWidth: 80);

            DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();

            btnEdit.Text = "수정";
            btnEdit.Width = 50;
            btnEdit.UseColumnTextForButtonValue = true;
            btnEdit.Name = "Edit";
            editIndex = dgvDemand.Columns.Add(btnEdit);

            LoadData();
        }

        private void dgvDemand_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == editIndex)
            {
                string demand_ver = dgvDemand["DEMAND_VER", e.RowIndex].Value.ToString();
                string demandID = dgvDemand["DEMAND_ID", e.RowIndex].Value.ToString();

                DemandVO ditem = dlist.Find((demand) => demand.DEMAND_VER == demand_ver && demand.DEMAND_ID == demandID);

                PopupDemand frm = new PopupDemand(ditem);
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Show();
            }
        }
    }
}
