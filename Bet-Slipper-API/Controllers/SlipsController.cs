using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bet_Slipper_Api.Contracts;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bet_Slipper_Api.Controllers
{
    [Route("Slips")]
    public class SlipsController : Controller
    {
        [HttpGet]
        public IActionResult Multiples()
        {
            return Ok("you hit the endpoint");
        }


        [HttpPost]
        public List<Slip> Multiples([FromBody]IEnumerable<Bet> bets, [FromQuery] int mulitpleNumber)
        {
            var multiples = GetCombinations(bets, mulitpleNumber);
            return multiples;
        }

        private List<Slip> GetCombinations(IEnumerable<Bet> bets, int mulitpleNumber)
        {

            /*TODO This is the wrong implementation, what I should have done is add Ids and then create multiple
            collections of IDs that way I could reduce duplicates that way. 
             */
            var result = new List<Slip>();

            foreach (var bet in bets)
            {
                foreach (var bet2 in bets)
                {
                    var addBet =  bet.League != bet2.League;
                     
                    if (addBet)
                    {
                        var newBet = CreateNewBet(bet, bet2);

                        var isDuplicate = result.Select(x => x.BetDescription).
                            Contains(
                            WriteNewBetDescription(bet.BetDescription, bet2.BetDescription)
                            );

                        if (!isDuplicate)
                        {
                            result.Add(newBet);
                        }
                    } 
                }         
            }

            return result; 
        }

        private Slip CreateNewBet(Bet bet1, Bet bet2)
        {
            var newBet = new Slip();
            newBet.BetDescription = WriteNewBetDescription(bet1.BetDescription, bet2.BetDescription);
            newBet.ActualOdds = bet1.ActualOdds * bet2.ActualOdds;
            newBet.MinimumOdds = bet1.MinOdds * bet2.MinOdds;
            newBet.Ids = new List<ObjectId> { bet1.Id, bet2.Id }; 
            return newBet; 
        }

        private string WriteNewBetDescription(string bet1, string bet2)
        {
            var betDescriptions = new List<string> { bet1, bet2 }; 
            betDescriptions.Sort();

            var stringBuilder = new StringBuilder(betDescriptions.First());

            foreach (var description in betDescriptions.Skip(1))
            {
                stringBuilder.Append($" and {description}"); 
            }
            return stringBuilder.ToString(); 
        }
    }
}
