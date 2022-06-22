#nullable disable

namespace PartneriApi.Models
{
    public partial class Mjesto
    {
        public int IdMjesta { get; set; }
        public string Naziv { get; set; }
        public string DrzavaId { get; set; }

        public virtual Partner Partner { get; set; }
    }
}
