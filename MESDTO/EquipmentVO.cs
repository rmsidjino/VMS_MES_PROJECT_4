using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MESDTO
{
    public class EquipmentVO
    {
        public string SITE_ID { get; set; }
        public string LINE_ID { get; set; }
        public string EQP_ID { get; set; }
        public string EQP_MODEL { get; set; }
        public string EQP_TYPE { get; set; }
        public string EQP_GROUP { get; set; }
        public string SIM_TYPE { get; set; }
        public string PRESET_ID { get; set; }
        public string DISPATCHER_ID { get; set; }
        public string EQP_STATE { get; set; }
        public int EQP_STATE_CODE { get; set; }
        public DateTime STATE_CHANGE_TIME { get; set; }
        public string AUTOMATION { get; set; }
        public string MODIFIER { get; set; }
        public DateTime MODIFIER_DATE { get; set; }

    }
}