#nullable disable

using ArtikliApi.DataTransferObjects;

namespace ArtikliApi.Models
{
    public partial class Artikl
    {
        public int IdArtikla { get; set; }
        public string Naziv { get; set; }
        public string JedinicaMjere { get; set; }
        public decimal? Cijena { get; set; }

        public static Artikl FromDto(ArtiklDto artikl)
        {
            return new Artikl
            {
                IdArtikla = artikl.IdArtikla,
                Naziv = artikl.Naziv,
                JedinicaMjere = artikl.JedinicaMjere,
                Cijena = artikl.Cijena
            };
        }

        public static ArtiklDto ToDto(Artikl artikl)
        {
            return new ArtiklDto
            {
                IdArtikla = artikl.IdArtikla,
                Naziv = artikl.Naziv,
                JedinicaMjere = artikl.JedinicaMjere,
                Cijena = artikl.Cijena.HasValue ? artikl.Cijena.Value : 0
            };
        }
    }
}
