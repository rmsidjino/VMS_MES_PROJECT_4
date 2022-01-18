
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
    public partial class frmUser : Form
    {
        ServiceHelp srv = new ServiceHelp("");
        //LoggingUtility _logging;
        int editIndex;
        List<UserVO> ulist;
        public UserVO CurrentUser { get; set; }
        public frmUser(UserVO CurrentUser)
        {
            InitializeComponent();
            this.CurrentUser = CurrentUser;
            //logging = new LoggingUtility("Setup", Level.Debug, 30); //테스트용
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            // 제품 데이터그리드뷰 컬럼 셋팅
            DataGridViewUtil.SetInitGridView(dgvUser);
            DataGridViewUtil.AddGridTextColumn(dgvUser, "ID", "ID", DataGridViewContentAlignment.MiddleCenter, colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvUser, "이름","FirstName", DataGridViewContentAlignment.MiddleCenter, colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvUser, "성","LastName", DataGridViewContentAlignment.MiddleCenter, colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvUser, "비밀번호","Password", DataGridViewContentAlignment.MiddleCenter, colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvUser, "이메일","Email",  DataGridViewContentAlignment.MiddleCenter, colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvUser, "권한","IsAdmin", DataGridViewContentAlignment.MiddleCenter, colWidth: 100);

            DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();

            btnEdit.Text = "수정";
            btnEdit.Width = 50;
            btnEdit.UseColumnTextForButtonValue = true;
            btnEdit.Name = "Edit";
            editIndex = dgvUser.Columns.Add(btnEdit);

            LoadData();
        }

        private async void LoadData()
        {

            ulist = null;
            ulist = await srv.GetListAsync($"api/User/Users", ulist);
            dgvUser.DataSource = ulist;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            PopupUser frm = new PopupUser();
            frm.ShowDialog();
            LoadData();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvUser.SelectedRows.Count < 1)
            {
                MessageBox.Show("삭제할 유저를 선택하여 주십시오.");
                return;
            }

            string ID = dgvUser.SelectedRows[0].Cells["ID"].Value.ToString();

            if (MessageBox.Show("정말 삭제하실겁니까?", "유저 삭제", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MESDTO.Message msg = await srv.GetAsync($"api/User/DelUser/{ID}");
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
                int ID = Convert.ToInt32(dgvUser["ID", e.RowIndex].Value);
                UserVO uInfo = ulist.Find((user) => user.ID == ID);
                PopupUser frm = new PopupUser(uInfo);
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();
                LoadData();
            }
        }
    }
}
