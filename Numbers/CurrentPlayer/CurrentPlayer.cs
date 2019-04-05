using PlayerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player
{
    public class CurrentPlayer : PlayerBase
    {
        public int MinNumber { get; set; }

        public int MaxNumber { get; set; }

        public int SecretNumber { get; set; }

        public CurrentPlayer() : base()
        {
        }
    }
}
