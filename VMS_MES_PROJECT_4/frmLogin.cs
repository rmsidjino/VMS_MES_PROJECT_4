using MESDTO;
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

namespace VMS_MES_PROJECT_4
{
    public partial class frmLogin : Form
    {
        ServiceHelp srv = new ServiceHelp("");
        MESDTO.Message msg;
        public UserVO CurrentUser { get; set; }
        public frmLogin()
        {
            InitializeComponent();

        }


        // label close CLICK
        private void labelClose_Click(object sender, EventArgs e)
        {
            //this.Close();
            Application.Exit();
        }

        // button login
        private async void buttonLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtPwd.Text))
            {
                MessageBox.Show("이메일, 비밀번호를 모두 입력하세요.");
                return;
            }

            UserVO user = new UserVO
            {
                Email = txtEmail.Text,
                Password = txtPwd.Text
            };

            Message<UserVO> Umsg = await srv.PostAsync("api/User/Check", user);

            if (Umsg.IsSuccess)
            {
                MessageBox.Show("로그인이 완료되었습니다");

                this.CurrentUser = Umsg.Data;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
                MessageBox.Show("로그인을 실패하였습니다");

        }

        // label go to signup CLICK
        private void lblSignup_Click(object sender, EventArgs e)
        {
            frmAccount registerform = new frmAccount();
            this.Hide();
            registerform.ShowDialog();
            this.Show();
        }

        // label go to signup MOUSE ENTER
        private void lblSignup_MouseEnter(object sender, EventArgs e)
        {
            lblSignup.ForeColor = Color.Yellow;
        }

        // label go to signup MOUSE LEAVE
        private void lblSignup_MouseLeave(object sender, EventArgs e)
        {
            lblSignup.ForeColor = Color.White;
        }

        private void lblWeb_Click(object sender, EventArgs e)
        {
            var psi = new ProcessStartInfo
            {
                FileName = "chrome.exe",
                Arguments = "https://localhost:44332/UserLogin/index",
                UseShellExecute = true
            };
            Process.Start(psi);
        }
    }
}
