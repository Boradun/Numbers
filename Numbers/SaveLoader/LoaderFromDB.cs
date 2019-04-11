using PlayerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveLoader
{
    public static class LoaderFromDB
    {
        public static Player LoadPlayer(string name,string password)
        {
            using (PlayerContext context = new PlayerContext())
            {
                return context.Players.FirstOrDefault(c => c.PlayerName == name && c.PlayerPassword == password);
            }
        }
    }
}
