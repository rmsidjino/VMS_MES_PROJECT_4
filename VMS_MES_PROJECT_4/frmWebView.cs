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
    public partial class frmWebView : Form
    {
        public frmWebView()
        {
            InitializeComponent();
        }

        private void frmWebView_Load(object sender, EventArgs e)
        {
            webView1.Navigate("http://vmsweb.azurewebsites.net/Gantt/Index");
        }
    }
}
