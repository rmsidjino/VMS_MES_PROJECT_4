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
        public PopupSetupTime()
        {
            InitializeComponent();
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
        }
    }
}
