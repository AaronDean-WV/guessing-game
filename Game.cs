using System;

class Program
{
    static void Main()
    {
        Random random = new Random();
        int secretNumber = random.Next(1, 101);
        int maxGuesses = 0;
        int numGuesses = 0;

        Console.WriteLine("Time to play high stakes guessing!");
        Console.WriteLine("Choose the difficulty level:");
        Console.WriteLine("1. Easy");
        Console.WriteLine("2. Medium");
        Console.WriteLine("3. Hard");
        Console.WriteLine("4. Cheater");

        while (maxGuesses == 0)
        {
            Console.Write("Enter the difficulty level (1-4): ");
            string difficultyInput = Console.ReadLine();

            if (int.TryParse(difficultyInput, out int difficultyLevel))
            {
                switch (difficultyLevel)
                {
                    case 1:
                        maxGuesses = 8;
                        break;
                    case 2:
                        maxGuesses = 6;
                        break;
                    case 3:
                        maxGuesses = 4;
                        break;
                    case 4:
                        maxGuesses = -1; // Unlimited guesses for cheater mode
                        break;
                    default:
                        Console.WriteLine("Invalid difficulty level. Please enter a number between 1 and 4.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }

        Console.WriteLine();
        Console.WriteLine("You have " + (maxGuesses == -1 ? "an unlimited amount of" : maxGuesses.ToString()) + " chances to guess the correct number or perish.");
        Console.WriteLine();

        while (numGuesses < maxGuesses || maxGuesses == -1)
        {
            Console.Write("Enter your guess (or leave blank to exit): ");
            string userInput = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine("Exiting the program...");
                return;
            }

            if (int.TryParse(userInput, out int userGuess))
            {
                Console.WriteLine("Your guess is: " + userGuess);

                if (userGuess == secretNumber)
                {
                    Console.WriteLine("Congratulations! You get to keep on living!");
                    break;
                }
                else if (secretNumber > userGuess)
                {
                    Console.WriteLine($"Sorry, your guess is incorrect. It's too low. You have {GetGuessesLeft(maxGuesses, numGuesses)} left.");
                }
                else
                {
                    Console.WriteLine($"Sorry, your guess is incorrect. It's too high. You have {GetGuessesLeft(maxGuesses, numGuesses)} left.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }

            numGuesses++;
        }

        if (numGuesses >= maxGuesses && maxGuesses != -1)
        {
            Console.WriteLine("You have run out of guesses. You must perish. The secret number was: " + secretNumber);
        }
    }

    static string GetGuessesLeft(int maxGuesses, int numGuesses)
    {
        if (maxGuesses == -1)
        {
            return "an unlimited amount";
        }
        else
        {
            return (maxGuesses  - (numGuesses + 1)).ToString();
        }
    }
}
