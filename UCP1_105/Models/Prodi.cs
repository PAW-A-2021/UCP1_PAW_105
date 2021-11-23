using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UCP1_105.Models
{
    public partial class Prodi
    {
        public Prodi()
        {
            Universitas = new HashSet<Universitas>();
        }

        public string IdProdi { get; set; }
        public string NamaProdi { get; set; }
        public string IdMatkul { get; set; }

        public virtual MataKuliah IdMatkulNavigation { get; set; }
        public virtual ICollection<Universitas> Universitas { get; set; }
    }
}
