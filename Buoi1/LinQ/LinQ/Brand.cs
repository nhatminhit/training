using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQ
{
    class Brand
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public Brand()
        {
            ID = 0;
            Name = "Default Name";
        }

        public Brand(int iD, string name)
        {
            ID = iD;
            Name = name;
        }
    }
}