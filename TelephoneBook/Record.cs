using System;

namespace TelephoneBook
{
    class Record
    {
        public string Name { get; set; }
        public int Phone { get; set; }
        public DateTime BDay { get; set; }
        public string ImageUri { get; set; }
        public string Note { get; set; }
        public int Id { get; set; }
    }
}
