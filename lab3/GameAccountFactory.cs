using lab3.DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    public class GameAccountFactory
    {
        public GameAccount CreateAccount(AccountEntity player)
        {
            switch (player.AccountType)
            {
                case "standart":
                    return new StandartGameAccount(player.Name, player.Rating, player.GamesCount);
                case "halved loss":
                    return new HalvedRatingLossGameAccount(player.Name, player.Rating, player.GamesCount);
                case "winstreak":
                    return new WinStreakGameAccount(player.Name, player.Rating, player.GamesCount);
                default:
                    throw new ArgumentException("Invalid account type");
            }
        }
    }
}
