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


       //private bool koniecGry;
        private bool ruchGraczaA;
        private bool GameEnd;

        private bool stop_act;
        DispatcherTimer dt = new DispatcherTimer();

        public Button[,] plansza;

        public int[,] array_game;

        public int[] records;

        private Gracz p1;

        private Gracz p2;

        public MainWindow()
        {
            InitializeComponent();
            playground();


            stop_act = false;
            //NewGame();

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

          
            ruchGraczaA = true;

            Player1Textbox.MaxLength = 20;
            Player2Textbox.MaxLength = 20;

        }


       
        

        private int i=0;
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (stop_act == false)
            {
                Start(sender, e);
            }
            if (i == 0) {
                stop_act = true;
            }
            /*
            if (GameEnd)
            {
               // NewGame();
                return;
            }
            */
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

                    Trace.WriteLine(b + "----------" + c);
                    Trace.WriteLine(array_game[b, c] + "----------wartosc");
                   
                    array_game[b, c] = 1;
                    Trace.WriteLine(array_game[b, c] + "-------po---wartosc");
                    Trace.WriteLine(b + "--------po--" + c);
                    
                   
              
                    clickedButton.Tag = false;
                 
                    ruchGraczaA = false;

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
                //    Trace.WriteLine(b + "----------" + c);
                 //   Trace.WriteLine(array_game[b, c] + "----------wartosc");
                    array_game[b, c] = 2;
                 //   Trace.WriteLine(array_game[b, c] + "------po----wartosc");
                  //  Trace.WriteLine(b + "--------po--" + c);
                   
                    clickedButton.Tag = true;
                    ruchGraczaA = true;
                    

                }
                
            }


            if (i == 25) {
                Trace.WriteLine("REMIS");
            }
            Sprawdz();
            //Start_stoper(sender, e);
        }


        private void Sprawdz()
        {

            #region Wiersze
            //Wiersze

            //Wiersz 0
            if ((array_game[0, 0] == 1) & (array_game[0, 1] == 1) & (array_game[0, 2] == 1) & (array_game[0, 3] == 1))
            {
                GameEnd = true;
                bt1_1.Background = Brushes.Red;
                bt1_2.Background = Brushes.Red;
                bt1_3.Background = Brushes.Red;
                bt1_4.Background = Brushes.Red;
            }

            if ((array_game[0, 0] == 2) & (array_game[0, 1] == 2) & (array_game[0, 2] == 2) & (array_game[0, 3] == 2))
            {
                GameEnd = true;
                bt1_1.Background = Brushes.Blue;
                bt1_2.Background = Brushes.Blue;
                bt1_3.Background = Brushes.Blue;
                bt1_4.Background = Brushes.Blue;
            }
            //Wiersz 0
            if ((array_game[0, 1] == 1) & (array_game[0, 2] == 1) & (array_game[0, 3] == 1) & (array_game[0, 4] == 1))
            {
                GameEnd = true;
                bt1_2.Background = Brushes.Red;
                bt1_3.Background = Brushes.Red;
                bt1_4.Background = Brushes.Red;
                bt1_5.Background = Brushes.Red;
            }

            if ((array_game[0, 1] == 2) & (array_game[0, 2] == 2) & (array_game[0, 3] == 2) & (array_game[0, 4] == 2))
            {
                GameEnd = true;
                bt1_2.Background = Brushes.Blue;
                bt1_3.Background = Brushes.Blue;
                bt1_4.Background = Brushes.Blue;
                bt1_5.Background = Brushes.Blue;
            }

            //Wiersz 1
            if ((array_game[1, 0] == 1) & (array_game[1, 1] == 1) & (array_game[1, 2] == 1) & (array_game[1, 3] == 1))
            {
                GameEnd = true;
                bt2_1.Background = Brushes.Red;
                bt2_2.Background = Brushes.Red;
                bt2_3.Background = Brushes.Red;
                bt2_4.Background = Brushes.Red;
            }

            if ((array_game[1, 0] == 2) & (array_game[1, 1] == 2) & (array_game[1, 2] == 2) & (array_game[1, 3] == 2))
            {
                GameEnd = true;
                bt2_1.Background = Brushes.Blue;
                bt2_2.Background = Brushes.Blue;
                bt2_3.Background = Brushes.Blue;
                bt2_4.Background = Brushes.Blue;
            }
            //Wiersz 1
            if ((array_game[1, 1] == 1) & (array_game[1, 2] == 1) & (array_game[1, 3] == 1) & (array_game[1, 4] == 1))
            {
                GameEnd = true;
                bt2_2.Background = Brushes.Red;
                bt2_3.Background = Brushes.Red;
                bt2_4.Background = Brushes.Red;
                bt2_5.Background = Brushes.Red;
            }

            if ((array_game[1, 1] == 2) & (array_game[1, 2] == 2) & (array_game[1, 3] == 2) & (array_game[1, 4] == 2))
            {
                GameEnd = true;
                bt2_2.Background = Brushes.Blue;
                bt2_3.Background = Brushes.Blue;
                bt2_4.Background = Brushes.Blue;
                bt2_5.Background = Brushes.Blue;
            }

            //Wiersz 2
            if ((array_game[2, 0] == 1) & (array_game[2, 1] == 1) & (array_game[2, 2] == 1) & (array_game[2, 3] == 1))
            {
                GameEnd = true;
                bt3_1.Background = Brushes.Red;
                bt3_2.Background = Brushes.Red;
                bt3_3.Background = Brushes.Red;
                bt3_4.Background = Brushes.Red;
            }

            if ((array_game[2, 0] == 2) & (array_game[2, 1] == 2) & (array_game[2, 2] == 2) & (array_game[2, 3] == 2))
            {
                GameEnd = true;
                bt3_1.Background = Brushes.Blue;
                bt3_2.Background = Brushes.Blue;
                bt3_3.Background = Brushes.Blue;
                bt3_4.Background = Brushes.Blue;
            }
            //Wiersz 2
            if ((array_game[2, 1] == 1) & (array_game[2, 2] == 1) & (array_game[2, 3] == 1) & (array_game[2, 4] == 1))
            {
                GameEnd = true;
                bt3_2.Background = Brushes.Red;
                bt3_3.Background = Brushes.Red;
                bt3_4.Background = Brushes.Red;
                bt3_5.Background = Brushes.Red;
            }

            if ((array_game[2, 1] == 2) & (array_game[2, 2] == 2) & (array_game[2, 3] == 2) & (array_game[2, 4] == 2))
            {
                GameEnd = true;
                bt3_2.Background = Brushes.Blue;
                bt3_3.Background = Brushes.Blue;
                bt3_4.Background = Brushes.Blue;
                bt3_5.Background = Brushes.Blue;
            }

            //Wiersz 3
            if ((array_game[3, 0] == 1) & (array_game[3, 1] == 1) & (array_game[3, 2] == 1) & (array_game[3, 3] == 1))
            {
                GameEnd = true;
                bt4_1.Background = Brushes.Red;
                bt4_2.Background = Brushes.Red;
                bt4_3.Background = Brushes.Red;
                bt4_4.Background = Brushes.Red;
            }

            if ((array_game[3, 0] == 2) & (array_game[3, 1] == 2) & (array_game[3, 2] == 2) & (array_game[3, 3] == 2))
            {
                GameEnd = true;
                bt4_1.Background = Brushes.Blue;
                bt4_2.Background = Brushes.Blue;
                bt4_3.Background = Brushes.Blue;
                bt4_4.Background = Brushes.Blue;
            }
            //Wiersz 3
            if ((array_game[3, 1] == 1) & (array_game[3, 2] == 1) & (array_game[3, 3] == 1) & (array_game[3, 4] == 1))
            {
                GameEnd = true;
                bt4_2.Background = Brushes.Red;
                bt4_3.Background = Brushes.Red;
                bt4_4.Background = Brushes.Red;
                bt4_5.Background = Brushes.Red;
            }

            if ((array_game[3, 1] == 2) & (array_game[3, 2] == 2) & (array_game[3, 3] == 2) & (array_game[3, 4] == 2))
            {
                GameEnd = true;
                bt4_2.Background = Brushes.Blue;
                bt4_3.Background = Brushes.Blue;
                bt4_4.Background = Brushes.Blue;
                bt4_5.Background = Brushes.Blue;
            }

            //Wiersz 4
            if ((array_game[4, 0] == 1) & (array_game[4, 1] == 1) & (array_game[4, 2] == 1) & (array_game[4, 3] == 1))
            {
                GameEnd = true;
                bt5_1.Background = Brushes.Red;
                bt5_2.Background = Brushes.Red;
                bt5_3.Background = Brushes.Red;
                bt5_4.Background = Brushes.Red;
            }

            if ((array_game[4, 0] == 2) & (array_game[4, 1] == 2) & (array_game[4, 2] == 2) & (array_game[4, 3] == 2))
            {
                GameEnd = true;
                bt5_1.Background = Brushes.Blue;
                bt5_2.Background = Brushes.Blue;
                bt5_3.Background = Brushes.Blue;
                bt5_4.Background = Brushes.Blue;
            }
            //Wiersz 4
            if ((array_game[4, 1] == 1) & (array_game[4, 2] == 1) & (array_game[4, 3] == 1) & (array_game[4, 4] == 1))
            {
                GameEnd = true;
                bt5_2.Background = Brushes.Red;
                bt5_3.Background = Brushes.Red;
                bt5_4.Background = Brushes.Red;
                bt5_5.Background = Brushes.Red;
            }

            if ((array_game[4, 1] == 2) & (array_game[4, 2] == 2) & (array_game[4, 3] == 2) & (array_game[4, 4] == 2))
            {
                GameEnd = true;
                bt5_2.Background = Brushes.Blue;
                bt5_3.Background = Brushes.Blue;
                bt5_4.Background = Brushes.Blue;
                bt5_5.Background = Brushes.Blue;
            }
            #endregion

            #region Kolumny
            //Kolumny

            //Kolumna 0
            if ((array_game[0, 0] == 1) & (array_game[1, 0] == 1) & (array_game[2, 0] == 1) & (array_game[3, 0] == 1))
            {
                GameEnd = true;
                bt1_1.Background = Brushes.Red;
                bt2_1.Background = Brushes.Red;
                bt3_1.Background = Brushes.Red;
                bt4_1.Background = Brushes.Red;
            }

            if ((array_game[0, 0] == 2) & (array_game[1, 0] == 2) & (array_game[2, 0] == 2) & (array_game[3, 0] == 2))
            {
                GameEnd = true;
                bt1_1.Background = Brushes.Blue;
                bt2_1.Background = Brushes.Blue;
                bt3_1.Background = Brushes.Blue;
                bt4_1.Background = Brushes.Blue;
            }
            //Kolumna 0
            if ((array_game[1, 0] == 1) & (array_game[2, 0] == 1) & (array_game[3, 0] == 1) & (array_game[4, 0] == 1))
            {
                GameEnd = true;
                bt2_1.Background = Brushes.Red;
                bt3_1.Background = Brushes.Red;
                bt4_1.Background = Brushes.Red;
                bt5_1.Background = Brushes.Red;
            }
            if ((array_game[1, 0] == 2) & (array_game[2, 0] == 2) & (array_game[3, 0] == 2) & (array_game[4, 0] == 2))
            {
                GameEnd = true;
                bt2_1.Background = Brushes.Blue;
                bt3_1.Background = Brushes.Blue;
                bt4_1.Background = Brushes.Blue;
                bt5_1.Background = Brushes.Blue;
            }

            //Kolumna 1
            if ((array_game[0, 1] == 1) & (array_game[1, 1] == 1) & (array_game[2, 1] == 1) & (array_game[3, 1] == 1))
            {
                GameEnd = true;
                bt1_2.Background = Brushes.Red;
                bt2_2.Background = Brushes.Red;
                bt3_2.Background = Brushes.Red;
                bt4_2.Background = Brushes.Red;
            }

            if ((array_game[0, 1] == 2) & (array_game[1, 1] == 2) & (array_game[2, 1] == 2) & (array_game[3, 1] == 2))
            {
                GameEnd = true;
                bt1_2.Background = Brushes.Blue;
                bt2_2.Background = Brushes.Blue;
                bt3_2.Background = Brushes.Blue;
                bt4_2.Background = Brushes.Blue;
            }
            //Kolumna 1
            if ((array_game[1, 1] == 1) & (array_game[2, 1] == 1) & (array_game[3, 1] == 1) & (array_game[4, 1] == 1))
            {
                GameEnd = true;
                bt2_2.Background = Brushes.Red;
                bt3_2.Background = Brushes.Red;
                bt4_2.Background = Brushes.Red;
                bt5_2.Background = Brushes.Red;
            }
            if ((array_game[1, 1] == 2) & (array_game[2, 1] == 2) & (array_game[3, 1] == 2) & (array_game[4, 1] == 2))
            {
                GameEnd = true;
                bt2_2.Background = Brushes.Blue;
                bt3_2.Background = Brushes.Blue;
                bt4_2.Background = Brushes.Blue;
                bt5_2.Background = Brushes.Blue;
            }

            //Kolumna 2
            if ((array_game[0, 2] == 1) & (array_game[1, 2] == 1) & (array_game[2, 2] == 1) & (array_game[3, 2] == 1))
            {
                GameEnd = true;
                bt1_3.Background = Brushes.Red;
                bt2_3.Background = Brushes.Red;
                bt3_3.Background = Brushes.Red;
                bt4_3.Background = Brushes.Red;
            }

            if ((array_game[0, 2] == 2) & (array_game[1, 2] == 2) & (array_game[2, 2] == 2) & (array_game[3, 2] == 2))
            {
                GameEnd = true;
                bt1_3.Background = Brushes.Blue;
                bt2_3.Background = Brushes.Blue;
                bt3_3.Background = Brushes.Blue;
                bt4_3.Background = Brushes.Blue;
            }
            //Kolumna 2
            if ((array_game[1, 2] == 1) & (array_game[2, 2] == 1) & (array_game[3, 2] == 1) & (array_game[4, 2] == 1))
            {
                GameEnd = true;
                bt2_3.Background = Brushes.Red;
                bt3_3.Background = Brushes.Red;
                bt4_3.Background = Brushes.Red;
                bt5_3.Background = Brushes.Red;
            }
            if ((array_game[1, 2] == 2) & (array_game[2, 2] == 2) & (array_game[3, 2] == 2) & (array_game[4, 2] == 2))
            {
                GameEnd = true;
                bt2_3.Background = Brushes.Blue;
                bt3_3.Background = Brushes.Blue;
                bt4_3.Background = Brushes.Blue;
                bt5_3.Background = Brushes.Blue;
            }

            //Kolumna 3
            if ((array_game[0, 3] == 1) & (array_game[1, 3] == 1) & (array_game[2, 3] == 1) & (array_game[3, 3] == 1))
            {
                GameEnd = true;
                bt1_4.Background = Brushes.Red;
                bt2_4.Background = Brushes.Red;
                bt3_4.Background = Brushes.Red;
                bt4_4.Background = Brushes.Red;
            }

            if ((array_game[0, 3] == 2) & (array_game[1, 3] == 2) & (array_game[2, 3] == 2) & (array_game[3, 3] == 2))
            {
                GameEnd = true;
                bt1_4.Background = Brushes.Blue;
                bt2_4.Background = Brushes.Blue;
                bt3_4.Background = Brushes.Blue;
                bt4_4.Background = Brushes.Blue;
            }
            //Kolumna 3
            if ((array_game[1, 3] == 1) & (array_game[2, 3] == 1) & (array_game[3, 3] == 1) & (array_game[4, 3] == 1))
            {
                GameEnd = true;
                bt2_4.Background = Brushes.Red;
                bt3_4.Background = Brushes.Red;
                bt4_4.Background = Brushes.Red;
                bt5_4.Background = Brushes.Red;
            }
            if ((array_game[1, 3] == 2) & (array_game[2, 3] == 2) & (array_game[3, 3] == 2) & (array_game[4, 3] == 2))
            {
                GameEnd = true;
                bt2_4.Background = Brushes.Blue;
                bt3_4.Background = Brushes.Blue;
                bt4_4.Background = Brushes.Blue;
                bt5_4.Background = Brushes.Blue;
            }

            //Kolumna 4
            if ((array_game[0, 4] == 1) & (array_game[1, 4] == 1) & (array_game[2, 4] == 1) & (array_game[3, 4] == 1))
            {
                GameEnd = true;
                bt1_5.Background = Brushes.Red;
                bt2_5.Background = Brushes.Red;
                bt3_5.Background = Brushes.Red;
                bt4_5.Background = Brushes.Red;
            }

            if ((array_game[0, 4] == 2) & (array_game[1, 4] == 2) & (array_game[2, 4] == 2) & (array_game[3, 4] == 2))
            {
                GameEnd = true;
                bt1_5.Background = Brushes.Blue;
                bt2_5.Background = Brushes.Blue;
                bt3_5.Background = Brushes.Blue;
                bt4_5.Background = Brushes.Blue;
            }
            //Kolumna 4
            if ((array_game[1, 4] == 1) & (array_game[2, 4] == 1) & (array_game[3, 4] == 1) & (array_game[4, 4] == 1))
            {
                GameEnd = true;
                bt2_5.Background = Brushes.Red;
                bt3_5.Background = Brushes.Red;
                bt4_5.Background = Brushes.Red;
                bt5_5.Background = Brushes.Red;
            }
            if ((array_game[1, 4] == 2) & (array_game[2, 4] == 2) & (array_game[3, 4] == 2) & (array_game[4, 4] == 2))
            {
                GameEnd = true;
                bt2_5.Background = Brushes.Blue;
                bt3_5.Background = Brushes.Blue;
                bt4_5.Background = Brushes.Blue;
                bt5_5.Background = Brushes.Blue;
            }
            #endregion

            #region Przekatne
            //Przekatne

            //Przekatna Lewa Gora - Prawy Dol
            if ((array_game[0, 0] == 1) & (array_game[1, 1] == 1) & (array_game[2, 2] == 1) & (array_game[3, 3] == 1))
            {
                GameEnd = true;
                bt1_1.Background = Brushes.Red;
                bt2_2.Background = Brushes.Red;
                bt3_3.Background = Brushes.Red;
                bt4_4.Background = Brushes.Red;
            }

            if ((array_game[0, 0] == 2) & (array_game[1, 1] == 2) & (array_game[2, 2] == 2) & (array_game[3, 3] == 2))
            {
                GameEnd = true;
                bt1_1.Background = Brushes.Blue;
                bt2_2.Background = Brushes.Blue;
                bt3_3.Background = Brushes.Blue;
                bt4_4.Background = Brushes.Blue;
            }
            //Przekatna Lewa Gora - Prawy Dol
            if ((array_game[1, 1] == 1) & (array_game[2, 2] == 1) & (array_game[3, 3] == 1) & (array_game[4, 4] == 1))
            {
                GameEnd = true;
                bt2_2.Background = Brushes.Red;
                bt3_3.Background = Brushes.Red;
                bt4_4.Background = Brushes.Red;
                bt5_5.Background = Brushes.Red;
            }
            if ((array_game[1, 1] == 2) & (array_game[2, 2] == 2) & (array_game[3, 3] == 2) & (array_game[4, 4] == 2))
            {
                GameEnd = true;
                bt2_2.Background = Brushes.Blue;
                bt3_3.Background = Brushes.Blue;
                bt4_4.Background = Brushes.Blue;
                bt5_5.Background = Brushes.Blue;
            }

            //Przekatna 1,0 4,3
            if ((array_game[1, 0] == 1) & (array_game[2, 1] == 1) & (array_game[3, 2] == 1) & (array_game[4, 3] == 1))
            {
                GameEnd = true;
                bt2_1.Background = Brushes.Red;
                bt3_2.Background = Brushes.Red;
                bt4_3.Background = Brushes.Red;
                bt5_4.Background = Brushes.Red;
            }

            if ((array_game[1, 0] == 2) & (array_game[2, 1] == 2) & (array_game[3, 2] == 2) & (array_game[4, 3] == 2))
            {
                GameEnd = true;
                bt2_1.Background = Brushes.Blue;
                bt3_2.Background = Brushes.Blue;
                bt4_3.Background = Brushes.Blue;
                bt5_4.Background = Brushes.Blue;
            }
            //Przekatna 0,1 3,4
            if ((array_game[0, 1] == 1) & (array_game[1, 2] == 1) & (array_game[2, 3] == 1) & (array_game[3, 4] == 1))
            {
                GameEnd = true;
                bt1_2.Background = Brushes.Red;
                bt2_3.Background = Brushes.Red;
                bt3_4.Background = Brushes.Red;
                bt4_5.Background = Brushes.Red;
            }
            if ((array_game[0, 1] == 2) & (array_game[1, 2] == 2) & (array_game[2, 3] == 2) & (array_game[3, 4] == 2))
            {
                GameEnd = true;
                bt1_2.Background = Brushes.Blue;
                bt2_3.Background = Brushes.Blue;
                bt3_4.Background = Brushes.Blue;
                bt4_5.Background = Brushes.Blue;
            }


            //Przekatna Prawa Gora - Lewy Dol
            if ((array_game[0, 4] == 1) & (array_game[1, 3] == 1) & (array_game[2, 2] == 1) & (array_game[3, 1] == 1))
            {
                GameEnd = true;
                bt1_5.Background = Brushes.Red;
                bt2_4.Background = Brushes.Red;
                bt3_3.Background = Brushes.Red;
                bt4_2.Background = Brushes.Red;
            }

            if ((array_game[0, 4] == 2) & (array_game[1, 3] == 2) & (array_game[2, 2] == 2) & (array_game[3, 1] == 2))
            {
                GameEnd = true;
                bt1_5.Background = Brushes.Blue;
                bt2_4.Background = Brushes.Blue;
                bt3_3.Background = Brushes.Blue;
                bt4_2.Background = Brushes.Blue;
            }
            //Przekatna Prawa Gora - Lewy Dol
            if ((array_game[1, 3] == 1) & (array_game[2, 2] == 1) & (array_game[3, 1] == 1) & (array_game[4, 0] == 1))
            {
                GameEnd = true;
                bt2_4.Background = Brushes.Red;
                bt3_3.Background = Brushes.Red;
                bt4_2.Background = Brushes.Red;
                bt5_1.Background = Brushes.Red;
            }
            if ((array_game[1, 3] == 2) & (array_game[2, 2] == 2) & (array_game[3, 1] == 2) & (array_game[4, 0] == 2))
            {
                GameEnd = true;
                bt2_4.Background = Brushes.Blue;
                bt3_3.Background = Brushes.Blue;
                bt4_2.Background = Brushes.Blue;
                bt5_1.Background = Brushes.Blue;
            }

            //Przekatna 0,3 3,0
            if ((array_game[0, 3] == 1) & (array_game[1, 2] == 1) & (array_game[2, 1] == 1) & (array_game[3, 0] == 1))
            {
                GameEnd = true;
                bt1_4.Background = Brushes.Red;
                bt2_3.Background = Brushes.Red;
                bt3_2.Background = Brushes.Red;
                bt4_1.Background = Brushes.Red;
            }

            if ((array_game[0, 3] == 2) & (array_game[1, 2] == 2) & (array_game[2, 1] == 2) & (array_game[3, 0] == 2))
            {
                GameEnd = true;
                bt1_4.Background = Brushes.Blue;
                bt2_3.Background = Brushes.Blue;
                bt3_2.Background = Brushes.Blue;
                bt4_1.Background = Brushes.Blue;
            }
            //Przekatna 1,4 4,1
            if ((array_game[1, 4] == 1) & (array_game[2, 3] == 1) & (array_game[3, 2] == 1) & (array_game[4, 1] == 1))
            {
                GameEnd = true;
                bt2_5.Background = Brushes.Red;
                bt3_4.Background = Brushes.Red;
                bt4_3.Background = Brushes.Red;
                bt5_2.Background = Brushes.Red;
            }
            if ((array_game[1, 4] == 2) & (array_game[2, 3] == 2) & (array_game[3, 2] == 2) & (array_game[4, 1] == 2))
            {
                GameEnd = true;
                bt2_5.Background = Brushes.Blue;
                bt3_4.Background = Brushes.Blue;
                bt4_3.Background = Brushes.Blue;
                bt5_2.Background = Brushes.Blue;
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
            Trace.WriteLine(array_game[0, 0] + "ciekawe");
            Trace.WriteLine(array_game[0, 1] + "ciekawe");
            Trace.WriteLine(array_game[0, 2] + "ciekawe");
            Trace.WriteLine(array_game[0, 3] + "ciekawe");
            Trace.WriteLine(array_game[0, 4] + "ciekawe");
            Trace.WriteLine(array_game[1, 0] + "ciekawe");
            Trace.WriteLine(array_game[1, 1] + "ciekawe");
            Trace.WriteLine(array_game[1, 2] + "ciekawe");
            Trace.WriteLine(array_game[1, 3] + "ciekawe");
            Trace.WriteLine(array_game[1, 4] + "ciekawe");
            Trace.WriteLine(array_game[2, 0] + "ciekawe");
            Trace.WriteLine(array_game[2, 1] + "ciekawe");
            Trace.WriteLine(array_game[2, 2] + "ciekawe");
            Trace.WriteLine(array_game[2, 3] + "ciekawe");
            Trace.WriteLine(array_game[2, 4] + "ciekawe");
            Trace.WriteLine(array_game[3, 0] + "ciekawe");
            Trace.WriteLine(array_game[3, 1] + "ciekawe");
            Trace.WriteLine(array_game[3, 2] + "ciekawe");
            Trace.WriteLine(array_game[3, 3] + "ciekawe");
            Trace.WriteLine(array_game[3, 4] + "ciekawe");
            Trace.WriteLine(increment + " TYLE CZASU");


            Trace.WriteLine(p1.Name +" gracz1  gracz1 " + p2.Name);


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            GameEnd = true;
            if(GameEnd == true)
            Stop(sender, e);
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
            /*
            public Zwyciestwo()
            {
                if (Win == true) {
                    return $"{Name}";
                }
            }
            */

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

           p1 = new Gracz(Player1Textbox.Text, false);
            p2 = new Gracz(Player2Textbox.Text, false);
        }
    }

}
