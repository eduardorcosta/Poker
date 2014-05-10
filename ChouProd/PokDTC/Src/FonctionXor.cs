
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
namespace poker
{
    class FonctionXor
    {
        public FonctionXor() { }

       private static string key = "AAEAADgAAADUnvdChebnDDqaIlQLhT0IA0nUTymoIVBop9ivXxBEvIjSRlIXNhIiBiFYLrwj2xL1YBJVilagEFWiDKytLKGDMlkSENgNU2056u1WIChQHAwEAAAALAAAAAQAAAAE";
        public static void Fonction_Xor2(string sourcefile, string resultfile)
        {
            string key = FonctionXor.key;

            // Tableau de bytes
            byte[] buffer = new byte[2048];

            XORMelangeur Scrambler = new XORMelangeur(key);

            try
            {
                // Flux qui vont lire le fichier source et créer le fichier de destination
                using (FileStream iStream = new FileStream(sourcefile, FileMode.Open))
                {
                    using (FileStream oStream = new FileStream(resultfile, FileMode.CreateNew))
                    {

                        int read;
                        while ((read = iStream.Read(buffer, 0, 2048)) > 0)
                        {
                            oStream.Write(Scrambler.scramble(buffer), 0, read);
                        }
                        iStream.Close();
                        oStream.Flush();
                        oStream.Close();
                    }
                    buffer = null;
               
                }
            }
            catch
            {
                // MessageBox.Show("Erreur lors du cryptage du fichier avec la fonction XOR!\nErreur : " + Ex.Message, "Erreur de cryptage", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public class XORMelangeur
        {
            byte[] key;

            // On prend la clé passée en paramètre
            public XORMelangeur(string keystring)
            {
                System.Text.ASCIIEncoding encodedData = new System.Text.ASCIIEncoding();
                // Et on la stocke dans un table de bytes
                key = encodedData.GetBytes(keystring);
            }

            // Pour "mélanger" les bytes des fichiers
            public byte[] scramble(byte[] b)
            {
                byte[] r = new byte[b.Length];
                for (int i = 0; i < b.Length; i++)
                {
                    r[i] = (byte)(b[i] ^ key[i % key.Length]);
                }
                return r;
            }
        }
    }
}
