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

        public int IdMjesto { get; set; }
        public string DrzavaId { get; set; }
        public string Naziv { get; set; }

        public virtual Drzava OznakaDrzaveNavigation { get; set; }
        public virtual ICollection<Partner> Partners { get; set; }
    }
}
