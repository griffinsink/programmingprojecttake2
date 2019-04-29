//Mason, Jack and Griffin worked on this while referencing Dharma Bellamkonda's connect four game

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
using System.Windows.Threading;
using System.Timers;
using System.Globalization;

namespace ConnectFour
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int chipSize = 58;

        private bg board;
        private bool inputLock;
        private DispatcherTimer timer;
        private Side CurSide;
        private Ellipse CurCir;
        private int CurCol;
        int redCount = 0;
        int blackCount = 0;





        public MainWindow()
        {
            InitializeComponent();
            NewGame();
        }

        //This button is used to create a new game and it contains the features that allows each chip to fall at a certain speed and for the board to be set up 6 by 7
        private void NewGame()
        {
            inputLock = true;
            board = new bg(6, 7);
            CurSide = Side.Player1;
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 15);
            timer.Start();
            gameCanvas.Children.Clear();
            inputLock = false;

            WorkButton();

        }



        //Here we are creating each chip and telling it  where to fall when we press each button for the row it needs to go
        private void DrawCircle(Side side, int col)
        {

            inputLock = true;
            Ellipse circle = new Ellipse();
            circle.Height = chipSize;
            circle.Width = chipSize;
            ImageBrush myBrush1 = new ImageBrush();
            myBrush1.ImageSource = new BitmapImage(new Uri(@"https://upload.wikimedia.org/wikipedia/commons/6/63/African_elephant_warning_raised_trunk.jpg", UriKind.Absolute));
            ImageBrush myBrush2 = new ImageBrush();
            myBrush2.ImageSource = new BitmapImage(new Uri(@"https://media.popculture.com/2017/08/game-of-thrones-cersei-lannister-20009418-1280x0.jpg", UriKind.Absolute));


            circle.Fill = (side == Side.player2) ? myBrush2 : myBrush1;
            Canvas.SetTop(circle, 0);
            Canvas.SetLeft(circle, col * 80);
            gameCanvas.Children.Add(circle);
            CurCir = circle;
            timer.Tick += dropping;

        }

        //This is where the chip actually falls
        private void dropping(object sender, EventArgs e)
        {
            int dropL = chipSize * (board.gb.GetLength(1) - 1 - board.ColPieces(CurCol));
            int speed = 40;
            if (Canvas.GetTop(CurCir) < dropL)
            {
                Canvas.SetTop(CurCir, Canvas.GetTop(CurCir) + speed);
            }
            else
            {
                timer.Tick -= dropping;
                inputLock = false;

            }
        }

        private void Button_Click(int column)
        {
            if (inputLock == false)
            {
                bool success = board.Insert(CurSide, column);
                if (success)
                {
                    CurCol = column;
                    DrawCircle(CurSide, column);
                    AfterTurn();

                }

            }
        }

        //In this we determine if the game is over or not and if so who won and then count that in our textblock as well as display a messagebox
        private void AfterTurn()
        {
            Side winner = board.Winner();
            
            if (winner != Side.None)
            {
                if (Side.Player1 == winner)
                {
                    if (Int32.TryParse(redscoretxtblock.Text, NumberStyles.Integer, CultureInfo.CurrentCulture, out redCount) != null)
                    {
                        redCount = redCount + 1;
                        redscoretxtblock.Text = redCount.ToString(CultureInfo.CurrentCulture);
                        MessageBox.Show("Player 1 Wins!");
                    }

                }
                else if (Side.player2 == winner)
                {
                    if (Int32.TryParse(bluescoretxtblock.Text, NumberStyles.Integer, CultureInfo.CurrentCulture, out blackCount) != null)
                    {
                        blackCount = blackCount + 1;
                        bluescoretxtblock.Text = blackCount.ToString(CultureInfo.CurrentCulture);
                        MessageBox.Show("Player 2 Wins!");
                    }
                }
                StopButtons();

            }
            else if (board.Tie())
            {
                StopButtons();

            }
            else
            {
                CurSide = (CurSide == Side.player2) ? Side.Player1 : Side.player2;
            }

        }

        //stopping player from clicking the button
        public void StopButtons()
        {
            Button1.IsEnabled = false;
            Button2.IsEnabled = false;
            Button3.IsEnabled = false;
            Button4.IsEnabled = false;
            Button5.IsEnabled = false;
            Button6.IsEnabled = false;
            Button7.IsEnabled = false;
        }

        //enables the button
        public void WorkButton()
        {
            Button1.IsEnabled = true;
            Button2.IsEnabled = true;
            Button3.IsEnabled = true;
            Button4.IsEnabled = true;
            Button5.IsEnabled = true;
            Button6.IsEnabled = true;
            Button7.IsEnabled = true;
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            Button_Click(0);
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            Button_Click(1);
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            Button_Click(2);
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            Button_Click(3);
        }

        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            Button_Click(4);
        }

        private void Button6_Click(object sender, RoutedEventArgs e)
        {
            Button_Click(5);
        }

        private void Button7_Click(object sender, RoutedEventArgs e)
        {
            Button_Click(6);
        }




        private void ButtonRestart_Click(object sender, RoutedEventArgs e)
        {
            NewGame();
        }

        private void RedScore_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AfterTurn();
        }

        private void BlueScore_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AfterTurn();
        }

        private void NewGamebtn_Click(object sender, RoutedEventArgs e)
        {
            NewGame();
            redscoretxtblock.Text = string.Empty;
            bluescoretxtblock.Text = string.Empty;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int clickCounter = 0;

            do
            {
                if (redCount >= 3)
                {
                    if (CurSide == Side.player2)
                    {
                        clickCounter++;
                        AfterTurn();

                    }
                }

                if (blackCount >= 3)
                {

                    if (CurSide == Side.Player1)
                    {
                        
                        AfterTurn();

                    }
                }
                clickCounter++;

            } while (clickCounter == 0) ; 
          
            if(clickCounter > 0)
            {
                MessageBox.Show("Power up has already been used!");
            }
        }
    }
}
