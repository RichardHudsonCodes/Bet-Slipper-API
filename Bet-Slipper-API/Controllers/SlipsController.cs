using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bet_Slipper_Api.Contracts;
using Bet_Slipper_API;
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

            

            return result; 
        }

        private Slip CreateNewBet(Bet bet1, Bet bet2)
        {
            var newBet = new Slip();
            newBet.ActualOdds = bet1.Price * bet2.Price;
            newBet.MinimumOdds = bet1.ExpectedPrice * bet2.ExpectedPrice;
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
