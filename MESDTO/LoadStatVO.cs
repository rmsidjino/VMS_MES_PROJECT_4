using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MESDTO
{
    public class LoadStatVO
    {
        public string VERSION_NO { get; set; }
        public string LINE_ID { get; set; }
        public string EQP_ID { get; set; }
        public DateTime TARGET_DATE { get; set; }
        public decimal SETUP { get; set; }
        public decimal BUSY { get; set; }
        public decimal IDLERUN { get; set; }
        public decimal IDLE { get; set; }
        public decimal PM { get; set; }
        public decimal DOWN { get; set; }
        public string MODIFIER { get; set; }
        public DateTime MODIFIER_DATE { get; set; }
    }
}
