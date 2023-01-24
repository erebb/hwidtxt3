using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Net;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;


namespace Azoth
{
    public partial class Form1 : Form
    {
        [DllImport("User32.dll")]
        static extern int SetForegroundWindow(IntPtr point);
        public int v = 1;
        public Form1()
        {
            InitializeComponent();
        }
        // STATUS OTO GÜNCELLEME CROOSHAİR EKLE
        private void metroPanel1_Paint(object sender, PaintEventArgs e)
        {

            string hedef = "https://github.com/erebb/hwidtxt3/blob/main/gncl.txt"; //Buraya güncelleme sürümünü kontrol edecek adresi giriyorsunuz.
            WebRequest istek = HttpWebRequest.Create(hedef);
            WebResponse yanit;
            yanit = istek.GetResponse();
            StreamReader bilgiler = new StreamReader(yanit.GetResponseStream());
            string gelen = bilgiler.ReadToEnd();
            int baslangic = gelen.IndexOf("<p>") + 3;
            int bitis = gelen.Substring(baslangic).IndexOf("</p>");
            string gelenbilgileri = gelen.Substring(baslangic, bitis);
            v = Convert.ToInt16(gelenbilgileri);
            timer1.Start();
            timer1.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        Process p = Process.GetProcessesByName("Eren").FirstOrDefault();
        private void button1_Click(object sender, EventArgs e)
        {
            var mbs = new ManagementObjectSearcher("Select ProcessorId From Win32_processor");
            ManagementObjectCollection mbsList = mbs.Get();
            string id = "";
            foreach (ManagementObject maObject in mbsList)
            {
                id = maObject["ProcessorId"].ToString();
                break;
            }
            string da12 = "1";// her versiyon geldiğinde bunu artır güncelleme getirmek istedğiğnde sitedeki dosyayıda  de bir artır
            WebClient webc12 = new WebClient();
            var gncl1 = webc12.DownloadString("https://github.com/erebb/hwidtxt3/blob/main/gncl.txt");
            WebClient webc = new WebClient();
            var idler = webc.DownloadString("https://github.com/erebb/hwidtxt3/blob/main/hwid.txt");
                if (idler.Contains(id)) // Eğer sitemizdeki ID'lerde kullanıcının CPU ID'si varsa yapılacak işlem.
            {
                if (gncl1.Contains(da12))
                {
                    MessageBox.Show("Updated", ":)", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                else
                {
                    MessageBox.Show("New Version.", ":(", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    System.Diagnostics.Process.Start("https://github.com/erebb/hwidtxt3/raw/main/WizBot.exe");
                    Environment.Exit(0);
                }



                // Ekrana giriş başarılı yazdırıyoruz.
                WebClient client31 = new WebClient();
               
                MessageBox.Show("Please Wait Loading Script.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                WebClient client69 = new WebClient();
                client69.DownloadFile("https://s3.eu-central-1.amazonaws.com/blob-eu-central-1-nwsekq/sara/25/2517/25175f41-de68-46a0-a271-50f78727f7d6.bin?response-content-disposition=attachment%3B%20filename%3D%22WizBot.exe%22&response-content-type=application%2Fx-msdownload&X-Amz-Content-Sha256=UNSIGNED-PAYLOAD&X-Amz-Algorithm=AWS4-HMAC-SHA256&X-Amz-Credential=AKIA4DM2EY46SOWUMUP4%2F20230112%2Feu-central-1%2Fs3%2Faws4_request&X-Amz-Date=20230112T150407Z&X-Amz-SignedHeaders=host&X-Amz-Expires=1800&X-Amz-Signature=10dea0d56b6a28ad3609e205b46a0fef767be3acb3c851be1a13a4ae031c3254", "C:/Windows/Temp/WizBot.exe");
                Thread.Sleep(900);
                MessageBox.Show("Welcome.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Process process = new Process();
                
                process.StartInfo.FileName = @"C:/Windows/Temp/WizBot.exe";
               
                process.Start();
                Thread.Sleep(350);
                Process p = Process.GetProcessesByName("WizBot").FirstOrDefault();
                if (p != null)
                {
                    IntPtr h = p.MainWindowHandle;
                    SetForegroundWindow(h);
                    SendKeys.SendWait("316962135783928343201984213423412344324");
                    Thread.Sleep(1);
                    SendKeys.SendWait("{Enter}");
                }



            }
            else // Eğer yoksa yapılacak işlem.
            {
                // Ekrana giriş yapılamadı yazdırıyoruz.
                MessageBox.Show("Unregistered HWID", "!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            Random rand = new Random();
            int one = rand.Next(0, 255);
            int two = rand.Next(0, 255);
            int three = rand.Next(0, 255);
            int four = rand.Next(0, 255);
            button1.BackColor = Color.FromArgb(one, two, three, four);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var mbs = new ManagementObjectSearcher("Select ProcessorId From Win32_processor");
            ManagementObjectCollection mbsList = mbs.Get();
            string id = "";
            foreach (ManagementObject maObject in mbsList)
            {
                id = maObject["ProcessorId"].ToString();
                break;
            }

            textBox1.Text = id; // TextBox'a CPU ID'yi yazdırıyoruz.
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string b = "1";// her versiyon geldiğinde bunu artır güncelleme getirmek istedğiğnde siteden de bir artır
            WebClient webc1 = new WebClient();
            var gncl = webc1.DownloadString("https://hwid31.000webhostapp.com/gncl.txt");
            if (gncl.Contains(b)) // Eğer sitemizdeki ID'lerde kullanıcının CPU ID'si varsa yapılacak işlem.
            {
                MessageBox.Show("Updated.", "!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Güncelleme Varsa Güncelleyin Yoksa Ban Yersiniz
            }
            else // Eğer yoksa yapılacak işlem.
            {
                // Ekrana giriş başarılı yazdırıyoruz.
                MessageBox.Show("New Version.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Diagnostics.Process.Start("https://hwid31.000webhostapp.com/WizBot.exe");
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        // JUNK CODE GÜNCELLECEĞİNDE DEĞİŞTİR


    }
    }
