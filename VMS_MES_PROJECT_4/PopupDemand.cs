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
        }

        public PopupDemand(DemandVO dItem)
        {
            InitializeComponent();
            this.dItem = dItem;
            update = true;
        }

        private async void btnOk_Click(object sender, EventArgs e)
        {
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
            if (cboProductID.Enabled)
            {
                msg = await srv.PostAsyncNone("api/Demand/InsertDemand", demand);
            }
            else
            {
                msg = await srv.PostAsyncNone("api/Demand/UpdateDemand", demand);
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