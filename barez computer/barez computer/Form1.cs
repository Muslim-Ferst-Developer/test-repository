using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.IO;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Security.AccessControl;

namespace barez_computer
{
    public partial class Form1 : Form
    {
        SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine();
        //دیاریکردنی ناو بۆ بەکارهێنەر
        SpeechSynthesizer Muslim = new SpeechSynthesizer();

        SpeechRecognitionEngine startlistining = new SpeechRecognitionEngine();
        //بەکاردێت بۆ دیاری کردنی چەندوەڵامێک بەهەرەمەکی
        Random rnd = new Random();
        //کاتی خایەندراو بۆ وەڵام دانەوەی بەکارهێنەر
        int rectimeout = 0;
        //دیاری کردنی کات بە پێی ئێستا
        DateTime TimeNow = DateTime.Now;
        //هێنانی دەنگ بۆ کۆمپیتەرە
        WMPLib.WindowsMediaPlayer player = new WMPLib.WindowsMediaPlayer();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //بەکاردێت بۆ وەرگرتنی هەمو دەنگێکی جیا وازی بەکارهێنەر
            recognizer.SetInputToDefaultAudioDevice();
            //دیاری کردنی ئەوکۆماندانەی کەلە فۆرمەکە پیشانمان دەدات
            recognizer.LoadGrammar(new Grammar(new GrammarBuilder(new Choices(File.ReadAllLines(@"DefaultCommands.txt")))));
            recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(Default_speechRecognized);
            recognizer.SpeechDetected += new EventHandler<SpeechDetectedEventArgs>(recognizer_speechRecognized);
            recognizer.RecognizeAsync(RecognizeMode.Multiple);
            
            startlistining.SetInputToDefaultAudioDevice();
            //دیاریکردنی ئەوکۆماندانەی کە توانای وەڵام دانەوەی هەیە
            startlistining.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(File.ReadAllLines(@"DefaultCommands.txt")))));
            startlistining.SpeechRecognitionRejected += new EventHandler<SpeechRecognitionRejectedEventArgs>(startlistining_speechrcognized);
        }

        private void Default_speechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            //ئەم مەرجانە بەکار هاتون بۆ ناساندنی داوا کاریەکان
            int rannum;
            string speech = e.Result.Text;

            if (speech== "‌‌HI")
            {
                Muslim.SpeakAsync("How can i help youe");

            }
            if (speech == "What is Your Name")
            {
                Muslim.SpeakAsync("muslim");

            }
            

            if (speech == "quran")
            {
                Muslim.SpeakAsync("Ok");
               player.URL = @"C:\Users\SABAT\Music\Alafasy_Audio\nasrqatamy.mp3";

            }
            if (speech == "What time is it")
            {
                Muslim.SpeakAsync(DateTime.Now.ToString("h mm tt"));
            }
            if (speech=="Be quaet")
            {

                Muslim.SpeakAsyncCancelAll();
                rannum = rnd.Next(1,2);
                if (rannum==1)
                {
                   
                    Muslim.SpeakAsync("yes,sir");

                }
                else if (rannum == 2)
                {
                        Muslim.SpeakAsync("sorry,iam silent"); 
                }
            }
            if (speech=="thanks")
            {
                Muslim.SpeakAsync("iam at your service");
                recognizer.RecognizeAsyncCancel();
                startlistining.RecognizeAsync(RecognizeMode.Multiple);
            }

            if (speech=="show commands")
            {
                string[] commands = (File.ReadAllLines(@"DefaultCommands.txt"));
                lstcommands.Items.Clear();
                lstcommands.SelectionMode = SelectionMode.None;
                lstcommands.Visible = true;
                Muslim.SpeakAsync("OK");
                foreach (string command in commands)
                {
                    lstcommands.Items.Add(command);
                }

            }
            if (speech=="Hide commands")
            {
                Muslim.SpeakAsync("OK");
                lstcommands.Visible = false;
            }
            if (speech == "open google")
            {
                Muslim.SpeakAsync("OK");
                Process.Start("Http://www.google.com");


            }


            if (speech == "open youtube")
            {
                Muslim.SpeakAsync("OK");
                Process.Start("https://www.youtube.com/");

            }
            if (speech == "go to File")
            {
                Muslim.SpeakAsync("OK");
                Process.Start("C:\\Users\\SABAT");
            }



        }

        private void recognizer_speechRecognized(object sender, SpeechDetectedEventArgs e)
        {
            //دیاری کردنی کاتی وەڵامدانەوەکە
            rectimeout = 0;
        }

        private void startlistining_speechrcognized(object sender, SpeechRecognitionRejectedEventArgs e)
        {
            //ئاگادارکردنەوەی پاش وەستان لەکارکردن
            string speech = e.Result.Text;
            if (speech =="I needyou")
            {
                startlistining.RecognizeAsyncCancel();
                Muslim.SpeakAsync("Ask Me");
                recognizer.RecognizeAsync(RecognizeMode.Multiple);
            }
        }
        //کاتی ئەنجام دانی تەواوی کارەکان
        private void TmrSpiking_Tick(object sender, EventArgs e)
        {
            
            if (rectimeout==10)
            {
                recognizer.RecognizeAsyncCancel();
            }
            else if (rectimeout==11)
            {
                TmrSpiking.Stop();
                startlistining.RecognizeAsync(RecognizeMode.Multiple);
                rectimeout = 0;
            }



        }
    }
}
