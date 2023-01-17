using System;
using System.Collections.Generic;
using System.Linq;
using Bet_Slipper_Api.Contracts;
using Bet_Slipper_API;
using Bet_Slipper_API.Bets;
using Bet_Slipper_API.Commands;
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
        public IEnumerable<CombinationBet> Multiples([FromServices]IGenerateMultiplesCommand generateMultiplesCommand,
        [FromBody]Slip slip)
        {
            var multiples = generateMultiplesCommand.Execute(slip.Bets, 2);
            return multiples;
        }
    }
}
