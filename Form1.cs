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
                    Qtext = "What is 2 + 2?",
                    Correctanswer = "4",
                    Wronganswers = new string[] { "3", "5", "6" }
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
                }

            };
        public Form1()
        {
            InitializeComponent();
            SoruGetir();
        }

        public void SoruGetir()
        {
            if(sayac<sorularim.Count)
            {
                Random random = new Random();
                int myRandomNumber = random.Next(0, 4); // 0 dahil, 4 hariç
                List<Button> myButtons = new List<Button> { button1,button2,button3,button4};
                Console.WriteLine("ŞİMDİ ŞANSLI SAYI: " + myRandomNumber);
                int yanlisSecnSay = 0;
                for (int i=0;i<myButtons.Count;i++)
                {
                    if(i != myRandomNumber)
                    {
                        myButtons[i].Click += new System.EventHandler(this.Button_Click);
                        myButtons[i].Text = sorularim[sayac].Wronganswers[yanlisSecnSay];
                        Console.WriteLine(i +  "  numarali secenek hatali secenek şeklinde doldurdldu");
                        yanlisSecnSay++;
                    }
                }

                myButtons[myRandomNumber].Click += new System.EventHandler(this.Dogru_Click);
                //myButtons[myRandomNumber].Text = sorularim[sayac].Correctanswer;
                Console.WriteLine("BEKLENEN CEVAP: "+myButtons[myRandomNumber].Text);
                
                sayac++;
            } else
            {
                label1.Text = "Bütün soruları cevapladınız";
            }

            
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Console.WriteLine("YANLIŞ CEVAP");
            yanlisCevapFonk();
        }

        private void Dogru_Click(object sender, EventArgs e)
        {
            Console.WriteLine("DOĞRU CEVAP");
            label2.Text = "Doğru Cevap !";
            label2.Visible = true;
            SoruGetir();
            Thread.Sleep(1000);
            label2.Visible = false;
            //button1 -= 
        }

        public void yanlisCevapFonk()
        {
            label2.Text = "Yanlış Cevap!";
            label2.Visible=true;
            sayac = 0;
            SoruGetir();
            Thread.Sleep(1000);
            label2.Visible = false;

        }
    }
}
