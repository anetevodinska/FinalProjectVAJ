using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Hangman
{
    internal class WordGenerator
    {

        public static string GetWord(bool IsRandom)
        {
            string Word = "";

            if (IsRandom)
            {
                Word = GetWordFromInternet().Result;
            }
            else
            {
                Word = GetWordFromUser();
            }

            return Word;
        }
        private static string GetWordFromUser()
        {
            Console.WriteLine("Please enter the word");
            string Word = Console.ReadLine();
            return Word;
        }
        /// <summary>
        /// Method get a word from internet
        /// From https://learn.microsoft.com/en-us/aspnet/web-api/overview/advanced/calling-a-web-api-from-a-net-client
        /// </summary>
        /// <returns>Word from internet</returns>
        private static async Task<string> GetWordFromInternet()
        {
            HttpClient client = new HttpClient();
            string temper;

            // We  send request to API and await for word
            HttpResponseMessage response = await client.GetAsync("https://random-word-api.herokuapp.com/word?lang=en"); 
            if (response.IsSuccessStatusCode)
            {
                // Get word from response (ex ["mam"])
                temper = await response.Content.ReadAsStringAsync();
                // Make word as word (ex ["mam"] => mam)
                string Word = temper[2..(temper.Length - 2)];
                return Word;
            }
            return "Error";
        }
    }

    

}
