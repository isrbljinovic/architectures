#nullable disable

using PartneriApi.DataTransferObjects;

namespace PartneriApi.Models
{
    public partial class Partner
    {
        public int IdPartnera { get; set; }
        public string Naziv { get; set; }
        public int MjestoId { get; set; }

        public virtual Mjesto IdMjestaNavigation { get; set; }

        public static Partner FromDto(PartnerDto partner)
        {
            var p = new Partner
            {
                IdPartnera = partner.IdPartnera,
                Naziv = partner.Naziv,
                MjestoId = partner.MjestoId,
            };

            return p;
        }

        public static PartnerDto ToDto(Partner partner)
        {
            var p = new PartnerDto
            {
                IdPartnera = partner.IdPartnera,
                Naziv = partner.Naziv,
                MjestoId = partner.MjestoId,
                NazivMjesta = partner.IdMjestaNavigation.Naziv
            };

            return p;
        }
    }
}
