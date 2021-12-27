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
        List<SetupVO> slist = null;
        public frmSetupTime()
        {
            InitializeComponent();
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

            LoadData();


        }

        private async void LoadData()
        {

            slist = await srv.GetListAsync("api/Setup/Setups", slist);
            dgvSetup.DataSource = slist;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            PopupSetupTime frm = new PopupSetupTime();
            frm.ShowDialog();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvSetup.SelectedRows.Count < 1)
            {
                MessageBox.Show("삭제할 셋업을 선택하여 주십시오.");
            }

            string siteID = dgvSetup.SelectedRows[0].Cells["SITE_ID"].Value.ToString();

            if (MessageBox.Show("정말 삭제하실겁니까?", "셋업 삭제", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MESDTO.Message msg = await srv.GetAsync($"api/Setup/DelSetup/{siteID}");
                if (msg.IsSuccess)
                {
                    LoadData();
                }
                MessageBox.Show(msg.ResultMessage);
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {

            SetupVO prod = null;
            prod = await srv.GetAsync($"api/Setup/Search/{cboSite.SelectedValue}", prod);

            dgvSetup.DataSource = prod;
        }
    }
}
