using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class IndexerDemo
    {
        public string Name{ get; set; }
        public string Password { get; set; }
        public string this[int index]
        {
            get
            {
                if (index == 0) return Name;
                else if (index == 1) return Password;
                else if (index == 2) return Password;
                else return null;
            }
            set
            {
                if (index == 0) Name = value;
                else if (index == 1) Password = value;
            }
        }
        public int this[string key]
        {
            get { return 1; }
            set { Password = value.ToString(); }
        }
    }
}

