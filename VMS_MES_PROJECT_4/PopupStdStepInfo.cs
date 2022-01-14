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
    public partial class PopupStdStepInfo : Form
    {
        ServiceHelp srv = new ServiceHelp("");
        MESDTO.Message msg;
        StdStepInfoVO stItem;
        List<CommonVO> com;
        bool update = false;

        public PopupStdStepInfo()
        {
            InitializeComponent();
        }

        public PopupStdStepInfo(StdStepInfoVO stItem)
        {
            InitializeComponent();
            this.stItem = stItem;
            update = true;
        }

        private async void btnOK_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            if (cboStdStepID.SelectedIndex < 1)
            {
                sb.AppendLine("- 표준공정ID를 선택하세요.");
            }

            if (cboStdStepName.SelectedIndex < 1)
            {
                sb.AppendLine("- 표준공정이름을 선택하세요.");
            }

            if (cboStdStepID.SelectedIndex != cboStdStepName.SelectedIndex)
            {
                sb.AppendLine("- 표준공정 정보가 같지 않습니다. 다시 입력하세요.");
            }

            if (txtStepTat.Text.Length < 1)
            {
                sb.AppendLine("- 공정시간을 입력하세요.");
            }

            if (txtStepYield.Text.Length < 1)
            {
                sb.AppendLine("- 공정수율을 입력하세요.");
            }

            if (txtStepSetup.Text.Length < 1)
            {
                sb.AppendLine("- 공정준비시간을 입력하세요.");
            }

            if (sb.ToString().Length > 1)
            {
                MessageBox.Show(sb.ToString());
                return;
            }

            StdStepInfoVO std_step_info = new StdStepInfoVO
            {
                STD_STEP_ID = cboStdStepID.Text,
                STD_STEP_NAME = cboStdStepName.Text,
                STEP_TAT = Convert.ToInt32(txtStepTat.Text),
                STEP_YIELD = Convert.ToInt32(txtStepYield.Text),
                STEP_SETUP = Convert.ToInt32(txtStepSetup.Text),
                MODIFIER = "Kim",
                MODIFIER_DATE = DateTime.Now
            };
            if (cboStdStepID.Enabled)
            {
                msg = await srv.PostAsyncNone("api/Std_step_info/InsertStd_step_info", std_step_info);
            }
            else
            {
                msg = await srv.PostAsyncNone("api/Std_step_info/UpdateStd_step_info", std_step_info);
            }
            if (msg.IsSuccess)
            {
                //btnSearch.PerformClick();
            }

            MessageBox.Show(msg.ResultMessage);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void PopupStd_step_info_Load(object sender, EventArgs e)
        {
            com = null;
            com = await srv.GetListAsync($"api/Common/All", com);

            CommonUtil.ComboBinding(cboStdStepID, com, "STEP", blankText: "선택");
            CommonUtil.ComboBinding(cboStdStepName, com, "STEP", blankText: "선택");


            if (update)
            {
                cboStdStepID.SelectedValue = stItem.STD_STEP_ID;
                cboStdStepName.SelectedValue = stItem.STD_STEP_NAME;
                txtStepTat.Text = stItem.STEP_TAT.ToString();
                txtStepYield.Text = stItem.STEP_YIELD.ToString();
                txtStepSetup.Text = stItem.STEP_SETUP.ToString();
            }
        }
    }
}
