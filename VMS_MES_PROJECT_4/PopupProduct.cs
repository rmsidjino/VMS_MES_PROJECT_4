﻿using System;
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
    public partial class PopupProduct : Form
    {
        ServiceHelp srv = new ServiceHelp("");
        MESDTO.Message msg;
        ProductVO pItem;
        List<CommonVO> com;
        bool update = false;
        public PopupProduct()
        {
            InitializeComponent();
        }

        public PopupProduct(ProductVO pItem)
        {
            InitializeComponent();
            this.pItem = pItem;
            update = true;
        }

        private async void btnOk_Click(object sender, EventArgs e)
        {
            ProductVO product = new ProductVO
            {
                PRODUCT_ID = txtProductID.Text,
                PRODUCT_TYPE = cboProductType.Text,
                PRODUCT_NAME = txtProductName.Text,
                PROCESS_ID = txtProcessID.Text,
                LOT_SIZE = Convert.ToInt32(txtLotSize.Text),
                INPUT_BATCH_SIZE = Convert.ToInt32(txtInputBatchSize.Text),
                MODIFIER = "Kim",
                MODIFIER_DATE = DateTime.Now
            };
            if (cboProductType.Enabled)
            {
                msg = await srv.PostAsyncNone("api/Product/InsertProduct", product);
            }
            else
            {
                msg = await srv.PostAsyncNone("api/Product/UpdateProduct", product);
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

        private async void PopupProduct_Load(object sender, EventArgs e)
        {
            com = null;
            com = await srv.GetListAsync($"api/Common/All", com);

            CommonUtil.ComboBinding(cboProductType, com, "PRODUCTTYPE", blankText: "선택");

            if (update)
            {
                txtProductID.Text = pItem.PRODUCT_ID.ToString();
                cboProductType.SelectedValue = pItem.PRODUCT_TYPE;
                txtProductName.Text = pItem.PRODUCT_NAME.ToString();
                txtProcessID.Text = pItem.PROCESS_ID.ToString();
                txtLotSize.Text = pItem.LOT_SIZE.ToString();
                txtInputBatchSize.Text = pItem.INPUT_BATCH_SIZE.ToString();
            }
        }
    }
}