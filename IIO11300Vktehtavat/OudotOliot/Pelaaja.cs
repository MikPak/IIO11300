using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.IO;

namespace OudotOliot
{
    public class Pelaaja
    {
        private string id, etunimi, sukunimi, kokonimi, esitysnimi, seura, siirtohinta;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Etunimi
        {
            get { return etunimi; }
            set { etunimi = value; }
        }

        public string Sukunimi
        {
            get { return sukunimi; }
            set { sukunimi = value; }
        }

        public string Kokonimi
        {
            get { return kokonimi; }
        }
        public string Esitysnimi
        {
            get { return esitysnimi; }
        }
        public string Siirtohinta
        {
            get { return siirtohinta; }
            set { siirtohinta = value; }
        }

        public string Seura
        {
            get { return seura; }
            set { seura = value; }
        }

        public Pelaaja()
        {

        }
        public Pelaaja(string id, string etunimi, string sukunimi, string seura, string siirtohinta)
        {
            this.id = id;
            this.etunimi = etunimi;
            this.sukunimi = sukunimi;
            this.kokonimi = etunimi + " " + sukunimi;
            this.esitysnimi = etunimi + " " + sukunimi + ", " + seura;
            this.seura = seura;
            this.siirtohinta = siirtohinta;
        }

        public static void SaveDataToFile(List<Pelaaja> dataa, string filu)
        {
            // kirjoitetaan data tiedostoon, jos tiedosto on jo olemassa liitetään se olemassa olevaan
            try
            {
                //tutkitaan onko tiedosto olemassa
                if (!System.IO.File.Exists(filu))
                {
                    // luodaan uusi
                    using (StreamWriter sw = File.CreateText(filu))
                    {
                        // Käydään kokoelma läpi ja kirjoitetaan kukin mittausdata omalle riville
                        foreach (var item in dataa)
                        {
                            sw.WriteLine(item);
                        }
                    }
                }
                else
                {
                    // Lisätään olemassa olevaan tiedostoon
                    using (StreamWriter sw = File.AppendText(filu))
                    {
                        foreach (var item in dataa)
                        {
                            sw.WriteLine(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
