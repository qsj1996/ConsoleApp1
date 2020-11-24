using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Model
{
    public class CMM_RESOURCE_SKILLS_MAPPING
    {
        public long CRSS_ID { get; set; }
        public long CRSS_RS_ID { get; set; }
        public int? CRSS_CSIM_ID { get; set; }
        public short? CRSS_CSLM_ID { get; set; }
        public string CRSS_RS_SKILL_TYPE { get; set; }
    }
}
