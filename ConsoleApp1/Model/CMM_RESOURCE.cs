using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Model
{

    public class CMM_RESOURCE
    {
        public long CRS_ID { get; set; }
        public string? CRS_NAME { get; set; }
        public string CRS_ENTERPRISE_ID { get; set; }
        public long CRS_LEVEL_ID { get; set; }
        public string CRS_STATUS { get; set; }
    }
}
