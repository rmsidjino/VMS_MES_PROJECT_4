using log4net.Core;
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
    public partial class frmSetupTime : Form
    {
        ServiceHelp srv = new ServiceHelp("");
        //LoggingUtility _logging;
        int editIndex;
        List<SetupVO> slist;
        List<CommonVO> com;

        public frmSetupTime()
        {
            InitializeComponent();
            //logging = new LoggingUtility("Setup", Level.Debug, 30); //테스트용
        }

        private void frmSetupTime_Load(object sender, EventArgs e)
        {
            // 제품 데이터그리드뷰 컬럼 셋팅
            DataGridViewUtil.SetInitGridView(dgvSetup);
            DataGridViewUtil.AddGridTextColumn(dgvSetup, "현장ID", "SITE_ID", colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvSetup, "라인ID", "LINE_ID", colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvSetup, "공정그룹", "EQP_GROUP", colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvSetup, "공정ID", "STEP_ID", colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvSetup, "가동준비시간", "TIME", DataGridViewContentAlignment.MiddleRight, colWidth: 130);

            DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();

            btnEdit.Text = "수정";
            btnEdit.Width = 50;
            btnEdit.UseColumnTextForButtonValue = true;
            btnEdit.Name = "Edit";
            editIndex = dgvSetup.Columns.Add(btnEdit);

            LoadData();
        }

        private async void LoadData()
        {
            slist = null;
            slist = await srv.GetListAsync("api/Setup/Setups", slist);
            dgvSetup.DataSource = slist;

            com = null;
            com = await srv.GetListAsync($"api/Common/All", com);

            CommonUtil.ComboBinding(cboSite, com, "SITE", blankText: "선택");
            CommonUtil.ComboBinding(cboStep, com, "STEP", blankText: "선택");
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            PopupSetupTime frm = new PopupSetupTime();
            frm.ShowDialog();
            LoadData();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvSetup.SelectedRows.Count < 1)
            {
                MessageBox.Show("삭제할 셋업을 선택하여 주십시오.");
                return;
            }

            string stepID = dgvSetup.SelectedRows[0].Cells["STEP_ID"].Value.ToString();

            if (MessageBox.Show("정말 삭제하실겁니까?", "셋업 삭제", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MESDTO.Message msg = await srv.GetAsync($"api/Setup/DelSetup/{stepID}");
                if (msg.IsSuccess)
                {
                    LoadData();
                }
                MessageBox.Show(msg.ResultMessage);
                //_logging.WriteInfo(msg.ResultMessage);
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string siteID = " ";
            if (cboSite.SelectedIndex > 0)
                siteID = cboSite.SelectedValue.ToString();

            string stepID = " ";
            if (cboStep.SelectedIndex > 0)
                stepID = cboStep.SelectedValue.ToString();

            slist = await srv.GetAsync($"api/Setup/SearchSetup/{siteID}/{stepID}/", slist);
            dgvSetup.DataSource = null;
            dgvSetup.DataSource = slist;           
        }

        private void dgvSetup_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == editIndex)
            {
                string siteID = dgvSetup["SITE_ID", e.RowIndex].Value.ToString();
                string lineID = dgvSetup["LINE_ID", e.RowIndex].Value.ToString();
                string stepID = dgvSetup["STEP_ID", e.RowIndex].Value.ToString();
                SetupVO sitem = slist.Find((setup) => setup.SITE_ID == siteID && setup.LINE_ID == lineID && setup.STEP_ID==stepID);
                PopupSetupTime frm = new PopupSetupTime(sitem);
                frm.Show();
            }
        }
    }
}
