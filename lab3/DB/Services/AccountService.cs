using lab3.DB.Entities;
using lab3.DB.Repository;
using lab3.DB.Repository.Base;
using lab3.DB.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3.DB.Services
{
    public class AccountService:IAccountService
    {
        private IAccountRepository accountRepository;
        public AccountService(DbContext context)
        {
            accountRepository = new AccountRepository(context);
            
        }
        public void CreateAccount()
        {
            AccountEntity account = new AccountEntity();
            Console.WriteLine("Enter name: ");
            string Name = Console.ReadLine();
            if (string.IsNullOrEmpty(Name))
            {
                Console.WriteLine("empty name");
                return;
            }
            else
            {
                account.Name = Name;   
            }
            Console.WriteLine("Enter AccountType standart/halved loss/winstreak: ");
            string accountType = Console.ReadLine();
            if (accountType=="standart" || accountType == "halved loss"|| accountType == "winstreak")
            {
                account.AccountType = accountType;
            }
            else
            {
                Console.WriteLine("Invalid type");
                return;
            }
            account.Rating = 1.0;
            account.GamesCount = 0;
            account.Id =1 + accountRepository.Read().ToList().Count();
            accountRepository.Create(account);
        }

        public void ReadAccountById(int accountId)
        {
            var account = accountRepository.Read().ToList().Find(x=> x.Id==accountId);
            if (account != null)
            {
                Console.WriteLine($"Name {account.Name}| ID {account.Id}| Account Type {account.AccountType}| Rating {account.Rating}| Games played {account.GamesCount}");
            }
            else{
                Console.WriteLine($"No account with id {accountId} in Db");
            }
        }

        public void ReadAccounts()
        {
            var accounts = accountRepository.Read().ToList();
            foreach(var account in accounts)
            {
                Console.WriteLine($"Name {account.Name}| ID {account.Id}| Account Type {account.AccountType}| Rating {account.Rating}| Games played {account.GamesCount}");
            }
        }

       
    }
}
