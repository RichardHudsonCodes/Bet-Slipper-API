
namespace Bet_Slipper_API.Bets
{
	public class CombinationBet
	{
		public CombinationBet(Bet[] bet, decimal stake)
		{
			Bet = bet;
			Stake = stake;
		}

        public Bet[] Bet { get; set; }
		public decimal Stake { get; set; } 
	
    }
}

