using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            if (option == 1)
            {
                word = WordGenerator.GetWord(true);
            }
            else if (option == 2)
            {
                word = WordGenerator.GetWord(false);
            }
            else
            {
                Console.WriteLine("Error:");
                return;
            }

            var chosenWord = word[word.Length - 1];

            var validCharacters = new Regex("^[a-z]$");

            var lives = 7;

            var letters = new List<string>();
            //empty array that contains all letters submitted during game


            while (lives != 0) // loop is valid until word is guessed or chances of guesses exceed
            {
                int charactersLeft = 0;
                foreach (var characters in chosenWord)
                {
                    var letter = characters.ToString();

                    if (letters.Contains(letter))
                    {
                        Console.Write(letter);
                    }
                    else
                    {
                        Console.Write("_");
                        charactersLeft++;
                    }
                    
                }
                Console.WriteLine(string.Empty);

                if (charactersLeft == 0)

                    Console.Write("Type in your letter: ");

                var key = Console.ReadKey().Key.ToString().ToLower();
                Console.WriteLine(string.Empty);

                if (!validCharacters.IsMatch(key))
                {
                    // If the character is invalid, we loop back to the beginning using the
                    // "continue" statement and let the user know of the error.
                    Console.WriteLine($"The letter {key} is invalid. Try again.");
                }

                if (letters.Contains(key))
                {
                    Console.WriteLine("You already entered this letter!");
                }

                letters.Add(key);
                if (chosenWord.Contains(key))
                {
                    lives--;
                    if (lives > 0)
                    {
                        // Here, a ternary is used in the string to either how a pluralized
                        // version of "try" or the singular one, depending on how many
                        // lives are left.
                        Console.WriteLine($"The letter {key} is not in the word. You have {lives} {(lives == 1 ? "try" : "tries")} left.");
                    }
                    if (lives > 0)
                    {
                        // This uses a ternary to pluralize the word lives unless there only one life left
                        Console.WriteLine($"You won ");
                    }

                    else
                    {
                        Console.WriteLine($"You lost! The word was {chosenWord}.");
                    }
                }
            }
        }
    }
}
             


