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
            string word;// picks a word for game

            Console.WriteLine("choose play option(enter a number)");
            Console.WriteLine("1 - play with computer");
            Console.WriteLine("2 - play with friend");


            int option = int.Parse(Console.ReadLine()); // loop for selecting type of game - random word or selected word by friend
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

            Console.Clear();


            var validCharacters = new Regex("^[a-z]$"); // command which regulates symbols that is valid to use, 

            var lives = 7; // general number to define of wrong entries for guess

            var letters = new List<string>();
            //empty array that contains all letters submitted during game

            HangmanImage hangmanImage = new HangmanImage();

            while (lives != 0) // loop is valid until word is guessed or chances of guesses have exceeded
            {
                Console.WriteLine();
                hangmanImage.Drow(lives);
                Console.WriteLine();

                var charactersLeft = 0;
                foreach (var characters in word) // loop for all characters in word, replacing unguessed letter as * 
                                                 //and shows correct place of letter in word
                {
                    var letter = characters.ToString();

                    if (letters.Contains(letter))
                    {
                        Console.Write(letter);
                    }
                    else
                    {
                        Console.Write("*");
                        charactersLeft++;
                    }

                }
                Console.WriteLine(string.Empty);

                if (charactersLeft == 0) // break of loop, when game is over - no characters left to guess
                {
                    break;
                }

                Console.Write("Type in your letter: ");

                var key = Console.ReadKey().Key.ToString().ToLower(); // defining that all characters will be transfered to lower case
                Console.WriteLine(string.Empty);

                if (!validCharacters.IsMatch(key)) // loop which check if entered value is valid for defined REGEX symbols
                {
                    // If the character is invalid, we loop back to the beginning using the
                    // "continue" statement and let the user know of the error.
                    Console.WriteLine($"The letter {key} is invalid. Try again.");
                    continue;
                }

                if (letters.Contains(key)) // to check if entries is not repeating
                {
                    // If the character is repeating, remind of entry, no chances taken off
            
                    Console.WriteLine("You already entered this letter!");
                    continue;
                }

                letters.Add(key); // if entry is a new, this string add letter in defined letter array line 41
                if (!word.Contains(key)) // loop to define correct guesses and reduce lives to enter letter
                {
                    lives--;
                    if (lives > 0)
                    {
                        // Here, a ternary is used in the string to either how a pluralized
                        // version of "try" or the singular one, depending on how many
                        // lives are left.
                        Console.WriteLine($"The letter {key} is not in the word. You have {lives} {(lives == 1 ? "try" : "tries")} left.");  
                        // boolean defines correct form of word to use on display
                    }
                }
            }
            // loop to show result of game - win or lost
            if (lives > 0)
            {
                // boolean for correct form of word
                Console.WriteLine($"You won with {lives} {(lives == 1 ? "life" : "lives")} left!");
            }
            else
            {
               Console.WriteLine($"You lost! The word was {word}.");
            }
            Console.ReadLine();
        }
    }
}

             


