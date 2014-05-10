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

namespace poker
{
	/// <summary>
	/// Class that get all information 
	/// </summary>
	public class Dispatcher
	{
		public Dispatcher(Form1 f,GameData g)
		{
			form=f;
			gameData=g;
		
		}
        /// <summary>
        /// game properties
        /// </summary>
		public GameData GameData{
			get{return gameData;}
			set{gameData=value;}
		}
        /// <summary>
        /// communication
        /// </summary>
		public ComInOut Communication
		{
			get{return comm;}
			set{comm=value;}
		}
        /// <summary>
        /// actual game
        /// </summary>
		public Game Game
		{
			get{return game;}
			set{game=value;}
		}
        /// <summary>
        /// main form
        /// </summary>
		public Form1 Form
		{
			get{return form;}
			set{form=value;}
		}
        /// <summary>
        /// player profil 
        /// </summary>
		public Profil Profil
		{
			get{return profil;}
			set{profil=value;}
		}
        public GameAnalyser Analyser
        {
            get { return analyser; }
            set { analyser = value; }
        }
        private AutoSpeech speaker;

        internal AutoSpeech Speaker
        {
            get { return speaker; }
            set { speaker = value; }
        }
		private GameData gameData;
		private ComInOut comm;
		private Game game;
		private Form1 form;
		private Profil profil=null;
        private GameAnalyser analyser = null;
        private Admin admin = null;

        public Admin Admin
        {
            get { return admin; }
            set { admin = value; }
        }

	}
}
