using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UCP1_105.Models
{
    public partial class Mahasiswa
    {
        public string IdMahasiswa { get; set; }
        public string NamaMahasiswa { get; set; }
        public string NimMahasiswa { get; set; }
        public string IdUniv { get; set; }

        public virtual Universitas IdUnivNavigation { get; set; }
    }
}
