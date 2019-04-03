using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using PlayerModel;

namespace SaveLoader
{
    public class PlayerContext : DbContext
    {
        public PlayerContext() : base()
        {
        }

        public DbSet<PlayerBase> Players { get; set; }

        public bool IsPlayerExist(string playerName)
        {
            var a = Players.Where(c => c.PlayerName == playerName);
            if (a.Count() != 0)
                return true;
            return false;
        }
    }


}
