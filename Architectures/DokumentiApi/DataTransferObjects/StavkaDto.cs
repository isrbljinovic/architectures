namespace DokumentiApi.DataTransferObjects
{
    public class StavkaDto
    {
        public int IdStavke { get; set; }
        public int DokumentId { get; set; }
        public int ArtiklId { get; set; }
        public string NazivArtikla { get; set; }
        public double? Kolicina { get; set; }
    }
}
