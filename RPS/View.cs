using System;
using System.Threading;

namespace RPS
{
    class View
    {
        public View(Model m, Controller c)
        {
            while (true)
            {
                Thread.Sleep(250);
                string UserInput = QueryUserInput();
                string resultMessage = GetResultMessage(c.ProcessResult(UserInput));
                Thread.Sleep(250);
                Console.WriteLine(resultMessage);
                Thread.Sleep(250);
                Console.WriteLine(value: "In " + m.roundsPlayed + " rounds played, the score is now You: " + m.userScore.ToString() + ", Me: " + m.opponentScore.ToString() + "." + Environment.NewLine);
                Thread.Sleep(250);
            }
        }
        public string QueryUserInput()
        {
            Console.Write(value: "Please enter \"r\" for rock, \"p\" for paper, or \"s\" for scissors." + Environment.NewLine);
            string letter;
            letter = Console.ReadLine();
            if (letter != "r" && letter != "p" && letter != "s")
            {
                Console.WriteLine("Error!  Incorrect input given.");
                return QueryUserInput();
            }
            else
            {
                return letter;
            }

        }
        public string GetResultMessage(int messageInt)
        {
            return messageInt switch
            {
                0 => "Too bad!  You lost!",
                1 => "Congrats!  You won!",
                2 => "It's a tie!",
                _ => throw new Exception(),
            };
        }
    }
}
