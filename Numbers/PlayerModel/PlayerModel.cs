using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerModel
{
    public class Player
    {
        public int PlayerId { get; set; }

        public string PlayerName { get; set; }

        public int PlayerScore { get; set; }

        public string PlayerPassword { get; set; }

        public int MinNumber { get; set; }

        public int MaxNumber { get; set; }

        public int SecretNumber { get; set; }

        public Player()
        {
            PlayerId = -1;
            PlayerName = "Гость";
            PlayerScore = 0;
        }
    }
}
