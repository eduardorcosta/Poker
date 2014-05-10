
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
using System.IO;
using System.Xml;
using System.Windows.Forms;
namespace poker
{
	/// <summary>
	/// Description résumée de Profil.
	/// </summary>
	public class Profil
	{
		private string playerName="";
		private string profileName="";
		private string avatar="";
		private int gamesplayed=0;
		private int gameswon=0;
		private int foldpreflop=0;
		private int foldpostflop=0;
		private int foldturn=0;
		private int foldriver=0;
		private int raise=0;
		private int allIn=0;
		private int allInWon=0;
		private long moneyWon=0;
		private int takedowns=0;
		private int wonWithoutShow=0;
		private int showdowns=0;
		private int payedFlop=0;


		public int PayedFlop{
			get{return this.payedFlop;}
				set{this.payedFlop=value;}
		
		}
		public int WonWithoutShow
		{
			get{return this.wonWithoutShow;}
			set{this.wonWithoutShow=value;}
		
		}
		public int Showdowns
		{
			get{return this.showdowns;}
			set{this.showdowns=value;}
		
		}

		public int TakeDowns
		{
			get{return this.takedowns;}
			set{this.takedowns=value;}
		}
		public int AllIn
		{
			get{return allIn;}
			set{allIn=value;}
		}
		public int AllInWon
		{
			get{return allInWon;}
			set{allInWon=value;}
		}		
		public long MoneyWon
		{
			get{return moneyWon;}
			set{moneyWon=value;}
		}
		public int Raise
		{
			get{return raise;}
			set{raise=value;}
		}
		public int Foldriver
		{
			get{return foldriver;}
			set{foldriver=value;}
		}
		public int Foldturn
		{
			get{return foldturn;}
			set{foldturn=value;}
		}
		public int Foldpreflop
		{
			get{return foldpreflop;}
			set{foldpreflop=value;}
		}
		public int Foldpostflop
		{
			get{return foldpostflop;}
			set{foldpostflop=value;}
		}
		public string PlayerName
		{
			get{return playerName;}
			set{playerName=value;}
		
		}
		public string ProfileName
		{
			get{return profileName;}
			set{profileName=value;}
		}
		public string Avatar
		{
			get{return avatar;}
			set{avatar=value;}
		}
		public int GamesPlayed
		{
			get{return gamesplayed;}
			set{gamesplayed=value;}
		}
		public int GamesWon
		{
			get{return gameswon;}
			set{gameswon=value;}
		}
		public Profil(string n)
		{
			profileName=n;
		}
		public Profil()
		{
		}
        /// <summary>
        /// load profil file
        /// </summary>
		public void Load()
		{
			//string name="";
			avatar="";
            if (File.Exists(Application.StartupPath + "//Profils//" + profileName + ".pass") &&
                File.Exists(Application.StartupPath + "//Profils//" + profileName + ".pok"))
            {
                try
                {
                    string pass = "";
                    // Create an instance of StreamReader to read from a file.
                    // The using statement also closes the StreamReader.
                    using (StreamReader sr = new StreamReader(Application.StartupPath + "//Profils//" + profileName + ".pass"))
                    {

                        string line;
                        // Read and display lines from the file until the end of 
                        // the file is reached.
                        while ((line = sr.ReadLine()) != null)
                        {
                            pass += line;
                        }
                    }

                    string data = "";

                    using (StreamReader sr = new StreamReader(Application.StartupPath + "//Profils//" + profileName + ".pok"))
                    {

                        string line;
                        // Read and display lines from the file until the end of 
                        // the file is reached.
                        while ((line = sr.ReadLine()) != null)
                        {
                            data += line;
                        }
                    }
                    string pass2 = MD5(data);
                    if (pass.CompareTo(pass2) != 0) { Console.WriteLine("bad"); return; }
                    else { Console.WriteLine("good"); }
                    XmlTextReader xml = new XmlTextReader(Application.StartupPath + "//Profils//" + profileName + ".pok");

                    while (xml.Read())
                    {


                        playerName = xml.GetAttribute("name");
                        avatar = xml.GetAttribute("avatar");
                        gamesplayed = (int)Convert.ToInt32(xml.GetAttribute("gamesplayed"));
                        gameswon = (int)Convert.ToInt32(xml.GetAttribute("gameswon"));
                        foldpreflop = (int)Convert.ToInt32(xml.GetAttribute("foldpreflop"));
                        foldpostflop = (int)Convert.ToInt32(xml.GetAttribute("foldpostflop"));
                        foldturn = (int)Convert.ToInt32(xml.GetAttribute("foldturn"));
                        foldriver = (int)Convert.ToInt32(xml.GetAttribute("foldriver"));
                        raise = (int)Convert.ToInt32(xml.GetAttribute("raise"));
                        allIn = (int)Convert.ToInt32(xml.GetAttribute("allIn"));
                        allInWon = (int)Convert.ToInt32(xml.GetAttribute("allInWon"));
                        moneyWon = (int)Convert.ToInt32(xml.GetAttribute("moneyWon"));
                        takedowns = (int)Convert.ToInt32(xml.GetAttribute("takedowns"));
                        showdowns = (int)Convert.ToInt32(xml.GetAttribute("showdowns"));
                        wonWithoutShow = (int)Convert.ToInt32(xml.GetAttribute("wonWithoutShow"));
                        payedFlop = (int)Convert.ToInt32(xml.GetAttribute("payedFlop"));

                        //protection=xml.GetAttribute("pass");
                    }
                }
                catch (Exception ex)
                { MessageBox.Show("An error occured when decrypting document" + ex.ToString()); }

            }
		
			//check value protected
		}
        /// <summary>
        /// save to disk
        /// </summary>
		public   void Save()
		{
			try
			{
				//faire un test ici pour voir si le fichier n'existe pas deja System.IO.File.Exists(strProfile)
				XmlTextWriter xml=new XmlTextWriter(Application.StartupPath+ "//Profils//" + profileName + ".pok",null);
				xml.WriteStartDocument(true);
				xml.WriteStartElement("perso");
                xml.WriteAttributeString("name", profileName);
				xml.WriteAttributeString("avatar",avatar);
				xml.WriteAttributeString("gamesplayed",gamesplayed.ToString());
				xml.WriteAttributeString("gameswon",gameswon.ToString());
				xml.WriteAttributeString("foldpreflop",foldpreflop.ToString());
				xml.WriteAttributeString("foldpostflop",foldpostflop.ToString());
				xml.WriteAttributeString("foldturn",foldturn.ToString());
				xml.WriteAttributeString("foldriver",foldriver.ToString());
				xml.WriteAttributeString("raise",raise.ToString());
				xml.WriteAttributeString("allIn",allIn.ToString());
				xml.WriteAttributeString("allInWon",allInWon.ToString());
				xml.WriteAttributeString("moneyWon",moneyWon.ToString());
				xml.WriteAttributeString("takedowns",takedowns.ToString());
				xml.WriteAttributeString("showdowns",showdowns.ToString());
				xml.WriteAttributeString("wonWithoutShow",wonWithoutShow.ToString());
				xml.WriteAttributeString("payedFlop",payedFlop.ToString());
				xml.WriteEndElement();
				xml.WriteEndDocument();
				xml.Flush();
				xml.Close();
				string pass="";
				using (StreamReader sr = new StreamReader(Application.StartupPath+ "//Profils//" + profileName + ".pok")) 
				{
					
					string line;
					// Read and display lines from the file until the end of 
					// the file is reached.
					while ((line = sr.ReadLine()) != null) 
					{
						pass+=line;
					}
				}
				string md5=MD5(pass);
				using (StreamWriter sw = new StreamWriter(Application.StartupPath+ "//Profils//" + profileName + ".pass"))
				{
					// Add some text to the file.
					sw.Write(md5);
					sw.Close();
				}

			}
            catch //(Exception ev)
			{
			 
			//	MessageBox.Show(ev.ToString());  
			}
		
		
		
		}
        /// <summary>
        /// compute MD5 signature
        /// </summary>
        /// <param name="Text"></param>
        /// <returns></returns>
		public static string MD5(string Text)
		{
			byte[] buffer = System.Text.Encoding.Default.GetBytes(Text);
			try
			{
				System.Security.Cryptography.MD5CryptoServiceProvider check;
				check = new System.Security.Cryptography.MD5CryptoServiceProvider();
				byte[] somme = check.ComputeHash(buffer);
				string ret = "";
				foreach (byte a in somme)
				{
					if (a<16)
						ret += "0" + a.ToString("X");
					else
						ret += a.ToString("X");
				}
				return ret ;
			}
			catch
			{
                throw;
			}
		}
        /// <summary>
        /// load profile by name 
        /// </summary>
        /// <param name="n"></param>
        public void Load(string n)
		{
			profileName=n;
			Load();

		
		
		}
	}
}
