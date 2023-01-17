using System;
using System.Collections.Generic;
using System.Linq;
using Bet_Slipper_API.Bets;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Bet_Slipper_API.Commands
{
	public class GenerateMultiplesCommand : IGenerateMultiplesCommand
	{
		public GenerateMultiplesCommand()
		{
		}

		public IEnumerable<CombinationBet> Execute(IEnumerable<Bet> bets, int multiple)
		{
            /*Create all possible combinations
			 Ensure that the following criteria are met
			1) Two bets in the same League/Category cannot be matched
			2) Two bets with the same selection can't be matched
			 */
            var lines = new List<CombinationBet>();

            var possibleCombinations = GetCombinations(bets.ToList()).Where(x => x.Count == multiple);
			foreach (var combination in possibleCombinations) 
			{
				lines.Add(new CombinationBet(combination.ToArray(), 20)); 
			}

			return lines; 
		}

        private List<List<Bet>> GetCombinations(List<Bet> bets)
        {
            var result = new List<List<Bet>>
            {
                new List<Bet>() // add an empty list of bets to the list
            }; //Create a list of list of bets 
            result.Last().Add(bets[0]); //add first bet to the last element in the sequence of the list 

			if (bets.Count == 1) 
			{
				return result; 
			}

			var nextBetList = GetCombinations(bets.Skip(1).ToList());

			nextBetList.ForEach(combo =>
			{
				result.Add(new List<Bet>(combo));
				combo.Add(bets[0]);
				result.Add(new List<Bet>(combo));
			});

			return result; 
        }
    }


    public interface IGenerateMultiplesCommand
	{
        IEnumerable<CombinationBet> Execute(IEnumerable<Bet> bets, int multiple);  
	}
}

