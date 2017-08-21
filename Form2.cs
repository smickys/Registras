using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Registras
{
    public partial class Form2 : Form
    {
        List<string> explanationList = new List<string>();
        public Form2()
        {
            InitializeComponent();
            explanationList.Add("Virš padalinio pavadinimo, eilute aukščiau, turi būti parašyta \"Bandymo rezultatai: \".\n\n"
                              + "Faile yra norodyti daugiau negu du padalinio pavadinimai, arba ištrinkite padalinio pavadinimus,"
                              + " arba sudarykite kiekvienam padaliniui atskirą failą, arba padalinio pavadinimus įrašykite lentelės viduje,"
                              + " įterpiant eilutę ir suliejus visus stulpelius į vieną, eilutę įterpti virš reikiamų darbuotojų.\n\n");

            explanationList.Add("Patikrinti ar efektinė dozės reikšmė parašyta tik viena.\n\n"
                              + "Patikrinti ar po pavardės nėra paliktų tarpų.\n\n"
                              + "Patikrinti ar tarp vardo ir pavardės paliktas tarpas, o ne nauja eilutė (Enter).\n\n"
                              + "Vardas ir pavardė turi būti parašyti viename stulpelyje, o ne atskiruose.\nPvz: \"Vardenis Pavardenis\".\n\n"
                              + "Jeigu asmuo turi vieną vardą ir dvi pavardes, tada pavardes rašyti per brūkšnelį.\nPvz: \"Vardenis Pavardenis-Pavardenis\"\n\n"
                              + "Jeigu asmuo turi du vardus ir vieną pavardę, tada vardus ir pavardę rašyti palikus tarpą tarp jų.\nPvz: \"Vardenis Vardenis Pavardenis\"\n\n"
                              + "Jeigu asmuo turi du vardus ir dvi pavardes, tada vardus rašyti palikus tarpą tarp jų, o pavardes rašyti per brūkšnelį.\nPvz: \"Vardenis Vardenis Pavardenis-Pavardenis\"\n\n");

            explanationList.Add("Patikrinti ar vardai ir pavardės parašyti atitinkamai, t.y. nesukeisti vietomis");

            explanationList.Add("Faile skaičiuojasi visos lentelės, ne tik su darbuotojų duomenimis surašytos lentelės." 
                              + " Pamėginkite sujungti keletą darbuotojų duomenų lentelių į vieną");

            explanationList.Add("Patikrinti ar data, šalia Dozimetro nešiojimo periodo, parašyta be klaidų");

            explanationList.Add("Programa negali atidaryti failo skaitymui. Pamėginkite į naują, tuščią protokolo šabloną ranka perrašyti visus duomenis");
        }
        
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < explanationList.Count; i++)
            {
                if(listBox1.SelectedIndex == i)
                {
                    richTextBox1_explanation.Text = explanationList[i];
                }
            }
        }
    }
}
