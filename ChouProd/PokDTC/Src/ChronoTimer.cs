
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
using System.Threading;
using System.Windows.Forms;
namespace poker
{
    /// <summary>
    /// implements a chrono
    /// </summary>
    public class ChronoTimer
    {
        private bool havePlayed = false;

        //avoid infinite loop due to timer
        private bool endOfgame = false;

        public bool EndOfgame
        {
            get { return endOfgame; }
            set { endOfgame = value; }
        }

        /// <summary>
        /// doit on afficher la clock?
        /// </summary>
        public bool HavePlayed
        {
            get { return havePlayed; }
            set
            {
                havePlayed = value; 
                if (value)
                {
                    this.currentTimeLeft = this.InitTimeLeft; 
                    
                }
               
            }
        }

        
        private delegate void DelegateControl(Control c);

        private int type_CHRONO; // 0  for chrono blinds,  1 for chrono joueurs

        public int Type_CHRONO
        {
            get { return type_CHRONO; }
            set { type_CHRONO = value; }
        }
        //affichage temps
        private Control control;
        /// <summary>
        /// assignes control to display time
        /// </summary>
        public Control Control
        {
            get { return control; }
            set { control = value; }
        }
        private Game game;

        public Game Game
        {
            get { return game; }
            set { game = value; }
        }
        private const int MINUTE = 60;
        int currentLessMinuteLeft = 60;

        int initTimeLeft = 0;

        public int InitTimeLeft
        {
            get { return initTimeLeft; }
            set { initTimeLeft = value; }
        }
        int currentTimeLeft = 0;


        public int TimeLeft
        {
            get { return currentTimeLeft; }
            set { currentTimeLeft = value; }
        }

    
        System.Threading.Timer timer;
        public ChronoTimer()
        {
            
        }
         ~ChronoTimer()
         {
            if(timer!=null)
                 timer.Dispose();
            
        }
        public ChronoTimer(Game g)
        {
          
         
            this.game = g;
        }
        TimerCallback timerDelegate;
        /// <summary>
        /// Start le chrono
        /// </summary>
        /// <param name="intervalle"></param>
        public void Start()
        {     if(timer!=null)
            timer.Dispose();
            timerDelegate = new TimerCallback(CheckStatus);
        
            timer = new System.Threading.Timer(timerDelegate, null, 0, 1000);
            
              
        
        
        }
        /// <summary>
        /// not yet implemented
        /// </summary>
        public void Stop()
        {
        


        }
        public void Change(int intervalle)
        {
           timerDelegate = new TimerCallback(CheckStatus);
            timer.Change(0, intervalle);



        }
        //test les secondes
        private void CheckStatus(object p){
            if (type_CHRONO!=0 && !havePlayed)
                return;





            currentTimeLeft--;
            if (currentTimeLeft < 0)
                return;

            if (currentTimeLeft == 0 )
            {
                if (type_CHRONO == 0)
                    this.game.IncreaseBlinds();
                else {
                  
                    this.game.MakeCurrentPlayerFold(this.game.CurrentPlayer);
                }
                currentTimeLeft = initTimeLeft;
                return;
            }

           

                switch (type_CHRONO)
                {
                    case 0:   
                  
                  
                        //currentLessMinuteLeft--;
                       
                            ShowTimeLeft();
                            //Changement affichage
                         //   currentLessMinuteLeft = MINUTE;
                            //affichage temps sur le control 
                    
                        
                        break;
                    case 1: 

                        //affichage temps si moins de 20 s restante

                        
                            ShowTimeLeft();
                          
                            //autoFOLD(); ( verifier que le joueur etait encore en lis
                       
                       
                        return;

                }
            
        
        }

        private void ShowTimeLeft()
        {
            if (endOfgame)
            {
                timer.Dispose();
                return;
            }
            try
            {
                object[] p = new object[1];
                p[0] = control;

                control.Invoke(new DelegateControl(ChangeText), p);
            }
            catch { }
        }


        private void ChangeText(Control c)
        {
            //temps en secondes
            if (TimeLeft > 60)
            {
                c.Text = TimeLeft/60 + " mn";
            }
            else{
                c.Text = TimeLeft  + " s";
            }
        }
    
    
    
    }




}
