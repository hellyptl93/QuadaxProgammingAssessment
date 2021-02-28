using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadaxProgrammingAssessment
{
    class Program
    {
        static void Main(string[] args)
        {
            // To show instructions for Game to start
            MasterMindMenu();
            Console.ReadKey();
        }

        private static void MasterMindMenu()
        {
            Console.WriteLine("***********************************************************************************************");
            Console.WriteLine("Welcome to the Mastermind game developed by Helly.");
            Console.WriteLine("***********************************************************************************************");
            Console.WriteLine("Rules::");
            Console.WriteLine("1. Four random numbers between 1-6 will be generated.");
            Console.WriteLine("2. Guess the correct four numbers.");
            Console.WriteLine("3. You will see a Minus sign (-) if you have guessed the correct number but in the wrong position.");
            Console.WriteLine("4. You will see a Plus sign (+) if you have guessed the correct number and in the correct position.");
            Console.WriteLine("5. No results for incorrect digits");
            Console.WriteLine("6. You have only 10 attempts to guess the correct number.");
            Console.WriteLine("***********************************************************************************************");
            
            Console.WriteLine("Are you ready to start the game? y/n");
            // To read the user input.. If you enter "y" you'll get into the game else you'll exit.
            var userinput = Console.ReadLine();
            if (userinput.ToUpper() == "Y")
            {
                // To start the game
                BeginMasterMind();
            }
            else
            {
                // To exit the game
                Environment.Exit(0);
            }


        }

        private static void BeginMasterMind()
        {
            List<int> randomNumber = new List<int>();          // initiate the list for random numbers
            int[] playerNumbers = new int[4];                   // Player guess
            randomNumber = GenerateRandomNumber();             // To get the random numbers
            string[] guessNumber = new string[4];            // Array to check the matching guess
            int attemptCounter = 9;            // counter for the while loop
            while (attemptCounter >= 0)
            {
                // Allow the player to guess four numbers
                playerNumbers = PlayerGuesses();
                // To match the guess
                guessNumber = CheckNumbers(randomNumber, playerNumbers);
                // To show the result
                PlayerResult(guessNumber, attemptCounter, randomNumber);
                attemptCounter -= 1; // Counter decrease for false attempt
            }

        }
        private static int[] PlayerGuesses()
        {
            int[] player = new int[4];
            Console.WriteLine("Choose a number between 1-6");
            // Loop through four times to guess four numbers
            for (int i = 0; i < 4; ++i)
            {
                try
                {
                    player[i] = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Can't leave it empty!");
                    player[i] = Convert.ToInt32(Console.ReadLine());
                }

            }
            Console.WriteLine("Your Guesses are:");
            Console.WriteLine(player[0] + "," + player[1] + "," + player[2] + "," + player[3]);
            return player;
        }


        private static void PlayerResult(string[] checks, int attempts, List<int> randomNumber)
        {
            // Check indexes are correct and also at correct position
            if (checks[0] == "+" && checks[1] == "+" && checks[2] == "+" && checks[3] == "+")
            {
                Console.WriteLine("Bingo! You got it right!");
                Console.WriteLine("***********************************************************************************************");
                Console.WriteLine("Wanna play again? y/n");
                var userinput = Console.ReadLine();
                if (userinput.ToUpper() == "Y")
                {
                    // To restart the game
                    BeginMasterMind();
                }
                else
                {
                    // To exit
                    Environment.Exit(0);
                }
            }
            // when user left with the last attempt
            else if (attempts == 1)
            {
                Console.WriteLine("You've got last chance remaining");
                Console.WriteLine("***********************************************************************************************");
            }
            // No attempt remaining
            else if (attempts == 0)
            {
                Console.WriteLine("You lost!");
                Console.Write("The Correct Number were:");
                Console.WriteLine(randomNumber[0] + "," + randomNumber[1] + "," + randomNumber[2] + "," + randomNumber[3]);
                Console.WriteLine("***********************************************************************************************");
                Console.WriteLine("Do you wanna play again? y/n");
            }
            else
            {
                var remaining = (attempts).ToString();
                Console.WriteLine("Try again!!");
                Console.WriteLine("You have " + remaining + " attempt(s) left.");
                Console.WriteLine("***********************************************************************************************");

            }
        }

        private static string[] CheckNumbers(List<int> randomNumber, int[] playerNumbers)
        {
            string[] signs = new string[4];
            // Loop through the player's guesses 
            for (int p = 0; p < playerNumbers.Length; ++p)
            {
                // Loop through random numbers
                for (int r = 0; r <= randomNumber.Count - 1; ++r)
                {
                    // If found a match
                    if (playerNumbers[p] == randomNumber[r])
                    {
                        // If found a match at the same position
                        if (p == r)
                        {
                            signs[p] = "+";
                            break;
                        }
                        // If found a match at the different position
                        else
                        {
                            signs[p] = "-";
                            break;
                        }
                    }
                    // No match
                    else
                    {
                        signs[p] = " ";
                    }
                }
            }
            Console.WriteLine("Result:");
            Console.WriteLine(signs[0] + "," + signs[1] + "," + signs[2] + "," + signs[3]);
            return signs;
        }
      
        private static List<int> GenerateRandomNumber()
        {
            // Create an object of Random class
            Random rnd = new Random();
            // Hold the value to return
            List<int> randomNumber = new List<int>();
            int random;
            // Runs until the count hit the 4th item
            while (randomNumber.Count < 4)
            {
                // To save the random number
                random = rnd.Next(1, 7);
                // To avoid generating duplicate numbers into the list
                if (!randomNumber.Contains(random))
                {
                    randomNumber.Add(random);
                }
            }
            return randomNumber;
        }
    }
}
