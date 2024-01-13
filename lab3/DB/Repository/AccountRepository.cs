using lab3.DB.Entities;
using lab3.DB.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3.DB.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private DbContext context;
        public AccountRepository(DbContext context)
        {
            this.context = context;
        }
        public void Create(AccountEntity account)
        {
            context.Accounts.Add(account);
        }

        public void Delete(string Name)
        {
            var AccountToDelete = context.Accounts.Find(x => x.Name == Name);
            if (AccountToDelete != null)
            {
                context.Accounts.Remove(AccountToDelete);
                Console.WriteLine($"Account with name {Name} was deleted.");
            }
            else
            {
                Console.WriteLine($"Account with name {Name} was not found.");
            }
        }

        public IEnumerable<AccountEntity> Read()
        {
            return context.Accounts;
        }

        public void Update(AccountEntity account, double newrating)
        {
            account.Rating = newrating;
            account.GamesCount += 1;
        }
    }
}
