using System;
using System.Collections.Generic;
using Bet_Slipper_API.Bets;

namespace Bet_Slipper_API.Commands
{
	public class GenerateMultiplesCommand : IGenerateMultiplesCommand
	{
		public GenerateMultiplesCommand()
		{
		}

		public IEnumerable<CombinationBet> Execute(Bet[] bets, int multiple)
		{
			throw new NotImplementedException(); 
		}

	}

	public interface IGenerateMultiplesCommand
	{
        IEnumerable<CombinationBet> Execute(Bet[] bets, int multiple);  
	}
}

