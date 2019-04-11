using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using PlayerModel;

namespace SaveLoader
{
    public static class SaverToDb
    {
        public static bool SavePlayerToDB(Player player)
        {
            using (PlayerContext playerContext = new PlayerContext())
            {
                if (playerContext.IsPlayerExist(player.PlayerName))
                {
                    playerContext.Players.FirstOrDefault(x => x.PlayerName == player.PlayerName).PlayerScore = player.PlayerScore;

                }
                else
                {
                    playerContext.Players.Add(player);
                }
                playerContext.SaveChanges();

                return true;
            }
        }
    }
}
