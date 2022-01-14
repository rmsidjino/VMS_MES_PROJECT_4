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
    public partial class PopupCommon : Form
    {
        ServiceHelp srv = new ServiceHelp("");
        MESDTO.Message msg;
        CommonVO cItem;
        List<CommonVO> com;
        bool update = false;
        public PopupCommon()
        {
            InitializeComponent();
        }

        public PopupCommon(CommonVO cItem)
        {
            InitializeComponent();
            this.cItem = cItem;
            update = true;
            txtComCode.Enabled = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnOK_Click(object sender, EventArgs e)
        {
            //유효성 체크
            StringBuilder sb = new StringBuilder();
            if (txtComCode.Text.Length < 1)
            {
                sb.AppendLine("- 공통코드ID을 입력하세요.");
            }
            if (txtComName.Text.Length < 1)
            {
                sb.AppendLine("- 공통코드이름을 입력하세요.");
            }
            if (sb.ToString().Length > 1)
            {
                MessageBox.Show(sb.ToString());
                return;
            }
            CommonVO com = new CommonVO
            {
                CCODE = txtComCode.Text,
                CNAME = txtComName.Text,
                CCATEGORY = cboComGroup.SelectedItem.ToString()
            };
            if (update)
            {
                msg = await srv.PostAsyncNone("api/Common/UpdateCommon", com);
            }
            else
            {
                msg = await srv.PostAsyncNone("api/Common/InsertCommon", com);
            }

            MessageBox.Show(msg.ResultMessage);
            if (msg.IsSuccess)
            {
                //btnSearch.PerformClick();
            }
            this.Close();

            
            
        }

        private async void PopupCommon_Load(object sender, EventArgs e)
        {
            com = null;
            com = await srv.GetListAsync($"api/Common/Commons", com);

            var cCategory = com.Select(x => x.CCATEGORY).Distinct();
            cboComGroup.DataSource = cCategory.ToList();

            if (update)
            {
                txtComCode.Text = cItem.CCODE;
                txtComName.Text = cItem.CNAME;
                cboComGroup.SelectedItem = cItem.CCATEGORY;
            }
        }

    }
}
