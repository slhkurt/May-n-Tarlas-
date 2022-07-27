using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MayinTarlasi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int skor = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            MayinDoldur(10, 10);

            textBox1.Clear();
        }
        void MayinDoldur(int mayin, int boyut)
        {
            flowLayoutPanel1.Width = boyut * 30;
            flowLayoutPanel1.Height = boyut * 30;
            flowLayoutPanel1.Controls.Clear();
            int[] mayinlar = new int[mayin];
            Random rnd = new Random();

            for (int i = 0; i < mayin; i++)
            {
                int secilen = rnd.Next(0, boyut * boyut);
                if (mayinlar.Contains(secilen))
                {
                    i--;
                    continue;
                }
                mayinlar[i] = secilen;
            }

            for (int i = 0; i < boyut*boyut; i++)
            {
                Button btn = new Button();
                btn.Width = 30;
                btn.Height = 30;
                btn.Margin = new Padding(0);
                btn.Tag = mayinlar.Contains(i);
                btn.Click += btn_click;
                flowLayoutPanel1.Controls.Add(btn);
            }
        }

        private void btn_click(object sender, EventArgs e)
        {
            Button tiklanan = (Button)sender;
            bool durum = (bool)tiklanan.Tag;
            if (durum == true)
            {
                tiklanan.BackColor = Color.Red;
                OyunBitir();
            }
            else
            {
                tiklanan.BackColor = Color.Green;
                skor++;
                textBox1.Text = skor.ToString();
            }
        }

        void OyunBitir()
        {
            skor = 0;
            foreach (Button item in flowLayoutPanel1.Controls)
            {
                bool durum = (bool)item.Tag;
                if (durum)
                {
                    item.BackColor = Color.Red;
                }
                else
                {
                    item.BackColor = Color.Green;
                }
            }
            DialogResult sonuc =  MessageBox.Show("Oyun Bitti Yeniden Oynamak İstermisiniz?","Devam Etmek İstermisiniz?",MessageBoxButtons.YesNo);
            if (sonuc == DialogResult.Yes)
            {
                MayinDoldur(10, 10);
            }
        }
    }
}
