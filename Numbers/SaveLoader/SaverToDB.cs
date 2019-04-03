using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using PlayerModel;

namespace SaveLoader
{
    public class SaverToDb
    {
        public class PlayerContext : DbContext
        {
            public PlayerContext() : base()
            {
            }

            public DbSet<PlayerBase> Players { get; set; }
        }
    }
}
