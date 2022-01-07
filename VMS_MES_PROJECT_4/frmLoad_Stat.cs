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
    public partial class frmLoad_Stat : Form
    {
        ServiceHelp srv = new ServiceHelp("");
        int editIndex;
        List<Load_StatVO> Llist;
        List<CommonVO> com;

        public frmLoad_Stat()
        {
            InitializeComponent();
        }

        private void frmLoad_Stat_Load(object sender, EventArgs e)
        {
            DataGridViewUtil.SetInitGridView(dgvLoadStat);
            DataGridViewUtil.AddGridTextColumn(dgvLoadStat, "버전번호", "VERSION_NO", colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvLoadStat, "라인ID", "LINE_ID", colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvLoadStat, "장비ID", "EQP_ID", colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvLoadStat, "목표마감일", "TARGET_DATE", colWidth: 130);
            DataGridViewUtil.AddGridTextColumn(dgvLoadStat, "가동준비 비율", "SETUP", colWidth: 130);
            DataGridViewUtil.AddGridTextColumn(dgvLoadStat, "가동", "BUSY", colWidth: 70);
            DataGridViewUtil.AddGridTextColumn(dgvLoadStat, "유후실행", "IDLERUN", colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvLoadStat, "유후", "IDLE", colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvLoadStat, "예방정비", "PM", colWidth: 130);
            DataGridViewUtil.AddGridTextColumn(dgvLoadStat, "중단", "DOWN", colWidth: 70);

            DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();

            btnEdit.Text = "수정";
            btnEdit.Width = 50;
            btnEdit.UseColumnTextForButtonValue = true;
            btnEdit.Name = "Edit";
            editIndex = dgvLoadStat.Columns.Add(btnEdit);

            LoadData();
        }

        private async void LoadData()
        {
            Llist = null;
            Llist = await srv.GetListAsync("api/Load_Stat/Load_Stats", Llist);
            dgvLoadStat.DataSource = Llist;

            com = null;
            com = await srv.GetListAsync($"api/Common/All", com);

            CommonUtil.ComboBinding(cboLine, com, "LINE_ID", blankText: "선택");
            CommonUtil.ComboBinding(cboEQP, com, "EQP_ID", blankText: "선택");
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string lineID = " ";
            if (cboLine.SelectedIndex > 0)
                lineID = cboLine.SelectedValue.ToString();

            string eqpID = " ";
            if (cboEQP.SelectedIndex > 0)
                eqpID = cboEQP.SelectedValue.ToString();


            string url = $"api/Load_Stat/SearchLoad_StatList?lineID={lineID}&eqpID={eqpID}";
            Llist = null;
            Llist = await srv.GetListAsync(url, Llist);
            dgvLoadStat.DataSource = null;
            dgvLoadStat.DataSource = Llist;
        }
    }
}