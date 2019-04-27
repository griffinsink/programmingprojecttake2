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

namespace ConnectFour
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int chipSize = 40;

        private boardgame board;
        private bool inputLock;
        private DispatcherTimer timer;
        private Side currentSide;
        private Ellipse CurrentCircle;
        private int currentColumn;
        





        public MainWindow()
        {
            InitializeComponent();
            NewGame();
        }

        private void NewGame()
        {
            inputLock = true;
            board = new boardgame(6, 7);
            currentSide = Side.Red;
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 50);
            timer.Start();
            gameCanvas.Children.Clear();
            inputLock = false;
            //Background();
            WorkButton();

        }

        private void Background()
        {
            for (int row = 0; row < board.Gameboard.GetLength(0); row++)
            {
                for (int column = 0; column < board.Gameboard.GetLength(1); column++)
                {
                    Rectangle square = new Rectangle();
                    square.Height = chipSize;
                    square.Width = chipSize;
                    //square.Fill = (column % 2 == 0) ? Brushes.White : Brushes.WhiteSmoke;
                    Canvas.SetBottom(square, chipSize * row);
                    Canvas.SetRight(square, chipSize * column);
                    gameCanvas.Children.Add(square);

                }
            }
        }

        private void DrawCircle(Side side, int col)
        {
            inputLock = true;
            Ellipse circle = new Ellipse();
            circle.Height = chipSize;
            circle.Width = chipSize;
            circle.Fill = (side == Side.Black) ? Brushes.Red : Brushes.Black;
            Canvas.SetTop(circle, 0);
            Canvas.SetLeft(circle, col * 80);
            gameCanvas.Children.Add(circle);
            CurrentCircle = circle;
            timer.Tick += dropping;

        }

        private void dropping(object sender, EventArgs e)
        {
            int dropL = chipSize * (board.Gameboard.GetLength(1) - 1 - board.PiecesInCol(currentColumn));
            int speed = 40;
            if (Canvas.GetTop(CurrentCircle) < dropL)
            {
                Canvas.SetTop(CurrentCircle, Canvas.GetTop(CurrentCircle) + speed);
            }
            else
            {
                timer.Tick -= dropping;
                inputLock = false;

            }
        }

        private void Button_Click(int column)
        {
            if(inputLock == false)
            {
                bool success = board.Insert(currentSide, column);
                if (success)
                {
                    currentColumn = column;
                    DrawCircle(currentSide, column);
                    AfterTurn();
                   
                }
                    
            }
        }

        private void AfterTurn()
        {
            Side winner = board.Winner();
            int redCount = 0;
            int blackCount = 0;
            if(winner != Side.None)
            {
                if (Side.Red == winner)
                {
                    redCount++;
                    redScore
                    
                }
                else if (Side.Black == winner)
                {
                    
                    blackCount++;
                }
                StopButtons();
       
            }
            else if (board.Tie())
            {
                StopButtons();
                
            }
            else
            {
            currentSide = (currentSide == Side.Black) ? Side.Red : Side.Black;
            }

        }

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

            MessageBox.Show("Red wins!");
        }

        private void BlueScore_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AfterTurn();
            MessageBox.Show("Blue wins!");
        }
    }
}
