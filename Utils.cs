using System;
using System.Drawing;
using Console = Colorful.Console;

namespace Spotify_Account_Creator
{
    class Utils
    {

        public static void centerText(String text, Color color)
        {
            Console.WriteLine(string.Format("{0," + (Console.WindowWidth / 2 + text.Length / 2) + "}", text), color);
        }

    }
}
