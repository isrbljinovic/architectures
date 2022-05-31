using DokumentiApi.DataTransferObjects;

#nullable disable

namespace DokumentiApi.Models
{
    public partial class Dokument
    {
        public int Id { get; set; }
        public string Vrsta { get; set; }
        public int? Broj { get; set; }
        public int IdPartner { get; set; }

        public static Dokument FromDto(DokumentDto dokument)
        {
            var dok = new Dokument
            {
                IdPartner = dokument.PartnerId,
                Vrsta = dokument.Vrsta,
                Broj = dokument.Broj,
                Id = dokument.Id,
            };

            return dok;
        }

        public static DokumentDto ToDto(Dokument dokument)
        {
            var dok = new DokumentDto
            {
                PartnerId = dokument.IdPartner,
                Vrsta = dokument.Vrsta,
                Broj = dokument.Broj,
                Id = dokument.Id,
            };

            return dok;
        }
    }
}
