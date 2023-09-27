using Dewey_Decimal_System2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Dewey_Decimal_System2.Controllers
{
    public class HomeController : Controller
    {
        //A list is used to store the call numbers.
        private List<string> callNumbers;
        //(Python (2019a))

        public HomeController()
        {
            // This is to initialized the list of call numbers here.
            callNumbers = GenerateRandomCallNumbers(10);
            //(Olumide, S. (2023))
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ReplacingBooks()
        {
            // This is to shuffle the call numbers to make them random.
            Shuffle(callNumbers);

            // This is to pass the shuffled call numbers to the view.
            return View(callNumbers);
        }
        //(Vishal (2018))

        //Display ten randomly generated call numbers.
        private List<string> GenerateRandomCallNumbers(int count)
        {
            List<string> callNumbers = new List<string>();
            Random random = new Random();

            for (int i = 0; i < count; i++)
            {
                // This is to generate a random topic number.
                int topicNumber = random.Next(1, 1000);

                // This is to generate random initials for the author.
                string authorInitials = $"{(char)random.Next('A', 'Z' + 1)}{(char)random.Next('A', 'Z' + 1)}{(char)random.Next('A', 'Z' + 1)}";

                // This is to format the call number as "topicNumber authorInitials".
                string callNumber = $"{topicNumber:D3} {authorInitials}";

                callNumbers.Add(callNumber);
            }

            return callNumbers;
        }

        //An appropriate sorting algorithm is used to sort the call numbers.
        //This takes a list (List<T>) as input and shuffles its elements randomly.
        private static void Shuffle<T>(List<T> list) 
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                
                //algorithm, which is an algorithm for generating a random permutation of a finite sequence.
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
        //Java shuffle arrays (Fisher Yates) - dot net Perls (no date)

        //User can change the order of the call numbers.
        //App checks whether the user got the ordering correct.
        [HttpPost]
        public IActionResult CheckOrder(List<string> OrderedCallNumbers)
        {
            List<string> sortedCallNumbers = OrderedCallNumbers.OrderBy(x => x).ToList();

            bool isCorrectOrder = OrderedCallNumbers.SequenceEqual(sortedCallNumbers);

            return View("Result", isCorrectOrder);
        }
        //earranging a set of numbers into order (no date)

    }
}
//[1]Python (2019a) GeeksforGeeks. Available at: https://www.geeksforgeeks.org/python-create-list-of-numbers-with-given-range/
//(Accessed: September 26, 2023).
//[2]Olumide, S. (2023) How to initialize a Java list – list of string initialization in Java, freecodecamp.org. Available at:
//https://www.freecodecamp.org/news/how-to-initialize-a-java-list/ (Accessed: September 26, 2023).
//[3]Vishal (2018) Python random.shuffle() function to shuffle list, PYnative. Vishal. Available at:
//https://pynative.com/python-random-shuffle/ (Accessed: September 26, 2023).
//[4]Java shuffle arrays (Fisher Yates) - dot net Perls (no date) Dotnetperls.com. Available at:
//https://www.dotnetperls.com/shuffle-java (Accessed: September 26, 2023).
//[5]Rearranging a set of numbers into order (no date) Code Golf Stack Exchange. Available at:
//https://codegolf.stackexchange.com/questions/49935/rearranging-a-set-of-numbers-into-order (Accessed: September 26, 2023).