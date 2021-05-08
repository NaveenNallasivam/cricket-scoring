using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace player_profile
{
    /// <summary>
    /// This file contains code for the backend functioning of the first window displayed
    /// </summary>
    public partial class MainWindow : Window
    {
        matchDetails matchInfo = new matchDetails(); //object for matchdetails class//
        string hostteam = String.Empty;
        string visitteam = String.Empty;
        string toss = String.Empty;
        string optto = String.Empty;
        int overs = 0;
        public MainWindow()
        {
            InitializeComponent();
        }
        //Following functions defines radio-button clicks for tosswin, choosing bat/bowl
        private void hostTeamToss_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton tossh = sender as RadioButton;
            toss = Convert.ToString(tossh.Content);
        }
        private void visitingTeamToss_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton tossv = sender as RadioButton;
            toss = Convert.ToString(tossv.Content);
        }
        private void optedToBat_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton optbat = sender as RadioButton;
            optto = Convert.ToString(optbat.Content);
        }
        private void optedToBowl_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton optbowl = sender as RadioButton;
            optto = Convert.ToString(optbowl.Content);
        }
        //Following function defines functions to do when start match button is clicked
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            hostteam = Convert.ToString(hostTeam.Text);
            visitteam = Convert.ToString(visitingTeam.Text);
            //try catch block used to check user has inputted proper number for overs
            try
            {
                overs = Convert.ToInt32(noOfOvers.Text);
                matchWindow passOver = new matchWindow(overs); //this passes the total no of overs to 2nd window 
                matchInfo.HostTeam = hostteam;
                matchInfo.VisitingTeam = visitteam;
                matchInfo.Tosswon = toss;
                matchInfo.OptedTo = optto;
                matchInfo.Overs = overs;
                if(toss.Length!=0&&optto.Length!=0&&overs>0)
                {
                    passOver.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Please select all the requirements");
                }
                
            }
            catch (Exception er)
            {
                MessageBox.Show(Convert.ToString(er));
                this.Close();
            }
           
        }
    }
}
