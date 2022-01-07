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
    public partial class PopupSetupTime : Form
    {
        ServiceHelp srv = new ServiceHelp("");
        MESDTO.Message msg;
        SetupVO sItem;
        List<CommonVO> com;
        bool update = false;
        public PopupSetupTime()
        {
            InitializeComponent();
        }

        public PopupSetupTime(SetupVO sItem)
        {
            InitializeComponent();
            this.sItem = sItem;
            update = true;
            

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnOK_Click(object sender, EventArgs e)
        {
            SetupVO setup = new SetupVO
            {
                SITE_ID = cboSite.SelectedValue.ToString(),
                LINE_ID = cboLine.Text,
                EQP_GROUP = cboEqpGroup.Text,
                STEP_ID = cboStep.Text,
                TIME = Convert.ToInt32(txtTime.Text),
                MODIFIER = "Kim",
                MODIFIED_DATE = DateTime.Now
            };
            if (cboSite.Enabled)
            {
                msg = await srv.PostAsyncNone("api/Setup/InsertSetup", setup);
            }
            else
            {
                msg = await srv.PostAsyncNone("api/Setup/UpdateSetup", setup);
            }
            if (msg.IsSuccess)
            {
                //btnSearch.PerformClick();
            }
            MessageBox.Show(msg.ResultMessage);
            this.Close();
        }

        private async void PopupSetupTime_Load(object sender, EventArgs e)
        {
            com = null;
            com = await srv.GetListAsync($"api/Common/All", com);

            CommonUtil.ComboBinding(cboSite, com, "SITE", blankText: "선택");
            CommonUtil.ComboBinding(cboLine, com, "LINE", blankText: "선택");
            CommonUtil.ComboBinding(cboStep, com, "STEP", blankText: "선택");
            CommonUtil.ComboBinding(cboEqpGroup, com, "STEP", blankText: "선택");

            if (update)
            {
                cboSite.SelectedValue = sItem.SITE_ID;
                cboLine.SelectedValue = sItem.LINE_ID;
                cboStep.SelectedValue = sItem.STEP_ID;
                cboEqpGroup.SelectedValue = sItem.EQP_GROUP;
                txtTime.Text = sItem.TIME.ToString();
            }
        }

    }
}
