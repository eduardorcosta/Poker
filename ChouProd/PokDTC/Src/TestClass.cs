using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace poker
{
    class TestClass
    {
        /// <summary>
        /// calcul de vol, distrib proba,   bonne repartition des tirages de 1 à 52 
        /// </summary>
        /// <param name="test"></param>
        public void LauchStatTest(int test)
        {
            MyRandom rd1 = new MyRandom();
            int a;
            double vol = 0;
            double mean = 0;
            double distance;
           

            long[] listeCard = new long[52];
            for (int i = 0; i <= test; i++)
            {
                a = rd1.getRandomNumber();
                listeCard[a]++;

            }
            double min = test;
            double max = 0;

            for (int i = 0; i < 52; i++)
            {
                listeCard[i]=listeCard[i] ;

                if (min > listeCard[i])
                    min = listeCard[i];

                if (max<  listeCard[i])
                    max = listeCard[i];
               // vol += (listeCard[i] - mean) * (listeCard[i] - mean);

            }

            vol = vol / 51.0;

            distance = (max-min) *100/ test;
            Console.WriteLine(test + "  " + distance);
           // Console.WriteLine("Variance=" + vol + "pour " +test +" tirages");

        
        }


        public void LaunchTirageMain(long test )
        {
            Deck deck = new Deck();
            long[,] tab=new long[14,14];

            for (int i = 0; i < test; i++)
            {
                deck.Shuffle();
                Card c1 = new Card(deck.TakeACard());
                Card c2 = new Card(deck.TakeACard());
                tab[c1.ValueR -1, c2.ValueR - 1]++;
                tab[c2.ValueR -1, c1.ValueR - 1]++;
            }
            StreamWriter stream = new StreamWriter("c:\\output.txt", true);
            long min = test;
            long max = 0;
            for(int i=0;i<13;i++)
            {
                for(int j=0;j<=i;j++)
                {
                    if (min > tab[i, j])
                        min = tab[i, j];
                    if(max < tab[i, j])
                        max = tab[i, j];
                    stream.Write(tab[i, j]);
                    stream.Write(" ");
                }
                stream.Write("\n");
            }

            stream.Close();
double dis=(max-min)*1.0/test;
Console.WriteLine(dis +"   " +test);
        }

    }
}
