using System;
using System.Net;
using System.Threading;

/*
* Created by TTheHolyOne#1642
* Holy Tools - Installer  V1
* Made all in C# and .NET Framework 4.7.2
* This was made with very basic C#
* Feel free to use all of the code
* My github is github.com/ttheholyone
* My youtube is youtube.com/ttheholyone
* my website is skids.host
* Please enjoy <3 I worked hard on this just note to make it into a exe you need Visual Studio then you need to build the code 
* Join any programming discord or look it up if you need further help
* Enjoy
* Feel free to delete my credits but I would appreciate it if you wouldnt :)
*/


namespace installtemplate
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Title = ("Holy Installer V1 - Welcome");
            Console.BackgroundColor = ConsoleColor.Black;


            string empty = string.Empty;
            string str1 = string.Empty;
            foreach (string str2 in args)
                str1 = str1 + str2 + " ";


            ConsoleColors();
            Console.Write(" Holy Installer | Made By TTheHolyOne#1642\n");

            Thread.Sleep(3000);



            // Downloading

            ConsoleColors();
            Console.Write(" Installing.. | ");
            var spinner = new Spinner(25, 1);
            Console.Title = ("Holy Installer - Installing");
            spinner.Start();
            using (WebClient webClient = new WebClient())
            {
                webClient.DownloadFile("download link here", "directory here");
            }
            spinner.Stop();
            Thread.Sleep(2000);
            Console.WriteLine("");
            ConsoleColors();
            Console.Write(" Finished | Please Wait Three Seconds...");
            Thread.Sleep(3000);

            Console.Clear();
            ConsoleColors();
            Console.Title = ("Holy Installer - Finished");
            Console.Write(" Installation done.. | Look inside the folder!\n");

            ConsoleColors();
            Console.Write(" https://skids.host | Our Website\n");
            ConsoleColors();
            Console.Write(" https://github.com/ttheholyone | My Github\n");
            ConsoleColors();
            Console.Write(" https://youtube.com/ttheholyone | My Youtube\n");

            ConsoleColors();
            Console.Title = ("Holy Installer - Goodbye");
            Console.Write(" Enjoy!");
            Console.Read();
            // Goes to any website you choose I chose mine System.Diagnostics.Process.Start("https://skids.host/install");
        }
        static void ConsoleColors()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("CONSOLE");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("]");
            Console.ForegroundColor = ConsoleColor.Cyan;
        }
        public class Spinner : IDisposable
        {
            private const string Sequence = @"/-\|";
            private int counter = 0;
            private readonly int left;
            private readonly int top;
            private readonly int delay;
            private bool active;
            private readonly Thread thread;

            public Spinner(int left, int top, int delay = 100)
            {
                this.left = left;
                this.top = top;
                this.delay = delay;
                thread = new Thread(Spin);
            }

            public void Start()
            {
                active = true;
                if (!thread.IsAlive)
                    thread.Start();
            }

            public void Stop()
            {
                active = false;
                Draw(' ');
            }

            private void Spin()
            {
                while (active)
                {
                    Turn();
                    Thread.Sleep(delay);
                }
            }

            private void Draw(char c)
            {
                Console.SetCursorPosition(left, top);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write(c);
            }

            private void Turn()
            {
                Draw(Sequence[++counter % Sequence.Length]);
            }

            public void Dispose()
            {
                Stop();
            }
        }
    }
}
