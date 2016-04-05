using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMLiigaEF
{
    public partial class Pelaajat
    {
        public string Kokonimi
        {
            get { return this.etunimi + " " + this.sukunimi + "@" + this.seura; }
        }
    }
}
