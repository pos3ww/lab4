using lab3.DB.Entities;
using lab3.DB.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3.DB.Repository
{
    public class GameRepository:IGameRepository
    {
        private DbContext context;
        public GameRepository(DbContext context)
        {
            this.context = context;
        }
        public void Create(GameEntity game)
        {
            context.Games.Add(game);
        }
        public IEnumerable<GameEntity> Read()
        {
            return context.Games;
        }
        public void Update(GameEntity game, int newgameid)
        {
            var GameIdToChange = context.Games.Find(x => x.Id == game.Id);
            if(GameIdToChange != null)
            {
                GameIdToChange.Id = newgameid;
                Console.WriteLine($"Game with ID {game.Id} was changed to id: {newgameid}");
            }
            else
            {
                Console.WriteLine($"Game with ID {game.Id} not found.");
            }
        }
        public void Delete(int id)
        {
            var GameToDelete = context.Games.Find(x => x.Id == id);
            if (GameToDelete != null)
            {
                context.Games.Remove(GameToDelete);
                Console.WriteLine($"Game with ID {id} was deleted.");
            }
            else
            {
                Console.WriteLine($"Game with ID {id} was not found.");
            }
        }

    }
}
