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
    public partial class PopupDemand : Form
    {
        ServiceHelp srv = new ServiceHelp("");
        MESDTO.Message msg;
        DemandVO dItem;
        List<CommonVO> com;
        bool update = false;

        public PopupDemand()
        {
            InitializeComponent();
            txtDemandID.Enabled = false;
            txtDemand_Ver.Enabled = false;

        }

        public PopupDemand(DemandVO dItem)
        {
            InitializeComponent();
            this.dItem = dItem;
            update = true;
        }

        private async void btnOk_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            if (txtDemand_Ver.Text.Length < 1)
            {
                sb.AppendLine("- 수주버전을 입력하세요.");
            }

            if (txtDemandID.Text.Length < 1)
            {
                sb.AppendLine("- 수주ID를 입력하세요.");
            }

            if (cboProductID.SelectedIndex < 1)
            {
                sb.AppendLine("- 제품ID를 선택하세요.");
            }

            if (cboCustomerID.SelectedIndex < 1)
            {
                sb.AppendLine("- 거래처ID를 선택하세요.");
            }

            if (dtpDueDate.Text.Length < 1)
            {
                sb.AppendLine("- 납기일을 선택하세요.");
            }

            if (txtDemand_Qty.Text.Length < 1)
            {
                sb.AppendLine("- 수주수량 입력하세요.");
            }

            if (sb.ToString().Length > 1)
            {
                MessageBox.Show(sb.ToString());
                return;
            }

            DemandVO demand = new DemandVO
            {
                DEMAND_VER = txtDemand_Ver.Text,
                DEMAND_ID = txtDemandID.Text,
                PRODUCT_ID = cboProductID.Text,
                CUSTOMER_ID = cboCustomerID.Text,
                DUE_DATE = dtpDueDate.Value,
                DEMAND_QTY = Convert.ToInt32(txtDemand_Qty.Text),
                MODIFIER = "Kim",
                MODIFIER_DATE = DateTime.Now
            };
            if (update)
            {
                msg = await srv.PostAsyncNone("api/Demand/UpdateDemand", demand);
            }
            else
            {
                msg = await srv.PostAsyncNone("api/Demand/InsertDemand", demand);
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

        private async void PopupDemand_Load(object sender, EventArgs e)
        {
            com = null;
            com = await srv.GetListAsync($"api/Common/All", com);

            CommonUtil.ComboBinding(cboProductID, com, "PRODUCT_ID", blankText: "선택");
            CommonUtil.ComboBinding(cboCustomerID, com, "CUSTOMER_ID", blankText: "선택");

            if (update)
            {
                txtDemand_Ver.Text = dItem.DEMAND_VER.ToString();
                txtDemandID.Text = dItem.DEMAND_ID.ToString();
                cboProductID.SelectedValue = dItem.PRODUCT_ID.ToString();
                cboCustomerID.Text = dItem.CUSTOMER_ID.ToString();
                dtpDueDate.Text = dItem.DUE_DATE.ToString();
                txtDemand_Qty.Text = dItem.DEMAND_QTY.ToString();
            }
        }
    }
}