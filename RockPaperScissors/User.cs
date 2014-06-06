using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RockPaperScissors
{
    public class User
    {
        #region Properties

        public string UserID { get; set; }

        public int CurrentScore { get; set; }

        public int TopScore { get; set; }


        #endregion

        #region Constructers

        public User(String username, int currentScore)
        {
            CurrentScore = currentScore;
            UserID = username;
            TopScore = 0;
        }

        #endregion

        #region Helpers

        public void UpdateScore(Program.GameOutcome outcome)
        {
            switch (outcome)
            {
                case Program.GameOutcome.PlayerWins:
                    CurrentScore += 1;
                    if (TopScore < CurrentScore)
                    {
                        TopScore = CurrentScore;
                    }
                    break;

                case Program.GameOutcome.ComputerWins:
                    CurrentScore = 0;
                    break;

                case Program.GameOutcome.Draw:
                    break;
            }

            UserBase rpcscore = new UserBase();
            var score = rpcscore.Users.Find(UserID);
        }
        #endregion
    }

}
