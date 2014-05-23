using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;
using System.Threading;
using System.Windows.Forms.VisualStyles;
using System.Windows.Forms;
using FileSystemWatcher.Properties;

namespace FileSystemWatcher
{
	public class FileReverseRead
	{


		private static readonly Encoding encoding = Encoding.ASCII;
		private const bool loop = true;

		public string Filename { set; get;}
		public int NoOfLinesWanted { get; set;}


		public List<List<String>> FindHand()
		{
			//const int neededLines = 5;
			List<List<string>> handFile = new List<List<string>> ();
			StreamReader file = new StreamReader(Filename);
			List<String> hand = new List<String>();
			string line;
			while((line = file.ReadLine()) != null){
				hand.Add(line);
				if(line.Contains("HAND")){
					handFile.Add (hand);
					hand = new List<String>();
				}
		
			}
			return handFile;

		}
			//List <string> text = File.ReadLines(Filename).Reverse().Take(2).ToList()



		public FileReverseRead ()
		{
			int noOfLines = 0;
			//int returnStatus = 0;
			string newline = "\n";//Environment.NewLine;??
			int charSize = encoding.IsSingleByte ? 1 : 2;
			byte[] buffer = null;
			bool printed = false;
			string temp = string.Empty;

			//ParseArgs (args);

			FileStream stream = null;
			try {                    
				stream = new FileStream (Filename, FileMode.Open, 
					FileAccess.Read, FileShare.Write);
				long endPos = stream.Length / charSize, oldPos = 0;
				long posLength;
				do {
					printed = false;
					noOfLines = 0;
					buffer = new byte[charSize];
					endPos = stream.Length / charSize;
					if (endPos <= oldPos)
						oldPos = endPos;  	// if file's content is 
					//deleted, reset position
					posLength = endPos - oldPos;

					for (long pos = charSize; pos <= posLength; pos += charSize) {
						stream.Seek (-pos, SeekOrigin.End);
						stream.Read (buffer, 0, charSize);
						temp = encoding.GetString (buffer);
						if (temp == newline) {
							noOfLines++;
						}
						if (noOfLines == NoOfLinesWanted ){ //|| pos == noOfCharsWanted) {
							buffer = new byte[endPos - stream.Position];
							stream.Read (buffer, 0, buffer.Length);
							Console.WriteLine (encoding.GetString (buffer));
							printed = true;
							oldPos = endPos;
							break;
						}
					}
					if (!printed) {
						buffer = new byte[endPos - oldPos];
						stream.Seek (-1, SeekOrigin.Current);
						stream.Read (buffer, 0, buffer.Length);
						Console.WriteLine (encoding.GetString (buffer));
						oldPos = endPos;
					}
					if (loop && endPos == stream.Length / charSize)
						Thread.Sleep (0);
				} while (true);
			} catch (Exception) {
				//Console.WriteLine ("Encountered some error.");
				//returnStatus = -1;
			} finally {
				if (stream != null)
					stream.Close ();
			}

			//return returnStatus;
		}
	}
}

