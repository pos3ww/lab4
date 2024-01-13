using lab3.Commands.Base;
using lab3.DB;
using lab3.DB.Services.Base;
using lab3.DB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3.Commands
{
    public class PlayGame : ICommand
    {
        public void CommandInfo()
        {
            Console.WriteLine("This command will let you play a game");
        }

        public void Execute(DbContext context)
        {
            
            IAccountService accountService = new AccountService(context);
            IGameService gameService = new GameService(context);
            Console.WriteLine("ENTER PLAYER ID`S");
            Console.WriteLine("player one id: ");
            string firstId = Console.ReadLine();
            if (int.TryParse(firstId, out int Id1))
            {
                Console.WriteLine($"First ID input accepted: {Id1}");
            }
            else
            {
                Console.WriteLine("Invalid input");
                return;
            }
            Console.WriteLine("player two id: ");
            string secondId = Console.ReadLine();
            if (int.TryParse(secondId, out int Id2))
            {
                Console.WriteLine($"First ID input accepted: {Id2}");
            }
            else
            {
                Console.WriteLine("Invalid input");
                return;
            }
            Console.WriteLine("Enter game type Standart/Training/OnePlayerRatingChange:");
            string gameType=Console.ReadLine();
            Console.WriteLine("Enter rating: ");
            string rating = Console.ReadLine();
            if (double.TryParse(rating, out double RatingDouble))
            {
                Console.WriteLine($"Rating input accepted: {RatingDouble}");
            }
            else
            {
                Console.WriteLine("Invalid input.");
                return;
            }
            gameService.CreateGame(Id1, Id2, gameType, RatingDouble);
        }
    }
}
