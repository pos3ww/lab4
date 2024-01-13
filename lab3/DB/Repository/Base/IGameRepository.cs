using lab3.DB.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3.DB.Repository.Base
{
    public interface IGameRepository
    {
        public void Create(GameEntity game);
        public IEnumerable<GameEntity> Read();
        public void Update(GameEntity game, int newgameid);
        public void Delete(int Id);
        
    }
}
