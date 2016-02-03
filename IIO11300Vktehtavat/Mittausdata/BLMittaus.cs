using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT.IIO11300
{
    [Serializable()]
    public class MittausData
    {
        private string klo;

        public string Kello
        {
            get { return klo; }
            set { klo = value; }
        }

        private string mittaus;

        public string Mittaus
        {
            get { return mittaus; }
            set { mittaus = value; }
        }
        public String DataMuoto
        {
            get { return Kello + ";" + mittaus; }
        }
        #region CONSTRUCTORS
        //luokalle tehdään kaksi konstruktoria 
        public MittausData()
        {
            klo = "0:00";
            mittaus = "empty";
        }
        public MittausData(string klo, string mdata)
        {
            this.klo = klo;
            this.mittaus = mdata;
        }
        #endregion
        // ylikirjoitetaan ToString
        public override string ToString()
        {
            //return base.ToString();
            return Kello + " = " + mittaus;
        }
        #region METHODS
        public static void SaveDataToFile(List<MittausData> dataa, string filu) 
        {
            // kirjoitetaan data tiedostoon, jos tiedosto on jo olemassa liitetään se olemassa olevaan
            try
            {
                //tutkitaan onko tiedosto olemassa
                if(!System.IO.File.Exists(filu))
                {
                    // luodaan uusi
                    using(StreamWriter sw = File.CreateText(filu))
                    {
                        // Käydään kokoelma läpi ja kirjoitetaan kukin mittausdata omalle riville
                        foreach (var item in dataa)
                        {
                            sw.WriteLine(item.DataMuoto);
                        }
                    }
                } else
                {
                    // Lisätään olemassa olevaan tiedostoon
                    using (StreamWriter sw = File.AppendText(filu))
                    {
                        foreach(var item in dataa)
                        {
                            sw.WriteLine(item.DataMuoto);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static List<MittausData> ReadDataFromFile(string filu)
        {
            // luetaan käyttäjän antamasta tiedostosta tekstirivejä ja muutetaan ne mittausdataksi
            try
            {
                //tutkitaan onko tiedosto olemassa
                if (File.Exists(filu))
                {
                    using (StreamReader sr = File.OpenText(filu))
                    {
                        MittausData md;
                        List<MittausData> luetut = new List<MittausData>();
                        string rivi = "";
                        while ((rivi = sr.ReadLine()) != null)
                        {
                           //tutkitaan löytyykö sovittu erotinmerkki ; --> etupuolella on kellonaika ja jälkeen mittausarvo
                           if ((rivi.Length > 3) && rivi.Contains(";"))
                            {
                                string[] split = rivi.Split(new char[] { ';' });
                                // Luodaan tekstinpätkistä olio
                                md = new MittausData(split[0], split[1]);
                                luetut.Add(md);
                            }
                        }
                        // palautetaan
                        return luetut;
                    }
                }
                else
                {
                    throw new FileNotFoundException();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}
