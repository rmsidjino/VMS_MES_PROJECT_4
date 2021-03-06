using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        List<LoadStatVO> Llist;
        List<CommonVO> com;
        UserVO CurrentUser;

        public frmLoad_Stat(UserVO CurrentUser)
        {
            InitializeComponent();
        }

        private void frmLoad_Stat_Load(object sender, EventArgs e)
        {
            DataGridViewUtil.SetInitGridView(dgvLoadStat);
            DataGridViewUtil.AddGridTextColumn(dgvLoadStat, "버전번호", "VERSION_NO", DataGridViewContentAlignment.MiddleCenter, colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvLoadStat, "라인ID", "LINE_ID", DataGridViewContentAlignment.MiddleCenter, colWidth: 80);
            DataGridViewUtil.AddGridTextColumn(dgvLoadStat, "장비ID", "EQP_ID", DataGridViewContentAlignment.MiddleCenter, colWidth: 80);
            DataGridViewUtil.AddGridTextColumn(dgvLoadStat, "목표마감일", "TARGET_DATE", DataGridViewContentAlignment.MiddleRight, colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvLoadStat, "가동준비 비율", "SETUP", DataGridViewContentAlignment.MiddleRight, colWidth: 130);
            DataGridViewUtil.AddGridTextColumn(dgvLoadStat, "가동", "BUSY", DataGridViewContentAlignment.MiddleRight, colWidth: 70);
            DataGridViewUtil.AddGridTextColumn(dgvLoadStat, "유후실행", "IDLERUN", DataGridViewContentAlignment.MiddleRight, colWidth: 80);
            DataGridViewUtil.AddGridTextColumn(dgvLoadStat, "유후", "IDLE", DataGridViewContentAlignment.MiddleRight, colWidth: 70);
            DataGridViewUtil.AddGridTextColumn(dgvLoadStat, "예방정비", "PM", DataGridViewContentAlignment.MiddleRight, colWidth: 80);
            DataGridViewUtil.AddGridTextColumn(dgvLoadStat, "중단", "DOWN", DataGridViewContentAlignment.MiddleRight, colWidth: 70);

            DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();

            LoadData();
        }

        private async void LoadData()
        {
            Llist = null;
            Llist = await srv.GetListAsync("api/LoadStat/Load_Stats", Llist);
            dgvLoadStat.DataSource = Llist;

            com = null;
            com = await srv.GetListAsync($"api/Common/All", com);

            CommonUtil.ComboBinding(cboLine, com, "LINE", blankText: "선택");
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


            string url = $"api/LoadStat/SearchLoad_StatList?lineID={lineID}&eqpID={eqpID}";
            Llist = null;
            Llist = await srv.GetListAsync(url, Llist);
            dgvLoadStat.DataSource = null;
            dgvLoadStat.DataSource = Llist;
        }


        private void lblEqpPlan_Click(object sender, EventArgs e)
        {
            frmCapacity frm = new frmCapacity();
            frm.Show();
        }

        private void dgvLoadStat_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;
            SortOrder so = SortOrder.None;
            if (grid.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None ||
                grid.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Ascending)
            {
                so = SortOrder.Descending;
            }
            else
            {
                so = SortOrder.Ascending;
            }
            //set SortGlyphDirection after databinding otherwise will always be none 
            Sort(grid.Columns[e.ColumnIndex].Name, so);
            grid.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = so;
        }

        private void Sort(string column, SortOrder sortOrder)
        {
            switch (column)
            {
                case "VERSION_NO":
                    {
                        if (sortOrder == SortOrder.Ascending)
                        {
                            dgvLoadStat.DataSource = Llist.OrderBy(x => x.VERSION_NO).ToList();
                        }
                        else
                        {
                            dgvLoadStat.DataSource = Llist.OrderByDescending(x => x.VERSION_NO).ToList();
                        }
                        break;
                    }
                case "LINE_ID":
                    {
                        if (sortOrder == SortOrder.Ascending)
                        {
                            dgvLoadStat.DataSource = Llist.OrderBy(x => x.LINE_ID).ToList();
                        }
                        else
                        {
                            dgvLoadStat.DataSource = Llist.OrderByDescending(x => x.LINE_ID).ToList();
                        }
                        break;
                    }
                case "EQP_ID":
                    {
                        if (sortOrder == SortOrder.Ascending)
                        {
                            dgvLoadStat.DataSource = Llist.OrderBy(x => x.EQP_ID).ToList();
                        }
                        else
                        {
                            dgvLoadStat.DataSource = Llist.OrderByDescending(x => x.EQP_ID).ToList();
                        }
                        break;
                    }              
            }
        }
    }
}