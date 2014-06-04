using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    class Program
    {
        private static Random random = new Random();
        private static bool exit = false;
        private static bool validmove = false;
        static void Main()
        {
            Console.WriteLine("Rock Paper Scissors - Type Exit to close the program");
            Move playerMove = Move.Paper;
            do
            {
             Console.WriteLine("Type your move: Rock, Paper, Scissors!");
             Console.WriteLine("--------------------------------------------------------");

                 
                do
                {
                    validmove = false;
                    string input = Console.ReadLine();
                    if (input == "exit")
                    {
                        exit = true;
                        break;
                    }
                    try
                    {
                        playerMove = (Move)Enum.Parse(typeof(Move), input);
                        validmove = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("That is not a valid move");
                       
                    }

                    
                } while (!(validmove));
            if (exit)
            {
                break;
            }
            Move computerMove = Generatemove();
            Console.WriteLine(computerMove.ToString());
            Console.WriteLine(EvaluateWinner(computerMove,playerMove).ToString());
            Console.WriteLine("--------------------------------------------------------");
            } while (true);
        }

        static Move Generatemove()
        {
            Array values = Enum.GetValues(typeof (Move));
            var move = (Move)values.GetValue(random.Next(values.Length));
            return move;
        }

        static GameOutcomes EvaluateWinner(Move computer, Move player)
        {
            int computerMoveValue = (int) computer;
            int playerMoveValue = (int) player;

            int diff = playerMoveValue - computerMoveValue;
            int outcomeNumber = diff % 3;
            if (outcomeNumber < 0)
                outcomeNumber += 3;
            return ((GameOutcomes)outcomeNumber);
        }

        #region enums

        enum Move
        {
            Rock,
            Paper,
            Scissors

        }

        enum GameOutcomes
        {
            Draw = 0,
            PlayerWins = 1,
            ComputerWins = 2,
        }

        #endregion
    }

}
