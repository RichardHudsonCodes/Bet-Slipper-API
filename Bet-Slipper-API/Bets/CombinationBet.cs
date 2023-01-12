using System;
using Bet_Slipper_API.Contracts;

namespace Bet_Slipper_API.Bets
{
	public class CombinationBet
	{
		public CombinationBet()
		{
			
		}

        public Bet[] Bet { get; set; }
		public decimal ExpectedPrice { get; set; }
		public decimal Price { get; set; }
    }
}

