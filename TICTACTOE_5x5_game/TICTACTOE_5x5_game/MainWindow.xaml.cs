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

        public Button p1;
        public Button p2;
        public Button p3;
        public Button p4;
        public Button p5;

        public bool p1_1;
        public bool p1_1_1;
        public bool p1_1_1_1;
        public bool p1_1_1_1_1;


        DispatcherTimer dt = new DispatcherTimer();

        public Button[,] plansza;

        public int[,] array_game;



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
            
        }


       
        

        private int i=0;
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (stop_act == false)
            {
                Start(sender, e);
            }
            //Trace.WriteLine(stop_act + "lotka");
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
                    //Int32.Parse(s[1]);
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

            Sprawdz();
            //Start_stoper(sender, e);
        }
        

        private void Sprawdz()
        {
     
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
           

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            GameEnd = true;
            if(GameEnd == true)
            Stop(sender, e);
        }
    }
   
}
