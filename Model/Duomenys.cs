using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registras.Model
{
    public class Duomenys
    {
        public string Imone { get; set; }
        public string Adresas { get; set; }
        public string Vardas { get; set; }
        public string Pavarde { get; set; }
        public string Pareigos { get; set; }
        public string TaikytasMetodas { get; set; }
        public string NaudotaIranga { get; set; }
        public string Padalinys { get; set; }
        public Doze Dozes { get; set; }
        public int IDkodas { get; set; }

        public Duomenys(string imone, string adresas, string vardas, string pavarde, string pareigos, string taikMetodas, string naudotaIranga, string padalinys, Doze d, int id)
        {
            this.Imone = imone;
            this.Adresas = adresas;
            this.Vardas = vardas;
            this.Pavarde = pavarde;
            this.Pareigos = pareigos;
            this.TaikytasMetodas = taikMetodas;
            this.NaudotaIranga = naudotaIranga;
            this.Padalinys = padalinys;
            this.Dozes = d;
            this.IDkodas = id;
        }


    }
}
