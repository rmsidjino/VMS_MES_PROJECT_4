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
        }
        public PopupEQP_AR_reg(EquipmentArrVO eqpItem)
        {
            InitializeComponent();
            this.eqpItem = eqpItem;
            update = true;
        }

        private async void btnOK_Click(object sender, EventArgs e)
        {
            //유효성 체크
            //if (!= null && != .Text)
            //{
            //    MessageBox.Show("시간이 다릅니다");
            //    return;
            //}

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
            if (cboProductID.Enabled)
            {
                msg = await srv.PostAsyncNone("api/EquipmentArr/InsertEquipmentArr", equipmentarr);
            }
            else
            {
                msg = await srv.PostAsyncNone("api/EquipmentArr/UpdateEquipmentArr", equipmentarr);
            }
            if (msg.IsSuccess)
            {
                //btnSearch.PerformClick();
            }
            MessageBox.Show(msg.ResultMessage);
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
                dtpStartDate.Value = eqpItem.EFF_START_DATE;
                dtpEndTime.Value = eqpItem.EFF_END_DATE;
                
            }



        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
