
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
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Xml.XPath;
namespace poker
{///
    //class de gestion de noms d'IA
    class IANames
    {
       private static string ia_names_fullpath = Application.StartupPath +"\\IA_names\\" + "ia_names.xml";

        private ArrayList alreadyUsed;
        private Random rd;
        private int nbr_names;
        public IANames() {

            alreadyUsed = new ArrayList(40);
            rd = new Random((int) DateTime.Now.Ticks);
            if (!File.Exists(ia_names_fullpath))
                throw new Exception(" IA Names file doesn't exist can't continue \n");

            try
            {

                XPathDocument doc = new XPathDocument(ia_names_fullpath);

                //Création du XpathNavigator
                XPathNavigator nav = doc.CreateNavigator();

                // Récupération de la racine du flux
                nav.MoveToRoot();

                // Récupération
                nav.MoveToFirstChild();

                AnalyseCurrentNode2(nav);

                if (this.nbr_names < 9)
                {
                    throw new Exception(" pas assez de noms d'ia ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
               
            }

        }
        public void EmptyAlreadyKnown() {
            this.alreadyUsed.Clear();
        
        }
        public string pickAname() 
        {
            int nbr=rd.Next(1, this.nbr_names);

            while (alreadyUsed.Contains(nbr))
            {

                nbr = rd.Next(1, this.nbr_names);
            }
            alreadyUsed.Add(nbr);
            if (!File.Exists(ia_names_fullpath))
                throw new Exception(" IA Names file doesn't exist can't continue \n");

            try
            {

                XPathDocument doc = new XPathDocument(ia_names_fullpath);

                //Création du XpathNavigator
                XPathNavigator nav = doc.CreateNavigator();

                // Récupération de la racine du flux
                nav.MoveToRoot();

                // Récupération
                nav.MoveToFirstChild();

               return  AnalyseCurrentNode(nav,nbr);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return "bot" + rd.Next(1, 10001);
            }


        
        }

        private string AnalyseCurrentNode(XPathNavigator nav,int nbr)
        {
            string name = nav.Name.ToLower();

            if (name == "ia")
            {
                nav.MoveToFirstChild();

               
                do
                {
                    name = nav.Name.ToLower();
                    if (name == "name")
                    {
                        nbr--;
                        name = nav.Value;
                    }
                } while
                                 (nav.MoveToNext() && nbr>0);

                if (nbr == 0)
                    return name;
               



            }
            return "bot " + rd.Next(1, 1001); 
        }
        private void AnalyseCurrentNode2(XPathNavigator nav)
        {
            string name = nav.Name.ToLower();

            if (name == "ia")
            {
                nav.MoveToFirstChild();

                this.nbr_names = 0;
                do
                {
                    name = nav.Name.ToLower();
                    if(name=="name")
                        this.nbr_names++;
                } while
                                 (nav.MoveToNext());
              




            }
           
        }

    }
}
