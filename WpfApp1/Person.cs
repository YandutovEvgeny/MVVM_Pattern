using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class Person
    {
        public string Name { get; set; }
        public long Tel { get; set; }
        public DateTime Bday { get; set; }
        public Person(string name, long tel, DateTime bday)
        {
            Name = name;
            Tel = tel;
            Bday = bday;
        }
    }
}
