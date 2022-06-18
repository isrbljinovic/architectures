using System.Collections.Generic;

namespace Mvvm.Models
{
    public class Dokument
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public int? Broj { get; set; }
        public int PartnerId { get; set; }
        public string PartnerNaziv { get; set; }

        public List<Stavka> Stavkas { get; set; }
    }
}