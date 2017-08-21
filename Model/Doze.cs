using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registras.Model
{
    public class Doze
    {
        public DateTime NesiojimoPradziosData { get; set; }
        public DateTime NesiojimoPabaigosData { get; set; }
        public string DozimetroNr { get; set; }
        public double GautaDoze { get; set; }
        public string NesiojimoVieta { get; set; }
        public double EfektineDoze { get; set; }

        public Doze(DateTime pradziosData, DateTime pabaigosData, string dozimetroNr, double gautaDoze, string nesiojimoVieta, double efektineDoze)
        {
            this.NesiojimoPradziosData = pradziosData;
            this.NesiojimoPabaigosData = pabaigosData;
            this.DozimetroNr = dozimetroNr;
            this.GautaDoze = gautaDoze;
            this.NesiojimoVieta = nesiojimoVieta;
            this.EfektineDoze = efektineDoze;
        }
    }
}
