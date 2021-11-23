using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UCP1_105.Models
{
    public partial class MataKuliah
    {
        public MataKuliah()
        {
            Prodi = new HashSet<Prodi>();
        }

        public string IdMatkul { get; set; }
        public string NamaMatkul { get; set; }
        public string KodeMatkul { get; set; }

        public virtual ICollection<Prodi> Prodi { get; set; }
    }
}
