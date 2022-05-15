using System.Collections.Generic;

#nullable disable

namespace NLayered.Contracts.Models
{
    public partial class Artikl
    {
        public Artikl()
        {
            Stavkas = new HashSet<Stavka>();
        }

        public int Sifra { get; set; }
        public string Naziv { get; set; }
        public decimal? Cijena { get; set; }
        public string JedinicaMjere { get; set; }

        public virtual ICollection<Stavka> Stavkas { get; set; }
    }
}
