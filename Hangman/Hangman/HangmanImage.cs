using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    internal class HangmanImage
    {
        string[] Image =
        {
            "_/V\\_",
            "(d_b)",
            "_/Y\\_",
            " |I| ",
            " / |",
            " | |",
            "-   -"
        };

        public HangmanImage(){}

        public void Drow(int lives)
        {
            int j = Image.Length - (Image.Length - lives);
            for(int i = 0; i < j; i++)
            {
                Console.WriteLine("\t{0}", Image[i]);
            }
        }
    }
}
