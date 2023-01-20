using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class Program
    {
        public static void Main(string[] args)
        {
            string word;

            Console.WriteLine("choose play option(enter a number)");
            Console.WriteLine("1 - play with computer");
            Console.WriteLine("2 - play with friend");


            int option = int.Parse(Console.ReadLine());
            if(option == 1)
            {
                word = WordGenerator.GetWord(true);
            }else if(option == 2)
            {
                word = WordGenerator.GetWord(false);
            }
            else
            {
                Console.WriteLine("Error:");
                return;
            }
            
            Console.WriteLine(word);

        }

    }
}
