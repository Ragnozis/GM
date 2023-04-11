using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Win32;

namespace GuessMusic
{
    internal class Quiz
    {
        static public List<string> QuizList = new List<string>();
        static public int GameDuration = 60;
        static public int MusicDuration = 10;
        static public bool RandomStart = false;
        static public string LastFolder = "";
        static public bool AllDirectories = false;

        static public void ReadMusic()
        {
            try
            {
                string[] music_list = Directory.GetFiles(LastFolder, "*.mp3", AllDirectories ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
                QuizList.Clear();
                QuizList.AddRange(music_list);
            }
            catch
            {
                Console.WriteLine("Ошибка");
            }

        }

        static string RegKeyName = "Software\\My\\GuessMelody";
        public static void WriteOptions()
        {
            RegistryKey rk = null;
            try
            {
                rk = Registry.CurrentUser.CreateSubKey(RegKeyName);
                if (rk == null) return;
                rk.SetValue("GameDuration", GameDuration);
                rk.SetValue("MusicDuration", MusicDuration);
                rk.SetValue("RandomStart", RandomStart);
                rk.SetValue("LastFolder", LastFolder);
                rk.SetValue("AllDirectories", AllDirectories);

            }
            finally
            {
                if (rk != null) rk.Close();
            }
        }
        public static void ReadOptions()
        {
            RegistryKey rk = null;
            try
            {
                rk = Registry.CurrentUser.OpenSubKey(RegKeyName);
                if (rk != null)
                {
                    GameDuration = (int)rk.GetValue("GameDuration");
                    MusicDuration = (int)rk.GetValue("MusicDuration");
                    RandomStart = Convert.ToBoolean(rk.GetValue("RandomStart", false));
                    LastFolder = (string)rk.GetValue("LastFolder");
                    AllDirectories = Convert.ToBoolean(rk.GetValue("AllDirectories", false));

                }

            }
            finally
            {
                if (rk != null) rk.Close();
            }
        }

    }
}
