
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    public class GameFactory
    {
        public Game CreateNewGame(GameAccount player1, GameAccount player2, String gametype, double ExpectedRating)
        {
            try
            {
                if (object.ReferenceEquals(player1, player2))
                {
                    throw new ArgumentException("cannot initiate game of two same players");
                }
                else
                {
                    switch (gametype)
                    {
                        case "Standart":
                            return new StandartGame(player1, player2, ExpectedRating);
                        case "Training":
                            return new TrainingGame(player1, player2, ExpectedRating);
                        case "OnePlayerRatingChange":
                            return new OnePlayerRatingChangeGame(player1, player2, ExpectedRating);
                        default:
                            throw new ArgumentException("Invalid game type");
                    }
                }
            }
            catch (ArgumentException ex)
            {

                Console.WriteLine("Error: " + ex.Message);
                return null;
            }


        }
    }
}
