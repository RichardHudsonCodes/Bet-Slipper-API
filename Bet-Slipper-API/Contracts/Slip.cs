using System.Collections.Generic;
using MongoDB.Bson;

namespace Bet_Slipper_Api.Contracts
{
    public class Slip
    {
        public Slip()
        {
        }

        public List<ObjectId> Ids { get; set; }
        public string BetDescription {get;set;}
        public decimal ActualOdds { get; set; }
        public decimal MinimumOdds { get; set; }
    }
}
