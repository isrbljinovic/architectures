#nullable disable

using ArtikliApi.DataTransferObjects;

namespace ArtikliApi.Models
{
    public partial class Artikl
    {
        public int Sifra { get; set; }
        public string Naziv { get; set; }
        public string JedinicaMjere { get; set; }
        public decimal? Cijena { get; set; }

        public static Artikl FromDto(ArtiklDto artikl)
        {
            return new Artikl
            {
                Sifra = artikl.Sifra,
                Naziv = artikl.Naziv,
                JedinicaMjere = artikl.JedinicaMjere,
                Cijena = artikl.Cijena
            };
        }

        public static ArtiklDto ToDto(Artikl artikl)
        {
            return new ArtiklDto
            {
                Sifra = artikl.Sifra,
                Naziv = artikl.Naziv,
                JedinicaMjere = artikl.JedinicaMjere,
                Cijena = artikl.Cijena.HasValue ? artikl.Cijena.Value : 0
            };
        }
    }
}
