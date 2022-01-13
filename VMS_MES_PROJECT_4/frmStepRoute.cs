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
    public partial class frmStepRoute : Form
    {
        ServiceHelp srv = new ServiceHelp("");
        int editIndex;
        List<StepRouteVO> Slist;
        List<CommonVO> com;

        public frmStepRoute()
        {
            InitializeComponent();
        }

        private void frmStepRoute_Load(object sender, EventArgs e)
        {
            DataGridViewUtil.SetInitGridView(dgvStepRoute);
            DataGridViewUtil.AddGridTextColumn(dgvStepRoute, "프로세스ID", "PROCESS_ID", DataGridViewContentAlignment.MiddleCenter, colWidth: 200);
            DataGridViewUtil.AddGridTextColumn(dgvStepRoute, "공정ID", "STEP_ID", DataGridViewContentAlignment.MiddleCenter, colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvStepRoute, "공정단계", "STEP_SEQ", DataGridViewContentAlignment.MiddleRight, colWidth: 90);
            DataGridViewUtil.AddGridTextColumn(dgvStepRoute, "표준공정ID", "STD_STEP_ID", DataGridViewContentAlignment.MiddleCenter, colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvStepRoute, "공정유형", "STEP_TYPE", DataGridViewContentAlignment.MiddleCenter, colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvStepRoute, "프로세스유형", "PROCESS_TYPE", DataGridViewContentAlignment.MiddleCenter, colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvStepRoute, "투입량", "IN_STOCK", DataGridViewContentAlignment.MiddleRight, colWidth: 70);
            DataGridViewUtil.AddGridTextColumn(dgvStepRoute, "산출량", "OUT_STOCK", DataGridViewContentAlignment.MiddleRight, colWidth: 70);

            DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();

            btnEdit.Text = "수정";
            btnEdit.Width = 50;
            btnEdit.UseColumnTextForButtonValue = true;
            btnEdit.Name = "Edit";
            editIndex = dgvStepRoute.Columns.Add(btnEdit);

            LoadData();
        }

        private async void LoadData()
        {
            Slist = null;
            Slist = await srv.GetListAsync("api/StepRoute/StepRoutes", Slist);
            dgvStepRoute.DataSource = Slist;

            com = null;
            com = await srv.GetListAsync($"api/Common/All", com);

            CommonUtil.ComboBinding(cboProcess, com, "PROCESS_ID", blankText: "선택");
            CommonUtil.ComboBinding(cboStep, com, "STEP", blankText: "선택");
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            PopupStepRoute frm = new PopupStepRoute();
            frm.ShowDialog();
            LoadData();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvStepRoute.SelectedRows.Count < 1)
            {
                MessageBox.Show("삭제할 제품을 선택하여 주십시오.");
                return;
            }

            string processID = dgvStepRoute.SelectedRows[0].Cells["PROCESS_ID"].Value.ToString();

            if (MessageBox.Show("정말 삭제하실겁니까?", "제품 삭제", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MESDTO.Message msg = await srv.GetAsync($"api/StepRoute/DeleteStepRoute/{processID}");
                if (msg.IsSuccess)
                {
                    LoadData();
                }
                MessageBox.Show(msg.ResultMessage);
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string processID = " ";
            if (cboProcess.SelectedIndex > 0)
                processID = cboProcess.SelectedValue.ToString();

            string stepID = " ";
            if (cboStep.SelectedIndex > 0)
                stepID = cboStep.SelectedValue.ToString();


            string url = $"api/StepRoute/SearchStepRouteList?processID={processID}&stepID={stepID}";
            Slist = null;
            Slist = await srv.GetListAsync(url, Slist);
            dgvStepRoute.DataSource = null;
            dgvStepRoute.DataSource = Slist;
        }

        private void dgvStepRoute_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == editIndex)
            {
                string processID = dgvStepRoute["PROCESS_ID", e.RowIndex].Value.ToString();
                string stepID = dgvStepRoute["STEP_ID", e.RowIndex].Value.ToString();
                string stdstepID = dgvStepRoute["STD_STEP_ID", e.RowIndex].Value.ToString();
                StepRouteVO Sitem = Slist.Find((step_route) => step_route.PROCESS_ID == processID && step_route.STEP_ID == stepID && step_route.STD_STEP_ID == stdstepID);
                
                PopupStepRoute frm = new PopupStepRoute(Sitem);
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Show();
            }
        }
    }
}
