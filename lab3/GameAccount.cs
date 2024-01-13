
using System;
namespace lab3
{
    public abstract class GameAccount
    {
        public string? UserName;
        private double CurrentRating;
        public int GamesCount;
        public List<string> PlayerHistory = new List<string>();
        public double CurrentRatingProperty
        {
            get { return CurrentRating; }
            set
            {
                if (value <= 1.0)
                {
                    CurrentRating = 1.0;
                }
                else
                {
                    CurrentRating = value;
                }
            }
        }
        public abstract void WinGame(GameAccount opponent, Game game);
        public abstract void LooseGame(GameAccount opponent, Game game);
        public void GetStats()
        {
            int i = 0;
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("  Player  | Opponent  |  Outcome  |   Game ID      | Rating Change");
            foreach (String item in this.PlayerHistory)
            {
                i++;
                if (i == 5)
                {
                    i = 0;
                    Console.WriteLine("  " + item);
                }
                else if (i < 5)
                {
                    Console.Write("  " + item + "    | ");
                }
            }
        }

        public void AddToStatList(GameAccount opponent, Game Game, String Result)
        {
            PlayerHistory.Add(UserName);
            PlayerHistory.Add(opponent.UserName);
            PlayerHistory.Add(Result);
            PlayerHistory.Add(Convert.ToString(Game.GameId));
            PlayerHistory.Add(Convert.ToString(Game.RatingList[0]));
        }

    }
    public class StandartGameAccount : GameAccount
    {
        public double PointsMultiplier = 1.0;
        public StandartGameAccount(String UserName, double InitialRating, int GamesCount)
        {
            this.UserName = UserName;
            CurrentRatingProperty = InitialRating;
            this.GamesCount = GamesCount;
        }

        public override void WinGame(GameAccount opponent, Game Game)
        {

            Game.RatingCalculation(Game.ExpectedRating);
            CurrentRatingProperty += Game.RatingList[0];
            AddToStatList(opponent, Game, "Won!");
            Game.RatingList.RemoveAt(0);
            GamesCount += 1;

        }
        public override void LooseGame(GameAccount opponent, Game Game)
        {
            Game.RatingCalculation(Game.ExpectedRating);
            CurrentRatingProperty -= Game.RatingList[0];
            AddToStatList(opponent, Game, "Lost");
            Game.RatingList.RemoveAt(0);
            GamesCount += 1;

        }


    }
    public class HalvedRatingLossGameAccount : GameAccount
    {
        public double PointsMultiplier = 0.5;
        public HalvedRatingLossGameAccount(String UserName, double InitialRating, int GamesCount)
        {
            this.UserName = UserName;
            CurrentRatingProperty = InitialRating;
            this.GamesCount = GamesCount;
        }

        public override void WinGame(GameAccount opponent, Game Game)
        {
            Game.RatingCalculation(Game.ExpectedRating);
            CurrentRatingProperty += Game.RatingList[0];
            AddToStatList(opponent, Game, "Won!");
            Game.RatingList.RemoveAt(0);
            GamesCount += 1;
        }
        public override void LooseGame(GameAccount opponent, Game Game)
        {
            Game.RatingCalculation(Game.ExpectedRating);
            CurrentRatingProperty -= PointsMultiplier * Game.RatingList[0];
            AddToStatList(opponent, Game, "Lost");
            Game.RatingList.RemoveAt(0);
            GamesCount += 1;
        }

    }
    public class WinStreakGameAccount : GameAccount
    {
        public double PointsMultiplier = 1;
        public int WinStreakCount = 0;
        public WinStreakGameAccount(String UserName, double InitialRating, int GamesCount)
        {
            this.UserName = UserName;
            CurrentRatingProperty = InitialRating;
            this.GamesCount = GamesCount;
        }

        public override void WinGame(GameAccount opponent, Game Game)
        {
            Game.RatingCalculation(Game.ExpectedRating);
            CurrentRatingProperty += Game.RatingList[0] + WinStreakCount * PointsMultiplier;
            AddToStatList(opponent, Game, "Won!");
            Game.RatingList.RemoveAt(0);
            GamesCount += 1;
            WinStreakCount += 1;

        }
        public override void LooseGame(GameAccount opponent, Game Game)
        {
            Game.RatingCalculation(Game.ExpectedRating);
            CurrentRatingProperty -= Game.RatingList[0];
            AddToStatList(opponent, Game, "Lost");
            Game.RatingList.RemoveAt(0);
            GamesCount += 1;
            WinStreakCount = 0;

        }

    }
}
