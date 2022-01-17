using MESDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VMS_MES_PROJECT_4
{
    public partial class frmEQP_AR : Form
    {
        ServiceHelp srv = new ServiceHelp("");
        int editIndex;
        List<EquipmentArrVO> eqplist;
        List<CommonVO> com;
        UserVO CurrentUser;

        public frmEQP_AR(UserVO CurrentUser)
        {
            InitializeComponent();
            this.CurrentUser = CurrentUser;
        }

        private void frmEQP_AR_Load(object sender, EventArgs e)
        {
            DataGridViewUtil.SetInitGridView(dgvEqpArr);
            DataGridViewUtil.AddGridTextColumn(dgvEqpArr, "제품ID", "PRODUCT_ID", DataGridViewContentAlignment.MiddleCenter, colWidth: 200);
            DataGridViewUtil.AddGridTextColumn(dgvEqpArr, "프로세서ID", "PROCESS_ID", DataGridViewContentAlignment.MiddleCenter, colWidth: 200);
            DataGridViewUtil.AddGridTextColumn(dgvEqpArr, "공정ID", "STEP_ID", DataGridViewContentAlignment.MiddleCenter, colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvEqpArr, "장비ID", "EQP_ID", DataGridViewContentAlignment.MiddleCenter, colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvEqpArr, "공정시간", "TACT_TIME", DataGridViewContentAlignment.MiddleRight,colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvEqpArr, "동작시간", "PROC_TIME", DataGridViewContentAlignment.MiddleRight,colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvEqpArr, "장비 가용 시간(시작)", "EFF_START_DATE", colWidth: 150);
            DataGridViewUtil.AddGridTextColumn(dgvEqpArr, "장비 가용 시간(종료)", "EFF_END_DATE", colWidth: 150);            

            DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();

            if (CurrentUser.IsAdmin == "관리자" || CurrentUser.IsAdmin == "마스터관리자")
            {
                btnEdit.Text = "수정";
                btnEdit.Width = 50;
                btnEdit.UseColumnTextForButtonValue = true;
                btnEdit.Name = "Edit";
                editIndex = dgvEqpArr.Columns.Add(btnEdit);
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
            eqplist = null;
            eqplist = await srv.GetListAsync("api/EquipmentArr/EquipmentArrs", eqplist);
            dgvEqpArr.DataSource = eqplist;

            com = null;
            com = await srv.GetListAsync($"api/Common/All", com);


            CommonUtil.ComboBinding(cboProductID, com, "PRODUCT_ID", blankText: "선택");
            CommonUtil.ComboBinding(cboProcessID, com, "PROCESS_ID", blankText: "선택");
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            PopupEQP_AR_reg frm = new PopupEQP_AR_reg();
            frm.ShowDialog();
            LoadData();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvEqpArr.SelectedRows.Count < 1)
            {
                MessageBox.Show("삭제할 설비를 선택하여 주십시오.");
                return;
            }

            string productID = dgvEqpArr.SelectedRows[0].Cells["PRODUCT_ID"].Value.ToString();

            if (MessageBox.Show("설비 배치 데이터에 영향이 있습니다. 정말 삭제하실겁니까?", "설비 삭제", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MESDTO.Message msg = await srv.GetAsync($"api/EquipmentArr/DelEquipmentArr/{productID}");
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
            if (cboProductID.SelectedIndex > 0)
                productID = cboProductID.SelectedValue.ToString();

            string processID = " ";
            if (cboProcessID.SelectedIndex > 0)
                processID = cboProcessID.SelectedValue.ToString();

            eqplist = await srv.GetAsync($"api/EquipmentArr/SearchEquipmentArr/{productID}/{processID}", eqplist);
            dgvEqpArr.DataSource = null;
            dgvEqpArr.DataSource = eqplist;
        }

        private void dgvEqpArr_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == editIndex)
            {
                string productID = dgvEqpArr["PRODUCT_ID", e.RowIndex].Value.ToString();
                EquipmentArrVO eqpitem = eqplist.Find((equipmentarr) => equipmentarr.PRODUCT_ID == productID);
                PopupEQP_AR_reg frm = new PopupEQP_AR_reg(eqpitem);                
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();
                LoadData();
            }
        }
    }
}
