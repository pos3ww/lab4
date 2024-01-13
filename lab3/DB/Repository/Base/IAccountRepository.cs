using lab3.DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace lab3.DB.Repository.Base
{
    public interface IAccountRepository
    {
        public void Create(AccountEntity account);
        public IEnumerable<AccountEntity> Read();
        public void Update(AccountEntity account, double newrating);
        public void Delete(string Name);
    }
}
