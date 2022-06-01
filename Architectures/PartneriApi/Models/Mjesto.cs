using System;
using System.Collections.Generic;

#nullable disable

namespace PartneriApi.Models
{
    public partial class Mjesto
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string OznakaDrzava { get; set; }

        public virtual Partner Partner { get; set; }
    }
}
