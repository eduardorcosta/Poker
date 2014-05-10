
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

namespace poker
{
    class BlindsStructure
    {
        long initStake=0;
        int state = 0;

        public int State
        {
            get { return state; }
            set { state = value; }
        }


        private static int realLengthBlinds=11;
        private static int realLengthAggrBlinds;

        public static int RealLengthAggrBlinds
        {
            get { return BlindsStructure.realLengthAggrBlinds; }
            set { BlindsStructure.realLengthAggrBlinds = value; }
        }
        public static int RealLengthBlinds
        {
            get { return realLengthBlinds; }
            set { realLengthBlinds = value; }
        }
       
        static long[,] blinds = new long[,] { { 0, 1, 2 }, { 0, 2, 4 }, { 0, 4, 8 }, { 0, 5, 10 }, { 0, 10, 20 }, { 0, 15, 30 }, { 0, 20, 40 }, { 0, 25, 40 }, { 0, 30, 60 }, { 0, 50, 100 }, { 0, 100, 200} };
        static long[,] aggrblinds = new long[,] { { 0, 500, 1000 }, { 0, 1000, 2000 }, { 0, 1500, 3000 }, { 0, 2000, 4000 }, { 0, 3000, 5000 }, { 0, 4000, 7000 }, { 0, 5000, 10000 }, { 0, 10000, 20000 }, { 0, 20000, 40000 }, { 0, 40000, 80000 }, { 0, 80000, 160000 } };

public static long[,] Blinds
{
  get { return blinds; }
  set { blinds = value; }
}

        public static long[,] AggrBlinds
        {
            get { return aggrblinds; }
            set { aggrblinds = value; }
        }
public  long getAggrBlind()
{
    int i = state;
    if (i >= realLengthAggrBlinds )
    {

        i = realLengthAggrBlinds  - 1;
    }
    return aggrblinds[i, 1];
}
        public  long getAggrAnte()
{
    int i = state;
    if (i >= realLengthAggrBlinds)
    {

        i = realLengthAggrBlinds - 1;
    }

    return aggrblinds[i, 0];
}
public  long getAggrBigBlind()
{
    int i = state;
    if (i >= realLengthAggrBlinds )
    {

        i = realLengthAggrBlinds  - 1;
    }
    return aggrblinds[i, 2];
}

        public static int GetLengthAggr() {
            return BlindsStructure.RealLengthAggrBlinds;
        
        }
        public static int GetLength()
        {
            return BlindsStructure.RealLengthBlinds;

        }

        public   long getBlind()
        {
            int i = state;
            if (i >= realLengthBlinds )
            {

                i = realLengthBlinds  - 1;
            }
           return blinds[i,1];
        }
        public  long getAnte()
        {
            int i = state;
            if (i >= realLengthBlinds )
            {

                i = realLengthBlinds  - 1;
            }
            return blinds[i, 0];
        }
        public  long getBigBlind()
        {
            int i = state;
            if (i >= realLengthBlinds )
            {

                i = realLengthBlinds  - 1;
            }
            return blinds[i,2];
        }
        //increase state  SB/BB/
        public void IncreaseBlindState(){
        
        state++;
        }


   


    
    
    }
}
