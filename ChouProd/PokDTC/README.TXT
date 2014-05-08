                                                                                                                                  
                                        (NNN)                                                                                         
  (NNNNNNNNNN_                          `""N)              (NNNNNNNNN_.      (NNNNNNNNNNNNNN       .JNNNNNN_ N)                       
  `""NF"""""NNN.                           N)              `"NF"""""NNNL     (N"""""NF""""4N      JNNF"  "4NNN)                       
     N)       4N.                          N)                N)       4NL    (N     N)    (N     (NF        4N)                       
     N)        N)      .NNNNNNNL           N)   (NNNNN       N)        (N)   (N     N)    (N    .NN          N)                       
     N)       (N)     JNN"`  "4NN.         N)   `NNF""       N)         NN   (N     N)    (N    (N)                                   
     N)      _NN     NN)        NN)        N)  JNF           N)         (N          N)          (N                                    
     NNNNNNNNNF     (N)          NN        N).NN`            N)         (N          N)          (N                                    
     NF"""""`       (N           (N        NNNNL             N)         JN          N)          (N.                                   
     N)             (N.          JN        NF `NN.           N)         NN          N)          (N)                                   
     N)             `NL         .NF        N)   4NL          N)        JN)          N)           NN.          _.                      
     N)              4NN.      _NN`        N)    `NN.        N)      .NNF           N)            4NL       JNN)                      
  (NNNNNNNNN          `NNNL__NNNF       (NNN)    NNNNNN    (NNNNNNNNNNN`        NNNNNNNNN)         4NNNL_JNNNN`                       
  `"""""""""            "4NNNN"`        `"""`    """"""    `"""""""""           """""""""`           "4NNNN"`                         
                                                                                                                                      
PokDTC developped by Alexandre CHOUVELLON 2005/2007 under GPL licence.  





                                                                                                                                                                                                                                                           
PokDTC is a free Poker Hold'em game with AI written in C#. The network feature let you play against friends
and talk to them in a chat room.

!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!NEED Framework .NET. 2 or greater!!!!!!!!!!!!!!!!!!!!!!!!!!!!
!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

Future features:  stronger IA
                  

Next release   ?
                   


Need beta testers!
To contact me "  chouprod       @       gmail   .      com "
To get the code source  http://www.sourceforge.net/projects/chouprod  by downloading the last source package or browsing 
the CVS. 






************************HOW TO PLAY ?******************************

First of all, load or create your profil.
Click on "New Game" to begin a game with bots or on "Net or Lan Game" to connect or create a server.
You can change some properties as your name, type of Hold'em Poker, number of players (only if your are the host).... 
Rules are these of Poker Texas Hold'em.



************************WHAT IS THE TWO GAME MODES ?******
 
Hardcore mode :

    One of the IA is cheating and knows all opponent's cards, try to avoid bluffing with him!
    The goal of this mode is to detect the cheater and to deal with other players only.


Aggressive/Survival mode:

        When you select this option you will try to perform a score to get your name in the PokDTC Hall of Fame.
You can succeed if you takedown a lot of  opponents    (aggressive mode) or if you survive a long time(survival mode) or both.
Properties in this mode are not editable. 
When you are the only one staying at the table, 9 new opponents come to deal with you, that opens a new level.       


*****************HOW TO USE MY OWN SOUND?***********************************

You just have to put wav files you want, into appropriate folder in media one.
Each folder is linked to an action "RAISE/FOLD/SUCCESS/LOSE"...
INSULT files are played at random.
If you create funny/foreign sounds, contact me to share your files with other Pokdtc users. 
 example:

 " ./MEDIA/0/RAISE/action.wav" will concern the first  player when he will raise
 " ./MEDIA/3/LOSE/action.wav" will concern the 4th player when he will lose a hand.




*******************How to change Bots names ? *********************

Nothing easier ! Find IA_names.xml in pokdtc directory, "IA_names" folder.
Edit this file with worldpad for example and add    "<name>The Name I want to add  </name> "  after the others.
You can delete names you don't like. Try to kept more than 10 names in the file. 
 
DO NOT erase  
<?xml version="1.0" encoding="UTF-8"?>
<IA>
       <---   add names here       like   <name>Pokdtc Bot </name>

</IA>   <--  don't forget to add this one if you have deleted it before





**************How to enter into HALL OF FAME?****************

If you perform well (or not) in Aggressive/Survival Mode, a file is build with your scores.
Just send me by mail the file  with extension .xor without changing the name,
You can find it here 
Startup Path of Pokdtc  "\AggressiveMode\XXXXXXXXXXXX.xor"

Do not forget to add  [POKDTC] HALL OF FAME in the subject of the mail.
If you perform well you will see your name in the Hall Of Fame.
 http://chouprod.sourceforge.net







*****************  
***RLZ HISTORY***
*****************


09/05/07 PokDTC 0.86
		New features:
			Export Game events into Unicode txt
			Auto fold and auto check / call BB 
		Improvements:
		    "Splittable" bottom menu 
			Better AI  ( however not good enough)
			After Hardcore DTC mode, you are told which one was cheating.
			Clearer game events
			User documentation changed
			Welcome panel font fixed
			Menu reorganized
			Documentation Updated 
			
		


21/03/07 PokDTC 0.858 
         New features:
            User documentation
            Blinking box 
			Pause
			Showdowns stats
		 New graphs:
			New UI and cards due to crusher
			
		 Bugs fixed:
		  Ranking files in normal mode.
		  Stats first time opening
		  Windows overlapping
		  
			 
26/02/07 PokDTC 0.856 BETA TESTING  => New beta tester Crusher
		 Mail Sender embedded
		 New AI		 
		 Dynamic blinds  
		 Chrono by player
		 Game speed
		 Remove button Raise*3 in limit
		 New Sound features
		 Translation into English/French/German
		 Cards Pictures in game events
		 Avatar bugs fixed
		 Stats fixed 
		 Triple Raise button added
		 Bet pot button added
		 Playing with keyboard 
		 AI play more on heads up
		 Hand comparaison fixed
		 GUI changed 
		 Kick button on LAN game for host
		 key shortcuts
		 Voices option (mute)
		 Some tiny issues fixed
		 German translation by crusher 
	 
16/01/07 PokDTC 0.841
		 Can disabled speaker
		 Survival mode fixed 

09/01/07 PokDTC 0.84
		 Add speaker
		 bug fixed on straight flush thanks to KALI

12/11/06 PokDTC 0.83
         New IA motor
         Survival/Aggressive Mode added
         Online High Score Opened
         Bots names can be edited  
         Bug fixed on full evaluation (thx to Kjell )
	     First dealer is randomized
         Multipot process rewritten 
         IP is editable
         Add chatting with pressing return key
         Host does not need anymore to finish last
         
         
23/08/06 PokDTC 0.82
         Mode hardcore added


13/08/06 PokDTC 0.81
         Fix bugs in hand comparison   => thanks to gklein283 and tm91 for reporting
	     Source code released
 
02/07/06 PokDTC 0.8 
         Fix raise problem for network game

06/05/06 PokDTC 0.7 testing purpose with french voice
         Installer 
         New SOUND feature, you can personalize your sound.
         Fix hand comparaison bug 
         Fix raise problem for network game

12/06/05 PokDTC version 0.6 build 104 beta version 
         IA modified, some bugs fixed 

12/04/05 PokDTC version 0.6 build 101-103 beta version 
         Add table stats, odds, own avatar.
	     Add profile so you can follow your skills along your games.
         Waiting for beta testers to release 0.6 stable 

10/13/05 PokDTC version 0.5b
         Add new graphics, some bugs fixed, network feature enabled.  

10/10/05 PokDTC version 0.5a
         Add graphics, IA shows its hand if necessary, some bugs fixed, network feature not available 

10/02/05 PokDTC version 0.42abis
         Fix fatal error when you fold.
10/02/05 PokDTC version 0.42a
         Fix infinity loop when you win,  allow ante, show community cards in order.


10/02/05  Second Major PokDTC version 0.42
	  -New features :
            No/Pot/Limit Poker
		Properties are editable
	  -Others
		Client and server is on the same application
		All code sources have been rewritten
            A summary shows the winner hand and your best hand
	  -Fix
            Hand evaluation, raise ...
	  -Stuffs to do:
		IA to develop
		Make the close of the application cleaner 
            Add a time to wait 
            Disconnection does not crashed the game
		Make the summary working over the net  
             


09/14/05  PokDTC version 0.41 
		no more ALLin, Big bling can raise, auto scroll down, 
		names can be changed during the game   
          + some fix

09/10/05  Major release 0.4
	  -New features :
           Network game,  Chat.
	  -Fix:
	   AI are not so dumb,
           more stability.
           plenty of game bugs
          

08/23/05  PokDTC version 0.3   
08/20/05  PokDTC version 0.2
08/19/05  First Release    PokDTC version 0.1a   


  




