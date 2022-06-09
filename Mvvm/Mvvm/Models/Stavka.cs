namespace Mvvm.Models
{
    public class Stavka
	{
        public int Id { get; set; }
        public int DokumentId { get; set; }
        public int SifraArtikla { get; set; }
        public string NazivArtikla { get; set; }
        public double? Kolicina { get; set; }
        public string JedinicaMjere { get; set; } = "kom";
    }
}

