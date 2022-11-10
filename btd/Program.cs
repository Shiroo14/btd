using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace btd
{
    class Options
    {
        //[CommandLine.Option('i', "input", Required = true, HelpText = "入力するファイル名")]
        public string InputFile
        {
            get;
            set;
        }

        //[CommandLine.Option('o', "output", Required = true, HelpText = "出力するファイル名")]
        public string OutputFile
        {
            get;
            set;
        }
    }

    internal static class Program
    {
        public static bool nd = false, nt = false, nb = true, nbt = false, nbet = false;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            int x = 0, y = 0;
            foreach (string cmd in args)
            {
                Console.WriteLine(cmd);
                if ( cmd.IndexOf("/x=") >= 0) //x pos
                {
                    x = int.Parse(cmd.Substring( cmd.IndexOf("=")+1 ));
                }
                if (cmd.IndexOf("/y=") >= 0) //y pos
                {
                    y = int.Parse(cmd.Substring( cmd.IndexOf("=")+1 ));
                }
                if (cmd.IndexOf("/t") >= 0) // 時刻を表示
                {
                    Program.nt = true;
                }
                if (cmd.IndexOf("/d") >= 0) // 日付を表示
                {
                    Program.nd = true;
                }
                if (cmd.IndexOf("/nb") >= 0) // battry %非表示
                {
                    Program.nb = false;
                }
                if (cmd.IndexOf("/br") >= 0) // battry remain time表示
                {
                    Program.nbt = true;
                }
                if (cmd.IndexOf("/be") >= 0) // battry estimate time表示
                {
                    Program.nbet = true;
                }
                if (cmd.IndexOf("/h") >= 0) // help表示
                {
                    MessageBox.Show("Battery Time Date\n\n/x pos x\n/y pos y\n/t time\n" +
                        "/d date\n/nb no battery%\n/br battery remain time\n" +
                        "/be estimate time\nleft click:hide\nright click:move&menu");
                    Environment.Exit(0);
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(x, y));
        }

    }
}

