using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MESDTO
{
    public class StdStepInfoVO
    {
        public string STD_STEP_ID { get; set; }
        public string STD_STEP_NAME { get; set; }
        public int STEP_TAT { get; set; }
        public int STEP_YIELD { get; set; }
        public int STEP_SETUP { get; set; }
        public string MODIFIER { get; set; }
        public DateTime MODIFIER_DATE { get; set; }
    }
}
