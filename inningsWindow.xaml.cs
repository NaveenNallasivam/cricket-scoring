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
    /// The file inningsWindow.xaml is the backend for the 3rd window displayed
    /// </summary>
    /// bugs to be fixed
    /// run out cannot be added. create this feature
    public partial class inningsWindow : Window
    {
        string striker;
        string nonstriker;
        string bowler;
        int score = 0;
        int vstrikerRun;
        int vnonStrikerRun;
        int strikerballsFaced = 0;
        int nonStrikerballsFaced = 0;
        int sFour = 0;
        int nFour = 0;
        int sSix = 0;
        int nSix = 0;
        int fours = 0;
        int sixs = 0;
        int lvwicket = 0;
        double strikeRate = 0;
        int ballCount = 0;
        double over;
        int totalOver;
        matchWindow nxtinnings = new matchWindow(String.Empty);
        playerProfile[] next = new playerProfile[100];
        int count = 0;
        //the following list contains the objects of playerProfile class passed as reference from matchWindow.xaml.cs//
        List<playerProfile> batsman = new List<playerProfile>();
        public inningsWindow(string striker, string nonstriker, string bowler, List<playerProfile> player,int over) 
        {
            InitializeComponent();
            this.striker = striker;
            this.nonstriker = nonstriker;
            this.bowler = bowler;
            batsman.AddRange(player);
            this.totalOver = over;
            strikerName.Text = this.striker;
            nonStrikerName.Text = this.nonstriker;
            bowlerName.Text = this.bowler;
        }
        //this function checks whether the current over is finished
        public void checkInnings(int ballCount)
        {
            if (ballCount == 6)
            {
                
                this.over = this.over + 1;
                this.ballCount = 0;
                changeStriker();//change in strike batsman after over is finished.
                                //change.Show();
                                //this.Close();
                if (this.over >= this.totalOver)
                {
                    nxtinnings=new matchWindow("start next innings");
                    nxtinnings.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Enter New Bowler");
                }
            }
        }
        //this function claculates the strikerate of the batsman
        public void calculateStrikeRate(int score,double over,int ballsfaced,string striker)
        {
            double balls = (over * 6) + ballsfaced;
            this.strikeRate = (score / balls) * 100;
            foreach (playerProfile p in batsman)
            {
              
                //checks for the striker
                if ((string.Equals(p.Name,striker) == true))
                {
                    p.StrikeRate = this.strikeRate;//updates the striker's strike rate
                    strikerStrikeRate.Text = Convert.ToString(p.StrikeRate);//updates the striker strike rate textblock
                    break;
                }
                //does the same for nonstriker
                if (string.Equals(p.Name, this.nonstriker))
                {
                    p.StrikeRate = this.strikeRate;
                    nonStrikerStrikeRate.Text = Convert.ToString(p.StrikeRate);
                    break;
                }
            }
        }
        //this function calculates the runrate of the innings
        public void calculateRunRate(int score, double over, int ballsfaced)
        {
            double balls = (over * 6) + ballsfaced;
            double runrate =(score / balls) * 6;
            Math.Round(runrate);
            displayRR.Text=Convert.ToString(runrate);
        }
        //this function updates individual runs and balls faced by the batsman
        public void updateBallAndRun(int runs,int balls)
        {
            //loop for updating runs
            foreach (playerProfile p in batsman)
            {
                //checks for striker and updates his runs
                if ((string.Equals(p.Name, this.striker) == true))
                {
                    this.vstrikerRun = this.vstrikerRun + runs;
                    p.Runs = this.vstrikerRun;
                    strikerRun.Text = Convert.ToString(p.Runs);
                    break;
                }
                if (string.Equals(p.Name, this.nonstriker))
                {
                    this.vnonStrikerRun = this.vnonStrikerRun + runs;
                    p.Runs = this.vnonStrikerRun;
                    nonStrikerRun.Text = Convert.ToString(p.Runs);
                    break;
                }
            }
            //loop for updating balls
            foreach (playerProfile p in batsman)
            {
                //checks for striker and updates balls
                if ((string.Equals(p.Name, striker) == true))
                {
                    this.strikerballsFaced = this.strikerballsFaced + balls;
                    strikerBall.Text = Convert.ToString(this.strikerballsFaced);
                    break;
                }
                //checks for non striker and updates balls
                if (string.Equals(p.Name, this.nonstriker))
                {
                    this.nonStrikerballsFaced = this.nonStrikerballsFaced + balls;
                    nonStrikerBall.Text = Convert.ToString(this.nonStrikerballsFaced);
                    break;
                }
            }

        }
        //this functions changes striker 
        public void changeStriker()
        {
           
            string temp = this.striker;
            this.striker = this.nonstriker;
            this.nonstriker = temp;
            if (String.Equals(batsman[2].Name, this.bowler) == false)
            {
                playerProfile temps = batsman[2];
                batsman[2] = batsman[1];
                batsman[1] = temps;
            }
         
        }
        public void changeBowler()
        {
            this.bowler = newBowler.Text;
            bowlerName.Text = newBowler.Text;
            next[count++] = new playerProfile();
            next[count - 1].Name = newBowler.Text;
            batsman.Add(next[count - 1]);
            bowlerWicket.Text = Convert.ToString(batsman[3].Wickets);
        }
        //this functions adds wicket to the bowler's profile
        public void addWicket()
        {
                if (string.Equals(batsman[2].Name, bowler))
                {
                    batsman[2].Wickets++;
                    bowlerName.Text = bowler;
                    bowlerWicket.Text = Convert.ToString(batsman[2].Wickets);
                }
            else
            {
                MessageBox.Show("error");
                MessageBox.Show(batsman[2].Name);
                MessageBox.Show(this.bowler);
            }
            
        }
        public void addBoundary(int boundary)
        {
            if (boundary == 4)
            {
                foreach (playerProfile p in batsman)
                {
                    //checks for striker and updates four
                    if ((string.Equals(p.Name, striker) == true))
                    {
                        sFour++;
                        strikerFour.Text = Convert.ToString(sFour);
                        break;
                    }
                    //checks for non striker and updates balls
                    if (string.Equals(p.Name, this.nonstriker))
                    {
                        nFour++;
                        nonStrikerFour.Text = Convert.ToString(nFour);
                        nonStrikerBall.Text = Convert.ToString(this.nonStrikerballsFaced);
                        break;
                    }
                }
            }
            if (boundary == 6)
            {
                foreach (playerProfile p in batsman)
                {
                    //checks for striker and updates four
                    if ((string.Equals(p.Name, striker) == true))
                    {
                        sSix++;
                        strikerSix.Text = Convert.ToString(sSix);
                        break;
                    }
                    //checks for non striker and updates balls
                    if (string.Equals(p.Name, this.nonstriker))
                    {
                        nSix++;
                        nonStrikerSix.Text = Convert.ToString(nSix);
                        break;
                    }
                }
            }
        }
        public void changeBatsman(string striker)
        {
                if ((string.Equals(striker, this.striker) == true))
                {
                    this.striker = newBatsmanName.Text;
                    next[count++] = new playerProfile();
                    next[count-1].Name = newBatsmanName.Text;
                    batsman.Remove(batsman[0]);
                    batsman.Add(next[count - 1]);
                    batsman.Reverse();
                if (String.Equals(batsman[2].Name, this.bowler) == false)
                {
                    playerProfile temp = batsman[2];
                    batsman[2] = batsman[1];
                    batsman[1] = temp;
                }
                    strikerName.Text =next[count-1].Name;
                    strikerRun.Text = Convert.ToString(0);
                    strikerBall.Text = Convert.ToString(0);
                    strikerFour.Text = Convert.ToString(0);
                    strikerSix.Text = Convert.ToString(0);
                    strikerStrikeRate.Text = Convert.ToString(0);
                    vstrikerRun = 0;
                    strikerballsFaced = 0;
                    sFour = 0;
                    sSix = 0;
              
                }
                //checks for non striker and updates balls
                if (string.Equals(striker, this.nonstriker)==true)
                {
                    this.nonstriker = newBatsmanName.Text;
                    next[count++] = new playerProfile();
                    next[count - 1].Name = newBatsmanName.Text;
                    batsman.Remove(batsman[1]);
                    batsman.Add(next[count - 1]);
                    playerProfile temp = batsman[2];
                    batsman[2] = batsman[1];
                    batsman[1] = temp;
                    nonStrikerName.Text = newBatsmanName.Text;
                    nonStrikerRun.Text = Convert.ToString(0);
                    nonStrikerBall.Text = Convert.ToString(0);
                    nonStrikerFour.Text = Convert.ToString(0);
                    nonStrikerSix.Text = Convert.ToString(0);
                    nonStrikerStrikeRate.Text = Convert.ToString(0);
                    vnonStrikerRun = 0;
                    nonStrikerballsFaced = 0;
                    nFour = 0;
                    nSix = 0;
               
                }
        }
        //The following functions defines score button clicks(0,1,2,3,4,5,6)//
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (wicket.IsChecked == true || runOutStriker.IsChecked == true || runOutNonStriker.IsChecked == true)
            {
                if (runOutStriker.IsChecked == false && runOutNonStriker.IsChecked == false)
                {
                    addWicket();
                }
                MessageBox.Show("Please Enter a new Batsman name");
            }
            //if there is wide or no ball score is counted but ball is not counted
             if ((wide.IsChecked == true || noBall.IsChecked == true))
            {
                score = score + 1;
                displayScore.Text = Convert.ToString(score);
                //checks for end of the over
                displayBallno.Text = Convert.ToString(ballCount);
                displayOverno.Text = Convert.ToString(over);
                displayWicket.Text = Convert.ToString(lvwicket);
                updateBallAndRun(0,0);
                calculateRunRate(score,over,ballCount);
                calculateStrikeRate(score,over,ballCount,this.striker);
                checkInnings(ballCount);
                legByes.IsChecked = false;
                byes.IsChecked = false;
     
            }
             //if there is no wide or noball ball is counted
            else
            {
                displayScore.Text = Convert.ToString(score);
                ballCount = ballCount + 1;    
                displayBallno.Text = Convert.ToString(ballCount);
                displayOverno.Text = Convert.ToString(over);
                displayWicket.Text = Convert.ToString(lvwicket);
                updateBallAndRun(0,1);
                checkInnings(ballCount);
                calculateRunRate(score, over, ballCount);
                calculateStrikeRate(score, over, ballCount,this.striker);
              
            }

        }
        private void one_Click(object sender, RoutedEventArgs e)
        {
            if (wicket.IsChecked == true || runOutStriker.IsChecked == true || runOutNonStriker.IsChecked == true)
            {
               
                MessageBox.Show("Please Enter a new Batsman name");
            }
            //if there is wide or no ball and there is no wicket score alone is counted
            //wicket in no ball will also be counted (eg.run out)
            if ((wide.IsChecked == true || noBall.IsChecked == true))
            {
                legByes.IsChecked = false;
                byes.IsChecked = false;
                score = score + 2;
                displayScore.Text = Convert.ToString(score);
                displayBallno.Text = Convert.ToString(ballCount);
                displayOverno.Text = Convert.ToString(over);
                displayWicket.Text = Convert.ToString(lvwicket);
                calculateRunRate(score, over, ballCount);
                calculateStrikeRate(score, over, ballCount,this.striker);
                if (wide.IsChecked == true)
                {
                    updateBallAndRun(0, 0);
                }
                else
                {
                    updateBallAndRun(1, 0);
                }
                changeStriker();
                checkInnings(ballCount);
           
            }
            //if there is legbye or bye both score and ball is counted
            //leg bye runs are not added to the bowler and batsman
            if ((legByes.IsChecked == true || byes.IsChecked == true))
            {
                score = score + 1;
                ballCount = ballCount + 1;     
                displayScore.Text = Convert.ToString(score);
                displayBallno.Text = Convert.ToString(ballCount);
                displayOverno.Text = Convert.ToString(over);
                displayWicket.Text = Convert.ToString(lvwicket);
                updateBallAndRun(0,1);
                calculateRunRate(score, over, ballCount);
                calculateStrikeRate(score, over, ballCount,this.striker);
                changeStriker();
                checkInnings(ballCount);
    
            }
            /*if the run and ball are legal both score and balls are counted and 
            they are added to the bowler and batsmen performance*/
            if(legByes.IsChecked == false && byes.IsChecked == false && wide.IsChecked == false && noBall.IsChecked == false)
            {
                score = score + 1;
                ballCount = ballCount + 1;
                displayScore.Text = Convert.ToString(score);
                displayBallno.Text = Convert.ToString(ballCount);
                displayOverno.Text = Convert.ToString(over);
                displayWicket.Text = Convert.ToString(lvwicket);
                updateBallAndRun(1,1);
                calculateRunRate(score, over, ballCount);
                calculateStrikeRate(score, over, ballCount,this.striker);
                changeStriker();
                checkInnings(ballCount);
           
            }

        }

        private void two_Click(object sender, RoutedEventArgs e)
        {
            if (wicket.IsChecked == true || runOutStriker.IsChecked == true || runOutNonStriker.IsChecked == true)
            {
                MessageBox.Show("Please Enter a new Batsman name");
            }
            if ((wide.IsChecked == true || noBall.IsChecked == true))
            {
                legByes.IsChecked = false;
                byes.IsChecked = false;
                score = score + 3;
                displayScore.Text = Convert.ToString(score);
                displayBallno.Text = Convert.ToString(ballCount);
                displayOverno.Text = Convert.ToString(over);
                displayWicket.Text = Convert.ToString(lvwicket);
                calculateRunRate(score, over, ballCount);
                calculateStrikeRate(score, over, ballCount,this.striker);
                if (wide.IsChecked == true)
                {
                    updateBallAndRun(0, 0);
                }
                else
                {
                    updateBallAndRun(2, 0);
                }
                checkInnings(ballCount);
              
            }
            if ((legByes.IsChecked == true || byes.IsChecked == true))
            {
                score = score + 2;
                ballCount = ballCount + 1;
                displayScore.Text = Convert.ToString(score);
                displayBallno.Text = Convert.ToString(ballCount);
                displayOverno.Text = Convert.ToString(over);
                displayWicket.Text = Convert.ToString(lvwicket);
                calculateRunRate(score, over, ballCount);
                calculateStrikeRate(score, over, ballCount,this.striker);
                updateBallAndRun(0,1);
                checkInnings(ballCount);
              
            }
            if (legByes.IsChecked == false && byes.IsChecked == false && wide.IsChecked == false && noBall.IsChecked == false)
            {
                score = score + 2;
                ballCount = ballCount + 1;
                displayScore.Text = Convert.ToString(score);
                displayBallno.Text = Convert.ToString(ballCount);
                displayOverno.Text = Convert.ToString(over);
                displayWicket.Text = Convert.ToString(lvwicket);
                calculateRunRate(score, over, ballCount);
                calculateStrikeRate(score, over, ballCount,this.striker);
                updateBallAndRun(2,1);
                checkInnings(ballCount);
        
            }
        }

        private void three_Click(object sender, RoutedEventArgs e)
        {
            if (wicket.IsChecked == true || runOutStriker.IsChecked == true || runOutNonStriker.IsChecked == true)
            { 
                MessageBox.Show("Please Enter a new Batsman name");
            }
    
            if (wide.IsChecked == true || noBall.IsChecked == true)
            {
                legByes.IsChecked = false;
                byes.IsChecked = false;
                score = score + 4;
                displayScore.Text = Convert.ToString(score);
                displayBallno.Text = Convert.ToString(ballCount);
                displayOverno.Text = Convert.ToString(over);
                displayWicket.Text = Convert.ToString(lvwicket);
                calculateRunRate(score, over, ballCount);
                calculateStrikeRate(score, over, ballCount,this.striker);
                if (wide.IsChecked == true)
                {
                    updateBallAndRun(0, 0);
                }
                else
                {
                    updateBallAndRun(3, 0);
                }
                changeStriker();
                checkInnings(ballCount);
          
            }
            if (legByes.IsChecked == true || byes.IsChecked == true)
            {
                score = score + 3;
                ballCount = ballCount + 1;
                displayScore.Text = Convert.ToString(score);
                displayBallno.Text = Convert.ToString(ballCount);
                displayOverno.Text = Convert.ToString(over);
                displayWicket.Text = Convert.ToString(lvwicket);
                calculateRunRate(score, over, ballCount);
                calculateStrikeRate(score, over, ballCount,this.striker);
                updateBallAndRun(0,1);
                changeStriker();
                checkInnings(ballCount);
         
            }
            if (legByes.IsChecked == false && byes.IsChecked == false && wide.IsChecked == false && noBall.IsChecked == false)
            {
                score = score + 3;
                ballCount = ballCount + 1;
                displayScore.Text = Convert.ToString(score);
                displayBallno.Text = Convert.ToString(ballCount);
                displayOverno.Text = Convert.ToString(over);
                displayWicket.Text = Convert.ToString(lvwicket);
                calculateRunRate(score, over, ballCount);
                calculateStrikeRate(score, over, ballCount,this.striker);
                updateBallAndRun(3,1);
                changeStriker();
                checkInnings(ballCount);
             
            }
        }

        private void four_Click(object sender, RoutedEventArgs e)
        {
            if (wicket.IsChecked == true || runOutStriker.IsChecked == true || runOutNonStriker.IsChecked == true)
            {
                MessageBox.Show("Please Enter a new Batsman name");
            }
            if (wide.IsChecked == true || noBall.IsChecked == true)
            {
                legByes.IsChecked = false;
                byes.IsChecked = false;
                score = score + 5;
                displayScore.Text = Convert.ToString(score);
                displayBallno.Text = Convert.ToString(ballCount);
                displayOverno.Text = Convert.ToString(over);
                displayWicket.Text = Convert.ToString(lvwicket);
                calculateRunRate(score, over, ballCount);
                calculateStrikeRate(score, over, ballCount,this.striker);
                if (wide.IsChecked == true) 
                {
                    updateBallAndRun(0, 0);
                }
                else
                {
                    updateBallAndRun(4, 0);
                }
                addBoundary(4);
                checkInnings(ballCount);
                
            }
            if (legByes.IsChecked == true || byes.IsChecked == true)
            {
                score = score + 4;
                ballCount = ballCount + 1;
                displayScore.Text = Convert.ToString(score);
                displayBallno.Text = Convert.ToString(ballCount);
                displayOverno.Text = Convert.ToString(over);
                displayWicket.Text = Convert.ToString(lvwicket);
                calculateRunRate(score, over, ballCount);
                calculateStrikeRate(score, over, ballCount,this.striker);
                updateBallAndRun(0,1);
                checkInnings(ballCount);
             
            }
            if (legByes.IsChecked == false && byes.IsChecked == false && wide.IsChecked == false && noBall.IsChecked == false)
            {
                score = score + 4;
                ballCount = ballCount + 1;
                displayScore.Text = Convert.ToString(score);
                displayBallno.Text = Convert.ToString(ballCount);
                displayOverno.Text = Convert.ToString(over);
                displayWicket.Text = Convert.ToString(lvwicket);
                calculateRunRate(score, over, ballCount);
                calculateStrikeRate(score, over, ballCount,this.striker);
                updateBallAndRun(4,1);
                addBoundary(4);
                checkInnings(ballCount);
                
            }
        }

        private void five_Click(object sender, RoutedEventArgs e)
        {
            if (wicket.IsChecked == true || runOutStriker.IsChecked == true || runOutNonStriker.IsChecked == true)
            {
                
                MessageBox.Show("Please Enter a new Batsman name");
            }
            if (wide.IsChecked == true || noBall.IsChecked == true)
            {
                legByes.IsChecked = false;
                byes.IsChecked = false;
                score = score + 6;
                displayScore.Text = Convert.ToString(score);
                displayBallno.Text = Convert.ToString(ballCount);
                displayOverno.Text = Convert.ToString(over);
                displayWicket.Text = Convert.ToString(lvwicket);
                calculateRunRate(score, over, ballCount);
                calculateStrikeRate(score, over, ballCount,this.striker);
                if (wide.IsChecked == true)
                {
                    updateBallAndRun(0, 0);
                }
                else
                {
                    updateBallAndRun(5, 0);
                }
                addBoundary(4);
                changeStriker();
                checkInnings(ballCount);
           
            }
            if (legByes.IsChecked == true || byes.IsChecked == true)
            {
                score = score + 5;
                ballCount = ballCount + 1;
                displayScore.Text = Convert.ToString(score);
                displayBallno.Text = Convert.ToString(ballCount);
                displayOverno.Text = Convert.ToString(over);
                displayWicket.Text = Convert.ToString(lvwicket);
                calculateRunRate(score, over, ballCount);
                calculateStrikeRate(score, over, ballCount,this.striker);
                updateBallAndRun(0,1);
                changeStriker();
                checkInnings(ballCount);
              
            }
            if (legByes.IsChecked == false && byes.IsChecked == false && wide.IsChecked == false && noBall.IsChecked == false)
            {
                score = score + 5;
                ballCount = ballCount + 1;
                displayScore.Text = Convert.ToString(score);
                displayBallno.Text = Convert.ToString(ballCount);
                displayOverno.Text = Convert.ToString(over);
                displayWicket.Text = Convert.ToString(lvwicket);
                calculateRunRate(score, over, ballCount);
                calculateStrikeRate(score, over, ballCount,this.striker);
                updateBallAndRun(5,1);
                addBoundary(4);
                changeStriker();
                checkInnings(ballCount);
               
            }
        }

        private void six_Click(object sender, RoutedEventArgs e)
        {
            if (wicket.IsChecked == true || runOutStriker.IsChecked == true || runOutNonStriker.IsChecked == true)
            {
                MessageBox.Show("Please Enter a new Batsman name");

            }
            if (wide.IsChecked == true || noBall.IsChecked == true)
            {
                legByes.IsChecked = false;
                byes.IsChecked = false;
                score = score + 7;
                displayScore.Text = Convert.ToString(score);
                displayBallno.Text = Convert.ToString(ballCount);
                displayOverno.Text = Convert.ToString(over);
                displayWicket.Text = Convert.ToString(lvwicket);
                calculateRunRate(score, over, ballCount);
                calculateStrikeRate(score, over, ballCount,this.striker);
                if (wide.IsChecked == true)
                {
                    updateBallAndRun(0, 0);
                }
                else
                {
                    updateBallAndRun(6, 0);
                }
                addBoundary(6);
                checkInnings(ballCount);
                
            }
            if (legByes.IsChecked == true || byes.IsChecked == true)
            {
                score = score + 6;
                ballCount = ballCount + 1;
                displayScore.Text = Convert.ToString(score);
                displayBallno.Text = Convert.ToString(ballCount);
                displayOverno.Text = Convert.ToString(over);
                displayWicket.Text = Convert.ToString(lvwicket);
                calculateRunRate(score, over, ballCount);
                calculateStrikeRate(score, over, ballCount,this.striker);
                updateBallAndRun(0, 1);
                checkInnings(ballCount);
             
            }
            if (legByes.IsChecked == false && byes.IsChecked == false && wide.IsChecked == false && noBall.IsChecked == false)
            {
                score = score + 6;
                ballCount = ballCount + 1;
                displayScore.Text = Convert.ToString(score);
                displayBallno.Text = Convert.ToString(ballCount);
                displayOverno.Text = Convert.ToString(over);
                displayWicket.Text = Convert.ToString(lvwicket);
                calculateRunRate(score, over, ballCount);
                calculateStrikeRate(score, over, ballCount,this.striker);
                updateBallAndRun(6,1);
                addBoundary(6);
                checkInnings(ballCount);
             
            }
        }

        private void wicket_Checked(object sender, RoutedEventArgs e)
        {
            lvwicket = lvwicket + 1;
            runOutStriker.IsChecked = false;
            runOutNonStriker.IsChecked = false;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (runOutNonStriker.IsChecked == true)
            {
                changeBatsman(this.nonstriker);
            }
            else
            {
                changeBatsman(this.striker);
            }
            wicket.IsChecked = false;
            runOutStriker.IsChecked = false;
            runOutNonStriker.IsChecked = false;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            changeBowler();
        }

        private void swapBatsman_Click(object sender, RoutedEventArgs e)
        {
            changeStriker();
            MessageBox.Show("Batsman swapped " + this.striker + " on strike");
        }
    }
}
