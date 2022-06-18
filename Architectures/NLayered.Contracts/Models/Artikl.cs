using NLayered.Contracts.DataTransferObjects;
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

        public static ArtiklDto ToDto(Artikl artikl)
        {
            return new ArtiklDto
            {
                Sifra = artikl.Sifra,
                Naziv = artikl.Naziv,
                Cijena = artikl.Cijena,
                JedinicaMjere = artikl.JedinicaMjere
            };
        }

        public static Artikl FromDto(ArtiklDto artiklDto)
        {
            return new Artikl
            {
                Naziv = artiklDto.Naziv,
                Cijena = artiklDto.Cijena,
                JedinicaMjere = artiklDto.JedinicaMjere
            };
        }
    }
}
