using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    public class Program
    {
        private static Random random = new Random();
        private static bool exit = false;
        private static bool validmove = false;
       
        static void Main()
        
        {
            Console.WriteLine("Rock Paper Scissors - Type Exit to close the program");
            Console.WriteLine("Type a Username to start:");
            User currentuser = new User(Console.ReadLine(),0);

            var context = new UserBase();
            context.Users.Add(currentuser);
            context.SaveChanges();

            Move playerMove = Move.Paper;
            do
            {
             Console.WriteLine("Type your move: Rock, Paper, Scissors!");
             Console.WriteLine("--------------------------------------------------------");

                 
                do
                {
                    validmove = false;
                    string input = System.Globalization.CultureInfo.InvariantCulture.TextInfo.ToTitleCase(Console.ReadLine());
                    if (input != "Exit")                   
                    {
                        try
                        {
                            playerMove = (Move) Enum.Parse(typeof (Move), input);
                            validmove = true;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("That is not a valid move");

                        }                        
                    }
                    else
                    {
                        exit = true;
                    }


                } while (!(validmove)& !exit);
            if (!exit)
            {
                Move computerMove = Generatemove();
                Console.WriteLine(computerMove.ToString());

                GameOutcome outcome = EvaluateWinner(computerMove, playerMove);
                currentuser.UpdateScore(outcome);
                Console.WriteLine(StringHelpers.Seperate(outcome.ToString()));
                Console.WriteLine("--------------------------------------------------------");


                Console.WriteLine("{0}'s Top Score: {1}", currentuser.UserID, currentuser.TopScore);
                Console.WriteLine("{0}'s Current Score: {1}", currentuser.UserID, currentuser.CurrentScore);
                Console.WriteLine("--------------------------------------------------------");
            }
            
            } while (!(exit));
        }

        static Move Generatemove()
        {
            Array values = Enum.GetValues(typeof (Move));
            var move = (Move)values.GetValue(random.Next(values.Length));
            return move;
        }

        static GameOutcome EvaluateWinner(Move computer, Move player)
        {
            int computerMoveValue = (int) computer;
            int playerMoveValue = (int) player;

            int diff = playerMoveValue - computerMoveValue;
            int outcomeNumber = diff % 3;
            if (outcomeNumber < 0)
                outcomeNumber += 3;
            return ((GameOutcome)outcomeNumber);
        }

        #region enums

        enum Move
        {
            Rock,
            Paper,
            Scissors

        }

        public enum GameOutcome
        {
            Draw = 0,
            PlayerWins = 1,
            ComputerWins = 2,
        }

        #endregion
    }

}
