using System.Collections.Generic;

namespace NLayered.Contracts.DataTransferObjects
{
    public class DokumentDto
    {
        public int IdDokumenta { get; set; }
        public string Vrsta { get; set; }
        public int? Broj { get; set; }
        public int PartnerId { get; set; }
        public string NazivPartnera { get; set; }

        public virtual List<StavkaDto> Stavkas { get; set; }
    }
}
