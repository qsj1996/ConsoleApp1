using ConsoleApp1.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var resourceList = new List<CMM_RESOURCE>();
            // 查询 EID 为 zhitang.xi 的 resource
            var q1 = from resource in resourceList
                     where resource.CRS_ENTERPRISE_ID == "zhitang.xi"   //填空
                     select resource;
            //q1数据类型？ 如何获得此结果的resource对象 CMM_RESOURCE r = q1._______
            CMM_RESOURCE r = q1.FirstOrDefault();



        }

    }


}
