using NLayered.Contracts.DataTransferObjects;
using System.Collections.Generic;

#nullable disable

namespace NLayered.Contracts.Models
{
    public partial class Partner
    {
        public Partner()
        {
            Dokuments = new HashSet<Dokument>();
        }

        public int IdPartnera { get; set; }
        public string Naziv { get; set; }
        public int? Sjediste { get; set; }

        public virtual Mjesto SjedisteNavigation { get; set; }
        public virtual ICollection<Dokument> Dokuments { get; set; }

        public static PartnerDto ToDto(Partner partner)
        {
            return new PartnerDto
            {
                IdPartnera = partner.IdPartnera,
                Naziv = partner.Naziv,
                Sjediste = partner.SjedisteNavigation.IdMjesto,
                NazivSjedista = partner.SjedisteNavigation.Naziv,
            };
        }

        public static Partner FromDto(PartnerDto partnerDto)
        {
            return new Partner
            {
                IdPartnera = partnerDto.IdPartnera,
                Naziv = partnerDto.Naziv,
                Sjediste = partnerDto.Sjediste
            };
        }
    }
}
