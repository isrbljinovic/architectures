using System.Collections.Generic;

namespace DokumentiApi.DataTransferObjects
{
    public class DokumentDto
    {
        public int IdDokumenta { get; set; }
        public string Naziv { get; set; }
        public int? Broj { get; set; }
        public int PartnerId { get; set; }
        public string PartnerNaziv { get; set; }

        public virtual List<StavkaDto> Stavkas { get; set; }
    }
}
