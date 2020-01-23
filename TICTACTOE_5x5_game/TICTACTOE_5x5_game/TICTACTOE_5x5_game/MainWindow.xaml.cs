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
using System.Diagnostics;
using System.Windows.Threading;

namespace TICTACTOE_5x5_game
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public bool koniecGry;

        private bool ruchGraczaA;

        private bool stop_act;

        DispatcherTimer dt = new DispatcherTimer();

        public Button[,] plansza;

        public int[,] array_game;

        public int[] records;

        private Gracz p1;

        private Gracz p2;

        private int i;

        public string imieWin;

        public int player1count;

        public int player2count;

        public MainWindow()
        {
            InitializeComponent();
            NewGame();
        }



        private void NewGame()
        {
            licz();
            koniecGry = false;
            playground();
            stop_act = false;
            ruchGraczaA = true;
            Player1Textbox.MaxLength = 17;
            Player2Textbox.MaxLength = 17;
            i = 0;
            for (var c = 1; c < 6; c++)
            {
                for (var d = 1; d < 6; d++)
                {
                    var nazwa = ("bt" + c + "_" + d);
                    Trace.WriteLine(nazwa);
                    var buttonik = (Button)this.FindName(nazwa);
                    buttonik.Content = "";
                    
                    var tak = (c - 1) + "." + (d - 1);
                    buttonik.Tag = tak;
                }
            }
        }

        private void playground()
        {
            plansza = new Button[5, 5] {
                                                 { bt1_1, bt1_2, bt1_3, bt1_4, bt1_5 },
                                                 { bt2_1, bt2_2, bt2_3, bt2_4, bt2_5 },
                                                 { bt3_1, bt3_2, bt3_3, bt3_4, bt3_5 },
                                                 { bt4_1, bt4_2, bt4_3, bt4_4, bt4_5 },
                                                 { bt5_1, bt5_2, bt5_3, bt5_4, bt5_5 },
                                                 };

            array_game = new int[5, 5]
                                            {
                                                 { 5, 5, 5, 5, 5 },
                                                 { 5, 5, 5, 5, 5 },
                                                 { 5, 5, 5, 5, 5 },
                                                 { 5, 5, 5, 5, 5 },
                                                 { 5, 5, 5, 5, 5 },
                                                                        };

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (stop_act == false)
            {
                Start(sender, e);
                Winner_text.Content = "";
                Winner.Content = "";
            }
            if (i == 0) {
                stop_act = true;
            }
            

            i++;
            Button clickedButton = (Button)sender;

            if (ruchGraczaA)
            {
                if ((clickedButton.Content).ToString() == "O" || (clickedButton.Content).ToString() == "X")
                {

                }
                else
                {
                 
                    string[] s = clickedButton.Tag.ToString().Split('.');
           
                    clickedButton.Content = "X";
                   
                    int b = Int32.Parse(s[0]);

                    int c = Int32.Parse(s[1]);

                    array_game[b, c] = 1;

                    clickedButton.Tag = false;
                 
                    ruchGraczaA = false;

                    Ruch.Content = "O";
                }
            }
            else {
                if ((clickedButton.Content).ToString() == "O" || (clickedButton.Content).ToString() == "X")
                {
                    
                }
                else
                {
                    string[] s = clickedButton.Tag.ToString().Split('.');
    
                    int b = Int32.Parse(s[0]);

                    int c = Int32.Parse(s[1]);

                    clickedButton.Content = "O";

                    array_game[b, c] = 2;

                    clickedButton.Tag = true;

                    ruchGraczaA = true;

                    Ruch.Content = "X";
                }
                
            }

            Sprawdz();

            
            if (koniecGry == true)
            {
                Winner_text.Content = "Wygrał: ";
                Stop(sender, e);
                NewGame();
            }
            if (i == 25)
            {
                koniecGry = true;
                Winner_text.Content = "REMIS";
            }
        }


        private void Sprawdz()
        {

            #region Wiersze
            //Wiersze

            //Wiersz 0
            if ((array_game[0, 0] == 1) & (array_game[0, 1] == 1) & (array_game[0, 2] == 1) & (array_game[0, 3] == 1))
            {
                player2count++;
                Winner.Content = p2.Name;
                koniecGry = true;
            }

            if ((array_game[0, 0] == 2) & (array_game[0, 1] == 2) & (array_game[0, 2] == 2) & (array_game[0, 3] == 2))
            {
                player1count++;
                Winner.Content = p1.Name;
                koniecGry = true;
            }
            //Wiersz 0
            if ((array_game[0, 1] == 1) & (array_game[0, 2] == 1) & (array_game[0, 3] == 1) & (array_game[0, 4] == 1))
            {
                player2count++;
                Winner.Content = p2.Name;
                koniecGry = true;
            }

            if ((array_game[0, 1] == 2) & (array_game[0, 2] == 2) & (array_game[0, 3] == 2) & (array_game[0, 4] == 2))
            {
                player1count++;
                Winner.Content = p1.Name;
                koniecGry = true;
            }

            //Wiersz 1
            if ((array_game[1, 0] == 1) & (array_game[1, 1] == 1) & (array_game[1, 2] == 1) & (array_game[1, 3] == 1))
            {
                player2count++;
                Winner.Content = p2.Name;
                koniecGry = true;
            }

            if ((array_game[1, 0] == 2) & (array_game[1, 1] == 2) & (array_game[1, 2] == 2) & (array_game[1, 3] == 2))
            {
                player1count++;
                Winner.Content = p1.Name;
                koniecGry = true;
            }
            //Wiersz 1
            if ((array_game[1, 1] == 1) & (array_game[1, 2] == 1) & (array_game[1, 3] == 1) & (array_game[1, 4] == 1))
            {
                player2count++;
                Winner.Content = p2.Name;
                koniecGry = true;
            }

            if ((array_game[1, 1] == 2) & (array_game[1, 2] == 2) & (array_game[1, 3] == 2) & (array_game[1, 4] == 2))
            {
                player1count++;
                Winner.Content = p1.Name;
                koniecGry = true;
            }

            //Wiersz 2
            if ((array_game[2, 0] == 1) & (array_game[2, 1] == 1) & (array_game[2, 2] == 1) & (array_game[2, 3] == 1))
            {
                player2count++;
                Winner.Content = p2.Name;
                koniecGry = true;
            }

            if ((array_game[2, 0] == 2) & (array_game[2, 1] == 2) & (array_game[2, 2] == 2) & (array_game[2, 3] == 2))
            {
                player1count++;
                Winner.Content = p1.Name;
                koniecGry = true;
            }
            //Wiersz 2
            if ((array_game[2, 1] == 1) & (array_game[2, 2] == 1) & (array_game[2, 3] == 1) & (array_game[2, 4] == 1))
            {
                player2count++;
                Winner.Content = p2.Name;
                koniecGry = true;
            }

            if ((array_game[2, 1] == 2) & (array_game[2, 2] == 2) & (array_game[2, 3] == 2) & (array_game[2, 4] == 2))
            {
                player1count++;
                Winner.Content = p1.Name;
                koniecGry = true;
            }

            //Wiersz 3
            if ((array_game[3, 0] == 1) & (array_game[3, 1] == 1) & (array_game[3, 2] == 1) & (array_game[3, 3] == 1))
            {
                player2count++;
                Winner.Content = p2.Name;
                koniecGry = true;
            }

            if ((array_game[3, 0] == 2) & (array_game[3, 1] == 2) & (array_game[3, 2] == 2) & (array_game[3, 3] == 2))
            {
                player1count++;
                Winner.Content = p1.Name;
                koniecGry = true;
            }
            //Wiersz 3
            if ((array_game[3, 1] == 1) & (array_game[3, 2] == 1) & (array_game[3, 3] == 1) & (array_game[3, 4] == 1))
            {
                player2count++;
                Winner.Content = p2.Name;
                koniecGry = true;
            }

            if ((array_game[3, 1] == 2) & (array_game[3, 2] == 2) & (array_game[3, 3] == 2) & (array_game[3, 4] == 2))
            {
                player1count++;
                Winner.Content = p1.Name;
                koniecGry = true;
            }

            //Wiersz 4
            if ((array_game[4, 0] == 1) & (array_game[4, 1] == 1) & (array_game[4, 2] == 1) & (array_game[4, 3] == 1))
            {
                player2count++;
                Winner.Content = p2.Name;
                koniecGry = true;
            }

            if ((array_game[4, 0] == 2) & (array_game[4, 1] == 2) & (array_game[4, 2] == 2) & (array_game[4, 3] == 2))
            {
                player1count++;
                Winner.Content = p1.Name;
                koniecGry = true;
            }
            //Wiersz 4
            if ((array_game[4, 1] == 1) & (array_game[4, 2] == 1) & (array_game[4, 3] == 1) & (array_game[4, 4] == 1))
            {
                player2count++;
                Winner.Content = p2.Name;
                koniecGry = true;
            }

            if ((array_game[4, 1] == 2) & (array_game[4, 2] == 2) & (array_game[4, 3] == 2) & (array_game[4, 4] == 2))
            {
                player1count++;
                Winner.Content = p1.Name;
                koniecGry = true;
            }
            #endregion

            #region Kolumny
            //Kolumny

            //Kolumna 0
            if ((array_game[0, 0] == 1) & (array_game[1, 0] == 1) & (array_game[2, 0] == 1) & (array_game[3, 0] == 1))
            {
                player2count++;
                Winner.Content = p2.Name;
                koniecGry = true;
            }

            if ((array_game[0, 0] == 2) & (array_game[1, 0] == 2) & (array_game[2, 0] == 2) & (array_game[3, 0] == 2))
            {
                player1count++;
                Winner.Content = p1.Name;
                koniecGry = true;
            }
            //Kolumna 0
            if ((array_game[1, 0] == 1) & (array_game[2, 0] == 1) & (array_game[3, 0] == 1) & (array_game[4, 0] == 1))
            {
                player2count++;
                Winner.Content = p2.Name;
                koniecGry = true;
            }
            if ((array_game[1, 0] == 2) & (array_game[2, 0] == 2) & (array_game[3, 0] == 2) & (array_game[4, 0] == 2))
            {
                player1count++;
                Winner.Content = p1.Name;
                koniecGry = true;
            }

            //Kolumna 1
            if ((array_game[0, 1] == 1) & (array_game[1, 1] == 1) & (array_game[2, 1] == 1) & (array_game[3, 1] == 1))
            {
                player2count++;
                Winner.Content = p2.Name;
                koniecGry = true;
            }

            if ((array_game[0, 1] == 2) & (array_game[1, 1] == 2) & (array_game[2, 1] == 2) & (array_game[3, 1] == 2))
            {
                player1count++;
                Winner.Content = p1.Name;
                koniecGry = true;
            }
            //Kolumna 1
            if ((array_game[1, 1] == 1) & (array_game[2, 1] == 1) & (array_game[3, 1] == 1) & (array_game[4, 1] == 1))
            {
                player2count++;
                Winner.Content = p2.Name;
                koniecGry = true;
            }
            if ((array_game[1, 1] == 2) & (array_game[2, 1] == 2) & (array_game[3, 1] == 2) & (array_game[4, 1] == 2))
            {
                player1count++;
                Winner.Content = p1.Name;
                koniecGry = true;
            }

            //Kolumna 2
            if ((array_game[0, 2] == 1) & (array_game[1, 2] == 1) & (array_game[2, 2] == 1) & (array_game[3, 2] == 1))
            {
                player2count++;
                Winner.Content = p2.Name;
                koniecGry = true;
            }

            if ((array_game[0, 2] == 2) & (array_game[1, 2] == 2) & (array_game[2, 2] == 2) & (array_game[3, 2] == 2))
            {
                player1count++;
                Winner.Content = p1.Name;
                koniecGry = true;
            }
            //Kolumna 2
            if ((array_game[1, 2] == 1) & (array_game[2, 2] == 1) & (array_game[3, 2] == 1) & (array_game[4, 2] == 1))
            {
                player2count++;
                Winner.Content = p2.Name;
                koniecGry = true;
            }
            if ((array_game[1, 2] == 2) & (array_game[2, 2] == 2) & (array_game[3, 2] == 2) & (array_game[4, 2] == 2))
            {
                player1count++;
                Winner.Content = p1.Name;
                koniecGry = true;
            }

            //Kolumna 3
            if ((array_game[0, 3] == 1) & (array_game[1, 3] == 1) & (array_game[2, 3] == 1) & (array_game[3, 3] == 1))
            {
                player2count++;
                Winner.Content = p2.Name;
                koniecGry = true;
            }

            if ((array_game[0, 3] == 2) & (array_game[1, 3] == 2) & (array_game[2, 3] == 2) & (array_game[3, 3] == 2))
            {
                player1count++;
                Winner.Content = p1.Name;
                koniecGry = true;
            }
            //Kolumna 3
            if ((array_game[1, 3] == 1) & (array_game[2, 3] == 1) & (array_game[3, 3] == 1) & (array_game[4, 3] == 1))
            {
                player2count++;
                Winner.Content = p2.Name;
                koniecGry = true;
            }
            if ((array_game[1, 3] == 2) & (array_game[2, 3] == 2) & (array_game[3, 3] == 2) & (array_game[4, 3] == 2))
            {
                player1count++;
                Winner.Content = p1.Name;
                koniecGry = true;
            }

            //Kolumna 4
            if ((array_game[0, 4] == 1) & (array_game[1, 4] == 1) & (array_game[2, 4] == 1) & (array_game[3, 4] == 1))
            {
                player2count++;
                Winner.Content = p2.Name;
                koniecGry = true;
            }

            if ((array_game[0, 4] == 2) & (array_game[1, 4] == 2) & (array_game[2, 4] == 2) & (array_game[3, 4] == 2))
            {
                player1count++;
                Winner.Content = p1.Name;
                koniecGry = true;
            }
            //Kolumna 4
            if ((array_game[1, 4] == 1) & (array_game[2, 4] == 1) & (array_game[3, 4] == 1) & (array_game[4, 4] == 1))
            {
                player2count++;
                Winner.Content = p2.Name;
                koniecGry = true;
            }
            if ((array_game[1, 4] == 2) & (array_game[2, 4] == 2) & (array_game[3, 4] == 2) & (array_game[4, 4] == 2))
            {
                player1count++;
                Winner.Content = p1.Name;
                koniecGry = true;
            }
            #endregion

            #region Przekatne
            //Przekatne

            //Przekatna Lewa Gora - Prawy Dol
            if ((array_game[0, 0] == 1) & (array_game[1, 1] == 1) & (array_game[2, 2] == 1) & (array_game[3, 3] == 1))
            {
                player2count++;
                Winner.Content = p2.Name;
                koniecGry = true;
            }

            if ((array_game[0, 0] == 2) & (array_game[1, 1] == 2) & (array_game[2, 2] == 2) & (array_game[3, 3] == 2))
            {
                player1count++;
                Winner.Content = p1.Name;
                koniecGry = true;
            }
            //Przekatna Lewa Gora - Prawy Dol
            if ((array_game[1, 1] == 1) & (array_game[2, 2] == 1) & (array_game[3, 3] == 1) & (array_game[4, 4] == 1))
            {
                player2count++;
                Winner.Content = p2.Name;
                koniecGry = true;
            }
            if ((array_game[1, 1] == 2) & (array_game[2, 2] == 2) & (array_game[3, 3] == 2) & (array_game[4, 4] == 2))
            {
                player1count++;
                Winner.Content = p1.Name;
                koniecGry = true;
            }

            //Przekatna 1,0 4,3
            if ((array_game[1, 0] == 1) & (array_game[2, 1] == 1) & (array_game[3, 2] == 1) & (array_game[4, 3] == 1))
            {
                player2count++;
                Winner.Content = p2.Name;
                koniecGry = true;
            }

            if ((array_game[1, 0] == 2) & (array_game[2, 1] == 2) & (array_game[3, 2] == 2) & (array_game[4, 3] == 2))
            {
                player1count++;
                Winner.Content = p1.Name;
                koniecGry = true;
            }
            //Przekatna 0,1 3,4
            if ((array_game[0, 1] == 1) & (array_game[1, 2] == 1) & (array_game[2, 3] == 1) & (array_game[3, 4] == 1))
            {
                player2count++;
                Winner.Content = p2.Name;
                koniecGry = true;
            }
            if ((array_game[0, 1] == 2) & (array_game[1, 2] == 2) & (array_game[2, 3] == 2) & (array_game[3, 4] == 2))
            {
                player1count++;
                Winner.Content = p1.Name;
                koniecGry = true;
            }


            //Przekatna Prawa Gora - Lewy Dol
            if ((array_game[0, 4] == 1) & (array_game[1, 3] == 1) & (array_game[2, 2] == 1) & (array_game[3, 1] == 1))
            {
                player2count++;
                Winner.Content = p2.Name;
                koniecGry = true;
            }

            if ((array_game[0, 4] == 2) & (array_game[1, 3] == 2) & (array_game[2, 2] == 2) & (array_game[3, 1] == 2))
            {
                player1count++;
                Winner.Content = p1.Name;
                koniecGry = true;
            }
            //Przekatna Prawa Gora - Lewy Dol
            if ((array_game[1, 3] == 1) & (array_game[2, 2] == 1) & (array_game[3, 1] == 1) & (array_game[4, 0] == 1))
            {
                player2count++;
                Winner.Content = p2.Name;
                koniecGry = true;
            }
            if ((array_game[1, 3] == 2) & (array_game[2, 2] == 2) & (array_game[3, 1] == 2) & (array_game[4, 0] == 2))
            {
                player1count++;
                Winner.Content = p1.Name;
                koniecGry = true;
            }

            //Przekatna 0,3 3,0
            if ((array_game[0, 3] == 1) & (array_game[1, 2] == 1) & (array_game[2, 1] == 1) & (array_game[3, 0] == 1))
            {
                player2count++;
                Winner.Content = p2.Name;
                koniecGry = true;
            }

            if ((array_game[0, 3] == 2) & (array_game[1, 2] == 2) & (array_game[2, 1] == 2) & (array_game[3, 0] == 2))
            {
                player1count++;
                Winner.Content = p1.Name;
                koniecGry = true;
            }
            //Przekatna 1,4 4,1
            if ((array_game[1, 4] == 1) & (array_game[2, 3] == 1) & (array_game[3, 2] == 1) & (array_game[4, 1] == 1))
            {
                player2count++;
                Winner.Content = p2.Name;
                koniecGry = true;
            }
            if ((array_game[1, 4] == 2) & (array_game[2, 3] == 2) & (array_game[3, 2] == 2) & (array_game[4, 1] == 2))
            {
                player1count++;
                Winner.Content = p1.Name;
                koniecGry = true;
            }

            #endregion
        }

        public void Start(object sender, RoutedEventArgs e)
        {
            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Tick += dtTicker;
            dt.Start();
        }

        private int increment = 0;
        private void dtTicker(object sender, EventArgs e)
        {
            increment++;
            TimerLabel.Content = increment.ToString();
        }
        private void Stop(object sender, RoutedEventArgs e)
        {
            dt.Stop();
        }

        public class Gracz
        {
            public string Name { get; set; }
            public bool Win { get; set; }
            public Gracz(string name, bool win)
            {
                Name = name;
                Win = win;
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

           p1 = new Gracz(Player2Textbox.Text, false);
           p2 = new Gracz(Player1Textbox.Text, false);
            gracz1.Content = p1.Name;
            gracz2.Content = p2.Name;
        }

        private void licz()
        {
            licznikp2.Content = player1count;
            licznikp1.Content = player2count;
        }


        }

}
