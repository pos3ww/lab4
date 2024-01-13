using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
namespace lab3
{
    public abstract class Game
    {
        public List<double> RatingList = new List<double>();
        public int GameId;
        public int game_decicion;
        public double ExpectedRating;
        public String gametype;
        public Game(GameAccount player1, GameAccount player2, double ExpectedRating)
        {

            Random random = new Random();
            this.game_decicion = random.Next(0, 2);
            this.GameId = random.Next(100000000, 900000000);
            this.ExpectedRating = ExpectedRating;
            
            try
            {
                if (ExpectedRating < 0.0)
                {
                    throw new ArgumentException("Rating change cannot be less than zero!");
                }
                else if (game_decicion == 0)
                {

                    player1.WinGame(player2, this);
                    player2.LooseGame(player1, this);
                  
                }
                else
                {
                    player2.WinGame(player1, this);
                    player1.LooseGame(player2, this);
                   
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        public abstract void RatingCalculation(double ExpectedRating);
    }
    public class StandartGame : Game
    {
        public StandartGame(GameAccount player1, GameAccount player2, double ExpectedRating) : base(player1, player2, ExpectedRating)
        {
        }
        public override void RatingCalculation(double ExpectedRating)
        {
            RatingList.Add(ExpectedRating);
            RatingList.Add(ExpectedRating);
        }
    }
    public class TrainingGame : Game
    {
        public TrainingGame(GameAccount player1, GameAccount player2, double ExpectedRating) : base(player1, player2, ExpectedRating)
        {
        }
        public override void RatingCalculation(double ExpectedRating)
        {
            RatingList.Add(0.0);
            RatingList.Add(0.0);
        }
    }
    public class OnePlayerRatingChangeGame : Game
    {
        public OnePlayerRatingChangeGame(GameAccount player1, GameAccount player2, double ExpectedRating) : base(player1, player2, ExpectedRating)
        {
        }
        public override void RatingCalculation(double ExpectedRating)
        {
            RatingList.Add(ExpectedRating);
            RatingList.Add(0.0);
        }
    }
}