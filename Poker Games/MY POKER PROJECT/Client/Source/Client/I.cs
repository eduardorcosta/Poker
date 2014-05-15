using System;
using System.IO;
using System.Net.Sockets;

namespace PokerGame
{
    static class I
    {
        //static TcpClient server = new TcpClient();
        //static StreamWriter sw;
		//static TextWriter sw;//stringWriter = new StringWriter();
		//static TextReader sr;
        static string tmp;//Stream ("");
        

        static string name;
        static int money;
		//static string infile="in.txt";
		//static string outfile = "out.txt";

        public static void Initialize()
        {
			//server.Connect(System.Net.IPAddress.Parse("127.0.0.1"), 55555);
			//sw = new string();//infile);//server.GetStream());
			//sw.AutoFlush = true;
            //sw = new string("a");//
            tmp = " ";
            //null;//new string.emptt=("");
            //sw = new StringWriter();// new StreamWriter("");
			//sr;// = new StringReader();//server.GetStream());
        }

        public static string Name
        {
            get { return name; }
            set { name = value; }
        }
        //public static string sw
        //{
        //    get {return _sw;}
        //    set{ _sw=sw; }
        //}
        public static int Money
        {
            get { return money; }
            set { money = value; }
        }

        public static void Write(string a)
        {
            //sw.WriteLine(a);
            //sw.Write(a);
            tmp = a;
        }

        public static string Read()
        {
            return (tmp);//sr.ToString());
        }

		public static void Clean()
		{
			tmp = string.Empty;
		}

    }
}
