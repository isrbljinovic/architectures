#nullable disable

using PartneriApi.DataTransferObjects;

namespace PartneriApi.Models
{
    public partial class Partner
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public int MjestoId { get; set; }

        public virtual Mjesto IdMjestaNavigation { get; set; }

        public static Partner FromDto(PartnerDto partner)
        {
            var p = new Partner
            {
                Id = partner.Id,
                Naziv = partner.Naziv,
                MjestoId = partner.IdMjesta,
            };

            return p;
        }

        public static PartnerDto ToDto(Partner partner)
        {
            var p = new PartnerDto
            {
                Id = partner.Id,
                Naziv = partner.Naziv,
                IdMjesta = partner.MjestoId,
                NazivMjesta = partner.IdMjestaNavigation.Naziv
            };

            return p;
        }
    }
}
