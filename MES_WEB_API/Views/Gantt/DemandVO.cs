using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MESDTO
{
    public class DemandVO
    {
        public string DEMAND_VER { get; set; }
        public string DEMAND_ID { get; set; }
        public string PRODUCT_ID { get; set; }
        public string CUSTOMER_ID { get; set; }
        public DateTime DUE_DATE { get; set; }
        public int DEMAND_QTY { get; set; }
        public string MODIFIER { get; set; }
        public DateTime MODIFIER_DATE { get; set; }
    }
}