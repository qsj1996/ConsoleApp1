using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Model
{
    public class CMM_SKILL_INVENTORY_MASTER
    {
        public int CSIM_ID { get; set; }
        public string CSIM_NAME { get; set; }
        public short CSIM_CSLM_ID { get; set; }
        public int? CSIM_PARENT_ID { get; set; }
        public string CSIM_ISACTIVE { get; set; }
        public string CSIM_BUSINESS_GRP { get; set; }
    }
}
