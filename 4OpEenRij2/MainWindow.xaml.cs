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

namespace _4OpEenRij2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    //methodes: winningCondition kan evt een publisher zijn waarop andere methods subscribed zijn
    //kleurjeton: moet beurtelings wisselen
    //rooster bijhouden in 2dimensionale list of array (2dim array? geneste array? geneste list?)

    public partial class MainWindow : Window
    {
        VierOpEenRij game;
        public int jetonKleur = 1;
        public bool kolomVol = false;
        public MainWindow()
        {
            InitializeComponent();
            newGame();
        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
            newGame();

        }
        public void newGame()
        {
            game = new VierOpEenRij();

            foreach (Control item in grid.Children)
            {

                if (item is TextBox)
                {
                    ((TextBox)item).Text = "";
                }
            }
        }

        private void btn0_Click(object sender, RoutedEventArgs e)
        {
            game.SteekJetonIn(0, jetonKleur, out kolomVol);
            if (kolomVol)
            {

            }
            else
            {
                tb
            }
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
