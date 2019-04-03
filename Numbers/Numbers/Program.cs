using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SaveLoader;
using PlayerModel;

namespace Numbers
{
    class Program
    {
        public static void Main(string[] args)
        {
            /*ConsoleKeyInfo key;
            var rule = @"[0-9]";
            var sb = new StringBuilder();
            while (true)
            {
                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                    break;

                if (Regex.IsMatch(key.KeyChar.ToString(), rule))
                {
                    sb.Append(key.KeyChar);
                    Console.Write(key.KeyChar);
                }
            }*/
            SaverToDb.PlayerContext playerContext = new SaverToDb.PlayerContext();
            playerContext.Players.Add(new PlayerBase(0, "admin", 1000000));
            playerContext.SaveChanges();
            playerContext.Dispose();
            
            Console.ReadKey();
        }
    }
}
