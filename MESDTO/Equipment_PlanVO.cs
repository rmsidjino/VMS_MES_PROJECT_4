using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MESDTO
{
    public  class Equipment_PlanVO
    {        
        public string VERSION_NO { get; set; }
        public string LINE_ID { get; set; }
        public string EQP_ID { get; set; }
        public string LOT_ID { get; set; }
        public string PRODUCT_ID { get; set; }
        public string PROCESS_ID { get; set; }
        public string STEP_ID { get; set; }
        public int PROCESS_QTY { get; set; }
        public DateTime DISPATCH_IN_TIME { get; set; }
        public DateTime START_TIME { get; set; }
        public DateTime END_TIME { get; set; }
        public string MACHINE_STATE { get; set; }
        public DateTime DUE_DATE { get; set; }
        public string MODIFIER { get; set; }
        public DateTime MODIFIER_DATE { get; set; }
    }
}
