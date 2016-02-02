using System;
using System.Collections.Generic;
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
    }
}
