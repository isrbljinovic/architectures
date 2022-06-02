using System.Collections.Generic;

namespace DokumentiApi.DataTransferObjects
{
    public class DokumentDto
    {
        public int Id { get; set; }
        public string Vrsta { get; set; }
        public int? Broj { get; set; }
        public int PartnerId { get; set; }
        public string PartnerNaziv { get; set; }

        public virtual List<StavkaDto> Stavkas { get; set; }
    }
}
