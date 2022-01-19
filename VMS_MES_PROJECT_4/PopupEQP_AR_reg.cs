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
    public partial class PopupEQP_AR_reg : Form
    {
        ServiceHelp srv = new ServiceHelp("");
        MESDTO.Message msg;
        EquipmentArrVO eqpItem;
        List<CommonVO> com;
        bool update = false;
        
        public PopupEQP_AR_reg()
        {
            InitializeComponent();
            cboProductID.Enabled = false;
            cboProcessID.Enabled = false;
            cboStepID.Enabled = false;
            txtEQPID.Enabled = false;

        }
        public PopupEQP_AR_reg(EquipmentArrVO eqpItem)
        {
            InitializeComponent();
            this.eqpItem = eqpItem;
            update = true;
            cboProductID.Enabled = false;
            cboProcessID.Enabled = false;
            cboStepID.Enabled = false;
            txtEQPID.Enabled = false;
        }

        private async void btnOK_Click(object sender, EventArgs e)
        {
            //유효성 체크
            StringBuilder sb = new StringBuilder();

           
            if (cboProductID.SelectedIndex < 1)
            {
                sb.AppendLine("- 제품ID를 선택하세요.");
            }
            if (cboProcessID.SelectedIndex < 1)
            {
                sb.AppendLine("- 프로세서ID를 선택하세요.");
            }
            if (cboStepID.SelectedIndex < 1)
            {
                sb.AppendLine("- 공정ID을 선택하세요.");
            }
            if (txtEQPID.Text.Length < 1)
            {
                sb.AppendLine("- 장비ID를 입력하세요.");
            }
            if (txtProcTime.Text != txtTactTime.Text)
            {
                sb.AppendLine("- 시간이 같지 않습니다. 다시 입력하세요.");
            }
            if(dtpStartDate.Value >= dtpEndTime.Value)
            {
                sb.AppendLine("-  시간이 맞지 않습니다. 다시 입력하세요.");
            }
            if (sb.ToString().Length > 1)
            {
                MessageBox.Show(sb.ToString());
                return;
            }
            EquipmentArrVO equipmentarr = new EquipmentArrVO
            {
                PRODUCT_ID = cboProductID.Text,
                PROCESS_ID = cboProcessID.Text,
                STEP_ID = cboStepID.Text,
                EQP_ID = txtEQPID.Text,
                TACT_TIME = Convert.ToInt32(txtTactTime.Text),
                PROC_TIME = Convert.ToInt32(txtProcTime.Text),
                EFF_START_DATE = dtpStartDate.Value,
                EFF_END_DATE = dtpEndTime.Value,                                                                                                             
                MODIFIER = "Kim",
                MODIFIER_DATE = DateTime.Now
            };
            if (update)
            {
                msg = await srv.PostAsyncNone("api/EquipmentArr/UpdateEquipmentArr", equipmentarr);
               
            }
            else
            {
                msg = await srv.PostAsyncNone("api/EquipmentArr/InsertEquipmentArr", equipmentarr);
            }

            MessageBox.Show(msg.ResultMessage);
            if (msg.IsSuccess)
            {
                //btnSearch.PerformClick();
            }           
            this.Close();
        }

        private async void PopupEQP_AR_reg_Load(object sender, EventArgs e)
        {
            com = null;
            com = await srv.GetListAsync($"api/Common/All", com);


            CommonUtil.ComboBinding(cboProductID, com, "PRODUCT_ID", blankText: "선택");
            CommonUtil.ComboBinding(cboProcessID, com, "PROCESS_ID", blankText: "선택");
            CommonUtil.ComboBinding(cboStepID, com, "STEP", blankText: "선택");
            
            if(update)
            {
                cboProductID.SelectedValue = eqpItem.PRODUCT_ID;
                cboProcessID.SelectedValue = eqpItem.PROCESS_ID;
                cboStepID.SelectedValue = eqpItem.STEP_ID;
                txtEQPID.SelectedText = eqpItem.EQP_ID;
                txtTactTime.SelectedText = eqpItem.TACT_TIME.ToString();
                txtProcTime.SelectedText = eqpItem.PROC_TIME.ToString();
                dtpStartDate.Text = eqpItem.EFF_START_DATE.ToString();
                dtpEndTime.Text = eqpItem.EFF_END_DATE.ToString();
                
            }



        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
