using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MESDTO
{
    public class ProductVO
    {
        public string PRODUCT_ID { get; set; }
        public string PRODUCT_TYPE { get; set; }
        public string PRODUCT_NAME { get; set; }
        public string PROCESS_ID { get; set; }
        public int LOT_SIZE { get; set; }
        public int INPUT_BATCH_SIZE { get; set; }
        public string MODIFIER { get; set; }
        public DateTime MODIFIER_DATE{ get; set; }
    }
}
