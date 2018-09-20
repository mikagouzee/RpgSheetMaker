using Library.ViewModels;
using Microsoft.AspNetCore.Mvc;
using RpgSheetMaker.Services;
using RpgSheetMaker.Tools;
using System.Collections.Generic;

namespace RpgSheetMaker.Controllers
{
    [Produces("application/json")]
    [Route("api/Game")]
    public class GameController : Controller
    {
        private readonly ILogMachine _logger;
        private readonly IGameService _service;

        public GameController(ILogMachine logger, IGameService service)
        {
            _logger = logger;
            _service = service;
        }
        
        [HttpGet()]
        public IActionResult GetAll()
        {
            List<GameViewModel> allMappedGames = new List<GameViewModel>();

            var allGames = _service.GetAll();

            foreach (var item in allGames)
            {
                allMappedGames.Add(new GameViewModel(item));
            }

            return Ok(allMappedGames);
        }

    }
}