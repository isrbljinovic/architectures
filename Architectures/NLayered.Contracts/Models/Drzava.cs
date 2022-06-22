using System.Collections.Generic;

#nullable disable

namespace NLayered.Contracts.Models
{
    public partial class Drzava
    {
        public Drzava()
        {
            Mjestos = new HashSet<Mjesto>();
        }

        public string IdDrzave { get; set; }
        public string Naziv { get; set; }
        public int Sifra { get; set; }

        public virtual ICollection<Mjesto> Mjestos { get; set; }
    }
}
