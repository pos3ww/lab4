using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3.DB.Entities
{
    public class GameEntity
    {
        public int Id { get; set; }
        public string Winner { get; set; }
        public int WinnerId { get; set; }
        public string Loser { get; set; }
        public int LoserId { get; set; }
        public double RatingChange { get; set; }

    }
}
