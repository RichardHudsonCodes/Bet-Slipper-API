using System;
using Bet_Slipper_API.Mongo;
using MongoDB.Bson.Serialization.Attributes;

namespace Bet_Slipper_API
{
    [BsonCollection("bets")]
    public class Bet : Document
    { 
        public DateTime DatePlaced { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal ExpectedPrice { get; set; }
    }
}
