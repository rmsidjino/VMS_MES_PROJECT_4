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
    public partial class PopupUser : Form
    {
        ServiceHelp srv = new ServiceHelp("");
        MESDTO.Message msg;
        UserVO uInfo;
        List<UserVO> user;
        List<CommonVO> com;
        bool update = false;
        public PopupUser()
        {
            InitializeComponent();

            txtID.Enabled = false;
        }

        public PopupUser(UserVO uInfo)
        {
            InitializeComponent();
            this.uInfo = uInfo;
            update = true;
            txtID.Enabled = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnOK_Click(object sender, EventArgs e)
        {
            //유효성 체크
            StringBuilder sb = new StringBuilder();
            if (txtFirstName.Text.Length < 1)
            {
                sb.AppendLine("- 성을 입력하세요.");
            }
            if (txtLastName.Text.Length < 1)
            {
                sb.AppendLine("- 이름을 입력하세요.");
            }
            if (txtEmail.Text.Length < 1)
            {
                sb.AppendLine("- 이메일을 입력하세요.");
            }
            if (txtPwd.Text.Length < 1)
            {
                sb.AppendLine("- 패스워드를 입력하세요.");
            }
            if (cboAdmin.SelectedIndex < 1)
            {
                sb.AppendLine("- 권한을 선택하세요.");
            }
            if (sb.ToString().Length > 1)
            {
                MessageBox.Show(sb.ToString());
                return;
            }
            UserVO user = new UserVO
            {
                ID = Convert.ToInt32(txtID.Text),
                LastName =txtLastName.Text,
                FirstName= txtFirstName.Text,
                Email= txtEmail.Text,
                Password = txtPwd.Text,
                IsAdmin= cboAdmin.SelectedValue.ToString()
            };

            if (update)
            {
                msg = await srv.PostAsyncNone("api/User/UpdateUser", user);
            }
            else
            {
                msg = await srv.PostAsyncNone("api/User/InsertUser", user);
            }

            MessageBox.Show(msg.ResultMessage);
            if (msg.IsSuccess)
            {
                //btnSearch.PerformClick();
            }
            this.Close();

            
            
        }

        private async void PopupUser_Load(object sender, EventArgs e)
        {

            com = null;
            com = await srv.GetListAsync($"api/Common/All", com);

            CommonUtil.ComboBinding(cboAdmin, com, "Admin", blankText: "선택");

            if (update)
            {
                txtID.Text = uInfo.ID.ToString();
                txtLastName.Text = uInfo.LastName;
                txtFirstName.Text = uInfo.FirstName;
                txtEmail.Text = uInfo.Email;
                txtPwd.Text = uInfo.Password;
                cboAdmin.SelectedValue = uInfo.IsAdmin;


            }
        }
    }
}
