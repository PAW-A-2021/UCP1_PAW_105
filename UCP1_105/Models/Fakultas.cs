using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UCP1_105.Models
{
    public partial class Fakultas
    {
        public Fakultas()
        {
            Universitas = new HashSet<Universitas>();
        }

        public string IdFakultas { get; set; }
        public string NamaFakultas { get; set; }

        public virtual ICollection<Universitas> Universitas { get; set; }
    }
}
