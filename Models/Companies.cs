using System;
using System.Collections.Generic;

namespace TestWebApp2.Models
{
    public partial class Companies
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int OwnerId { get; set; }

        public Owners Owner { get; set; }
    }
}
