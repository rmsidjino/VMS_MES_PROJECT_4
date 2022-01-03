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
    public partial class frmProduct : Form
    {
        ServiceHelp srv = new ServiceHelp("");
        int editIndex;
        List<ProductVO> slist;
        List<CommonVO> com;

        private void frmProduct_Load(object sender, EventArgs e)
        {
            DataGridViewUtil.SetInitGridView(dgvProduct);
            DataGridViewUtil.AddGridTextColumn(dgvProduct, "제품ID", "PRODUCT_ID", colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvProduct, "제품유형", "LINE_ID", colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvProduct, "제품이름", "EQP_GROUP", colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvProduct, "공정ID", "STEP_ID", colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvProduct, "로트크기", "LOT_SIZE", colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvProduct, "입력되는 1회분 사이즈", "INPUT_BATCH_SIZE", colWidth: 100);

            DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();

            btnEdit.Text = "수정";
            btnEdit.Width = 50;
            btnEdit.UseColumnTextForButtonValue = true;
            btnEdit.Name = "Edit";
            editIndex = dgvProduct.Columns.Add(btnEdit);

            LoadData();
        }

        private async void LoadData()
        {
            slist = null;
            slist = await srv.GetListAsync("api/Product/Products", slist);
            dgvProduct.DataSource = slist;

            com = null;
            com = await srv.GetListAsync($"api/Common/All", com);

            CommonUtil.ComboBinding(cboProduct, com, "PRODUCT", blankText: "선택");
            CommonUtil.ComboBinding(cboProcess, com, "PROCESS", blankText: "선택");
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            PopupProduct frm = new PopupProduct();
            frm.ShowDialog();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProduct.SelectedRows.Count < 1)
            {
                MessageBox.Show("삭제할 제품을 선택하여 주십시오.");
                return;
            }

            string productID = dgvProduct.SelectedRows[0].Cells["PRODUCT_ID"].Value.ToString();

            if (MessageBox.Show("정말 삭제하실겁니까?", "제품 삭제", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MESDTO.Message msg = await srv.GetAsync($"api/Product/DeleteProduct/{productID}");
                if (msg.IsSuccess)
                {
                    LoadData();
                }
                MessageBox.Show(msg.ResultMessage);
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            ProductVO prod = null;
            prod = await srv.GetAsync($"api/Product/Search/{cboProduct.SelectedValue}", prod);
            prod = await srv.GetAsync($"api/Product/Search/{cboProcess.SelectedValue}", prod);
            dgvProduct.DataSource = prod;
        }

        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == editIndex)
            {
                string productID = dgvProduct["PRODUCT_ID", e.RowIndex].Value.ToString();
               
                ProductVO sitem = slist.Find((product) => product.PRODUCT_ID == productID);
                PopupProduct frm = new PopupProduct(sitem);
                frm.Show();
            }
        }
    }
}