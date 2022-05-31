#nullable disable

using DokumentiApi.DataTransferObjects;

namespace DokumentiApi.Models
{
    public partial class Stavka
    {
        public int Id { get; set; }
        public int DokumentId { get; set; }
        public int? SifraArtikla { get; set; }
        public double? Kolicina { get; set; }

        public virtual Dokument Dokument { get; set; }

        public static Stavka FromDto(StavkaDto stavkaDto)
        {
            return new Stavka
            {
                DokumentId = stavkaDto.DokumentId,
                SifraArtikla = stavkaDto.SifraArtikla,
                Kolicina = stavkaDto.Kolicina,
                Id = stavkaDto.Id,
            };
        }

        public static StavkaDto ToDto(Stavka stavka)
        {
            return new StavkaDto
            {
                Id = stavka.Id,
                Kolicina = stavka.Kolicina,
                SifraArtikla = stavka.SifraArtikla.HasValue ? stavka.SifraArtikla.Value : 0,
                DokumentId = stavka.DokumentId,
            };
        }

        public static void Update(Stavka stavka, StavkaDto stavkaDto)
        {
            stavka.Id = stavkaDto.Id;
            stavka.Kolicina = stavkaDto.Kolicina;
            stavka.SifraArtikla = stavkaDto.SifraArtikla;
            stavka.DokumentId = stavkaDto.DokumentId;
        }
    }
}
