using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerModel
{
    class CurrentPlayer : PlayerBase
    {
        public int MinNumber { get; set; }

        public int MaxNumber { get; set; }

        public int SecretNumber { get; set; }

        public CurrentPlayer() : base()
        {
        }
        public CurrentPlayer(int Id, string name, int score, int GivenMinNumber, int GivenMaxNumber, int GivenSecretNumber) : base(Id, name, score)
        {
            MinNumber = GivenMinNumber;
            MaxNumber = GivenMaxNumber;
            SecretNumber = GivenSecretNumber;
        }
    }
}
