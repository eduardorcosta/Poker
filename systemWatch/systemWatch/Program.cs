using System;
using System.IO;
using System.Security.Permissions;

namespace systemWatch {
	public class Watcher
	{

		public static void Main()
		{
			Run();

		}

		public static void FileRead(string fullPath)
		{
			StreamReader objReader = new StreamReader(fullPath);
			string line = "";

			while ((line = objReader.ReadLine ()) != null)
			{
				Console.WriteLine(line);
			}
			objReader.Close ();
		}

		[PermissionSet(SecurityAction.Demand, Name="FullTrust")]
		public static void Run()
		{
			//string[] args = System.Environment.GetCommandLineArgs();

			// If a directory is not specified, exit program. 
			//if(args.Length != 2)
			//{
			// Display the proper way to call the program.
			//	Console.WriteLine("Usage: Watcher.exe (directory)");
			//			return;
			//}

			// Create a new FileSystemWatcher and set its properties.
			FileSystemWatcher watcher = new FileSystemWatcher();
			watcher.Path = "/Users/eduardo/Documents/POKER/PokerStar/eddymerks/";
			//args[1];
			/* Watch for changes in LastAccess and LastWrite times, and
	           the renaming of files or directories. */
			watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
				| NotifyFilters.FileName | NotifyFilters.DirectoryName;
			//watcher.NotifyFilter = NotifyFilters.Size| NotifyFilters.FileName | NotifyFilters.DirectoryName;
			// Only watch text files.
			watcher.Filter = "*.txt";

			// Add event handlers.
			watcher.Changed += new FileSystemEventHandler(OnChanged);
			watcher.Created += new FileSystemEventHandler(OnChanged);
			watcher.Deleted += new FileSystemEventHandler(OnChanged);
			watcher.Renamed += new RenamedEventHandler(OnRenamed);

			// Begin watching.
			watcher.EnableRaisingEvents = true;

			// Wait for the user to quit the program.
			Console.WriteLine("Press \'q\' to quit the sample.");
			while(Console.Read()!='q'){}
		}

		// Define the event handlers. 
		private static void OnChanged(object source, FileSystemEventArgs e)
		{
			// Specify what is done when a file is changed, created, or deleted.
			Console.WriteLine("File: " +  e.FullPath + " " + e.ChangeType);
			//FileRead(e.FullPath);
		}

		private static void OnRenamed(object source, RenamedEventArgs e)
		{
			// Specify what is done when a file is renamed.
			Console.WriteLine("File: {0} renamed to {1}", e.OldFullPath, e.FullPath);
		}
	}
}