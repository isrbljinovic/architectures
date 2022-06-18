﻿using NLayered.Contracts.DataTransferObjects;
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

        public int Id { get; set; }
        public string Naziv { get; set; }
        public int? Sjediste { get; set; }

        public virtual Mjesto SjedisteNavigation { get; set; }
        public virtual ICollection<Dokument> Dokuments { get; set; }

        public static PartnerDto ToDto(Partner partner)
        {
            return new PartnerDto
            {
                Id = partner.Id,
                Naziv = partner.Naziv,
                Sjediste = partner.SjedisteNavigation.Id
            };
        }

        public static Partner FromDto(PartnerDto partnerDto)
        {
            return new Partner
            {
                Id = partnerDto.Id,
                Naziv = partnerDto.Naziv,
                Sjediste = partnerDto.Sjediste
            };
        }
    }
}
