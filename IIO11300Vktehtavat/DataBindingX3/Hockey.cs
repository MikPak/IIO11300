using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBindingX3
{
    public class HockeyPlayer : INotifyPropertyChanged
    {
        private string name;
        private string number;
        public string Name
        {
            set
            {
                name = value;
                Notify("Name");
            }
            get
            {
                return name;
            }
        }
        public string Number
        {
            get { return number; }
            set
            {
                Number = value;
                Notify("Number");
            }
        }
        public string NameAndNumber
        {
            get { return name + "#" + number; }
        }

        //constructors
        public HockeyPlayer()
        {

        }
        public HockeyPlayer(string name, string number)
        {
            this.name = name;
            this.number = number;
        }
        //methods
        public override string ToString()
        {
            return name + "#" + number;
        }
        //INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        
        void Notify(string propname)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propname));
            }
        }
    }
    public class HockeyTeam
    {
        #region PROPERTIES
        // Huom public field ei kelpaa WPF:n databindingissä, pitää olla Property
        public string Name { get; set; }
        public string City { get; set; }
        #endregion
        #region CONSTRUCTORS
        public HockeyTeam()
        {
            Name = "";
            City = "unknown";
        }
        public HockeyTeam(string name, string city)
        {
            Name = name;
            City = city;
        }
        #endregion
        public override string ToString()
        {
            return Name + "@" + City;
        }
    }

    public class HockeyLeague
    {
        //Perustetaan SMLiiga, sisältää x kpl joukkueita
        // HUOM: jos halutaan että databindaus huomaa automaattisesti
        // muutokset kokoelmassa, käytä ObservableCollection-kokoelmaa
        List<HockeyTeam> teams = new List<HockeyTeam>();
        public HockeyLeague()
        {
            teams.Add(new HockeyTeam("HIFK", "Helsinki"));
            teams.Add(new HockeyTeam("JYP", "Jyväskylä"));
            teams.Add(new HockeyTeam("Kalpa", "Kuopio"));
            teams.Add(new HockeyTeam("Sport", "Vaasa"));
        }
        //Metodi joka palauttaa liigan joukkueet
        public List<HockeyTeam> GetTeams()
        {
            return teams;
        }
    }
}
