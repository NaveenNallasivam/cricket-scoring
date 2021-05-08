using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//playerProfile has the individual players performance such as runs, wickets, catches, stumpings as members

namespace player_profile
{
    public class playerProfile
    {
        string name;
        double runs;
        double strikeRate;
        int wickets;
        int catches;
        int stumpings;
        double battingAverage;
        double bowlingAverage;
        public playerProfile() { }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        
        
        
        public double Runs
        {
            get { return runs; }
            set { runs = value; }
        }
        public int Wickets
        {
            get { return wickets; }
            set { wickets = value; }
        }
        public int Catches
        {
            get { return catches; }
            set { catches = value; }
        }
        public int Stumpings
        {
            get { return stumpings; }
            set { stumpings = value; }
        }
        public double StrikeRate
        {
            get { return strikeRate;}
            set { strikeRate = value; }
        }
    }
}
