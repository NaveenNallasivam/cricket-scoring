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
using System.Windows.Shapes;

namespace player_profile
{
    /// <summary>
    /// Interaction logic for matchWindow.xaml
    /// </summary>
    public partial class matchWindow : Window
    {
        string striker = String.Empty;
        string nonStriker = String.Empty;
        string bowler = String.Empty;
        int over;
        
       //initializing over via constructor called from previous window
        public matchWindow(int over)
        {
            InitializeComponent();
            this.over = over;
        }
        public matchWindow(string target)
        {
            InitializeComponent();
            MessageBox.Show(target);
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            playerProfile[] add = new playerProfile[3];
            add[0] = new playerProfile();
            add[1] = new playerProfile();
            add[2] = new playerProfile();
            striker = strikerName.Text;
            bowler = bowlerName.Text;
            nonStriker = nonStrikerName.Text;
            add[0].Name = striker;
            add[1].Name = nonStriker;
            add[2].Name = bowler;
            List<playerProfile> player = new List<playerProfile>();
            player.Add(add[0]);
            player.Add(add[1]);
            player.Add(add[2]);
            inningsWindow innings = new inningsWindow(striker, nonStriker, bowler,player,this.over);//constructor call to inningswindow
            innings.Show();
            this.Close();
        }

    }
}
