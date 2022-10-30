using System;
using System.Collections.Generic;
using System.Linq;
using Bet_Slipper_Api.Contracts;
using Bet_Slipper_API;
using Microsoft.AspNetCore.Mvc;

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
        public List<Bet[]> Multiples([FromBody]Slip slip)
        {
            var multiples = GetCombinations(slip.Bets, slip.Multiple);
            return multiples;
        }

        private List<Bet[]> GetCombinations(IEnumerable<Bet> bets, int mulitpleNumber)
        {

            /*TODO This is the wrong implementation, what I should have done is add Ids and then create multiple
            collections of IDs that way I could reduce duplicates that way. 
             */
            var result = Combinations(bets).ToList();

            return result; 
        }

        public static IEnumerable<T[]> Combinations<T>(IEnumerable<T> source)
        {
            if (null == source)
                throw new ArgumentNullException(nameof(source));

            T[] data = source.ToArray();

            return Enumerable
              .Range(0, 1 << (data.Length))
              .Select(index => data
                 .Where((v, i) => (index & (1 << i)) != 0)
                 .ToArray());
        }
    }
}
