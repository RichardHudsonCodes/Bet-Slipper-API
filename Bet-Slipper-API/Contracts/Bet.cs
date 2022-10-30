
using System;
using MongoDB.Bson;

namespace Bet_Slipper_Api.Contracts
{
    public class Bet
    {
        public Bet()
        {

        }

        public ObjectId Id { get; set; }
        public string BetDescription { get; set; }
        public string League { get; set; }
        public string Market { get; set; }
        public decimal ActualOdds { get; set; }
        public decimal MinOdds { get; set; }
        public bool? Outcome { get; set; }
    }
}
