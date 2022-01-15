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
    public partial class frmCommon : Form
    {
        ServiceHelp srv = new ServiceHelp("");
        //LoggingUtility _logging;
        int editIndex;
        List<CommonVO> clist;
        public UserVO CurrentUser { get; set; }
        public frmCommon()
        {
            InitializeComponent();
            this.CurrentUser = CurrentUser;
            //logging = new LoggingUtility("Setup", Level.Debug, 30); //테스트용
        }

        private void frmCommon_Load(object sender, EventArgs e)
        {
            // 제품 데이터그리드뷰 컬럼 셋팅
            DataGridViewUtil.SetInitGridView(dgvCommon);
            DataGridViewUtil.AddGridTextColumn(dgvCommon, "공통코드ID", "CCODE", DataGridViewContentAlignment.MiddleCenter, colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvCommon, "공통코드이름", "CNAME", DataGridViewContentAlignment.MiddleCenter, colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvCommon, "공통코드그룹", "CCATEGORY", DataGridViewContentAlignment.MiddleCenter, colWidth: 100);

            DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();

            btnEdit.Text = "수정";
            btnEdit.Width = 50;
            btnEdit.UseColumnTextForButtonValue = true;
            btnEdit.Name = "Edit";
            editIndex = dgvCommon.Columns.Add(btnEdit);

            LoadData();
        }

        private async void LoadData()
        {

            clist = null;
            clist = await srv.GetListAsync($"api/Common/Commons", clist);
            dgvCommon.DataSource = clist;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            PopupCommon frm = new PopupCommon();
            frm.ShowDialog();
            LoadData();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCommon.SelectedRows.Count < 1)
            {
                MessageBox.Show("삭제할 코드를 선택하여 주십시오.");
                return;
            }

            string CCODE = dgvCommon.SelectedRows[0].Cells["CCODE"].Value.ToString();

            if (MessageBox.Show("정말 삭제하실겁니까?", "공통코드 삭제", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MESDTO.Message msg = await srv.GetAsync($"api/Common/DelCommon/{CCODE}");
                if (msg.IsSuccess)
                {
                    LoadData();
                }
                MessageBox.Show(msg.ResultMessage);
                //_logging.WriteInfo(msg.ResultMessage);
            }
        }


        private void dgvSetup_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == editIndex)
            {
                string CCODE = dgvCommon["CCODE", e.RowIndex].Value.ToString();
                CommonVO citem = clist.Find((com) => com.CCODE == CCODE);
                PopupCommon frm = new PopupCommon(citem);
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();
                LoadData();
            }
        }
    }
}
