using System.Collections.Generic;
using NLayered.Contracts.DataTransferObjects;

#nullable disable

namespace NLayered.Contracts.Models
{
    public partial class Dokument
    {
        public Dokument()
        {
            Stavkas = new HashSet<Stavka>();
        }

        public int Id { get; set; }
        public string Vrsta { get; set; }
        public int? Broj { get; set; }
        public int PartnerId { get; set; }

        public virtual Partner Partner { get; set; }
        public virtual ICollection<Stavka> Stavkas { get; set; }

        public static Dokument FromDto(DokumentDto dokument)
        {
            var dok = new Dokument
            {
                PartnerId = dokument.PartnerId,
                Vrsta = dokument.Vrsta,
                Broj = dokument.Broj,
                Id = dokument.Id,
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
                PartnerId = dokument.PartnerId,
                Vrsta = dokument.Vrsta,
                Broj = dokument.Broj,
                Id = dokument.Id,
                Stavkas = new List<StavkaDto>(),
            };

            foreach (var stavka in dokument.Stavkas)
            {
                dok.Stavkas.Add(
                    Stavka.ToDto(stavka));
            }

            return dok;
        }
    }
}
