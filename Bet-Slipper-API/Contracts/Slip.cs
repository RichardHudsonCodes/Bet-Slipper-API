using System.Collections.Generic;
using Bet_Slipper_API;

namespace Bet_Slipper_Api.Contracts
{
    public class Slip
    {
        public Slip()
        {
        }

        public List<Bet> Bets { get; set; }
        public int Multiple { get; set; }
    }
}
