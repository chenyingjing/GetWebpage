using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
using System.IO;
using System.Threading;

//using Winista.Text.HtmlParser.Lex;


namespace GetWebpage
{
    public partial class Form1 : Form
    {
        Thread _crawlThread;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create("http://blog.csdn.net/");
                HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create("http://www.google.com");
                myRequest.Timeout = 1000;
                HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
                ////MessageBox.Show(myResponse.CharacterSet);
                StreamReader sr = new StreamReader(myResponse.GetResponseStream());
                string html = sr.ReadToEnd();
                MessageBox.Show(html);
                myResponse.Close();

                //WebClient aWebClient = new WebClient();
                //aWebClient.Encoding = Encoding.Default;
                //string html = aWebClient.DownloadString("http://blog.csdn.net/");
                //MessageBox.Show(html);
/*
                FolderBrowserDialog fb = new FolderBrowserDialog();
                DialogResult dr = fb.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    folerTextBox.Text = fb.SelectedPath;
                }
 */
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void goButton_Click(object sender, EventArgs e)
        {
            try
            {
                string urlString = urlTextBox.Text;
                string folder = folerTextBox.Text;
                string keywords = keywordTextBox.Text;
                Crawler crawler = new Crawler((int)maxLevelSelector.Value,
                    urlString, folder, keywords);
                crawler.finishCall = ThreadFinish;
                _crawlThread = new Thread(crawler.CrawlFromUrl);
                _crawlThread.Start();
                Process.Start("explorer.exe", folder);
                goButton.Enabled = false;
                stopButton.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ThreadFinish()
        {
            goButton.Enabled = true;
            MessageBox.Show("Finish");
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            goButton.Enabled = true;
            stopButton.Enabled = false;
            _crawlThread.Abort();
        }
    }
}
