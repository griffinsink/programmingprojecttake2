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

namespace ConnectFour
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int chipSize = 80;

        private boardgame board;
        private bool inputLock;

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
            gameGrid.Children.Clear();
            

        }

        //private void Background()
        //{
        //    for(int row=0; row < board.Gameboard.GetLength(0); row++)
        //    {
        //        for(int column=0; column< board.Gameboard.GetLength(1); column++)
        //        {
        //            Rectangle square = new Rectangle();
        //            square.Height = chipSize;
        //            square.Width = chipSize;
                    
        //        }
        //    }
        //}

        private void DrawCircle(Side side, int col)
        {
            inputLock = true;
            Ellipse circle = new Ellipse();
            circle.Height = chipSize;
            circle.Width = chipSize;
            circle.Fill = (side == Side.Red) ? Brushes.RoyalBlue : Brushes.Crimson;
            Canvas.SetTop(circle, 0);
            Canvas.SetLeft(circle, col * 80);
            gameGrid.Children.Add(circle);
            CurrentCircle = circle;

        }
        
        private void Button_Click(int column)
        {
            if(inputLock == false)
            {
                bool success = board.Insert(currentSide, column);
                if (success)
                {
                    currentColumn = column;
                   
                }
                    
            }
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
    }
}
