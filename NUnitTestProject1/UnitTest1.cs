using ConsoleApp1.Model;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Diagnostics;

namespace NUnitTestProject1
{
    public class Tests
    {

        public List<CMM_RESOURCE> resourceList = new List<CMM_RESOURCE>()
        {
            new CMM_RESOURCE {CRS_ID=1, CRS_NAME="Xi Zhitang", CRS_ENTERPRISE_ID="zhitang.xi", CRS_STATUS="O",CRS_LEVEL_ID=1},
            new CMM_RESOURCE {CRS_ID=2, CRS_NAME="Zhang San", CRS_ENTERPRISE_ID="san.zhang", CRS_STATUS="R",CRS_LEVEL_ID=3},
            new CMM_RESOURCE {CRS_ID=3, CRS_NAME="Li Si",  CRS_ENTERPRISE_ID="si.li", CRS_STATUS="O",CRS_LEVEL_ID=2},
            new CMM_RESOURCE {CRS_ID=4, CRS_NAME="Wang Wu", CRS_ENTERPRISE_ID="wu.wang", CRS_STATUS="R",CRS_LEVEL_ID=1},
            new CMM_RESOURCE {CRS_ID=5, CRS_NAME="Sun Liu", CRS_ENTERPRISE_ID="liu.sun", CRS_STATUS="O",CRS_LEVEL_ID=3}

        };

        public List<CMM_RESOURCE_SKILLS_MAPPING> rsmList = new List<CMM_RESOURCE_SKILLS_MAPPING>()
        {

        };

        public List<CMM_SKILL_INVENTORY_MASTER> csimList = new List<CMM_SKILL_INVENTORY_MASTER>()
        {

        };


        [Test]
        public void Test1()
        {
            // 查询 EID 为 zhitang.xi 的 resource  分别写出 查询语法和方法语法
            var q1 = from resource in resourceList
                     where resource.CRS_ENTERPRISE_ID == "zhitang.xi"   //此行填空
                     select resource;
            var q11 = resourceList.Where(i => i.CRS_ENTERPRISE_ID.Equals("zhitang.xi"));
            //q1数据类型？ 如何获得此结果的resource对象 CMM_RESOURCE r = q1._______
            CMM_RESOURCE r = q1.FirstOrDefault();

        }

        [Test]
        public void Test2()
        {
            //查询 crs_status为 O 的 resources  分别写出 查询语法和方法语法
            var q2 = from resource in resourceList
                     where resource.CRS_STATUS.Equals("O")  //此行填空
                     select resource;
            var q22 = resourceList.Where(i => i.CRS_STATUS.Equals("O"));
            //q2数据类型？ 如何获得此结果的resource 集合(list)     List<CMM_RESOURCE> r = q2.________
            List<CMM_RESOURCE> r = q2.ToList();

        }

        [Test]
        public void Test3()
        {
            // 按 CRS_LEVEL_ID 分组  分别写出 查询语法和方法语法
            var q3 = from resouce in resourceList
                     group resouce by resouce.CRS_LEVEL_ID;

            var q33 = resourceList.GroupBy(i => i.CRS_LEVEL_ID);

            // 下列代码打印结果
            foreach(var q in q3)
            {
                Debug.WriteLine(q.Key);
                foreach (var re in q)
                {
                    Debug.WriteLine($"\t{re.CRS_ENTERPRISE_ID}");
                }
            }

            foreach (var q in q33)
            {
                Debug.WriteLine(q.Key);
                foreach (var re in q)
                {
                    Debug.WriteLine($"\t{re.CRS_ENTERPRISE_ID}");
                }
            }
            //1
            //	zhitang.xi
            //	wu.wang
            //3
            //	san.zhang
            //	liu.sun
            //2
            //	si.li
        }

        [Test]
        public void Test4()
        {
            //内联查询 san.zhang的所有  结果返回skill name(L5 SKILL NAME) 的list集合
            var q4 = from crs in resourceList
                     join rsm in rsmList on crs.CRS_ID equals rsm.CRSS_RS_ID
                     join csim in csimList on rsm.CRSS_CSIM_ID equals csim.CSIM_ID
                     where crs.CRS_ENTERPRISE_ID.Equals("san.zhang")
                     select csim.CSIM_NAME;
            var skillNameList = q4.ToList();

        }

        [Test]
        public void Test5()
        {
            //查询 最大的crs_level_id
            var maxLevel = resourceList.Max(i => i.CRS_LEVEL_ID);

            //查询 crs_status为O的人数
            var count = resourceList.Where(i => i.CRS_STATUS == "O").Count();

        }

        public delegate bool Comparison<in T>(T left, T right);

        public bool f1(int a, string b) { return b.Length > a; }
        public int f2(string a, string b) { return a.Length + b.Length; }
        public bool f3(string a, string b) { return a.Length == b.Length; }
        public bool f4(int a, int b) { return a == b; }

        [Test]
        public void Test6()
        {
            Comparison<string> c;
            //以下哪个绑定正确
            //c += f1;
            //c += f2;
            //c += f3;
            //c += f4;
        }

        public Func<CMM_RESOURCE, bool> d1;

        [Test]
        public void Test7()
        {
            //一下那些调用正确
            var list = new List<string>();
            var str = "1";
            //var a = list.WhereDemo(i => i == "1");
            //var b = str.WhereDemo(i => i == "1");
            //var c = resourceList.WhereDemo(i => i.CRS_ID);
            //d1 += Predicate;
            //var d = resourceList.WhereDemo(d1);

        }

        public bool Predicate(CMM_RESOURCE crs)
        {
            return crs.CRS_LEVEL_ID == 1;
        }

    }
    public static class DemoExtention
    {
        public static IEnumerable<TSource> WhereDemo<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            foreach (var item in source)
            {
                if (predicate(item)) yield return item;
            }
        }
    }
}