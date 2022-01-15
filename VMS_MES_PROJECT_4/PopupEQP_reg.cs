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
    public partial class PopupEQP_reg : Form
    {
        ServiceHelp srv = new ServiceHelp("");
        MESDTO.Message msg;
        EquipmentVO eItem;
        List<CommonVO> com;
        bool update = false;
        public PopupEQP_reg()
        {
            InitializeComponent();
        }
        public PopupEQP_reg(EquipmentVO eItem)
        {
            InitializeComponent();
            this.eItem = eItem;
            update = true;
        }

        private async void frmEQP_reg_Load(object sender, EventArgs e) // 수정
        {
            com = null;
            com = await srv.GetListAsync($"api/Common/All", com);

            CommonUtil.ComboBinding(cboSiteID, com, "SITE", blankText: "선택");
            CommonUtil.ComboBinding(cboLineID, com, "LINE", blankText: "선택");            
            CommonUtil.ComboBinding(cboEqpType, com, "GROUP", blankText: "선택");
            CommonUtil.ComboBinding(cboEqpGroup, com, "GROUP", blankText: "선택");
            CommonUtil.ComboBinding(cboSimType, com, "SIMULATION", blankText: "선택");
            CommonUtil.ComboBinding(cboDispatcherType, com, "DISPATCHER", blankText: "선택");
            CommonUtil.ComboBinding(cboEqpState, com, "STATE", blankText: "선택");
            CommonUtil.ComboBinding(cboAutomation, com, "AUTOMATION", blankText: "선택");
            

            //CommonUtil.ComboBinding(txtEQPID, com, "EQPID", blankText: "선택");

            if (update)
            {
                cboSiteID.SelectedValue = eItem.SITE_ID;
                cboLineID.SelectedValue = eItem.LINE_ID;
                txtEQPID.SelectedText = eItem.EQP_ID;
                txtEQPModel.SelectedText = eItem.EQP_MODEL;
                cboEqpGroup.SelectedValue = eItem.EQP_GROUP;
                cboSimType.SelectedValue = eItem.SIM_TYPE;
                txtPresetID.SelectedText = eItem.PRESET_ID;
                cboDispatcherType.SelectedValue = eItem.DISPATCHER_TYPE;
                cboEqpState.SelectedValue = eItem.EQP_STATE;
                txtEqpStateCode.SelectedText = eItem.EQP_STATE_CODE.ToString();
                DtpStateChangeTime.Value = eItem.STATE_CHANGE_TIME;
                cboAutomation.SelectedValue = eItem.AUTOMATION;


            }
        }

        private async void button1_Click(object sender, EventArgs e)// 수정
        {
            StringBuilder sb = new StringBuilder();
            //유효성 체크
            if (cboSiteID.SelectedIndex < 1)
            {
                sb.AppendLine("- 현장ID를 선택하세요.");
            }
            if (cboLineID.SelectedIndex < 1)
            {
                sb.AppendLine("- 라인ID를 선택하세요.");
            }
            if (txtEQPID.Text.Length < 1)
            {
                sb.AppendLine("- 장비ID를 입력하세요.");
            }
            if (txtEQPModel.Text.Length < 1)
            {
                sb.AppendLine("- 장비 모델을 입력하세요.");
            }
            if (txtEQPID.Text != txtEQPModel.Text)
            {
                sb.AppendLine("- 장비 정보가 같지 않습니다. 다시 입력하세요.");
            }
            if (cboEqpGroup.SelectedIndex < 1)
            {
                sb.AppendLine("- 공정 그룹을 선택하세요.");
            }
            if (cboSimType.SelectedIndex < 1)
            {
                sb.AppendLine("- 시뮬레이션 타입을 선택하세요.");
            }
            if (txtPresetID.Text.Length < 1)
            {
                sb.AppendLine("- 사전 설정ID를 입력하세요.");
            }
            if (cboDispatcherType.SelectedIndex < 1)
            {
                sb.AppendLine("- 비상배치타입을 선택하세요.");
            }
            if (cboEqpState.SelectedIndex < 1)
            {
                sb.AppendLine("- 장비 가동 상태를 선택하세요.");
            }

            if (sb.ToString().Length > 1)
            {
                MessageBox.Show(sb.ToString());
                return;
            } 
            
            EquipmentVO equipment = new EquipmentVO
            {
                SITE_ID = cboSiteID.Text,
                LINE_ID = cboLineID.Text,
                EQP_ID = txtEQPID.Text,
                EQP_MODEL = txtEQPModel.Text,
                EQP_TYPE = cboEqpType.Text,
                EQP_GROUP = cboEqpGroup.Text,
                SIM_TYPE = cboSimType.Text,
                PRESET_ID = txtPresetID.Text,
                DISPATCHER_TYPE = cboDispatcherType.Text,
                EQP_STATE = cboEqpState.Text,
                EQP_STATE_CODE = Convert.ToInt32(txtEqpStateCode.Text),
                STATE_CHANGE_TIME = DtpStateChangeTime.Value,
                AUTOMATION = cboAutomation.Text,               
                MODIFIER = "Kim",
                MODIFIER_DATE = DateTime.Now
            };
            if (update)
            {
                msg = await srv.PostAsyncNone("api/Equipment/UpdateEquipment", equipment);
                
            }
            else
            {
                msg = await srv.PostAsyncNone("api/Equipment/InsertEquipment", equipment);
            }
            MessageBox.Show(msg.ResultMessage);
            if (msg.IsSuccess)
            {
                //btnSearch.PerformClick();
            }
           
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
