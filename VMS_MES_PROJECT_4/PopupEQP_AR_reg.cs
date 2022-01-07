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
       
       
    }
}
