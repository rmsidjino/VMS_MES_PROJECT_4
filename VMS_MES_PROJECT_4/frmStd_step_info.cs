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
    public partial class frmStd_step_info : Form
    {
        ServiceHelp srv = new ServiceHelp("");
        int editIndex;
        List<StdStepInfoVO> stlist;
        List<CommonVO> com;

        public frmStd_step_info()
        {
            InitializeComponent();
        }

        private void frmStd_step_info_Load(object sender, EventArgs e)
        {
            DataGridViewUtil.SetInitGridView(dgvStdStepInfo);
            DataGridViewUtil.AddGridTextColumn(dgvStdStepInfo, "표준공정ID", "STD_STEP_ID", DataGridViewContentAlignment.MiddleCenter, colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvStdStepInfo, "표준공정이름", "STD_STEP_NAME", DataGridViewContentAlignment.MiddleCenter, colWidth: 110);
            DataGridViewUtil.AddGridTextColumn(dgvStdStepInfo, "공정시간", "STEP_TAT", DataGridViewContentAlignment.MiddleRight, colWidth: 80);
            DataGridViewUtil.AddGridTextColumn(dgvStdStepInfo, "공정수율", "STEP_YIELD", DataGridViewContentAlignment.MiddleRight, colWidth: 80);
            DataGridViewUtil.AddGridTextColumn(dgvStdStepInfo, "공정준비시간", "STEP_SETUP", DataGridViewContentAlignment.MiddleRight, colWidth: 110);

            DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();

            btnEdit.Text = "수정";
            btnEdit.Width = 50;
            btnEdit.UseColumnTextForButtonValue = true;
            btnEdit.Name = "Edit";
            editIndex = dgvStdStepInfo.Columns.Add(btnEdit);

            LoadData();
        }
        private async void LoadData()
        {
            stlist = null;
            stlist = await srv.GetListAsync("api/Std_step_info/Std_step_infos", stlist);
            dgvStdStepInfo.DataSource = stlist;

            com = null;
            com = await srv.GetListAsync($"api/Common/All", com);

            CommonUtil.ComboBinding(cboStd_Step_Id, com, "STEP", blankText: "선택");
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            PopupStdStepInfo frm = new PopupStdStepInfo();
            frm.ShowDialog();
            LoadData();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvStdStepInfo.SelectedRows.Count < 1)
            {
                MessageBox.Show("삭제할 표준공정ID를 선택하여 주십시오.");
                return;
            }

            string std_step_ID = dgvStdStepInfo.SelectedRows[0].Cells["STD_STEP_ID"].Value.ToString();

            if (MessageBox.Show("표준 공정 정보 데이터에 영향이 있습니다. 정말 삭제하실겁니까?", "표준공정ID 삭제", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MESDTO.Message msg = await srv.GetAsync($"api/Std_step_info/DeleteStd_step_info/{std_step_ID}");
                if (msg.IsSuccess)
                {
                    LoadData();
                }
                MessageBox.Show(msg.ResultMessage);
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string std_step_ID = " ";
            if (cboStd_Step_Id.SelectedIndex > 0)
                std_step_ID = cboStd_Step_Id.SelectedValue.ToString();

            string url = $"api/Std_step_info/SearchStdStepInfoList?std_step_ID={std_step_ID}";
            stlist = null;
            stlist = await srv.GetListAsync(url, stlist);
            dgvStdStepInfo.DataSource = null;
            dgvStdStepInfo.DataSource = stlist;
        }

        private void dgvStdStepInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == editIndex)
            {
                string std_step_ID = dgvStdStepInfo["STD_STEP_ID", e.RowIndex].Value.ToString();

                StdStepInfoVO sitem = stlist.Find((std_step_info) => std_step_info.STD_STEP_ID == std_step_ID);

                PopupStdStepInfo frm = new PopupStdStepInfo(sitem);
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Show();
            }
        }
    }
}