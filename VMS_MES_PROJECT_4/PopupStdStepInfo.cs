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
            StdStepInfoVO std_step_info = new StdStepInfoVO
            {
                STD_STEP_ID = cboStd_Step_Id.Text,
                STD_STEP_NAME = cboStd_Step_Name.Text,
                STEP_TAT = Convert.ToInt32(txtStep_Tat.Text),
                STEP_YIELD = Convert.ToInt32(txtStep_Yield.Text),
                STEP_SETUP = Convert.ToInt32(txtStep_Setup.Text),
                MODIFIER = "Kim",
                MODIFIER_DATE = DateTime.Now
            };
            if (cboStd_Step_Id.Enabled)
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
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void PopupStd_step_info_Load(object sender, EventArgs e)
        {
            com = null;
            com = await srv.GetListAsync($"api/Common/All", com);

            CommonUtil.ComboBinding(cboStd_Step_Id, com, "STEP", blankText: "선택");
            CommonUtil.ComboBinding(cboStd_Step_Name, com, "STEP", blankText: "선택");


            if (update)
            {
                cboStd_Step_Id.SelectedValue = stItem.STD_STEP_ID;
                cboStd_Step_Name.SelectedValue = stItem.STD_STEP_NAME;
                txtStep_Tat.Text = stItem.STEP_TAT.ToString();
                txtStep_Yield.Text = stItem.STEP_YIELD.ToString();
                txtStep_Setup.Text = stItem.STEP_SETUP.ToString();
            }
        }
    }
}
