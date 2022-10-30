using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bet_Slipper_API.RepositoryService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;

namespace Bet_Slipper_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BetsController : ControllerBase
    {
        private readonly ILogger<BetsController> _logger;
        private IRepository<Bet> _betRepo;

        public BetsController(ILogger<BetsController> logger, IRepository<Bet> betRepository)
        {
            _logger = logger;
            _betRepo = betRepository;
        }

        [HttpPost]
        public IEnumerable<Bet> SaveBet([FromBody] List<Bet> bets)
        {
           _betRepo.InsertMany(bets);

           return bets;
        }

        [HttpGet]
        public async Task<IEnumerable<Bet>> GetBets([FromQuery]List<string> betIds)
        {
            var bets = new List<Bet>();

            foreach (var id in betIds)
            {
                bets.Add(await _betRepo.GetByID(ObjectId.Parse(id)));
            }

            return bets;
        }        
    }
}
