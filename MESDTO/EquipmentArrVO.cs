using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MESDTO
{
    public class EquipmentArrVO
    {
        public string PRODUCT_ID { get; set; }
        public string PROCESS_ID { get; set; }
        public string STEP_ID { get; set; }
        public string EQP_ID { get; set; }
        public int TACT_TIME { get; set; }
        public int PROC_TIME { get; set; }
        public DateTime EFF_START_DATE { get; set; }
        public DateTime EFF_END_DATE { get; set; }
        public string MODIFIER { get; set; }
        public DateTime MODIFIER_DATE { get; set; }

    }
}
