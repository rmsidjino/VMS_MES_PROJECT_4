using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MESDTO
{
    public class SetupVO
    {
        public string SITE_ID { get; set; }
        public string LINE_ID { get; set; }
        public string EQP_GROUP { get; set; }
        public string STEP_ID { get; set; }
        public int TIME { get; set; }
        public string MODIFIER { get; set; }
        public DateTime MODIFIED_DATE{ get; set; }
    }
}
