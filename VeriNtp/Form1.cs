using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace VeriNtp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        long oncekiHaberSayi;
        private void Form1_Load(object sender, EventArgs e)
        {
            XmlTextReader veriOku = new XmlTextReader("https://tr.motor1.com/rss/make/bmw/");
            FileStream fadi = new FileStream("veri.txt",FileMode.Create,FileAccess.Write);
            StreamWriter wadi = new StreamWriter(fadi);

            while (veriOku.Read())
            {
                oncekiHaberSayi++;
                string veri;
                if (veriOku.Name=="title")
                {
                    veri = veriOku.ReadString().Trim();
                    listBox1.Items.Add(veri);
                }
                if (veriOku.Name == "description")
                {
                    veri = veriOku.ReadString().Trim();
                    listBox1.Items.Add(veri);
                }

                wadi.Close();
                fadi.Close();
            }
        
        
        
        
        }
                //Index numarasına göre seçim yapmaya çalışmıştım.

        private void timer1_Tick(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            XmlTextReader veriOku = new XmlTextReader("https://tr.motor1.com/rss/make/bmw/");
            FileStream fadi = new FileStream("veri.txt", FileMode.Open, FileAccess.Read);
            StreamReader wadi = new StreamReader(fadi);
            if (oncekiHaberSayi< fadi.Length)
            {
                MessageBox.Show("haber geldi");
            }
            while (veriOku.Read())
            {
                String veri;
                if (veriOku.Name == "title")
                {
                    veri = veriOku.ReadString().Trim();
                    listBox1.Items.Add(veri);
                   

                }
                if (veriOku.Name == "description")
                {
                    veri = veriOku.ReadString().Trim();
                    listBox1.Items.Add(veri);
                }

            }
            wadi.Close();
            fadi.Close();
        }
    }
}
