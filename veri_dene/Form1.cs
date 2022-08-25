using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
namespace veri_dene
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string adres = "https://razerid.razer.com/?client_id=63c74d17e027dc11f642146bfeeaee09c3ce23d8&redirect=https%3A%2F%2Fgold.razer.com%2F";
            WebRequest istek = HttpWebRequest.Create(adres); //adres alanındaki web isteği için oluştur.
            WebResponse cevap;
            cevap = istek.GetResponse();
            StreamReader donenbilgiler = new StreamReader(cevap.GetResponseStream());
            string gelendegerler = donenbilgiler.ReadToEnd();//gelen bilgiler ile birlikte donen bilgileri sonlandır.
            int baslıkbaslangic = gelendegerler.IndexOf("<title>") + 7; // başlık kaç karakterden oluşacak bilgisi 
            int baslıkbitisi = gelendegerler.Substring(baslıkbaslangic).IndexOf("</title>");
            string baslik = gelendegerler.Substring(baslıkbaslangic, baslıkbitisi);
            MessageBox.Show(baslik);

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();  // form2 göster diyoruz
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
