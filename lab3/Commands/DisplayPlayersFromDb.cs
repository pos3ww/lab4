using lab3.Commands.Base;
using lab3.DB;
using lab3.DB.Services;
using lab3.DB.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3.Commands
{
    internal class DisplayPlayersFromDb : ICommand
    {
        
        public void CommandInfo()
        {
            Console.WriteLine("This command will display players from database");
        }

        public void Execute(DbContext context)
        {
            IAccountService accountService = new AccountService(context);
            Console.WriteLine("DISPLAYING PLAYERS FROM DB");
            accountService.ReadAccounts();

        }
    }
}
