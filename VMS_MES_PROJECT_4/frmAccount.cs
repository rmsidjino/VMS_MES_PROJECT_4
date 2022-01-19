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
    public partial class frmAccount : Form
    {
        ServiceHelp srv = new ServiceHelp("");
        MESDTO.Message msg;
        bool pCheck = false;
        bool iCheck = false;
        bool rCheck = false;

        
        public frmAccount()
        {      
            InitializeComponent();
        }

        private void btnPwdCheck_Click(object sender, EventArgs e)
        {
            pCheck = CheckPassword(txtPwd.Text);
            if (pCheck)
                MessageBox.Show("사용가능한 패스워드입니다.");
            else
                MessageBox.Show("비밀번호를 다시 설정해주세요. 6자에서 12자 사이이며 대소문자, 특수문자가 1개씩 포함되어야 합니다.");
        }

        public static bool CheckPassword(string pass)
        {
            //min 6 chars, max 12 chars
            if (pass.Length < 6 || pass.Length > 12)
                return false;

            //No white space
            if (pass.Contains(" "))
                return false;

            //At least 1 upper case letter
            if (!pass.Any(char.IsUpper))
                return false;

            //At least 1 lower case letter
            if (!pass.Any(char.IsLower))
                return false;

            //No two similar chars consecutively
            for (int i = 0; i < pass.Length - 1; i++)
            {
                if (pass[i] == pass[i + 1])
                    return false;
            }

            //At least 1 special char
            string specialCharacters = @"%!@#$%^&*()?/>.<,:;'\|}]{[_~`+=-" + "\"";
            char[] specialCharactersArray = specialCharacters.ToCharArray();
            foreach (char c in specialCharactersArray)
            {
                if (pass.Contains(c))
                    return true;
            }
            return true;
        }
        public static bool IsEmail(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return false;

            // MUST CONTAIN ONE AND ONLY ONE @
            var atCount = input.Count(c => c == '@');
            if (atCount != 1) return false;

            // MUST CONTAIN PERIOD
            if (!input.Contains(".")) return false;

            // @ MUST OCCUR BEFORE LAST PERIOD
            var indexOfAt = input.IndexOf("@", StringComparison.Ordinal);
            var lastIndexOfPeriod = input.LastIndexOf(".", StringComparison.Ordinal);
            var atBeforeLastPeriod = lastIndexOfPeriod > indexOfAt;
            if (!atBeforeLastPeriod) return false;

            try
            {
                var addr = new System.Net.Mail.MailAddress(input);
                return addr.Address == input;
            }
            catch
            {
                return false;
            }
        }

        private async void btnIDCheck_Click(object sender, EventArgs e)
        {
            if (!IsEmail(txtEmail.Text))
            {
                MessageBox.Show("이메일 형식이 맞지 않습니다.");
                return;
            }
            UserVO user = new UserVO
            {
                Email = txtEmail.Text,
            };

            msg = await srv.PostAsyncNone($"api/User/CheckID",user);
            if (msg.IsSuccess)
            {
                MessageBox.Show(msg.ResultMessage);
                iCheck = true;           
            }
            else
            {
                MessageBox.Show(msg.ResultMessage);
            }
        }

        private void txtRepeatPwd_Leave(object sender, EventArgs e)
        {
            if (txtPwd.Text.Equals(txtRepeatPwd.Text))
            {
                rCheck = true;
                lblRepeatPwd.Visible = false;
            }
            else
            {
                rCheck = false;
                lblRepeatPwd.Visible = true;
            }
        }

        private void frmAccount_Load(object sender, EventArgs e)
        {
            lblRepeatPwd.Visible = false;
        }

        private async void btnCreate_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            if (txtEmail.Text.Length < 1)
            {
                sb.AppendLine("- 이메일을 입력하세요.");
            }
            if (iCheck == false)
            {
                sb.AppendLine("- 이메일 체크를 해주세요.");
            }
            if (txtPwd.Text.Length < 1)
            {
                sb.AppendLine("- 비밀번호를 입력하세요.");
            }
            if (txtRepeatPwd.Text.Length < 1 || rCheck == false || pCheck ==false)
            {
                sb.AppendLine("- 비밀번호를 체크하세요.");
            }
            if (txtLastName.Text.Length < 1)
            {
                sb.AppendLine("- 성을 입력하세요.");
            }
            if (txtFirstName.Text.Length < 1)
            {
                sb.AppendLine("- 이름을 입력하세요.");
            }
            if (sb.ToString().Length > 1)
            {
                MessageBox.Show(sb.ToString());
                return;
            }

            UserVO user = new UserVO
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Password = txtPwd.Text,
                Email = txtEmail.Text
            };

            msg = await srv.PostAsyncNone("api/User/Create", user);

            if (msg.IsSuccess)
            {
                MessageBox.Show(msg.ResultMessage);
                this.Close();
            }
            else
            {
                MessageBox.Show(msg.ResultMessage);
            }
        }

        private void lblSignIn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
