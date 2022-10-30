using Bet_Slipper_API.Mongo;

namespace Bet_Slipper_API.Contracts
{
    public class BetDescription
    {
        public string Selection { get; set; }
        public string Competition { get; set; }
        public string Market { get; set; }
        public string Country { get; set; }
    }
}