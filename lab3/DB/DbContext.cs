using lab3.DB.Entities;

namespace lab3.DB
{
    public class DbContext
    {
        public List<GameEntity> Games { get; set; }
        public List<AccountEntity> Accounts { get; set; }
        public DbContext()
        {
            Games = new List<GameEntity>
            {
                new GameEntity { Id = 113465236, Winner = "Gleb", WinnerId=1, Loser = "Vika", LoserId=2, RatingChange = 10.0 },
                new GameEntity { Id = 223563254, Winner = "Maks", WinnerId=3, Loser = "Vika", LoserId=2, RatingChange = 9.0 },
                new GameEntity { Id = 312454336, Winner = "Vika", WinnerId=2, Loser = "Gleb", LoserId=1, RatingChange = 14.0 },
                new GameEntity { Id = 458758744, Winner = "Gleb", WinnerId=1, Loser = "Vika", LoserId=2, RatingChange = 3.0 },
                new GameEntity { Id = 570934322, Winner = "Gleb", WinnerId=1, Loser = "Maks", LoserId=3, RatingChange = 7.0 },
                new GameEntity { Id = 642235444, Winner = "Vika", WinnerId=2, Loser = "Gleb", LoserId=1, RatingChange = 5.0 },
                new GameEntity { Id = 113465236, Winner = "Gleb", WinnerId=1, Loser = "Maks", LoserId=3, RatingChange = 14.0 },
                new GameEntity { Id = 113465236, Winner = "Gleb", WinnerId=1, Loser = "Vika", LoserId=2, RatingChange = 12.0 }
            };
            Accounts = new List<AccountEntity>
            {
                new AccountEntity{Name="Gleb",Id=1, GamesCount=5, AccountType="standart", Rating=3.0},
                new AccountEntity{Name="Vika",Id=2, GamesCount=5, AccountType="halved loss", Rating=4.0},
                new AccountEntity{Name="Maks",Id=3, GamesCount=2, AccountType="winstreak", Rating=1.0},
            };
        }

    }

}
   