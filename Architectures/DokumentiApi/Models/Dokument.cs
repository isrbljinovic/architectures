using DokumentiApi.DataTransferObjects;
using System.Collections.Generic;
using System.Linq;

#nullable disable

namespace DokumentiApi.Models
{
    public partial class Dokument
    {
        public Dokument()
        {
            Stavkas = new HashSet<Stavka>();
        }

        public int IdDokumenta { get; set; }
        public string Naziv { get; set; }
        public int? Broj { get; set; }
        public int? PartnerId { get; set; }

        public virtual ICollection<Stavka> Stavkas { get; set; }

        public static Dokument FromDto(DokumentDto dokument)
        {
            var dok = new Dokument
            {
                PartnerId = dokument.PartnerId,
                Naziv = dokument.Naziv,
                Broj = dokument.Broj,
                IdDokumenta = dokument.IdDokumenta,
                Stavkas = new List<Stavka>(),
            };

            foreach (var stavka in dokument.Stavkas)
            {
                dok.Stavkas.Add(
                    Stavka.FromDto(stavka));
            }

            return dok;
        }

        public static DokumentDto ToDto(Dokument dokument)
        {
            var dok = new DokumentDto
            {
                PartnerId = dokument.PartnerId.HasValue ? dokument.PartnerId.Value : 0,
                Naziv = dokument.Naziv,
                Broj = dokument.Broj,
                IdDokumenta = dokument.IdDokumenta,
                Stavkas = new List<StavkaDto>(),
            };

            foreach (var stavka in dokument.Stavkas)
            {
                dok.Stavkas.Add(
                    Stavka.ToDto(stavka));
            }

            return dok;
        }

        public static void Map(DokumentDto from, Dokument to)
        {
            to.Naziv = from.Naziv;

            foreach (var stavka in from.Stavkas)
            {
                to.Stavkas.Where(x => x.IdStavke == stavka.IdStavke).First().Kolicina = stavka.Kolicina;
            }
        }
    }
}
