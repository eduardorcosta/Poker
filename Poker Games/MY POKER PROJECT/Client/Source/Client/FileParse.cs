using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Parse
{
    public class FileParse
    {
        
		public string Filename { set; get;}
        private List<List<string>> handFile;
        private int pos = 0;

		private List<String> AllHands(){
			StreamReader file = new StreamReader(Filename);
			List<String> AllHand = new List<String>();
			string line;
			while((line = file.ReadLine()) != null){
				AllHand.Add(line);
			}
			return AllHand;
		}

		private List<List<String>> SepareteHands()
		{
			//const int neededLines = 5;
			List<List<string>> handFile = new List<List<string>> ();
			List<String> allHands = AllHands ();
			List<String> hand;// = List<String> ();

			int inicio = 0;
			int qtd = 0;
			int count = 0;
			foreach (var item in allHands){

				if(item.Contains ("Hand")) { //} line.Contains("HAND")){
					if ( count != 0 ){
						//nao e a primeira mao
						hand = allHands.GetRange (inicio, qtd);
						handFile.Add (hand);
						inicio += qtd;
						qtd = 0;
						count = 0;
					}
					count++;
				}
				qtd++;
			}
			return handFile;
		}

		public List<String> GetLastHand(){
			List<List<string>> handFile = SepareteHands ();
			return handFile [handFile.Count-1];
		}      

		public FileParse (string Filename )
		{
            this.Filename = Filename;        
            handFile = SepareteHands();
		}
	    public GenericParse NextHand(){
            if (pos>=handFile.Count)
                return null;
            else /*if (pos == 0)
            {
                return handFile[0];
            }
            else*/
            {
                HandParse hand = new HandParse(handFile[pos++]);
                return hand.genericParse;
            }

        }
        public GenericParse PrevHand()
        {
            if (pos==0)
                return null;
            else /*if (pos == 0)
            {
                return handFile[0];
            }
            else*/
            {
                HandParse hand = new HandParse(handFile[--pos]);
                return hand.genericParse;
            }

        }
    }
}
