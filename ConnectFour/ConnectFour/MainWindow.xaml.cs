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
        





        public MainWindow()
        {
            InitializeComponent();
            NewGame();
        }

        private void NewGame()
        {
            inputLock = true;
            board = new boardgame(6, 7);


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
