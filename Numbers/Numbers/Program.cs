using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaveLoader;
using PlayerModel;
using Game;

namespace Numbers
{
    class Program
    {
        public static void Main(string[] args)
        {
            /*SaverToDb.PlayerContext playerContext = new SaverToDb.PlayerContext();
            playerContext.Players.Add(new PlayerBase(0, "admin", 1000000));
            playerContext.SaveChanges();
            playerContext.Dispose();
            */
            /*CurrentPlayer currentPlayer = GameController.LoadPlayer();
            Console.WriteLine($"Ваши очки {currentPlayer.PlayerScore}");*/

            //SaverToDb.SavePlayerToDB(GameController.CreatePlayer());
            Console.WriteLine($"hi ");
            GameController.MainMenu();
        }
    }
}
