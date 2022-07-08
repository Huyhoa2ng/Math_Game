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
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading;
namespace Math_Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //Click button start training and exit

        Random MyRandom = new Random();
        int Answered, Correct;
        int CorrectAnswer, Digits;
        string Question;
        int NumberCheck;
        

        string YourAnswer;
        int NumberDigitsAnswer;


        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            int score;
            string Message = "";
#pragma warning disable CS0252 // Possible unintended reference comparison; left hand side needs cast
            if (btnStart.Content == "Start Training")
            {
                btnStart.Content = "Stop Training";
                btnExit.IsEnabled = false;
                Answered = 0;
                Correct = 0;
                lblTested.Content = 0;
               lblCorrect.Content = 0;
                lblQuestion.Content = GetQuestion();
            } 
            else
            {
                btnStart.Content = "Start Training";
                btnExit.IsEnabled = true;
                lblQuestion.Content = "";

                if (Answered > 0)
                {
                    score = (int)(100 * (double)(Correct) / Answered);
                    Message = "The number of question tried: " + Answered.ToString() + "\r\n";
                    Message += "The number of correctly number answered: " + Correct.ToString() + "(" + score.ToString() + "%)";
                    System.Windows.MessageBox.Show(Message);
                }
            }
#pragma warning restore CS0252 // Possible unintended reference comparison; left hand side needs cast
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            //close() similiar break;
            this.Close();
        }

        //Get question

        private string GetQuestion()
        {
            int Ptype, P, RandValue, Factor;
            P = 0;

            //Caculutus

            do
            {

                Ptype = MyRandom.Next(4) + 1;
                if (Ptype == 1 && chkAdd.IsChecked == true)
                {
                    //Addition
                    P = Ptype;
                    RandValue = MyRandom.Next(10);
                    Factor = GetFactor(1);
                    CorrectAnswer = RandValue + Factor;
                    Question = RandValue.ToString() + "+" + Factor.ToString() + "=";

                }
                else if (Ptype == 2 && chkSubs.IsChecked == true)
                {
                    //Substraction
                    P = Ptype;
                    RandValue = MyRandom.Next(10);
                    Factor =GetFactor(2);
                    CorrectAnswer = RandValue - Factor;
                    Question = RandValue.ToString() + "-" + Factor.ToString() + "=";
                }
                else if (Ptype == 3 && chkMul.IsChecked == true)
                {
                    //Multiplication
                    P = Ptype;
                    RandValue = MyRandom.Next(10);
                    Factor = GetFactor(3);
                    CorrectAnswer = RandValue * Factor;
                   
                    Question = RandValue.ToString() + "*" + Factor.ToString() + "=";
                }
                else if (Ptype == 4 && chksDiv.IsChecked == true)
                {
                    P = Ptype;
                    RandValue = MyRandom.Next(10);
                    Factor = GetFactor(4);
                    CorrectAnswer = RandValue / Factor;
                    Question = RandValue.ToString() + "/" + Factor.ToString() + "=";
                }
            } while (P == 0);

            if (CorrectAnswer < 10)
            {
                Digits = 1;
                return (Question + "?");
            }
            else
            {
                Digits = 2;
                return(Question + "??");
            }
        }
        //Get answer

        private void FormMathGame_KeyPress(object sender,KeyPressEventArgs e)
        {
            if (btnStart.Content == "Start Training")
                return;

            //Allow to enter 0-9
            if(e.KeyChar >='0' && e.KeyChar <= '9')
            {
                e.Handled = false;
                YourAnswer += e.KeyChar;
                lblQuestion.Content = Question + YourAnswer;

                if(NumberDigitsAnswer != Digits)
                {
                    NumberDigitsAnswer++;
                    lblQuestion.Content = "?";
                    return;
                }
                else
                {
                    Answered++;
                }
                
                //Check answered

                if(Convert.ToInt32(YourAnswer) ==CorrectAnswer)
                {
                    Correct++;
                }
                lblTested.Content = Answered.ToString();
                lblTested.UpdateDefaultStyle();
                lblCorrect.Content = Correct.ToString();
                lblCorrect.UpdateDefaultStyle();
                lblQuestion.Content = GetQuestion();
                lblQuestion.UpdateDefaultStyle();
               
            }
            else
            {
                e.Handled = true;
            }


        }
        private void rdoFactor0_Click(object sender, RoutedEventArgs e)
        {
            NumberCheck++;
            if(chksDiv.IsChecked == true && rdoFactor0.IsChecked==true )
            {
                System.Windows.MessageBox.Show("cannot");
                rdoFactor0.IsChecked =false;
            }
            else
            {
                rdoFactor0.IsChecked = true;
            }    
        }


        //Factor 0-9

        private int GetFactor(int e)
        {
            if(rdoFactor0.IsChecked==true)
            {
                return (0);
            }
            else if(rdoFactor1.IsChecked==true)
            {
                return (1);
            }
            else if(rdoFactor2.IsChecked==true)
            {
                return (2);
            }
            else if(rdoFactor3.IsChecked==true)
            {
                return (3);
            }
            else if(rdoFactor4.IsChecked==true)
            {
                return (4);
            }
            else if(rdoFactor5.IsChecked==true)
            {
                return (5);
            }
            else if(rdoFactor6.IsChecked==true)
            {
                return (6);
            }
            else if(rdoFactor7.IsChecked==true)
            {
                return (7);
            }
            else if(rdoFactor8.IsChecked==true)
            {
                return (8);
            }
            else if(rdoFactor9.IsChecked==true)
            {
                return (9);
            }
            else
            {
                //Random
                if(e==4)
                {
                    return (MyRandom.Next(9) + 1);
                }
                else
                {
                    return (MyRandom.Next(10));
                }
            }
        }

        //Special condition for div and button are checked.

        private void chkType_CheckedChanged(object sender,EventArgs e)
        {
            System.Windows.Controls.CheckBox CheckClicked;

            CheckClicked = (System.Windows.Controls.CheckBox)sender;

            NumberCheck = 0;

            if(chkAdd.IsChecked==true)
            {
                NumberCheck++;
            }
            else if(chkSubs.IsChecked==true)
            {
                NumberCheck++;
            }
            else if(chkMul.IsChecked==true)
            {
                NumberCheck++;
            }
             
            if(NumberCheck==0)
            {
                CheckClicked.IsChecked = true;
                this.Focus();
            }    
            
        }



    }
}
