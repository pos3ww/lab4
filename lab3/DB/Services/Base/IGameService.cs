using lab3.DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3.DB.Services.Base
{
    public interface IGameService
    {
        public void ReadGames();

        public void CreateGame(int player1ID, int player2ID, string gametype, double Rating);
        public void ReadPlayerGamesByPlayerId(int playerId);

    }
}
