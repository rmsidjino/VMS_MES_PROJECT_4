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
        List<ProductVO> plist;
        List<CommonVO> com;
        UserVO CurrentUser;

        public frmProduct(UserVO CurrentUser)
        {
            InitializeComponent();
            this.CurrentUser = CurrentUser;
        }

        private void frmProduct_Load(object sender, EventArgs e)
        {
            DataGridViewUtil.SetInitGridView(dgvProduct);
            DataGridViewUtil.AddGridTextColumn(dgvProduct, "제품ID", "PRODUCT_ID", DataGridViewContentAlignment.MiddleCenter, colWidth: 180);
            DataGridViewUtil.AddGridTextColumn(dgvProduct, "제품유형", "PRODUCT_TYPE", DataGridViewContentAlignment.MiddleCenter, colWidth: 80);
            DataGridViewUtil.AddGridTextColumn(dgvProduct, "제품이름", "PRODUCT_NAME", DataGridViewContentAlignment.MiddleCenter, colWidth: 180);
            DataGridViewUtil.AddGridTextColumn(dgvProduct, "프로세스ID", "PROCESS_ID", DataGridViewContentAlignment.MiddleCenter, colWidth: 230);
            DataGridViewUtil.AddGridTextColumn(dgvProduct, "로트크기", "LOT_SIZE", DataGridViewContentAlignment.MiddleRight, colWidth: 80);
            DataGridViewUtil.AddGridTextColumn(dgvProduct, "입력되는 1회분 사이즈", "INPUT_BATCH_SIZE", DataGridViewContentAlignment.MiddleRight, colWidth: 170);

            DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();

            if (CurrentUser.IsAdmin == "관리자" || CurrentUser.IsAdmin == "마스터관리자")
            {
                btnEdit.Text = "수정";
                btnEdit.Width = 50;
                btnEdit.UseColumnTextForButtonValue = true;
                btnEdit.Name = "Edit";
                editIndex = dgvProduct.Columns.Add(btnEdit);
            }
            else
            {
                btnCreate.Enabled = false;
                btnDelete.Enabled = false;
            }
            LoadData();
        }

        private async void LoadData()
        {
            plist = null;
            plist = await srv.GetListAsync("api/Product/Products", plist);
            dgvProduct.DataSource = plist;

            com = null;
            com = await srv.GetListAsync($"api/Common/All", com);

            CommonUtil.ComboBinding(cboProduct, com, "PRODUCT_ID", blankText: "선택");
        }


        private void btnCreate_Click(object sender, EventArgs e)
        {
            PopupProduct frm = new PopupProduct();
            frm.ShowDialog();
            LoadData();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProduct.SelectedRows.Count < 1)
            {
                MessageBox.Show("삭제할 제품을 선택하여 주십시오.");
                return;
            }

            string productID = dgvProduct.SelectedRows[0].Cells["PRODUCT_ID"].Value.ToString();

            if (MessageBox.Show("제품 데이터에 영향이 있습니다. 정말 삭제하실겁니까?", "제품 삭제", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
            string productID = " ";
            if (cboProduct.SelectedIndex > 0)
                productID = cboProduct.SelectedValue.ToString();

            string url = $"api/Product/SearchProductList?productID={productID}";
            plist = null;
            plist = await srv.GetListAsync(url, plist);
            dgvProduct.DataSource = null;
            dgvProduct.DataSource = plist;
        }

        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == editIndex)
            {
                string productID = dgvProduct["PRODUCT_ID", e.RowIndex].Value.ToString();

                ProductVO sitem = plist.Find((product) => product.PRODUCT_ID == productID);

                PopupProduct frm = new PopupProduct(sitem);
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();
                LoadData();
            }
        }
    }
}