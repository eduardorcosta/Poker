/*This file is part of PokDTC developed by Alexandre CHOUVELLON.

PokDTC is free software; you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation; either version 2 of the License, or
(at your option) any later version.

PokDTC is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with PokDTC; if not, write to the Free Software
Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA
*/
using System;
using System.Collections.Generic;
using System.Text;
using SpeechLib;
namespace poker
{
    class AutoSpeech
    {
        SpeechVoiceSpeakFlags spFlags = SpeechVoiceSpeakFlags.SVSFlagsAsync;
        SpVoice voice;
        int voiceNumber = 0;
        public AutoSpeech() 
        {
            voice = new SpVoice();
            this.ChangeVoice(0);
            voice.Rate = 0;
        
        }
        public void ChangeToSync() {

            spFlags = SpeechVoiceSpeakFlags.SVSFDefault;
        }
        public void ChangeToASync()
        {

            spFlags = SpeechVoiceSpeakFlags.SVSFlagsAsync;
        }
        /// <summary>
        /// Object to make speech, choise MSMARY if found
        /// </summary>
        /// <param name="a">select voice</param>
        public AutoSpeech(int a)
        {
            voice = new SpVoice();
            this.ChangeVoice(a);
            voice.Rate = -2;

        }
        /// <summary>
        /// change voice
        /// </summary>
        /// <param name="a"></param>
        public void ChangeVoice(int a)
        { 
        int max = voice.GetVoices("","").Count;
        int i;
        for ( i = 0; i < max; i++)
        {
            if (voice.GetVoices("", "").Item(i).Id.Contains("MSMary"))
                break;
        }
        if(a>=max-1)
            a=max;
        if (a < 0)
            a = 0;
        try
        {
            voice.Voice = voice.GetVoices("", "").Item(i);
            voiceNumber = a;
            
        }
        catch { }
        }
        /// <summary>
        /// said something
        /// </summary>
        /// <param name="text"></param>
        public void Talk(string text)
        {
            try
            {
                voice.Speak(text, spFlags);
            }
            catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                
                }
        
        }


    }
}
