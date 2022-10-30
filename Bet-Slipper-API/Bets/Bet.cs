using System;
using Bet_Slipper_API.Contracts;
using Bet_Slipper_API.Mongo;

namespace Bet_Slipper_API
{
    [BsonCollection("bets")]
    public class Bet : Document
    { 
        public DateTime DatePlaced { get; set; }
        public BetDescription Description { get; set; }
        public decimal Price { get; set; }
        public decimal ExpectedPrice { get; set; }
        public bool? Outcome { get; set; }
    }
}
