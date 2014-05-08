using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Threading;

using System.Runtime.InteropServices;  

namespace poker
{
    public partial class MediaPlayer : UserControl
    {
//        QuartzTypeLib.FilgraphManager graphManager =
//new QuartzTypeLib.FilgraphManager();
//        QuartzTypeLib.IMediaControl mc ;

        [DllImport("winmm.dll", SetLastError = true,
                                       CallingConvention = CallingConvention.Winapi)]
        static extern bool PlaySound(
            string pszSound,
            IntPtr hMod,
            SoundFlags sf);
        // Flags for playing sounds.  For this example, we are reading 
        // the sound from a filename, so we need only specify 
        // SND_FILENAME | SND_ASYNC
        [Flags]
        public enum SoundFlags : int
        {
            SND_SYNC = 0x0000,  // play synchronously (default) 
            SND_ASYNC = 0x0001,  // play asynchronously 
            SND_NODEFAULT = 0x0002,  // silence (!default) if sound not found 
            SND_MEMORY = 0x0004,  // pszSound points to a memory file
            SND_LOOP = 0x0008,  // loop the sound until next sndPlaySound 
            SND_NOSTOP = 0x0010,  // don't stop any currently playing sound 
            SND_NOWAIT = 0x00002000, // don't wait if the driver is busy 
            SND_ALIAS = 0x00010000, // name is a registry alias 
            SND_ALIAS_ID = 0x00110000, // alias is a predefined ID
            SND_FILENAME = 0x00020000, // name is file name 
            SND_RESOURCE = 0x00040004  // name is resource name or atom 
        }


        /// <summary>
        /// class to play sound 
        /// </summary>
        public MediaPlayer()
        {
            InitializeComponent();
         //mc=(QuartzTypeLib.IMediaControl)graphManager;
        }
        Form1 mainform;
        public Form1 MainForm
        {

            set { mainform = value; }
        }
        private string path2song;
      
        public void PlaySound(string med)
        {
            if (!File.Exists(med))
                return;
            path2song = med;
            //Thread th = new Thread(new ThreadStart(Play));
            //th.Start();


           Play();

        }
        public void PlaySoundASynchronous(string med)
        {
            if (med == "")
                return;
            path2song = med;
            //Thread th = new Thread(new ThreadStart(Play));
            //th.Start();


            PlayASynchronous();

        }
        private void PlayASynchronous()
        {
            string med = path2song;
            try
            {
                //WMPLib.IWMPMedia media = FindMedia(med);
                //go2 = false;
                //string state = this.axWindowsMediaPlayer1.playState.ToString();
                //if (state.CompareTo("wmppsReady") != 0)
                //    Thread.Sleep(5000); 
                //this.axWindowsMediaPlayer1.currentMedia = media;


                //while (!go2)
                //{

                //    Thread.Sleep(500);
                //}
                //while (!go) {

                //    Thread.Sleep(500);

                //}

                // Specify the file.
                // mc.RenderFile(med);

                // Start playing the audio asynchronously.
                //mc.Run();

                PlaySound(med, IntPtr.Zero,
                       SoundFlags.SND_FILENAME|SoundFlags.SND_ASYNC);
            }
            catch { return; }
        }
        private void Play()
        {
            string med= path2song;
            try
            {
                //WMPLib.IWMPMedia media = FindMedia(med);
                //go2 = false;
                //string state = this.axWindowsMediaPlayer1.playState.ToString();
                //if (state.CompareTo("wmppsReady") != 0)
                //    Thread.Sleep(5000); 
                //this.axWindowsMediaPlayer1.currentMedia = media;
              

                //while (!go2)
                //{

                //    Thread.Sleep(500);
                //}
                //while (!go) {

                //    Thread.Sleep(500);
                
                //}
  
                // Specify the file.
               // mc.RenderFile(med);
                
                // Start playing the audio asynchronously.
                //mc.Run();

                PlaySound(med, IntPtr.Zero,
                       SoundFlags.SND_FILENAME);
            }
            catch { return; }
        }

        //private WMPLib.IWMPMedia FindMedia(string st)
        //{

        //    if (File.Exists(st))

        //        return this.axWindowsMediaPlayer1.newMedia(st);
        //    else
        //        return this.axWindowsMediaPlayer1.newMedia("");

        //}
       // private bool go=true;
        //private bool go2 = true;
        //private void axWindowsMediaPlayer1_CurrentMediaItemAvailable(object sender, AxWMPLib._WMPOCXEvents_CurrentMediaItemAvailableEvent e)
        //{
        //    go2 = true;
        //}

        //private void axWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        //{
        //    string state = this.axWindowsMediaPlayer1.playState.ToString();
        //    if (state.CompareTo("wmppsReady") == 0)
        //        this.axWindowsMediaPlayer1.Ctlcontrols.play();
            
        //}
    }
}
