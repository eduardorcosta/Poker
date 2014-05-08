
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
using System.IO;
using System.Windows.Forms;
using System.Xml;
namespace poker
{
    class AggressiveMode
    {

        public AggressiveMode(string version) {
            this.version = version;
            this.numberOfTakeDowns = 0;
            this.level = 1;
            this.AggressiveModeBool = false;
        
        }
        private bool aggressiveMode = false;

        public bool AggressiveModeBool
        {
            get { return aggressiveMode; }
            set { aggressiveMode = value; }
        }
        private int numberOfTakeDowns; //nombre de fois que le joueur local a éliminé un gars

        public int NumberOfTakeDowns
        {
            get { return numberOfTakeDowns; }
            set { numberOfTakeDowns = value; }
        }
        private int level; // nombre de fois que la table est reconstituée

        public int Level
        {
            get { return level; }
            set { level = value; }
        }
        private string version;

public string Version
{
  get { return version; }
  set { version = value; }
}

        public string  Save(string name)
        
        {

            int numberTakeDowns=numberOfTakeDowns;
            int level=this.level;
            string datenow = getDateNow();
            try
            {
                
                if (File.Exists(Application.StartupPath + "//AggressiveMode//" + datenow + ".xml"))
                    File.Delete(Application.StartupPath + "//AggressiveMode//" + datenow + ".xml");

                if (File.Exists(Application.StartupPath + "//AggressiveMode//" + datenow + ".xor"))
                    File.Delete(Application.StartupPath + "//AggressiveMode//" + datenow + ".xor");

                XmlTextWriter xml = new XmlTextWriter(Application.StartupPath + "//AggressiveMode//" + datenow + ".xml", null);

                using (xml)
                {
                    xml.WriteStartDocument(true);
                    xml.WriteStartElement("ranking");
                    xml.WriteAttributeString("name", name);
                    xml.WriteAttributeString("nbrOfTakeDown", numberTakeDowns.ToString());
                    xml.WriteAttributeString("level", level.ToString());
                    xml.WriteAttributeString("date", datenow);
                    xml.WriteAttributeString("pok_version", version);
                    xml.WriteEndElement();
                    xml.WriteEndDocument();
                    xml.Flush();
                    xml.Close();
                }

                FonctionXor.Fonction_Xor2(Application.StartupPath + "\\AggressiveMode\\" + datenow + ".xml", Application.StartupPath + "//AggressiveMode//" + datenow + ".xor");
                if (File.Exists(Application.StartupPath + "\\AggressiveMode\\" + datenow + ".xml"))
                    File.Delete(Application.StartupPath + "\\AggressiveMode\\" + datenow + ".xml");

                return Application.StartupPath + "\\AggressiveMode\\" + datenow + ".xor";
            }
            catch (Exception exception)
            {

                MessageBox.Show(" An error occured during the ranking  generation \n\n\n" + exception);
                if (File.Exists(Application.StartupPath + "\\AggressiveMode\\" + datenow + ".xor"))
                    File.Delete(Application.StartupPath + "\\AggressiveMode\\" + datenow + ".xor");
                return "";
            }
        }

        private string getDateNow()
        {
            long date = DateTime.Now.Ticks;
            return date.ToString();
        }

    }
}
