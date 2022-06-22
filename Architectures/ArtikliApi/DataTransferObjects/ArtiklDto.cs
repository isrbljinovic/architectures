namespace ArtikliApi.DataTransferObjects
{
    public class ArtiklDto
    {
        public int IdArtikla { get; set; }

        public string Naziv { get; set; }

        public string JedinicaMjere { get; set; }

        public decimal Cijena { get; set; }
    }
}
