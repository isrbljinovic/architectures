using System.Collections.Generic;

#nullable disable

namespace NLayered.Contracts.Models
{
    public partial class Mjesto
    {
        public Mjesto()
        {
            Partners = new HashSet<Partner>();
        }

        public int Id { get; set; }
        public string OznakaDrzave { get; set; }
        public string Naziv { get; set; }

        public virtual Drzava OznakaDrzaveNavigation { get; set; }
        public virtual ICollection<Partner> Partners { get; set; }
    }
}
