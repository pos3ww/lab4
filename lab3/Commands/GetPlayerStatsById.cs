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
    public class GetPlayerStatsById : ICommand
    {
        public void CommandInfo()
        {
            Console.WriteLine("This command will get stats by player ID");
        }

        public void Execute(DbContext context)
        {
            IAccountService accountService = new AccountService(context);
            Console.WriteLine("GETTING STATS BY ID");
            Console.WriteLine("ENTER ID:");
            string userInput = Console.ReadLine();
            try
            {
                int playerId = int.Parse(userInput);
                accountService.ReadAccountById(playerId);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input");
            }
        }
    }
}
