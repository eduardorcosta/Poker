
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
using System.Globalization;
namespace poker
{
    /// <summary>
    /// allow translation of pokdtc in different languages
    /// default language is detected with localization 
    /// </summary>
    class Language
    {
        public  static double Version = 0.869;
        #region language definition
        /// <summary>
        /// 0     ENGLISH
        /// 1     GERMAN
        /// 2     FRENCH
        /// </summary>
        private static int currentLanguage = 0;
        /// <summary>
        /// english
        /// </summary>
        private   const int ENG = 0;
        /// <summary>
        /// english
        /// </summary>
        public static int ENG1
        {
            get { return ENG; }
        } 

        /// <summary>
        /// german
        /// </summary>
        private const int DE = 1;
        /// <summary>
        /// german
        /// </summary>
        public static int DE1
        {
            get { return DE; }
        } 

        /// <summary>
        /// french
        /// </summary>
        private const int FR = 2;
        /// <summary>
        /// french
        /// </summary>
        public static int FR1
        {
            get { return FR; }
        } 

        #endregion
        /// <summary>
        /// set current language
        /// </summary>
        /// 

        public static string MainContributors() 
        {

            return " Mister T, Crusher, Cc, Eliz";
        
        }
        public static int CurrentLanguage
        {
            get { return Language.currentLanguage; }
            set { Language.currentLanguage = value; }
        }

        public static void ChangeCurrentLanguage(string culture)
        {
            if (culture.Contains("fr"))
            {
                Language.currentLanguage = FR;
                return;
            }
            if (culture.Contains("en"))
            {
                Language.currentLanguage = ENG;
                return;
            }

            if (culture.Contains("de"))
            {
                Language.currentLanguage = DE;
                return;
            }
            Language.currentLanguage = ENG;
        }
        #region Button Translation
        /// <summary>
       /// Raise button text
       /// </summary>
       /// <returns></returns>
        public static string GetRaiseButton() 
        {
            switch (currentLanguage)
            {
                case ENG: return "Bet/Raise";
                case DE: return "Bet/Raise";
                case FR: return "Ouvrir/Relance";

            
            }

            return "Bet/Raise";
        }
        /// <summary>
        /// Call button Text
        /// </summary>
        /// <returns></returns>
        public static string GetCallButton()
        {
            switch (currentLanguage)
            {
                case ENG: return "Check/Call";
                case DE: return "Check/Call";
                case FR: return "Parole/Suivre";


            }

            return "Check/Call";
        }

        public static string GetAllInButton()
        {
            switch (currentLanguage)
            {
                case ENG: return "All In";
                case DE: return "All In";
                case FR: return "Tapis";


            }

            return "All In";
        }
        public static string GetFoldButton()
        {
            switch (currentLanguage)
            {
                case ENG: return "Fold";
                case DE: return "Fold";
                case FR: return "Couché";


            }

            return "Fold";
        }
        public static string GetTripleRaiseButton()
        {
            switch (currentLanguage)
            {
                case ENG: return "Raise*3";
                case DE: return "Raise*3";
                case FR: return "Relance*3";


            }

            return "Raise*3";
        }
        /// <summary>
        /// browse avatar button
        /// </summary>
        /// <returns></returns>
        public static string GetBrowseButton()
        {
            switch (currentLanguage)
            {
                case ENG: return "Browse";
                case DE: return "Bild wählen";
                case FR: return "Parcourir";


            }

            return "Browse";
        }
        /// <summary>
        /// browse avatar button
        /// </summary>
        /// <returns></returns>
        public static string GetSaveButton()
        {
            switch (currentLanguage)
            {
                case ENG: return "Save";
                case DE: return "Speichern";
                case FR: return "Sauver";


            }

            return "Save";
        }
        /// <summary>
        /// button send for chat
        /// </summary>
        /// <returns></returns>
        public static string GetSendButton()
        {
            switch (currentLanguage)
            {
                case ENG: return "Send";
                case DE: return "Senden";
                case FR: return "Envoyer";


            }

            return "Send";
        }
        /// <summary>
        /// button connect
        /// </summary>
        /// <returns></returns>
        public static string GetConnectButton()
        {
            switch (currentLanguage)
            {
                case ENG: return "connect";
                case DE: return "verbinden";
                case FR: return "connecter";


            }

            return "connect";
        }
        /// <summary>
        /// button connect
        /// </summary>
        /// <returns></returns>
        public static string GetOkButton()
        {
            switch (currentLanguage)
            {
                case ENG: return "Ok";
                case DE: return "Ok";
                case FR: return "Ok";


            }

            return "Ok";
        }
        /// <summary>
        /// button create profil
        /// </summary>
        /// <returns></returns>
        public static string GetCreateProfilButton()
        {
            switch (currentLanguage)
            {
                case ENG: return "Create profile";
                case DE: return "Erstelle ein Profil";
                case FR: return "Création de profil";


            }

            return "Create profile";
        }
        /// <summary>
        /// button load profil
        /// </summary>
        /// <returns></returns>
        public static string GetLoadProfilButton()
        {
            switch (currentLanguage)
            {
                case ENG: return "Load Profile";
                case DE: return "Lade Profil";
                case FR: return "Chargement de Profile";


            }

            return "Load Profile";
        }
        /// <summary>
        /// button save & Exit
        /// </summary>
        /// <returns></returns>
        public static string GetSaveAndExitButton()
        {
            switch (currentLanguage)
            {
                case ENG: return "Save & Exit";
                case DE: return "Speichern und Beenden";
                case FR: return "Sauver & Sortir";


            }

            return "Save & Exit";
        }
        /// <summary>
        /// button create host 
        /// </summary>
        /// <returns></returns>
        public static string GetCreateServerButton()
        {
            switch (currentLanguage)
            {
                case ENG: return "Create host";
                case DE: return "Create host";
                case FR: return "Creation du serveur";


            }

            return "Create host";
        }
        /// <summary>
        /// button create server 
        /// </summary>
        /// <returns></returns>
        public static string GetExitWithoutSavingButton()
        {
            switch (currentLanguage)
            {
                case ENG: return "Exit Without Saving";
                case DE: return "Beenden ohne zu speichern";
                case FR: return "Sortir sans sauvergarder";


            }

            return "Exit Without Saving";
        }
        /// <summary>
        /// button kick
        /// </summary>
        /// <returns></returns>
        public static string GetKickButton()
        {
            switch (currentLanguage)
            {
                case ENG: return "Kick from game";
                case DE: return "Aus dem Spiel werfen";
                case FR: return "Dégagez du jeu";


            }

            return "Kick from game";
        }


        #endregion

        #region title groupBox
        /// <summary>
        /// ip title
        /// </summary>
        /// <returns></returns>
        public static string GetIpTitle()
        {
            switch (currentLanguage)
            {
                case ENG: return "Ip";
                case DE: return "Ip";
                case FR: return "Ip";


            }

            return "Ip";
        
        }
        /// <summary>
        ///port title
        /// </summary>
        /// <returns></returns>
        public static string GetPortTitle()
        {
            switch (currentLanguage)
            {
                case ENG: return "Port";
                case DE: return "Port";
                case FR: return "Port";


            }

            return "Port";

        }
        /// <summary>
        ///Avatar title
        /// </summary>
        /// <returns></returns>
        public static string GetAvatarTitle()
        {
            switch (currentLanguage)
            {
                case ENG: return "Avatar";
                case DE: return "Bild";
                case FR: return "Avatar";


            }

            return "Avatar";

        }
        /// <summary>
        ///("The avatar will be copied to appropriate path");
        /// </summary>
        /// <returns></returns>
        public static string GetAvatarCopyBox()
        {
            switch (currentLanguage)
            {
                case ENG: return "The avatar will be copied to appropriate path" ;
                case DE: return "Der Avatar wird in den entsprechenden Pfad kopiert";
                case FR: return "L'avatar va être copié là où il faut" ;


            }

            return "The avatar will be copied to appropriate path";

        }
        /// <summary>
        ///"a player is out of money "
        /// </summary>
        /// <returns></returns>
        public static string GetPlayerIsOUtofMoneyTitle()
        {
            switch (currentLanguage)
            {
                case ENG: return "a player is out of money ";
                case DE: return "Ein Spieler hat kein Geld mehr  ";
                case FR: return "Un joueur à poil, un !";


            }

            return "a player is out of money ";

        }
        /// <summary>
        ///Name title
        /// </summary>
        /// <returns></returns>
        public static string GetNameTitle()
        {
            switch (currentLanguage)
            {
                case ENG: return "Name";
                case DE: return "Name";
                case FR: return "Nom";


            }

            return "Name";

        }
        /// <summary>
        ///Stats title
        /// </summary>
        /// <returns></returns>
        public static string GetStatsTitle()
        {
            switch (currentLanguage)
            {
                case ENG: return "Stats";
                case DE: return "Statistik";
                case FR: return "Stats";


            }

            return "Stats";

        }

                /// <summary>
        ///"you are out of money"
        /// </summary>
        /// <returns></returns>
        public static string GetYOutOfMoneyTitle()
        {
            switch (currentLanguage)
            {
                case ENG: return "you are out of money";
                case DE: return "Du hast kein Geld mehr";
                case FR: return "Vous êtes à sec";


            }

            return "you are out of money";

        }
        /// <summary>
        ///Game events title
        /// </summary>
        /// <returns></returns>
        public static string GetGameEventsTitle()
        {
            switch (currentLanguage)
            {
                case ENG: return "Game Events";
                case DE: return "Spiel Ablauf";
                case FR: return "Evenements du jeu";


            }

            return "Game Events";

        }
        /// <summary>
        ///Your choices
        /// </summary>
        /// <returns></returns>
        public static string GetYourChoiceTitle()
        {
            switch (currentLanguage)
            {
                case ENG: return "Your Choices";
                case DE: return "Aktionen";
                case FR: return "Vos choix";


            }

            return "Your Choices";

        }
        /// <summary>
        ///Value for calling
        /// </summary>
        /// <returns></returns>
        public static string GetValueForCallingTitle()
        {
            switch (currentLanguage)
            {
                case ENG: return "Calling value";
                case DE: return "Wert zum callen";
                case FR: return "Montant pour suivre";


            }

            return "Calling Value";

        }
        /// <summary>
        /// Chat
        /// </summary>
        /// <returns></returns>
        public static string GetChatTitle()
        {
            switch (currentLanguage)
            {
                case ENG: return "Chat";
                case DE: return "Chat";
                case FR: return "Chat";


            }

            return "Chat";

        }
        /// <summary>
        /// Pot
        /// </summary>
        /// <returns></returns>
        public static string GetPotTitle()
        {
            switch (currentLanguage)
            {
                case ENG: return "Pot";
                case DE: return "Pot";
                case FR: return "Pot";


            }

            return "Pot";

        }
        /// <summary>
        /// Player's profil
        /// </summary>
        /// <returns></returns>
        public static string GetPlayerProfilTitle()
        {
            switch (currentLanguage)
            {
                case ENG: return "Player's profile";
                case DE: return "Spieler Profil";
                case FR: return "Profil du joueur";


            }

            return "Player's profile";

        }
        /// <summary>
        /// Ante
        /// </summary>
        /// <returns></returns>
        public static string GetAnteTitle()
        {
            switch (currentLanguage)
            {
                case ENG: return "Ante";
                case DE: return "Einsatz";
                case FR: return "Ante";


            }

            return "Ante";

        }
        /// <summary>
        /// Blind
        /// </summary>
        /// <returns></returns>
        public static string GetBlindTitle()
        {
            switch (currentLanguage)
            {
                case ENG: return "Blind";
                case DE: return "Blind";
                case FR: return "Blind";


            }

            return "Blind";

        }
        /// <summary>
        /// BigBlind
        /// </summary>
        /// <returns></returns>
        public static string GetBigBlindTitle()
        {
            switch (currentLanguage)
            {
                case ENG: return "BigBlind";
                case DE: return "BigBlind";
                case FR: return "BigBlind";


            }

            return "BigBlind";

        }
        /// <summary>
        /// Type
        /// </summary>
        /// <returns></returns>
        public static string GetTypeTitle()
        {
            switch (currentLanguage)
            {
                case ENG: return "Type";
                case DE: return "Spielart";
                case FR: return "Type";


            }

            return "Type";

        }
        /// <summary>
        /// Limit Raise
        /// </summary>
        /// <returns></returns>
        public static string GetLimitRaiseTitle()
        {
            switch (currentLanguage)
            {
                case ENG: return "Limit Raise";
                case DE: return "Limit Raise";
                case FR: return "Limite Raise";


            }

            return "Limit Raise";

        }
        /// <summary>
        /// Number of players
        /// </summary>
        /// <returns></returns>
        public static string GetNumberOfPlayersTitle()
        {
            switch (currentLanguage)
            {
                case ENG: return "Number of players";
                case DE: return "Anzahl der Spieler";
                case FR: return "Nombre de joueurs";


            }

            return "Number of players";

        }

        /// <summary>
        /// Add row
        /// </summary>
        /// <returns></returns>
        public static string GetAddRow()
        {
            switch (currentLanguage)
            {
                case ENG: return "Add row";
                case DE: return "Add row";
                case FR: return "Ajout d'une ligne";


            }

            return "Add row";

        }
        /// <summary>
        /// Dynamic Blinds
        /// </summary>
        /// <returns></returns>
        public static string GetDynamicBlinds()
        {
            switch (currentLanguage)
            {
                case ENG: return "Dynamic Blinds";
                case DE: return "Dynamic Blinds";
                case FR: return "Blinds dynamiques";


            }

            return "Dynamic Blinds";

        }
        /// <summary>
        /// Activate Dynamic Blinds
        /// </summary>
        /// <returns></returns>
        public static string GetActivateDynamicBlinds()
        {
            switch (currentLanguage)
            {
                case ENG: return "Activate Dynamic Blinds";
                case DE: return "Activate Dynamic Blinds";
                case FR: return "Activez Blinds dynamiques";


            }

            return "Activate Dynamic Blinds";

        }

        /// <summary>
        /// Duration before increase in minute
        /// </summary>
        /// <returns></returns>
        public static string GetTimeBeforeIncreasing()
        {
            switch (currentLanguage)
            {
                case ENG: return "Duration before increase in minute";
                case DE: return "Duration before increase minute";
                case FR: return "Durée entre deux augmentations en min";


            }

            return "Duration before increase in minute";

        }

        /// <summary>
        /// Thought duration in seconde
        /// </summary>
        /// <returns></returns>
        public static string GetTime2Mind()
        {
            switch (currentLanguage)
            {
                case ENG: return "Thought duration in seconde";
                case DE: return "Thought duration in seconde";
                case FR: return "Durée de reflexion";


            }

            return "Thought duration in seconde";

        }

        /// <summary>
        /// Try to find the cheater
        /// </summary>
        /// <returns></returns>
        public static string GetTryToFind()
        {
            switch (currentLanguage)
            {
                case ENG: return "Try to find the cheater";
                case DE: return "Try to find the cheater";
                case FR: return "Détectez le tricheur!";


            }

            return "Try to find the cheater";

        }

        /// <summary>
        /// Try to survive and takedown a max of player
        /// </summary>
        /// <returns></returns>
        public static string GetTryToSurvive()
        {
            switch (currentLanguage)
            {
                case ENG: return "Try to survive and takedown a max of player";
                case DE: return "Try to survive and takedown a max of player";
                case FR: return "Essaiez de survivre tout en dégageant un max de joueurs";


            }

            return "Try to survive and takedown a max of player";

        }
        /// <summary>
        /// Start money
        /// </summary>
        /// <returns></returns>
        public static string GetStartMoneysTitle()
        {
            switch (currentLanguage)
            {
                case ENG: return "Bank roll";
                case DE: return "Startgeld";
                case FR: return "Argent de départ";


            }

            return "Bank roll";

        }
        /// <summary>
        /// Hardcore mode
        /// </summary>
        /// <returns></returns>
        public static string GetHardcoreModeTitle()
        {
            switch (currentLanguage)
            {
                case ENG: return "Hardcore mode";
                case DE: return "Hardcore Modus";
                case FR: return "DTC mode";


            }

            return "Hardcore mode";

        }
        /// <summary>
        /// Aggressive/Survival mode
        /// </summary>
        /// <returns></returns>
        public static string GetAggressiveSurvivalModeTitle()
        {
            switch (currentLanguage)
            {
                case ENG: return "Aggressive/Survival mode";
                case DE: return "Agressiver/Überlebens Modus";
                case FR: return "Aggressif/Survie mode";


            }

            return "Aggressive/Survival mode";

        }
        #endregion
        #region label
        /// <summary>
        /// Games Played
        /// </summary>
        /// <returns></returns>
        public static string GetGamesPlayedLabel()
        {
            switch (currentLanguage)
            {
                case ENG: return "Games Played";
                case DE: return "Partien gespielt";
                case FR: return "Parties jouées";


            }

            return "Games Played";

        }
        /// <summary>
        /// Flop/Hand
        /// </summary>
        /// <returns></returns>
        public static string GetFlopHandLabel()
        {
            switch (currentLanguage)
            {
                case ENG: return "Flop/Hand";
                case DE: return "Flop/Hand";
                case FR: return "Flop/Main";


            }

            return "Flop/Hand";

        }

        /// <summary>
        /// Takedowns
        /// </summary>
        /// <returns></returns>
        public static string GetTakedownsWonLabel()
        {
            switch (currentLanguage)
            {
                case ENG: return "Takedowns";
                case DE: return "Takedowns";
                case FR: return "Takedowns";


            }

            return "Takedowns";

        }
        /// <summary>
        /// Games won
        /// </summary>
        /// <returns></returns>
        public static string GetGamesWonLabel()
        {
            switch (currentLanguage)
            {
                case ENG: return "Games won";
                case DE: return "Partien gewonnen";
                case FR: return "Parties gagnées";


            }

            return "Games won";

        }
        /// <summary>
        /// Money won
        /// </summary>
        /// <returns></returns>
        public static string GetMoneyWonLabel()
        {
            switch (currentLanguage)
            {
                case ENG: return "Money won";
                case DE: return "Geld gewonnen";
                case FR: return "Argent gagné";


            }

            return "Money won";

        }
        /// <summary>
        /// AllIn/Won
        /// </summary>
        /// <returns></returns>
        public static string GetAllInWonLabel()
        {
            switch (currentLanguage)
            {
                case ENG: return "AllIn/Won";
                case DE: return "AllIn/Gewonnen";
                case FR: return "AllIn/Gagné";


            }

            return "AllIn/Won";

        }
        /// <summary>
        /// written by
        /// </summary>
        /// <returns></returns>
        public static string GetWrittenByWonLabel()
        {
            switch (currentLanguage)
            {
                case ENG: return "written by Alexandre Chouvellon under GPL terms 2005/2007";
                case DE: return "geschrieben von Alexandre Chouvellon unter GPL Konditionen 2005/2007";
                case FR: return "écrit par  Alexandre Chouvellon sous license GPL 2005/2007";


            }

            return "written by Alexandre Chouvellon under GPL terms 2005/2007";

        }
        /// <summary>
        /// Main contributors
        /// </summary>
        /// <returns></returns>
        public static string GetMainContriLabel()
        {
            switch (currentLanguage)
            {
                case ENG: return "Main contributors";
                case DE: return "Haupt Mitwirkende";
                case FR: return "Principaux contributeurs";


            }

            return "Main contributors";

        }
        /// <summary>
        /// Odds
        /// </summary>
        /// <returns></returns>
        public static string GetOddsLabel()
        {
            switch (currentLanguage)
            {
                case ENG: return "Odds";
                case DE: return "Odds";
                case FR: return "Chance";


            }

            return "Odds";

        }
        /// <summary>
        /// Won
        /// </summary>
        /// <returns></returns>
        public static string GetWonLabel()
        {
            switch (currentLanguage)
            {
                case ENG: return "Won";
                case DE: return "Gewonnen";
                case FR: return "gagné";


            }

            return "Won";

        }
        /// <summary>
        /// Pair
        /// </summary>
        /// <returns></returns>
        public static string GetPairLabel()
        {
            switch (currentLanguage)
            {
                case ENG: return "Pair";
                case DE: return "Paar";
                case FR: return "Paire";


            }

            return "Pair";

        }
        /// <summary>
        /// Double Pair
        /// </summary>
        /// <returns></returns>
        public static string Get2PairLabel()
        {
            switch (currentLanguage)
            {
                case ENG: return "Double Pair";
                case DE: return "Zwei Paare";
                case FR: return "Double Paire";


            }

            return "Double Pair";

        }
        /// <summary>
        /// Three of 
        /// </summary>
        /// <returns></returns>
        public static string GetThreeOfLabel()
        {
            switch (currentLanguage)
            {
                case ENG: return "Three of";
                case DE: return "Drilling";
                case FR: return "Brelan de";


            }

            return "Three of";

        }
        /// <summary>
        /// Three of a kind
        /// </summary>
        /// <returns></returns>
        public static string GetThreeOfKindLabel()
        {
            switch (currentLanguage)
            {
                case ENG: return "Three of a kind";
                case DE: return "Drilling";
                case FR: return "Brelan";


            }

            return "Three of a kind";

        }
        /// <summary>
        /// Four of 
        /// </summary>
        /// <returns></returns>
        public static string GetFourOfLabel()
        {
            switch (currentLanguage)
            {
                case ENG: return "Four of";
                case DE: return "Vierling";
                case FR: return "Carré de";


            }

            return "Four of";

        }
        /// <summary>
        /// Four of a kind
        /// </summary>
        /// <returns></returns>
        public static string GetFourOfKindLabel()
        {
            switch (currentLanguage)
            {
                case ENG: return "Four of a kind";
                case DE: return "Vierling";
                case FR: return "Carré";


            }

            return "Four of a kind";

        }
        /// <summary>
        /// straight
        /// </summary>
        /// <returns></returns>
        public static string GetStraightLabel()
        {
            switch (currentLanguage)
            {
                case ENG: return "straight";
                case DE: return "Strasse";
                case FR: return "Quinte";


            }

            return "straight";

        }
        /// <summary>
        /// Flush
        /// </summary>
        /// <returns></returns>
        public static string GetFlushLabel()
        {
            switch (currentLanguage)
            {
                case ENG: return "Flush";
                case DE: return "Flush";
                case FR: return "Couleur";


            }

            return "Flush";

        }
        /// <summary>
        /// FullHouse
        /// </summary>
        /// <returns></returns>
        public static string GetFullHouseLabel()
        {
            switch (currentLanguage)
            {
                case ENG: return "Full House";
                case DE: return "Full House";
                case FR: return "Full House";


            }

            return "FullHouse";

        }
        /// <summary>
        /// Royal Straight Flush
        /// </summary>
        /// <returns></returns>
        public static string GetRoyalStraightFlushLabel()
        {
            switch (currentLanguage)
            {
                case ENG: return "Royal Straight Flush";
                case DE: return "Royal Flush";
                case FR: return "Quinte Flush Royale";


            }

            return "Royal Straight Flush";

        }
        /// <summary>
        /// Straight Flush
        /// </summary>
        /// <returns></returns>
        public static string GetStraightFlushLabel()
        {
            switch (currentLanguage)
            {
                case ENG: return "Straight Flush";
                case DE: return "Straight Flush";
                case FR: return "Quinte Flush";


            }

            return "Straight Flush";

        }
        /// <summary>
        /// Generate files
        /// </summary>
        /// <returns></returns>
        public static string GetGenerateFilesLabel()
        {
            switch (currentLanguage)
            {
                case ENG: return "Generate files for Web High Score";
                case DE: return "Erstelle Dateien für die Internet High Score Liste";
                case FR: return "Générez les fichier pour le High score en ligne";


            }

            return "Generate files for Web High Score";

        }
        /// <summary>
        /// Try to survive and to realize the maximum of takedowns
        /// </summary>
        /// <returns></returns>
        public static string GetTryToLabel()
        {
            switch (currentLanguage)
            {
                case ENG: return "Try to survive and to realize the maximum of takedowns";
                case DE: return "Versuche zu bestehen und erziele die meisten Takedowns";
                case FR: return "Survivez et sortez un max de joueurs";


            }

            return "Try to survive and to realize the maximum of takedowns";

        }
        /// <summary>
        /// Properties are fixed
        /// </summary>
        /// <returns></returns>
        public static string GetPropAreFixedLabel()
        {
            switch (currentLanguage)
            {
                case ENG: return "Properties are fixed";
                case DE: return "Einstellungen nicht änderbar";
                case FR: return "Les propriétés du jeu sont fixés";


            }

            return "Properties are fixed";

        }
        /// <summary>
        /// Try to find the cheater 
        /// </summary>
        /// <returns></returns>
        public static string GetTryToFindTheCheaterLabel()
        {
            switch (currentLanguage)
            {
                case ENG: return "Try to find the cheater";
                case DE: return "Versuche den Betrüger zu finden";
                case FR: return "Repérez le tricheur";


            }

            return "Try to find the cheater";

        }
        /// <summary>
        /// Player
        /// </summary>
        /// <returns></returns>
        public static string GetPlayerLabel()
        {
            switch (currentLanguage)
            {
                case ENG: return "Player";
                case DE: return "Spieler";
                case FR: return "Joueur";


            }

            return "Player";

        }
        /// <summary>
        /// Money
        /// </summary>
        /// <returns></returns>
        public static string GetMoneyLabel()
        {
            switch (currentLanguage)
            {
                case ENG: return "Money";
                case DE: return "Geld";
                case FR: return "Money";


            }

            return "Money";

        }
        /// <summary>
        /// Flop/Hand/Won
        /// </summary>
        /// <returns></returns>
        public static string GetFlopHandWonLabel()
        {
            switch (currentLanguage)
            {
                case ENG: return "Flop/Hand/Won";
                case DE: return "Flop/Hand/Won";
                case FR: return "Flop/Main/Gagné";


            }

            return "Flop/Hand/Won";

        }
        /// <summary>
        /// AllIns/Won
        /// </summary>
        /// <returns></returns>
        public static string GetAllInsWonLabel()
        {
            switch (currentLanguage)
            {
                case ENG: return "AllIns/Won";
                case DE: return "AllIns/Gewonnen";
                case FR: return "AllIns/Gagné";


            }

            return "AllIns/Won";

        }
        /// <summary>
        /// Showdowns/Won
        /// </summary>
        /// <returns></returns>
        public static string GetShowdownsWonLabel()
        {
            switch (currentLanguage)
            {
                case ENG: return "Showdowns/Won";
                case DE: return "Showdowns/Gewonnen";
                case FR: return "Showdowns/Gagné";


            }

            return "Showdowns/Won";

        }
        /// <summary>
        /// Takedowns
        /// </summary>
        /// <returns></returns>
        public static string GetTakedownsLabel()
        {
            switch (currentLanguage)
            {
                case ENG: return "Takedowns";
                case DE: return "Takedowns";
                case FR: return "Takedowns";


            }

            return "Takedowns";

        }
        /// <summary>
        /// Welcome to PokDTC 
        /// </summary>
        /// <returns></returns>
        public static string GetWelcomeToLabel()
        {
            switch (currentLanguage)
            {
                case ENG: return "Welcome to PokDTC";
                case DE: return "Willkommen zu PokDTC" ;
                case FR: return "Bienvenue sur PokDTC";


            }

            return "Welcome to PokDTC";

        }
        /// <summary>
        /// Create your profile, follow your stats and perform your skills
        /// </summary>
        /// <returns></returns>
        public static string GetCreateYourPLabel()
        {
            switch (currentLanguage)
            {
                case ENG: return "Create your profile, follow your stats and perform your skills";
                case DE: return "Erstelle ein Profil, beobachte Deine Statistik und verbessere Deine Fähigkeiten";
                case FR: return "Créer votre profil, suivez l'évolution de vos stats et améliorez vous";


            }

            return "Create your profile, follow your stats and perform your skills";

        }
        /// <summary>
        /// Play poker with friends over LAN/NET or against virtual players
        /// </summary>
        /// <returns></returns>
        public static string GetPlayPokerLabel()
        {
            switch (currentLanguage)
            {
                case ENG: return "Play poker with friends over LAN/NET or against virtual players";
                case DE: return "Spiele mit Freunden Poker über LAN/Netzwerk oder gegen virtuelle Spieler";
                case FR: return "Jouer au poker avec vos amis au bureau, chez vous ou en amphi via LAN/NET ou contre des bots";


            }

            return "Play poker with friends over LAN/NET or against virtual players";

        }
        /// <summary>
        /// Try Survival mode and access to the Hall of Fame on web
        /// </summary>
        /// <returns></returns>
        public static string GetTryLabel()
        {
            switch (currentLanguage)
            {
                case ENG: return "Try Survival mode and access to the Hall of Fame on web";
                case DE: return "Probiere den Überlebensmodus und erreiche einen Eintrag in der Hall of Fame im Web";
                case FR: return "Tentez le mode survie pour entrer dans le high score";


            }

            return "Probiere den Überlebensmodus und erreiche einen Eintrag in der Hall of Fame im Web";

        }
        /// <summary>
        /// See my whereabouts in "about" menu.
        /// </summary>
        /// <returns></returns>
        public static string GetSeeMyAddress()
        {
            switch (currentLanguage)
            {
                case ENG: return "See my whereabouts in \"About\" menu";
                case DE: return "See my whereabouts in \"About\" menu";
                case FR: return "Mes coordonnées sont dans le menu \"A propos\" ";


            }

            return "See my whereabouts in \"About\" menu";

        }
        /// <summary>
        /// Download last version 
        /// </summary>
        /// <returns></returns>
        public static string GetDownloadLast()
        {
            switch (currentLanguage)
            {
                case ENG: return "Download last version";
                case DE: return "Download last version";
                case FR: return "Téléchargez la dernière version";
            }
            return "Download last version";

        }
        /// <summary>
        /// Send your comments to chouprod@gmail.com
        /// </summary>
        /// <returns></returns>
        public static string GetSendyourComLabel()
        {
            switch (currentLanguage)
            {
                case ENG: return "Send your comments to chouprod@gmail.com";
                case DE: return "Schicke Deine Kommentare an chouprod@gmail.com";
                case FR: return "Envoyez toutes critiques à chouprod@gmail.com";


            }

            return "Send your comments to chouprod@gmail.com";

        }
        /// <summary>
        /// Developed under GPL terms by Alexandre Chouvellon
        /// </summary>
        /// <returns></returns>
        public static string GetDevByLabel()
        {
            switch (currentLanguage)
            {
                case ENG: return "Developed under GPL terms by Alexandre Chouvellon";
                case DE: return "Entwickelt unter GPL Benutzungsbedingungen von Alexandre Chouvellon";
                case FR: return "Développé sous licence GPL par Alexandre Chouvellon";


            }

            return "Developed under GPL terms by Alexandre Chouvellon";

        }
        /// <summary>
        /// Developed under GPL terms by Alexandre Chouvellon
        /// </summary>
        /// <returns></returns>
        public static string GetDevUnderLabel()
        {
            switch (currentLanguage)
            {
                case ENG: return "Developed under GPL terms by Alexandre Chouvellon";
                case DE: return "Entwickelt unter GPL Benutzungsbedingungen von Alexandre Chouvellon";
                case FR: return "Développé sous licence GPL par Alexandre Chouvellon";


            }

            return "Developed under GPL terms by Alexandre Chouvellon";

        }
        #endregion
        #region window title

        /// <summary>
        /// Connection
        /// </summary>
        /// <returns></returns>
        public static string GetConnectionWinTitle()
        {
            switch (currentLanguage)
            {
                case ENG: return "Connection";
                case DE: return "Verbindung";
                case FR: return "Connexion";


            }

            return "Connection";

        }
        /// <summary>
        /// Let's play Poker
        /// </summary>
        /// <returns></returns>
        public static string GetLetsplayPokerWinTitle()
        {
            switch (currentLanguage)
            {
                case ENG: return "Let's play Poker";
                case DE: return "Let's play Poker";
                case FR: return "Let's play Poker";


            }

            return "Let's play Poker";

        }
        /// <summary>
        /// Properties
        /// </summary>
        /// <returns></returns>
        public static string GetPropertiesWinTitle()
        {
            switch (currentLanguage)
            {
                case ENG: return "Properties";
                case DE: return "Einstellungen";
                case FR: return "Properties";


            }

            return "Properties";

        }
        /// <summary>
        /// Server
        /// </summary>
        /// <returns></returns>
        public static string GetServerWinTitle()
        {
            switch (currentLanguage)
            {
                case ENG: return "Server";
                case DE: return "Server";
                case FR: return "Server";


            }

            return "Server";

        }
        /// <summary>
        /// Stats
        /// </summary>
        /// <returns></returns>
        public static string GetStatsWinTitle()
        {
            switch (currentLanguage)
            {
                case ENG: return "Stats";
                case DE: return "Statistik";
                case FR: return "Stats";


            }

            return "Stats";

        }
        #endregion
       
        #region Game Events

        /// <summary>
        /// wins the pot other players fold
        /// </summary>
        /// <returns></returns>
        public static string GetWinsThePotEvents()
        {
            switch (currentLanguage)
            {
                case ENG: return "wins the pot other players fold";
                case DE: return "wins the pot other players fold";
                case FR: return "remporte le pot les autres joueurs se sont couchés";


            }

            return "wins the pot other players fold";

        }


        /// <summary>
        /// and won
        /// </summary>
        /// <returns></returns>
        public static string GetAndWonEvents()
        {
            switch (currentLanguage)
            {
                case ENG: return "and won";
                case DE: return "und gewinnt";
                case FR: return "et gagne";


            }

            return "and won";

        }


        /// <summary>
        /// wins with
        /// </summary>
        /// <returns></returns>
        public static string GetWinsWithEvents()
        {
            switch (currentLanguage)
            {
                case ENG: return "wins with";
                case DE: return "gewinnt mit";
                case FR: return "gagne avec";


            }

            return "wins with";

        }
 

        /// <summary>
        /// Blinds have changed
        /// </summary>
        /// <returns></returns>
        public static string GetBlindsChangedEvents()
        {
            switch (currentLanguage)
            {
                case ENG: return "Blinds have raised";
                case DE: return "Die Blinds wurden erhöht";
                case FR: return "Les Blinds ont changé";


            }

            return "Blinds have changed";

        }
        public static string GetMucks()
        {
            switch (currentLanguage)
            {
                case ENG: return "mucks";
                case DE: return "mucks";
                case FR: return "ne montre pas";


            }

            return "mucks";

        }
        /// <summary>
        /// Pot split
        /// </summary>
        /// <returns></returns>
        public static string GetPotSplitEvents()
        {
            switch (currentLanguage)
            {
                case ENG: return "Split Pot";
                case DE: return "Split Pot";
                case FR: return "Partage du pot";


            }

            return "Pot split";

        }
        /// <summary>
        /// recovers his
        /// </summary>
        /// <returns></returns>
        public static string GetRecoversHisEvents()
        {
            switch (currentLanguage)
            {
                case ENG: return "recovers his";
                case DE: return "erhält seine";
                case FR: return "récupere ses";
            }

            return "recovers his";

        }

                /// <summary>
        /// "connexion lost with host"
        /// </summary>
        /// <returns></returns>
        public static string GetConnectionLostEvents()
        {
            switch (currentLanguage)
            {
                case ENG: return "connection lost with host";
                case DE: return "Verbindung zum Host verloren";
                case FR: return "connexion perdu avec l'hote";
            }

            return "connexion lost with host";

        }
        /// <summary>
        /// pays the SB
        /// </summary>
        /// <returns></returns>
        public static string GetPaysSBEvents2()
        {
            switch (currentLanguage)
            {
                case ENG: return "pays the SB";
                case DE: return "zahlt den SB";
                case FR: return "paie la SB";
            }

            return "pays the SB";

        }
        /// <summary>
        /// "pays a part of the BB";
        /// </summary>
        /// <returns></returns>
        public static string GetPaysPartBBEvents()
        {
            switch (currentLanguage)
            {
                case ENG: return "pays a part of the BB";
                case DE: return "zahlt den parten BB";
                case FR: return "paie une part de la BB";
            }

            return "pays a part of the BB";

        }
        /// <summary>
        /// "pays a part ofthe SB";
        /// </summary>
        /// <returns></returns>
        public static string GetPaysPartSBEvents()
        {
            switch (currentLanguage)
            {
                case ENG: return "pays a part of the SB";
                case DE: return "zahlt den parten SB";
                case FR: return "paie une part de la  SB";
            }

            return "pays a part of the SB";

        }
        /// <summary>
        /// pays the BB
        /// </summary>
        /// <returns></returns>
        public static string GetPaysBBEvents2()
        {
            switch (currentLanguage)
            {
                case ENG: return "pays the BB";
                case DE: return "zahlt den  BB";
                case FR: return "paie la BB";
            }

            return "pays the BB";

        }
        /// <summary>
        /// pays the small blind
        /// </summary>
        /// <returns></returns>
        public static string GetPaysSBEvents()
        {
            switch (currentLanguage)
            {
                case ENG: return "pays the SB";
                case DE: return "zahlt den SB";
                case FR: return "paie la SB";
            }

            return "pays the small blind";

        }
        /// <summary>
        /// pays the big blind
        /// </summary>
        /// <returns></returns>
        public static string GetPaysBBEvents()
        {
            switch (currentLanguage)
            {
                case ENG: return "pays the BB";
                case DE: return "zahlt den BB";
                case FR: return "paie la BB";
            }

            return "pays the BB";

        }

        /// <summary>
        /// Small blind
        /// </summary>
        /// <returns></returns>
        public static string GetSBEvents()
        {
            switch (currentLanguage)
            {
                case ENG: return "Small blind";
                case DE: return "Small blind";
                case FR: return "Small blind";
            }

            return "Small blind";

        }


        /// <summary>
        /// Big blind
        /// </summary>
        /// <returns></returns>
        public static string GetBBEvents()
        {
            switch (currentLanguage)
            {
                case ENG: return "Big blind";
                case DE: return "Big blind";
                case FR: return "Big blind";
            }

            return "Big blind";

        }

        /// <summary>
        /// Table 1, Hand
        /// </summary>
        /// <returns></returns>
        public static string GetTableHandEvents()
        {
            switch (currentLanguage)
            {
                case ENG: return "Table 1, Hand ";
                case DE: return "Tisch 1, Hand ";
                case FR: return "Table 1, Main ";
            }

            return "Table 1, Hand ";

        }
        /// <summary>
        /// Ante are paid
        /// </summary>
        /// <returns></returns>
        public static string GetAnteRpaidEvents()
        {
            switch (currentLanguage)
            {
                case ENG: return "Ante are paid";
                case DE: return "Einsätze wurden bezahlt";
                case FR: return "les Ante ont été payés";
            }

            return "Ante are paid";

        }
        /// <summary>
        /// deals cards
        /// </summary>
        /// <returns></returns>
        public static string GetDealsCardsEvents()
        {
            switch (currentLanguage)
            {
                case ENG: return "deals cards";
                case DE: return "gibt Karten";
                case FR: return "distribue les cartes";
            }

            return "deals cards";

        }

        /// <summary>
        /// Flop
        /// </summary>
        /// <returns></returns>
        public static string GetFlopEvents()
        {
            switch (currentLanguage)
            {
                case ENG: return "Flop";
                case DE: return "Flop";
                case FR: return "Flop";


            }

            return "Flop";

        }

        /// <summary>
        /// River
        /// </summary>
        /// <returns></returns>
        public static string GetRiverEvents()
        {
            switch (currentLanguage)
            {
                case ENG: return "River";
                case DE: return "River";
                case FR: return "River";


            }

            return "River";

        }
        /// <summary>
        /// Turn
        /// </summary>
        /// <returns></returns>
        public static string GetTurnEvents()
        {
            switch (currentLanguage)
            {
                case ENG: return "Turn";
                case DE: return "Turn";
                case FR: return "Turn";


            }

            return "Turn";

        }
        /// <summary>
        /// Clubs
        /// </summary>
        /// <returns></returns>
        public static string GetClubsEvents()
        {
            switch (currentLanguage)
            {
                case ENG: return "Clubs";
                case DE: return "Kreuz";
                case FR: return "Trèfle";


            }

            return "Clubs";

        }


        /// <summary>
        /// Club
        /// </summary>
        /// <returns></returns>
        public static string GetClubEvents()
        {
            switch (currentLanguage)
            {
                case ENG: return "Club";
                case DE: return "Kreuz";
                case FR: return "Trèfle";


            }

            return "Club";

        }
        /// <summary>
        /// Diamond
        /// </summary>
        /// <returns></returns>
        public static string GetDiamondsEvents()
        {
            switch (currentLanguage)
            {
                case ENG: return "Diamonds";
                case DE: return "Karo";
                case FR: return "Carreau";


            }

            return "Diamonds";

        }
        /// <summary>
        /// Diamond
        /// </summary>
        /// <returns></returns>
        public static string GetDiamondEvents()
        {
            switch (currentLanguage)
            {
                case ENG: return "Diamond";
                case DE: return "Karo";
                case FR: return "Carreau";


            }

            return "Diamond";

        }
        /// <summary>
        /// Heart
        /// </summary>
        /// <returns></returns>
        public static string GetHeartsEvents()
        {
            switch (currentLanguage)
            {
                case ENG: return "Hearts";
                case DE: return "Herz";
                case FR: return "Coeur";


            }

            return "Hearts";

        }
        /// <summary>
        /// Heart
        /// </summary>
        /// <returns></returns>
        public static string GetHeartEvents()
        {
            switch (currentLanguage)
            {
                case ENG: return "Heart";
                case DE: return "Herz";
                case FR: return "Coeur";


            }

            return "Heart";

        }
        /// <summary>
        /// Spades
        /// </summary>
        /// <returns></returns>
        public static string GetSpadesEvents()
        {
            switch (currentLanguage)
            {
                case ENG: return "Spades";
                case DE: return "Pik";
                case FR: return "Pique";


            }

            return "Spades";

        }
        /// <summary>
        /// Spade
        /// </summary>
        /// <returns></returns>
        public static string GetSpadeEvents()
        {
            switch (currentLanguage)
            {
                case ENG: return "Spade";
                case DE: return "Pik";
                case FR: return "Pique";


            }

            return "Spade";

        }

        /// <summary>
        /// Of   (from 8 of Spades)
        /// </summary>
        /// <returns></returns>
        public static string GetOf()
        {
            switch (currentLanguage)
            {
                case ENG: return "of";
                case DE: return "von";
                case FR: return "de";


            }

            return "of";

        }

        /// <summary>
        /// King
        /// </summary>
        /// <returns></returns>
        public static string GetKingEvents()
        {
            switch (currentLanguage)
            {
                case ENG: return "King";
                case DE: return "König";
                case FR: return "Roi";


            }

            return "King";

        }
        /// <summary>
        /// Ace
        /// </summary>
        /// <returns></returns>
        public static string GetAceEvents()
        {
            switch (currentLanguage)
            {
                case ENG: return "Ace";
                case DE: return "Ass";
                case FR: return "As";


            }

            return "Ace";

        }
        /// <summary>
        /// Queen
        /// </summary>
        /// <returns></returns>
        public static string GetQueenEvents()
        {
            switch (currentLanguage)
            {
                case ENG: return "Queen";
                case DE: return "Dame";
                case FR: return "Dame";


            }

            return "Queen";

        }
        /// <summary>
        /// Jack
        /// </summary>
        /// <returns></returns>
        public static string GetJackEvents()
        {
            switch (currentLanguage)
            {
                case ENG: return "Jack";
                case DE: return "Bube";
                case FR: return "Valet";


            }

            return "Jack";

        }

        /// <summary>
        /// Deuce
        /// </summary>
        /// <returns></returns>
        public static string GetDeuceEvents()
        {
            switch (currentLanguage)
            {
                case ENG: return "Deuce";
                case DE: return "Zweien";
                case FR: return "Deux";


            }

            return "Deuce";

        }


        /// <summary>
        /// folds
        /// </summary>
        /// <returns></returns>
        public static string GetfoldsEvents()
        {
            switch (currentLanguage)
            {
                case ENG: return "folds";
                case DE: return "passt";
                case FR: return "passe";


            }

            return "folds";

        }
        /// <summary>
        /// is out of money
        /// </summary>
        /// <returns></returns>
        public static string GetOutOfMoneyEvents()
        {
            switch (currentLanguage)
            {
                case ENG: return "is out of money";
                case DE: return "hat kein Geld mehr";
                case FR: return "est en slip";


            }

            return "is out of money";

        }
        /// <summary>
        /// out of game
        /// </summary>
        /// <returns></returns>
        public static string GetOutOfGameEvents()
        {
            switch (currentLanguage)
            {
                case ENG: return "out of game";
                case DE: return "aus dem Spiel";
                case FR: return "est rentré chez lui";


            }

            return "out of game";

        }
        /// <summary>
        /// has
        /// </summary>
        /// <returns></returns>
        public static string GetHasEvents()
        {
            switch (currentLanguage)
            {
                case ENG: return "has";
                case DE: return "hat";
                case FR: return "a";


            }

            return "has";

        }

        /// <summary>
        /// bets and us all in 
        /// </summary>
        /// <returns></returns>
        public static string GetBetsAndISallinEvents()
        {
            switch (currentLanguage)
            {
                case ENG: return "bets and is all in ";
                case DE: return "bietet und geht All In";
                case FR: return "ouvre et est allin";


            }

            return "bets and us all in ";

        }
        /// <summary>
        /// raises
        /// </summary>
        /// <returns></returns>
        public static string GetRaisesEvents()
        {
            switch (currentLanguage)
            {
                case ENG: return "raises";
                case DE: return "erhöhen";
                case FR: return "relance";


            }

            return "raises";

        }
        /// <summary>
        /// And
        /// </summary>
        /// <returns></returns>
        public static string GetAnd()
        {
            switch (currentLanguage)
            {
                case ENG: return "and";
                case DE: return "und";
                case FR: return "et";


            }

            return "and";

        }
        /// <summary>
        /// is All in 
        /// </summary>
        /// <returns></returns>
        public static string GetIsAllinEvents()
        {
            switch (currentLanguage)
            {
                case ENG: return "is all in";
                case DE: return "geht All In";
                case FR: return "est all in";


            }

            return "is All in";

        }

        /// <summary>
        /// raises and is allin
        /// </summary>
        /// <returns></returns>
        public static string GetRaiseIsAllinEvents()
        {
            switch (currentLanguage)
            {
                case ENG: return "raises and is allin";
                case DE: return "erhöht und geht All In";
                case FR: return "relance et est allin";


            }

            return "raises and is allin";

        }

        /// <summary>
        /// calls
        /// </summary>
        /// <returns></returns>
        public static string GetCallsEvents()
        {
            switch (currentLanguage)
            {
                case ENG: return "calls";
                case DE: return "geht mit";
                case FR: return "suit";


            }

            return "calls";

        }
        /// <summary>
        /// checks
        /// </summary>
        /// <returns></returns>
        public static string GetchecksEvents()
        {
            switch (currentLanguage)
            {
                case ENG: return "checks";
                case DE: return "checkt";
                case FR: return "parole";


            }

            return "checks";

        }
        /// <summary>
        /// so it is a 
        /// </summary>
        /// <returns></returns>
        public static string GetSoItIsAEvents()
        {
            switch (currentLanguage)
            {
                case ENG: return "so it is a ";
                case DE: return "das ist ein ";
                case FR: return "donc c'est du ";


            }

            return "so it is a ";

        }
                /// <summary>
        ///   " wins the pot other players fold"
        /// </summary>
        /// <returns></returns>
        public static string GetWinsOtherFoldEvents()
        {
            switch (currentLanguage)
            {
                case ENG: return " wins the pot other players fold";
                case DE: return " gewinnt den Pot, die anderen Spieler passen";
                case FR: return " gagne le pot les autres joueurs se sont couchés";


            }

            return " wins the pot other players fold";

        }
      
        /// <summary>
        /// raises to 
        /// </summary>
        /// <returns></returns>
        public static string GetRaisesToEvents()
        {
            switch (currentLanguage)
            {
                case ENG: return "raises to";
                case DE: return "erhöht auf";
                case FR: return "relance sur";


            }

            return "raises to";

        }

        /// <summary>
        /// Board 
        /// </summary>
        /// <returns></returns>
        public static string GetBoardToEvents()
        {
            switch (currentLanguage)
            {
                case ENG: return "Board";
                case DE: return "Board";
                case FR: return "Board";


            }

            return "Board";

        }
        /// <summary>
        /// bets
        /// </summary>
        /// <returns></returns>
        public static string GetBetsToEvents()
        {
            switch (currentLanguage)
            {
                case ENG: return "bets";
                case DE: return "bietet";
                case FR: return "ouvre";


            }

            return "bets";

        }

        /// <summary>
        /// Flop is 
        /// </summary>
        /// <returns></returns>
        public static string GetFlopIsEvents()
        {
            switch (currentLanguage)
            {
                case ENG: return "Flop is";
                case DE: return "Flop ist";
                case FR: return "Le Flop est";


            }

            return "Flop is";

        }

        /// <summary>
        /// Turn is 
        /// </summary>
        /// <returns></returns>
        public static string GetTurnIsEvents()
        {
            switch (currentLanguage)
            {
                case ENG: return "Turn is";
                case DE: return "Turn ist";
                case FR: return "La Turn est";


            }

            return "Turn is";

        }

        /// <summary>
        /// River is 
        /// </summary>
        /// <returns></returns>
        public static string GetRiverIsEvents()
        {
            switch (currentLanguage)
            {
                case ENG: return "River is";
                case DE: return "River ist";
                case FR: return "La River est";


            }

            return "River is";

        }
     /// <summary>
        ///   "You had " + this.Player.Hand.Card1.Name + " " + this.Player.Hand.Card1.Color + " " + this.Player.Hand.Card2.Name + " " + this.Player.Hand.Card2.Color + " as private cards so you get a " + this.Player.Hand.HandName + "\n");
              
        /// </summary>
        /// <returns></returns>
        public static string GetYouHadEvents(Card c1,Card c2,string hand)
        {
            switch (currentLanguage)
            {
                case ENG: return "You had " + c1.CompleteName() + " " + c2.CompleteName() + " as private cards so you get a " + hand + "\n";

                case DE: return "Du hast " + c1.CompleteName() + " " + c2.CompleteName() + " as private cards so you get a " + hand + "\n";

                case FR: return "Vous avez " + c1.CompleteName() + " " + c2.CompleteName() + " comme cartes privées donc vous avez touché du " + hand + "\n";
          


            }

            return "You had " + c1.CompleteName() + " " + c2.CompleteName() + " as private cards so you get a " + hand + "\n";
 

        }
        
        /// <summary>
        ///with
        /// </summary>
        /// <returns></returns>
        public static string GetWithEvents()
        {
            switch (currentLanguage)
            {
                case ENG: return "with";
                case DE: return "mit";
                case FR: return "avec";


            }

            return "with";

        }

        /// <summary>
        /// Winner
        /// </summary>
        /// <returns></returns>
        public static string GetWinnerEvents()
        {
            switch (currentLanguage)
            {
                case ENG: return "Winner";
                case DE: return "Gewinner";
                case FR: return "Gagnant";


            }

            return "Winner";

        }
        #endregion

        #region messagebox

        /// <summary>
        ///   Ranking file generated
        /// </summary>
        /// <returns></returns>
        public static string GetRankingFilesGenToEvents()
        {
            switch (currentLanguage)
            {
                case ENG: return "Ranking file generated";
                case DE: return "Ranglisten Datei wurde erstellt" ;
                case FR: return "Fichier généré";


            }

            return "Ranking file generated";

        }
        /// <summary>
        ///   "Do you want to generate the Ranking file ? \n\n you have done " +nbTD+" takedowns\n and you have accessed to level " +level +" \n\n\n Ranking files allow you to enter into the Hall of Fame on web http://chouprod.sourceforge.net\n\n\n You have to send generated .XOR files to chouprod@gmail.com , with [POKDTC] in subject "
        /// </summary>
        /// <returns></returns>
        public static string GetRankingFilesGenQuestionToEvents(int nbTD,int level)
        {
            switch (currentLanguage)
            {
                case ENG: return "Do you want to generate the Ranking file ? \n\n you have done " +nbTD+" takedowns\n and you have accessed to level " +level +" \n\n\n Ranking files allow you to enter into the Hall of Fame on web http://chouprod.sourceforge.net\n\n\n "  ;

                case DE: return "Möchtest Du eine Ranglisten Datei erstellen ? \n\n" + " Du hast " + nbTD + " Takedowns erziehlt" + " \n und Du hast Stufe " + level + " erreicht" + " \n\n\n Ranglisten Dateien ermöglichen Dir einen Eintrag in der Halle der Ehre im Internet unter http://chouprod.sourceforge.net" + " \n\n\n" ;
                case FR: return "Voulez vous générer le fichier de score? \n\n Vous avez réalisé " + nbTD + " takedowns\n et vous avez atteit le niveau " + level + " \n\n\n Les fichiers de score vous permettre d'accéder au Top Score sur le web http://chouprod.sourceforge.net\n\n\n ";
               
                   

       

            }

           return "Do you want to generate the Ranking file ? \n\n you have done " + nbTD + " takedowns\n and you have accessed to level " + level + " \n\n\n Ranking files allow you to enter into the Hall of Fame on web http://chouprod.sourceforge.net\n\n\n ";
               

        }

        
                       /// <summary>
        ///   "Not enough player to continue, play again"
        /// </summary>
        /// <returns></returns>
        public static string GetAdvanceToNextEvents(int td)
        {
            switch (currentLanguage)
            {
                case ENG: return "You advance to the next level\n New players are coming, you already got " + td + " takedowns";
                case DE: return "Du erreichst die nächste Stufe\n Neue Spieler kommen hinzu, Du hast schon " + td + " Takedowns erreicht";
                case FR: return "Vous avez atteint le niveau suivant\n De nouveaux joueurs arrivent, vous avez déjà " + td + " takedowns";


            }

            return "You advance to the next level\n New players are coming, you already got " + td + " takedowns";

        }
        
        /// <summary>
        ///   "Not enough player to continue, play again"
        /// </summary>
        /// <returns></returns>
        public static string GetNotEnoughPlayerEvents()
        {
            switch (currentLanguage)
            {
                case ENG: return "Not enough player to continue, play again";
                case DE: return "Nicht genug Spieler um weiterzumachen, spiele noch einmal";
                case FR: return "Pas assez de joueurs pour continuer, relancez une partie";


            }

            return "Not enough player to continue, play again";

        }
            /// <summary>
        ///   Ranking file 
        /// </summary>
        /// <returns></returns>
        public static string GetRankingFilesEvents()
        {
            switch (currentLanguage)
            {
                case ENG: return "Ranking File";
                case DE: return "Ranglisten Datei";
                case FR: return "Fichier de score";


            }

            return "Ranking File";

        }
   /// <summary>
        ///   Ranking file 
        /// </summary>
        /// <returns></returns>
        public static string GetPlayForFreeEvents()
        {
            switch (currentLanguage)
            {
                case ENG: return "You can continue playing without betting more money " + Environment.NewLine + "Do you want to change your mind and play for free?";

                case DE: return "Du kannst weiterspielen ohne mehr Geld zu investieren " + Environment.NewLine + "Möchtest Du Deine Meinung ändern und weitermachen?";
                case FR: return "Vous pouvez continuer de jouer sans mettre d'argent" + Environment.NewLine + "Voulez vous jouer pour pas un copec de plus?";


            }

            return "You can continue playing without betting more money " + Environment.NewLine + "Do you want to change your mind and play for free?";

        }

        /// <summary>
        ///   Advice
        /// </summary>
        /// <returns></returns>
        public static string GetAdviceEvents()
        {
            switch (currentLanguage)
            {
                case ENG: return "Advice";
                case DE: return "Hinweis";
                case FR: return "Conseil";


            }

            return "Advice";

        }
        
                /// <summary>
        ///   "No profil selected"
        /// </summary>
        /// <returns></returns>
        public static string GetNoprofilSelectedEvents()
        {
            switch (currentLanguage)
            {
                case ENG: return "None profile selected";
                case DE: return "Kein Profil gewählt";
                case FR: return "Aucun profil sélectionné, c'est mal";


            }

            return "No profil selected";

        }
                /// <summary>
        ///   "Can't edit properties during this mode"
        /// </summary>
        /// <returns></returns>
        public static string GetCannotEditEvents()
        {
            switch (currentLanguage)
            {
                case ENG: return  "Can't edit properties during this mode";
                case DE: return "Bei diesem Spieltyp können die Einstellungen nicht verändert werden";
                case FR: return  "Il est impossible d'accéder aux propriétés dans ce mode";


            }

            return  "Can't edit properties during this mode";

        }
               /// <summary>
        ///    "Please load a profil";
        /// </summary>
        /// <returns></returns>
        public static string GetPleaseLoadEvents()
        {
            switch (currentLanguage)
            {
                case ENG: return  "Please load a profile";
                case DE: return "Bitte lade ein Profil";
                case FR: return  "Chargez un profil, ca serait sympa";


            }

            return  "Please load a profile";;

        }
               /// <summary>
        ///     "Do not do that !!"
        /// </summary>
        /// <returns></returns>
        public static string GetDoNotDoTHatEvents()
        {
            switch (currentLanguage)
            {
                case ENG: return   "Do not do that !!";
                case DE: return  "Das solltest Du nicht tun !!";
                case FR: return  "Evitez de faire ca!!";


            }

            return   "Do not do that !!";

        }
     

                  /// <summary>
        ///    "Not enough money to continue, try again"
        /// </summary>
        /// <returns></returns>
        public static string GetNotEnoughMoneyEvents()
        {
            switch (currentLanguage)
            {
                case ENG: return "Not enough money to continue, try again";
                case DE: return "Nicht genug Geld um weiterzuspielen, versuche es noch mal";
                case FR: return "Vous êtes à sec, essayez encore pour voir";


            }

            return "Not enough money to continue, try again";

        }
                /// <summary>
        ///   "Already bored?"
        /// </summary>
        /// <returns></returns>
        public static string GetAlreadyBoredEvents()
        {
            switch (currentLanguage)
            {
                case ENG: return "Already bored?";
                case DE: return "Schon gelangweilt?";
                case FR: return "Déjà saoulé?";


            }

            return "Already bored?";

        }
     
                /// <summary>
        ///       "Question"
        /// </summary>
        /// <returns></returns>
        public static string GetQuestionEvents()
        {
            switch (currentLanguage)
            {
                case ENG: return "Question";
                case DE: return     "Frage";
                case FR: return     "Question";


            }

            return     "Question";

        }
    
               /// <summary>
        ///    "Please close the other odds window before trying  to open  a new one"
        /// </summary>
        /// <returns></returns>
        public static string GetCloseOtherWEvents()
        {
            switch (currentLanguage)
            {
                case ENG: return  "Please close the other odds window before trying  to open  a new one";
                case DE: return  "Bitte schließe zuerst das Chancen Fenster bevor Du versuchst ein neues zu öffnen";
                case FR: return  "Fermez les autres fenètres de stats avant d'en ouvrir une autre sinon on s'en sort pas";


            }

            return  "Please close the other odds window before trying  to open  a new one";

        }
       
		        /// <summary>
        ///    "Server already listening,do you want to reset connections?",
		                /// </summary>
        /// <returns></returns>
        public static string GetServerAlreayEvents()
        {
            switch (currentLanguage)
            {
                case ENG: return "Host already listening,do you want to reset connections?";
                case DE: return "Der Server läuft bereits, möchtest Du die Verbindung zurücksetzen?";
                case FR: return "Une connexion est déjà active, voulez vous l'annuler?";


            }

            return "Host already listening,do you want to reset connections?";

        }	
          /// <summary>
        ///   "Reset"
        /// </summary>
        /// <returns></returns>
        public static string GetResetEvents()
        {
            switch (currentLanguage)
            {
                case ENG: return "Reset";
                case DE: return "Reset";
                case FR: return "Reset";


            }

            return "Reset";

        }
      /// <summary>
        ///  "Another game is running"
        /// </summary>
        /// <returns></returns>
        public static string GetAnotherGameEvents()
        {
            switch (currentLanguage)
            {
                case ENG: return "Another game is running";
                case DE: return "Ein anderes Spiel läuft";

                case FR: return "Une autre partie est déjà en cours";


            }

            return "Another game is running";

        }
        /// <summary>
        ///  "Game is over"
        /// </summary>
        /// <returns></returns>
        public static string GetGameIsOverEvents()
        {
            switch (currentLanguage)
            {
                case ENG: return "Game is over";
                case DE: return "Das Spiel ist zuende";

                case FR: return "La partie est terminée";


            }

            return "Game is over";

        }
        /// <summary>
        ///  "Last Hand"
        /// </summary>
        /// <returns></returns>
        public static string GetLastHandEvents()
        {
            switch (currentLanguage)
            {
                case ENG: return "Last Hand";
                case DE: return "Letzte Hand";

                case FR: return "Dernière main";


            }

            return "Dernière main";

        }


        /// <summary>
        ///  "This hand will be the last hand, do you want to continue?"
        /// </summary>
        /// <returns></returns>
        public static string GetLastHandBox()
        {
            switch (currentLanguage)
            {
                case ENG: return "This hand will be the last hand, do you want to continue?";
                case DE: return "Es wird die letzte Hand gespielt, weitermachen?";

                case FR: return "Cette main sera la dernière, c'est votre dernier mot?";


            }

            return "This hand will be the last hand, do you want to continue?";

        }
        #endregion


        #region menu title

        /// <summary>
        /// New game
        /// </summary>
        /// <returns></returns>
        public static string GetNewGameMenu()
        {
            switch (currentLanguage)
            {
                case ENG: return "New game";
                case DE: return "Neues Spiel";

                case FR: return "Nouvelle partie";


            }

            return "New game";

        }

        /// <summary>
        /// Net or Lan Game
        /// </summary>
        /// <returns></returns>
        public static string GetNetOrLanGameMenu()
        {
            switch (currentLanguage)
            {
                case ENG: return "Net or lan game";
                case DE: return "Netzwerkspiel";

                case FR: return "Partie en ligne ou locale";


            }

            return "Net or lan game";

        }

        /// <summary>
        /// Create host
        /// </summary>
        /// <returns></returns>
        public static string GetCreateServerMenu()
        {
            switch (currentLanguage)
            {
                case ENG: return "Create host";
                case DE: return "Server erstellen";

                case FR: return "Hébergez une partie";


            }

            return "Create host";

        }
        /// <summary>
        /// Connect to host
        /// </summary>
        /// <returns></returns>
        public static string GetConnectServerMenu()
        {
            switch (currentLanguage)
            {
                case ENG: return "Connect to host";
                case DE: return "Mit Server verbinden";

                case FR: return "Rejoindre une partie";


            }

            return "Connect to host";

        }
  

        /// <summary>
        /// Profil
        /// </summary>
        /// <returns></returns>
        public static string GetProfilMenu()
        {
            switch (currentLanguage)
            {
                case ENG: return "Profile";
                case DE: return "Profil";

                case FR: return "Profil";


            }

            return "Profile";

        }

        /// <summary>
        /// New Profil
        /// </summary>
        /// <returns></returns>
        public static string GetNewProfilMenu()
        {
            switch (currentLanguage)
            {
                case ENG: return "New Profil";
                case DE: return "Neues Profil";

                case FR: return "Nouveau Profile";


            }

            return "New Profil";

        }
        /// <summary>
        /// Edit Profil
        /// </summary>
        /// <returns></returns>
        public static string GetEditProfilMenu()
        {
            switch (currentLanguage)
            {
                case ENG: return "Edit Profile";
                case DE: return "Edit Profil";

                case FR: return "Edition de profil";


            }

            return "Edit Profile";

        }

        /// <summary>
        /// Local Player
        /// </summary>
        /// <returns></returns>
        public static string GetLocalPlayerMenu()
        {
            switch (currentLanguage)
            {
                case ENG: return "Local Player";
                case DE: return "Lokaler Spieler";

                case FR: return "Joueur local";


            }

            return "Local Player";

        }
        /// <summary>
        /// Virtual Player
        /// </summary>
        /// <returns></returns>
        public static string GetVirtualPlayerMenu()
        {
            switch (currentLanguage)
            {
                case ENG: return "Virtual Player";
                case DE: return "Virtueller Spieler";

                case FR: return "Joueur Virtuel";


            }

            return "Virtual Player";

        }

        /// <summary>
        /// Properties
        /// </summary>
        /// <returns></returns>
        public static string GetPropertiesMenu()
        {
            switch (currentLanguage)
            {
                case ENG: return "Properties";
                case DE: return "Einstellungen";

                case FR: return "Propriétées";


            }

            return "Properties";

        }

        /// <summary>
        /// Stats
        /// </summary>
        /// <returns></returns>
        public static string GetStatsMenu()
        {
            switch (currentLanguage)
            {
                case ENG: return "Stats";
                case DE: return "Statistik";

                case FR: return "Stats";


            }

            return "Stats";

        }
        /// <summary>
        /// Odds
        /// </summary>
        /// <returns></returns>
        public static string GetOddsMenu()
        {
            switch (currentLanguage)
            {
                case ENG: return "Odds";
                case DE: return "Chancen";
                case FR: return "Chance de tirage";


            }

            return "Odds";

        }

        /// <summary>
        /// Sound options
        /// </summary>
        /// <returns></returns>
        public static string GetSoundOptionMenu()
        {
            switch (currentLanguage)
            {
                case ENG: return "Sound options";
                case DE: return "Sound Optionen";
                case FR: return "Options de son";


            }

            return "Sound options";

        }

        /// <summary>
        /// Speaker
        /// </summary>
        /// <returns></returns>
        public static string GetSpeakerMenu()
        {
            switch (currentLanguage)
            {
                case ENG: return "Speaker";
                case DE: return "Speaker";
                case FR: return "Commentateur";
            }
            return "Speaker";
        }
        /// <summary>
        /// Voices
        /// </summary>
        /// <returns></returns>
        public static string GetVoicesMenu()
        {
            switch (currentLanguage)
            {
                case ENG: return "Voices";
                case DE: return "Voices";
                case FR: return "Voix";
            }
            return "Voices";
        }
        /// <summary>
        /// Own data
        /// </summary>
        /// <returns></returns>
        public static string GetOwnDataMenu()
        {
            switch (currentLanguage)
            {
                case ENG: return "Own data";
                case DE: return "Eigene Daten";
                case FR: return "Données persos";
            }
            return "Own data";
        }
        /// <summary>
        /// Language
        /// </summary>
        /// <returns></returns>
        public static string GetLanguageMenu()
        {
            switch (currentLanguage)
            {
                case ENG: return "Language";
                case DE: return "Sprache";
                case FR: return "Langage";
            }
            return "Language";
        }
        /// <summary>
        /// Exit
        /// </summary>
        /// <returns></returns>
        public static string GetExitMenu()
        {
            switch (currentLanguage)
            {
                case ENG: return "Exit";
                case DE: return "Exit";
                case FR: return "Sortie";
            }
            return "Exit";
        }
        /// <summary>
        /// Speed game
        /// </summary>
        /// <returns></returns>
        public static string GetSpeedMenu()
        {
            switch (currentLanguage)
            {
                case ENG: return "Game Speed";
                case DE: return "Game Speed";
                case FR: return "Vitesse du jeu";
            }
            return "Game Speed";
        }
        /// <summary>
        /// Fastest
        /// </summary>
        /// <returns></returns>
        public static string GetFastestMenu()
        {
            switch (currentLanguage)
            {
                case ENG: return "Fastest";
                case DE: return "Fastest";
                case FR: return "Rapide";
            }
            return "Fastest";
        }
        /// <summary>
        /// Medium
        /// </summary>
        /// <returns></returns>
        public static string GetMediumMenu()
        {
            switch (currentLanguage)
            {
                case ENG: return "Medium";
                case DE: return "Medium";
                case FR: return "Moyen";
            }
            return "Medium";
        }
        /// <summary>
        /// Slowest
        /// </summary>
        /// <returns></returns>
        public static string GetSlowestMenu()
        {
            switch (currentLanguage)
            {
                case ENG: return "Slowest";
                case DE: return "Langsam";
                case FR: return "Lent";
            }
            return "Slowest";
        }
        /// <summary>
        /// About
        /// </summary>
        /// <returns></returns>
        public static string GetAboutMenu()
        {
            switch (currentLanguage)
            {
                case ENG: return "About";
                case DE: return "About";
                case FR: return "A propos";
            }
            return "About";
        }
        #endregion 
         
               /// <summary>
        ///  "If you enjoy this FREE software, please support me \n by sending  a postcard from your country/city.";
        /// </summary>
        /// <returns></returns>
        public static string GetPostCardMenu()
        {
            switch (currentLanguage)
            {
                case ENG: return "If you enjoy this FREE software, please support me by sending a postcard from your country/city.";
                case DE: return "If you enjoy this FREE software, please support me by sending a postcard from your country/city.";
                case FR: return "Si vous aimez ce jeu complètement gratuit, svp soutenez mon travail en m'envoyant une carte postale de votre ville. Ca serait cool!";
            }
            return "If you enjoy this FREE software, please support me by sending a postcard from your country/city.";
        }
        /// <summary>
        /// Current blinds
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentBlinds()
        {
            switch (currentLanguage)
            {
                case ENG: return "Current blinds";
                case DE: return "Current blinds";
                case FR: return "Blinds:";
            }
            return "Current blinds";
        }

        internal static string GetScoreTooBad()
        {
            switch (currentLanguage)
            {
                case ENG: return "Ranking too bad to be save";
                case DE: return "Ranking too bad to be save";
                case FR: return "Score trop mauvais pour être sauvé";
            }
            return "Ranking too bad to be save";
        }


        /// <summary>
        /// "Mail sent, give some times to see your name on the web page chouprod.sourceforge.net"
        /// </summary>
        /// <returns></returns>
        public static string GetMailSent()
        {
            switch (currentLanguage)
            {
                case ENG: return "Mail sent, give some time to see your name on the web page chouprod.sourceforge.net";
                case DE: return "Mail sent, give some time to see your name on the web page chouprod.sourceforge.net";
                case FR: return "Mail envoyé, dès que j'ai du temps je mets le nouveau high score  sur chouprod.sourceforge.net";
            }
            return "Mail sent, give some times to see your name on the web page chouprod.sourceforge.net";
        }

        /// <summary>
        /// Current blinds
        /// </summary>
        /// <returns></returns>
        public static string GetMailError(string path2xor)
        {
            switch (currentLanguage)
            {
                case ENG: return "Mail error, Please check your SMTP address or your internet connection\n"+"You can send it by yourself\n " +"Send this file to chouprod@gmail.com\n" + path2xor;
                case DE: return "Mail error, Please check your SMTP address or your internet connection\n" + "You can send it by yourself\n " + "Send this file to chouprod@gmail.com\n" + path2xor;
                case FR: return "Echec de l'envoie, vérifiez svp l'adresse SMTP de votre connexion actuelle\n"+ "Vous pouvez l'envoyer vous même à chouprod@gmail.com\n" +path2xor;
            }
            return "Mail error, Please check your SMTP address or your internet connection\n"+"You can send it by yourself\n " +"Send this file to chouprod@gmail.com\n" + path2xor;
        }

        internal static string GetSomeComments()
        {
            switch (currentLanguage)
            {
                case ENG: return "Some Comments?";
                case DE: return "Some Comments?";
                case FR: return "Des commentaires?";
            }
            return "Some Comments?";
        }

    

    }
}