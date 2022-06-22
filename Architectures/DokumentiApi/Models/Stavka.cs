#nullable disable

using DokumentiApi.DataTransferObjects;

namespace DokumentiApi.Models
{
    public partial class Stavka
    {
        public int IdStavke { get; set; }
        public int DokumentId { get; set; }
        public int? ArtiklId { get; set; }
        public double? Kolicina { get; set; }

        public virtual Dokument Dokument { get; set; }

        public static Stavka FromDto(StavkaDto stavkaDto)
        {
            return new Stavka
            {
                DokumentId = stavkaDto.DokumentId,
                ArtiklId = stavkaDto.ArtiklId,
                Kolicina = stavkaDto.Kolicina,
                IdStavke = stavkaDto.IdStavke,
            };
        }

        public static StavkaDto ToDto(Stavka stavka)
        {
            return new StavkaDto
            {
                IdStavke = stavka.IdStavke,
                Kolicina = stavka.Kolicina,
                ArtiklId = stavka.ArtiklId.HasValue ? stavka.ArtiklId.Value : 0,
                DokumentId = stavka.DokumentId,
            };
        }

        public static void Update(Stavka stavka, StavkaDto stavkaDto)
        {
            stavka.IdStavke = stavkaDto.IdStavke;
            stavka.Kolicina = stavkaDto.Kolicina;
            stavka.ArtiklId = stavkaDto.ArtiklId;
            stavka.DokumentId = stavkaDto.DokumentId;
        }
    }
}
