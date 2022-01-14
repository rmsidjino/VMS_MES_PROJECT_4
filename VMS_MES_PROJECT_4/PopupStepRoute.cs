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
    public partial class PopupStepRoute : Form
    {
        ServiceHelp srv = new ServiceHelp("");
        MESDTO.Message msg;
        StepRouteVO SItem;
        List<CommonVO> com;
        bool update = false;

        public PopupStepRoute()
        {
            InitializeComponent();
        }

        public PopupStepRoute(StepRouteVO SItem)
        {
            InitializeComponent();
            this.SItem = SItem;
            update = true;
        }

        private async void btnOk_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            if (txtProcessID.Text.Length < 1)
            {
                sb.AppendLine("- 프로세스ID를 입력하세요.");
            }

            if (cboStepID.SelectedIndex < 1)
            {
                sb.AppendLine("- 공정ID를 선택하세요.");
            }

            if (txtStepSeq.Text.Length < 1)
            {
                sb.AppendLine("- 공정단계를 입력하세요.");
            }

            if (cboStdStepID.SelectedIndex < 1)
            {
                sb.AppendLine("- 표준공정ID를 선택하세요.");
            }

            if (cboStepID.SelectedIndex != cboStdStepID.SelectedIndex)
            {
                sb.AppendLine("- 공정이 같지 않습니다. 다시 입력하세요.");
            }

            if (cboStepType.SelectedIndex < 1)
            {
                sb.AppendLine("- 공정유형을 선택하세요.");
            }

            if (cboProcessType.SelectedIndex < 1)
            {
                sb.AppendLine("- 프로세스 유형을 선택하세요.");
            }

            if (sb.ToString().Length > 1)
            {
                MessageBox.Show(sb.ToString());
                return;
            }

            StepRouteVO step_route = new StepRouteVO
            {
                PROCESS_ID = txtProcessID.Text,
                STEP_ID = cboStepID.Text,
                STEP_SEQ = Convert.ToInt32(txtStepSeq.Text),
                STD_STEP_ID = cboStdStepID.Text,
                STEP_TYPE = cboStepType.Text,
                PROCESS_TYPE = cboProcessType.Text,
                IN_STOCK = Convert.ToInt32(txtInStock.Text),
                OUT_STOCK = Convert.ToInt32(txtOutStock.Text),
                MODIFIER = "Kim",
                MODIFIER_DATE = DateTime.Now
            };
            if (txtProcessID.Enabled)
            {
                msg = await srv.PostAsyncNone("api/StepRoute/InsertStepRoute", step_route);
            }
            else
            {
                msg = await srv.PostAsyncNone("api/StepRoute/UpdateStepRoute", step_route);
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

        private async void PopupStepRoute_Load(object sender, EventArgs e)
        {
            com = null;
            com = await srv.GetListAsync($"api/Common/All", com);

            CommonUtil.ComboBinding(cboStepID, com, "STEP", blankText: "선택");
            CommonUtil.ComboBinding(cboStdStepID, com, "STEP", blankText: "선택");
            CommonUtil.ComboBinding(cboStepType, com, "STEPTYPE", blankText: "선택");
            CommonUtil.ComboBinding(cboProcessType, com, "PROCESSTYPE", blankText: "선택");

            if (update)
            {
                txtProcessID.Text = SItem.PROCESS_ID.ToString();
                cboStepID.SelectedValue = SItem.STEP_ID;
                txtStepSeq.Text = SItem.STEP_SEQ.ToString();
                cboStdStepID.SelectedValue = SItem.STD_STEP_ID;
                cboStepType.SelectedValue = SItem.STEP_TYPE;
                cboProcessType.SelectedValue = SItem.PROCESS_TYPE;
                txtInStock.Text = SItem.IN_STOCK.ToString();
                txtOutStock.Text = SItem.OUT_STOCK.ToString();
            }
        }
    }
} 
