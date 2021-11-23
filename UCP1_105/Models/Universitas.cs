using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UCP1_105.Models
{
    public partial class Universitas
    {
        public Universitas()
        {
            Mahasiswa = new HashSet<Mahasiswa>();
        }

        public string IdUniv { get; set; }
        public string NamaUniv { get; set; }
        public string IdFakultas { get; set; }
        public string IdProdi { get; set; }

        public virtual Fakultas IdFakultasNavigation { get; set; }
        public virtual Prodi IdProdiNavigation { get; set; }
        public virtual ICollection<Mahasiswa> Mahasiswa { get; set; }
    }
}
