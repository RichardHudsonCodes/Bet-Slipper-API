using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bet_Slipper_API.RepositoryService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Bet_Slipper_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BetController : ControllerBase
    { 
        private readonly ILogger<BetController> _logger;
        private IRepository<Bet> _betRepo;

        public BetController(ILogger<BetController> logger, IRepository<Bet> betRepository)
        {
            _logger = logger;
            _betRepo = betRepository; 
        }

        [HttpGet]
        public IEnumerable<Bet> Get()
        {
            var rng = new Random();
            var betArray =  Enumerable.Range(1, 5).Select(index => new Bet
            {
                DatePlaced = DateTime.Now.AddDays(index),
                Price = rng.Next(-20, 55),
               
            })
            .ToArray();

            foreach (var bet in betArray)
            {
                _betRepo.InsertOne(bet);
            }

            return betArray; 
        }
    }
}
