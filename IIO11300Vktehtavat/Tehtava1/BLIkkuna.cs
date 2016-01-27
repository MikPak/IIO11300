using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT.IIO11300
{
    class IkkunaVE0
    {
        // tehdään public, ÄLÄ käytä! Edustaa "huonoa" ohjelmointitapaa
        public double leveys;
        public double korkeus;
        public double LaskePintaala()
        {
            return leveys * korkeus;
        }
    }
    public class Ikkuna
    {
        //Properties
        //property = Ominaisuus
        //parempi tapa on avata "hallitusti" olio ominaisuuksien kautta
        private double korkeus;

        public double Korkeus
        {
            get { return korkeus; }
            set { korkeus = value; }
        }

        private double leveys;

        public double Leveys
        {
            get { return leveys; }
            set { leveys = value; }
        }
        //read-only tyyppinen property
        //Metodit
        public double PintaAla
        {
            get
            {
                return korkeus * leveys;
            }
        }
        public double LaskePintaAla()
        {
            //return korkeus * leveys;
            return LaskeIPintaala();
        }
        private double LaskeIPintaala()
        {
            return korkeus * leveys;
        }
    }
}
