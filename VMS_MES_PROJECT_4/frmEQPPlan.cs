using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MESDTO;

namespace VMS_MES_PROJECT_4
{
    public partial class frmEQPPlan : Form
    {
        ServiceHelp srv = new ServiceHelp("");
        int editIndex;
        List<Equipment_PlanVO> eqpplanlist;
        List<CommonVO> com;
        UserVO CurrentUser;

        public frmEQPPlan(UserVO CurrentUser)
        {
            InitializeComponent();
            this.CurrentUser = CurrentUser;
        }

        private void frmEQPPlan_Load(object sender, EventArgs e)
        {
            DataGridViewUtil.SetInitGridView(dgvEQPPlan);
            DataGridViewUtil.AddGridTextColumn(dgvEQPPlan, "버전번호", "VERSION_NO", DataGridViewContentAlignment.MiddleRight, colWidth: 100);            
            DataGridViewUtil.AddGridTextColumn(dgvEQPPlan, "라인ID", "LINE_ID", DataGridViewContentAlignment.MiddleCenter, colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvEQPPlan, "장비ID", "EQP_ID", DataGridViewContentAlignment.MiddleCenter, colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvEQPPlan, "LOTID", "LOT_ID", DataGridViewContentAlignment.MiddleCenter, colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvEQPPlan, "제품ID", "PRODUCT_ID", DataGridViewContentAlignment.MiddleCenter, colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvEQPPlan, "과정ID", "PROCESS_ID", DataGridViewContentAlignment.MiddleCenter, colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvEQPPlan, "단계ID", "STEP_ID", DataGridViewContentAlignment.MiddleCenter, colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvEQPPlan, "과정량", "PROCESS_QTY", DataGridViewContentAlignment.MiddleRight, colWidth: 150);
            DataGridViewUtil.AddGridTextColumn(dgvEQPPlan, "발송된 날짜", "DISPATCH_IN_TIME", DataGridViewContentAlignment.MiddleRight, colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvEQPPlan, "시작시간", "START_TIME", DataGridViewContentAlignment.MiddleRight, colWidth: 130);
            DataGridViewUtil.AddGridTextColumn(dgvEQPPlan, "끝난시간", "END_TIME", DataGridViewContentAlignment.MiddleRight, colWidth: 150);
            DataGridViewUtil.AddGridTextColumn(dgvEQPPlan, "기계상태", "MACHINE_STATE", DataGridViewContentAlignment.MiddleCenter, colWidth: 150);
            DataGridViewUtil.AddGridTextColumn(dgvEQPPlan, "마감시간", "DUE_DATE", DataGridViewContentAlignment.MiddleRight, colWidth: 150);
           

            LoadData();
        }

        private async void LoadData()
        {
            eqpplanlist = null;
            eqpplanlist = await srv.GetListAsync("api/EquipmentPlan/EquipmentPlans", eqpplanlist);
            dgvEQPPlan.DataSource = eqpplanlist;
           
            

            com = null;
            com = await srv.GetListAsync($"api/Common/All", com);


            
            CommonUtil.ComboBinding(cboProductID, com, "PRODUCT_ID", blankText: "선택");
            
           
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string productID = " ";
            if (cboProductID.SelectedIndex > 0)
                productID = cboProductID.SelectedValue.ToString();

            
            eqpplanlist = await srv.GetAsync($"api/EquipmentPlan/SearchEquipmentPlan/{productID}/", eqpplanlist);
            dgvEQPPlan.DataSource = null;
            dgvEQPPlan.DataSource = eqpplanlist;
        }

        private void lblEqpPlan_Click(object sender, EventArgs e)
        {
            //var psi = new ProcessStartInfo
            //{
            //    FileName = "chrome.exe",
            //    Arguments = "https://localhost:44332/Gantt/index",
            //    UseShellExecute = true
            //};
            //Process.Start(psi);

            Form frm = new frmLotGantt();
            frm.Show();


        }
    }
}
