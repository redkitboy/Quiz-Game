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
        static int yanlisSayisi = 0;
        static int puansayac = 0;
        List<Questions> sorularim = new List<Questions>
{
    new Questions
    {
        Qtext = "Türkiye'nin başkenti neresidir?",
        Correctanswer = "Ankara",
        Wronganswers = new string[] { "İstanbul", "İzmir", "Bursa" },
        seviye = 1
    },
    new Questions
    {
        Qtext = "En büyük okyanus hangisidir?",
        Correctanswer = "Pasifik Okyanusu",
        Wronganswers = new string[] { "Atlas Okyanusu", "Hint Okyanusu", "Arktik Okyanusu" },
        seviye = 3
    },
    new Questions
    {
        Qtext = "Türkiye'nin en yüksek dağı hangisidir?",
        Correctanswer = "Ağrı Dağı",
        Wronganswers = new string[] { "Erciyes Dağı", "Kaçkar Dağı", "Uludağ" },
        seviye = 2
    },
    new Questions
    {
        Qtext = "İstanbul Boğazı hangi iki denizi birleştirir?",
        Correctanswer = "Marmara Denizi ve Karadeniz",
        Wronganswers = new string[] { "Ege Denizi ve Akdeniz", "Karadeniz ve Ege Denizi", "Marmara Denizi ve Akdeniz" },
        seviye = 2
    },
    new Questions
    {
        Qtext = "Türkiye'nin en uzun nehri hangisidir?",
        Correctanswer = "Kızılırmak",
        Wronganswers = new string[] { "Fırat Nehri", "Dicle Nehri", "Meriç Nehri" },
        seviye = 3
    },
    new Questions
    {
        Qtext = "Dünya'nın uydusu nedir?",
        Correctanswer = "Ay",
        Wronganswers = new string[] { "Güneş", "Venüs", "Mars" },
        seviye = 2
    },
    new Questions
    {
        Qtext = "Bir yıl kaç gündür?",
        Correctanswer = "365",
        Wronganswers = new string[] { "360", "364", "366" },
        seviye = 2
    },
    new Questions
    {
        Qtext = "En uzun süre tahtta kalan Osmanlı padişahı kimdir?",
        Correctanswer = "Kanuni Sultan Süleyman",
        Wronganswers = new string[] { "Fatih Sultan Mehmet", "Yavuz Sultan Selim", "II. Mahmud" },
        seviye = 3
    },
    new Questions
    {
        Qtext = "Rönesans hangi ülkede başlamıştır?",
        Correctanswer = "İtalya",
        Wronganswers = new string[] { "Fransa", "İngiltere", "İspanya" },
        seviye = 3
    },
    new Questions
    {
        Qtext = "Hangi gezegen halkalarıyla ünlüdür?",
        Correctanswer = "Satürn",
        Wronganswers = new string[] { "Mars", "Jüpiter", "Venüs" },
        seviye = 3
    },
    new Questions
    {
        Qtext = "Türkiye'nin en büyük gölü hangisidir?",
        Correctanswer = "Van Gölü",
        Wronganswers = new string[] { "Tuz Gölü", "Beyşehir Gölü", "Eğirdir Gölü" },
        seviye = 2
    },
    new Questions
    {
        Qtext = "Türkiye'nin ilk cumhurbaşkanı kimdir?",
        Correctanswer = "Mustafa Kemal Atatürk",
        Wronganswers = new string[] { "İsmet İnönü", "Celal Bayar", "Adnan Menderes" },
        seviye = 1
    },
    new Questions
    {
        Qtext = "Dünyanın en yüksek şelalesi hangisidir?",
        Correctanswer = "Angel Şelalesi",
        Wronganswers = new string[] { "Niagara Şelalesi", "Victoria Şelalesi", "Iguazu Şelalesi" },
        seviye = 3
    },
    new Questions
    {
        Qtext = "Hangi elementin kimyasal sembolü 'O'dur?",
        Correctanswer = "Oksijen",
        Wronganswers = new string[] { "Altın", "Gümüş", "Demir" },
        seviye = 2
    },
    new Questions
    {
        Qtext = "Dünya'nın en uzun nehri hangisidir?",
        Correctanswer = "Nil Nehri",
        Wronganswers = new string[] { "Amazon Nehri", "Yangtze Nehri", "Mississippi Nehri" },
        seviye = 3
    },
    new Questions
    {
        Qtext = "Türkçede en çok kullanılan harf hangisidir?",
        Correctanswer = "A",
        Wronganswers = new string[] { "E", "I", "O" },
        seviye = 3
    },
    new Questions
    {
        Qtext = "Yer çekimini keşfeden bilim insanı kimdir?",
        Correctanswer = "Isaac Newton",
        Wronganswers = new string[] { "Albert Einstein", "Galileo Galilei", "Nikola Tesla" },
        seviye = 2
    },
    new Questions
    {
        Qtext = "Dünya'nın en büyük çölü hangisidir?",
        Correctanswer = "Sahra Çölü",
        Wronganswers = new string[] { "Gobi Çölü", "Arabistan Çölü", "Kalahari Çölü" },
        seviye = 3
    },
    new Questions
    {
        Qtext = "Bir futbol maçında kaç oyuncu sahada olur (her iki takım toplamı)?",
        Correctanswer = "22",
        Wronganswers = new string[] { "20", "24", "18" },
        seviye = 2
    },
    new Questions
    {
        Qtext = "Türk Bayrağı'nın rengi nedir?",
        Correctanswer = "Kırmızı ve Beyaz",
        Wronganswers = new string[] { "Mavi ve Beyaz", "Yeşil ve Beyaz", "Kırmızı ve Siyah" },
        seviye = 1
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
            button5.Select();
        }

        public void SoruGetir()
        {
            if(yanlisSayisi<2)
            {
                Random random1 = new Random();
                sayac = random1.Next(0, sorularim.Count);
                if (sayac < sorularim.Count)
                {
                    label1.Text = sorularim[sayac].Qtext.ToString();
                    Random random = new Random();
                    myRandomNumber = random.Next(0, 4); // 0 dahil, 4 hariç
                    Console.WriteLine("ŞİMDİ ŞANSLI SAYI: " + myRandomNumber);
                    int yanlisSecnSay = 0;
                    for (int i = 0; i < myButtons.Count; i++)
                    {
                        if (i != myRandomNumber)
                        {
                            myButtons[i].Click += new System.EventHandler(this.Button_Click);
                            myButtons[i].Text = sorularim[sayac].Wronganswers[yanlisSecnSay];
                            //Console.WriteLine(i +  "  numarali secenek hatali secenek şeklinde doldurdldu");
                            yanlisSecnSay++;
                        }
                    }

                    myButtons[myRandomNumber].Click += new System.EventHandler(this.Dogru_Click);
                    myButtons[myRandomNumber].Text = sorularim[sayac].Correctanswer;
                    Console.WriteLine("BEKLENEN CEVAP: " + myButtons[myRandomNumber].Text);

                    sayac++;
                    Console.WriteLine("\n \n");
                    //Thread.Sleep(1000);
                }
                else
                {
                    label2.Text = "Bütün soruları cevapladınız";
                    label2.Visible = true;
                }
            } else
            {
                foreach(var item in myButtons)
                {
                    item.Visible = false;
                }
                label1.Visible = false;
                label2.Text = "2 Yanlış yaptınız ve oyun bitti.";
                label2.Visible=true;
                label3.Visible = true;
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
            puansayac++;
            label3.Text=puansayac.ToString() + " Puan topladınız.";
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
            else if(zamansayac==6)
            {
                label2.Visible = false;
                zamansayac = 0;
                myButtons[myRandomNumber].BackColor= Color.WhiteSmoke;
                dogruTimer.Stop();
                SoruGetir();
                button5.Select();

            }
        }



        public void yanlisCevapFonk()
        {
            yanlisSayisi++;
            label2.Text = "Yanlış Cevap!";
            yanlisTimer.Start();
            if(yanlisSayisi>1)
            {
                sayac = 0;
            }
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
            zamansayac++;
            if (zamansayac == 3)
            {
                label2.Visible=true;
                wrongButton.BackColor = Color.Red;
                myButtons[myRandomNumber].BackColor = Color.LawnGreen;
            }
            else if (zamansayac == 15)
            {
                label2.Visible = false;
                zamansayac = 0;
                myButtons[myRandomNumber].BackColor = Color.WhiteSmoke;
                wrongButton.BackColor= Color.WhiteSmoke;
                yanlisTimer.Stop();
                SoruGetir();
                button5.Select();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
