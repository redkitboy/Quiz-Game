using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Quiz_Game
{
    public partial class Form1 : Form
    {
        static int sayac = 0;
        static int zamansayac = 0;
        List<Questions> sorularim = new List<Questions>
            {
                new Questions
                {
                    Qtext = "What is the capital of France?",
                    Correctanswer = "Paris",
                    Wronganswers = new string[] { "London", "Berlin", "Rome" }
                },
                new Questions
                {
                    Qtext = "What is 9 x 3?",
                    Correctanswer = "27",
                    Wronganswers = new string[] { "11", "49", "35" }
                },
                new Questions
                {
                    Qtext = "What is the color of the sky?",
                    Correctanswer = "Blue",
                    Wronganswers = new string[] { "Green", "Red", "Yellow" }
                },
                new Questions
                {
                    Qtext = "What is the capital of Japan?",
                    Correctanswer = "Tokyo",
                    Wronganswers = new string[] { "Kyoto", "Osaka", "Hiroshima" }
                },
                new Questions
                {
                    Qtext = "What is the largest planet in our Solar System?",
                    Correctanswer = "Jupiter",
                    Wronganswers = new string[] { "Earth", "Saturn", "Mars" }
                },
                new Questions
                {
                    Qtext = "Where was Euro 2024 Football Championship held?",
                    Correctanswer = "Germany",
                    Wronganswers = new string[] { "Sweden", "Brasil", "Poland" }
                }

            };
        static List<Button> myButtons = new List<Button>();
        static int myRandomNumber;
        static Button wrongButton = new Button();

        public Form1()
        {
            InitializeComponent();
            myButtons.Add(button1);
            myButtons.Add(button2);
            myButtons.Add(button3);
            myButtons.Add(button4);
            SoruGetir();
        }

        public void SoruGetir()
        {
            
            if(sayac<sorularim.Count)
            {
                label1.Text = sorularim[sayac].Qtext.ToString();
                Random random = new Random();
                myRandomNumber = random.Next(0, 4); // 0 dahil, 4 hariç
                Console.WriteLine("ŞİMDİ ŞANSLI SAYI: " + myRandomNumber);
                int yanlisSecnSay = 0;
                for (int i=0;i<myButtons.Count;i++)
                {
                    if(i != myRandomNumber)
                    {
                        myButtons[i].Click += new System.EventHandler(this.Button_Click);
                        myButtons[i].Text = sorularim[sayac].Wronganswers[yanlisSecnSay];
                        //Console.WriteLine(i +  "  numarali secenek hatali secenek şeklinde doldurdldu");
                        yanlisSecnSay++;
                    }
                }

                myButtons[myRandomNumber].Click += new System.EventHandler(this.Dogru_Click);
                myButtons[myRandomNumber].Text = sorularim[sayac].Correctanswer;
                Console.WriteLine("BEKLENEN CEVAP: "+myButtons[myRandomNumber].Text);
                
                sayac++;
                Console.WriteLine("\n \n");
                //Thread.Sleep(1000);
            } else
            {
                label2.Text = "Bütün soruları cevapladınız";
                label2.Visible = true;
            }

            
        }

        private void Button_Click(object sender, EventArgs e)
        {
            wrongButton = sender as Button;
            Console.WriteLine("YANLIŞ CEVAP");
            yanlisCevapFonk();
        }

        private void Dogru_Click(object sender, EventArgs e)
        {
            dogruTimer.Start();
            Console.WriteLine("DOĞRU CEVAP");
            label2.Text = "doğru cevap !";
            //label2.Visible=true;
            
            for (int i = 0; i < myButtons.Count; i++)
            {
                if (i != myRandomNumber)
                {
                    myButtons[i].Click -= new System.EventHandler(this.Button_Click);
                }
            }
            myButtons[myRandomNumber].Click -= new System.EventHandler(this.Dogru_Click);
            //myButtons[myRandomNumber].BackColor = Color.WhiteSmoke;
            //label2.Visible = false;
            
            



        }

        

        private void timer1_Tick(object sender, EventArgs e) // "dogruTimer" tick yaptığında çalışır
        {
            zamansayac++;
            if(zamansayac==2)
            {
                label2.Visible = true;
                myButtons[myRandomNumber].BackColor = Color.LawnGreen;
            }
            else if(zamansayac==10)
            {
                label2.Visible = false;
                zamansayac = 0;
                myButtons[myRandomNumber].BackColor= Color.WhiteSmoke;
                dogruTimer.Stop();
                //myButtons[myRandomNumber].(); butonun seçili olmasını iptal edeceğiz
                SoruGetir();

            }
        }



        public void yanlisCevapFonk()
        {
            label2.Text = "Yanlış Cevap!";
            yanlisTimer.Start();
            sayac = 0;
            for (int i = 0; i < myButtons.Count; i++)
            {
                if (i != myRandomNumber)
                {
                    myButtons[i].Click -= new System.EventHandler(this.Button_Click);
                }
            }
            myButtons[myRandomNumber].Click -= new System.EventHandler(this.Dogru_Click);


        }
        private void yanlisTimer_Tick(object sender, EventArgs e)
        {
            //Button wrongbutton = sender as Button;

            zamansayac++;
            if (zamansayac == 2)
            {
                wrongButton.BackColor = Color.Red;
                myButtons[myRandomNumber].BackColor = Color.LawnGreen;
            }
            else if (zamansayac == 10)
            {
                label2.Visible = false;
                zamansayac = 0;
                myButtons[myRandomNumber].BackColor = Color.WhiteSmoke;
                wrongButton.BackColor= Color.WhiteSmoke;
                yanlisTimer.Stop();
                SoruGetir();
            }
        }
    }
}
