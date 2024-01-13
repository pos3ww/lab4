using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3.DB.Entities
{
    public class AccountEntity
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int GamesCount { get; set; }
        public double Rating { get; set; }
        public string? AccountType { get; set; }
    }
}
