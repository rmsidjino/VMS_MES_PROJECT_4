using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MESDTO
{
    public class StepRouteVO
    {
        public string PROCESS_ID { get; set; }
        public string STEP_ID { get; set; }
        public int STEP_SEQ { get; set; }
        public string STD_STEP_ID { get; set; }
        public string STEP_TYPE { get; set; }
        public string PROCESS_TYPE { get; set; }
        public int IN_STOCK { get; set; }
        public int OUT_STOCK { get; set; }
        public string MODIFIER { get; set; }
        public DateTime MODIFIER_DATE { get; set; }
    }
}
