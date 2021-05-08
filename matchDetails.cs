using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*This file defines a user defined variable called matchDetails which contains the names of the hosting,visiting teams,
toss winning team and its decision as its members. This class is planned to be used when displaying match summary*/

namespace player_profile
{
    class matchDetails
    {
        string hostTeam;
        string visitingTeam;
        string tossWon;
        string optedTo;
        int overs;
        public string HostTeam
        {
            get { return hostTeam; }
            set { hostTeam = value; }
        }
        public string VisitingTeam
        {
            get { return visitingTeam; }
            set { visitingTeam = value; }
        }
        public string Tosswon
        {
            get { return tossWon; }
            set { tossWon = value; }
        }
        public string OptedTo
        {
            get { return optedTo; }
            set { optedTo = value; }
        }
        public int Overs
        {
            get { return overs; }
            set { overs = value; }
        }

    }
}
