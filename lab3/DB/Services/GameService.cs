using lab3.DB.Entities;
using lab3.DB.Repository;
using lab3.DB.Repository.Base;
using lab3.DB.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace lab3.DB.Services
{
    public class GameService:IGameService    {
        private IAccountRepository accountRepository;
        private IGameRepository gameRepository;
        private GameFactory gameFactory = new GameFactory();
        private GameAccountFactory GameAccountFactory = new GameAccountFactory();
        public GameService(DbContext context)
        {
            accountRepository = new AccountRepository(context);
            gameRepository = new GameRepository(context);

        }
        public void CreateGame(int playerId1, int playerId2, string gameType, double Rating)
        {
            if(playerId1 == playerId2)
            {
                Console.WriteLine("Can not create where the players are same accounts");
                return;     
            }
            var accounts = accountRepository.Read().ToList();
            var player1 = accounts.Find(x => x.Id == playerId1);
            var player2 = accounts.Find(x => x.Id == playerId2);
            var player1acc = GameAccountFactory.CreateAccount(player1);
            var player2acc = GameAccountFactory.CreateAccount(player2);
            Game newgame = gameFactory.CreateNewGame(player1acc, player2acc, gameType, Rating);
            if (newgame == null)
            {
                Console.WriteLine("Game type was invalid so game was not created");
                return;
            }
            else if (newgame.game_decicion == 0)
            {
                gameRepository.Create(new GameEntity{ Id = newgame.GameId, Winner = player2acc.UserName,WinnerId=player2.Id, Loser = player1acc.UserName, LoserId= player1.Id, RatingChange = Rating });
                Console.WriteLine("Game was won by "+ player2acc.UserName);
            }
            else if(newgame.game_decicion == 1)
            {
                gameRepository.Create(new GameEntity { Id = newgame.GameId, Winner = player1acc.UserName, WinnerId = player1.Id, Loser = player2acc.UserName, LoserId = player2.Id, RatingChange = Rating });
                Console.WriteLine("Game was won by " + player1acc.UserName);
            }
            
            accountRepository.Update(player1, player1acc.CurrentRatingProperty);
            accountRepository.Update(player2, player2acc.CurrentRatingProperty);
        }

        public void ReadGames()
        {
            var games = gameRepository.Read();
            Console.WriteLine("Reading all games");
            Console.WriteLine(" Game ID | Winner | Loser | Rating Change");
            foreach(var game in games)
            {
                Console.WriteLine($"{game.Id}   {game.Winner}    {game.Loser}    {game.RatingChange}");
            }
        }

        public void ReadPlayerGamesByPlayerId(int playerId)
        {
            bool gamefound = false;
            var AllGames= gameRepository.Read().ToList();

            Console.WriteLine("Reading games of player with ID "+playerId);
            Console.WriteLine(" Game ID | Winner | Loser | Rating Change");
            foreach (var game in AllGames)
            {
                if (game.WinnerId==playerId || game.LoserId == playerId)
                {
                    Console.WriteLine($"{game.Id}   {game.Winner}    {game.Loser}    {game.RatingChange}");
                    gamefound = true;
                }
            }
            if (gamefound == false)
            {
                Console.WriteLine($" Games of player with ID {playerId} do not exist 0_0");
            }
        }
    }
}
