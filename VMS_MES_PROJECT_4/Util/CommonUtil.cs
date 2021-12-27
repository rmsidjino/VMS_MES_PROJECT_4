using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MESDTO;

namespace VMS_MES_PROJECT_4
{ 
    class CommonUtil
    {
        public static void ComboBinding(ComboBox cbo, List<CommonVO> list, string gubun,
            bool blankItem = true, string blankText = "")
        {
            var codeList = list.Where((item) => item.CCATEGORY.Equals(gubun)).ToList();
            if (blankItem)
            {
                CommonVO blank = new CommonVO
                {
                    CCODE = "",
                    CNAME = blankText,
                    CCATEGORY = gubun
                };
                codeList.Insert(0, blank);
            }

            cbo.DisplayMember = "CNAME";
            cbo.ValueMember = "CCODE";
            cbo.DataSource = codeList;
        }
    }
}
