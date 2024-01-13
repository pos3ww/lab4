using lab3.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3.Commands.Base
{
    public interface ICommand
    {
        public void Execute(DbContext context);
        public void CommandInfo();
    }
}
