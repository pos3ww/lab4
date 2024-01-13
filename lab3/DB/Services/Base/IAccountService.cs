using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3.DB.Services.Base
{
    public interface IAccountService
    {
        
        public void CreateAccount();
        
        public void ReadAccounts();
        public void ReadAccountById(int accountId);
    }
}
