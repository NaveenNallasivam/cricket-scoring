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
        int runs;
        int ballsFaced;
        double strikeRate;
        int wickets;
        int catches;
        int stumpings;
        int runsGiven;
        int maiden;
        double economy;
        int oversBowled;
        double battingAverage;
        double bowlingAverage;
        public playerProfile() { }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        
        public int BallsFaced
        {
            get { return ballsFaced; }
            set { ballsFaced = value; }
        }
        
        public int Runs
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
        public int OversBowled
        {
            get { return oversBowled; }
            set { oversBowled = value; }
        }
        public double StrikeRate
        {
            get { return strikeRate;}
            set { strikeRate = value; }
        }
        public int RunsGiven
        {
            get { return runsGiven; }
            set { runsGiven = value; }
        }
        public int Maiden
        {
            get { return maiden; }
            set { maiden = value; }
        }
        public double Economy
        {
            get { return economy; }
            set { economy = value; }
        }
    }
}
