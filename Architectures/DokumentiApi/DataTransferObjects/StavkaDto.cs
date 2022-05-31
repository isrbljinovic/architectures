namespace DokumentiApi.DataTransferObjects
{
    public class StavkaDto
    {
        public int Id { get; set; }
        public int DokumentId { get; set; }
        public int SifraArtikla { get; set; }
        public double? Kolicina { get; set; }
    }
}
