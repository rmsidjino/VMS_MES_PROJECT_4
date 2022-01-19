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
    public partial class frmEqpGantt : Form
    {
        public frmEqpGantt()
        {
            InitializeComponent();
        }

        private void frmWebView_Load(object sender, EventArgs e)
        {
            webView1.Navigate("https://vmsweb.azurewebsites.net/Gantt/WinformGanttEqp");
            webView1.Size = this.ClientSize;

        }
    }
}
