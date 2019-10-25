using System;
using System.Collections.Generic;

namespace TestWebApp2.Models
{
    public partial class Owners
    {
        public Owners()
        {
            Companies = new HashSet<Companies>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public ICollection<Companies> Companies { get; set; }
    }
}
