namespace DokumentiApi.DataTransferObjects
{
    public class DokumentDto
    {
        public int Id { get; set; }
        public string Vrsta { get; set; }
        public int? Broj { get; set; }
        public int PartnerId { get; set; }   
    }
}
