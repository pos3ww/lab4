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
    public class CreatePlayerWithAccountType : ICommand
    {
        
        public void CommandInfo()
        {
            Console.WriteLine("This command will let you create a player");
        }

        public void Execute(DbContext context)
        {
            IAccountService accountService = new AccountService(context);
            Console.WriteLine("CREATING AN ACCOUNT");
            accountService.CreateAccount();
        }
    }
}
