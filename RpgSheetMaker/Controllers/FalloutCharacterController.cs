using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RpgSheetMaker.Services;
using RpgSheetMaker.Tools;
using RpgSheetMaker.ViewModels;

namespace RpgSheetMaker.Controllers
{
    [Produces("application/json")]
    [Route("api/FalloutCharacter")]
    public class FalloutCharacterController : Controller
    {
        private readonly ILogMachine _logger;
        private readonly IService _service;
        private readonly string _name;

        public FalloutCharacterController(IService service, ILogMachine logMachine)
        {
            _logger = logMachine;
            _service = service;
            _name = "Fallout";
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            _logger.Log("In Fallout Controller GetAll");

            var allCharac = _service.Get(_name);

            List<CharacterViewModel> allDto = new List<CharacterViewModel>();
            foreach (var charac in allCharac)
            {
                CharacterViewModel dto = new CharacterViewModel(charac);
                allDto.Add(dto);
            }

            return Ok(allDto);
        }

        [HttpGet("{characterName}")]
        public IActionResult GetbyName(string characterName)
        {
            _logger.Log("In get with parameter " + characterName);

            var myCharac = _service.GetByName(_name, characterName);
            var response = new CharacterViewModel(myCharac);
            return Ok(response);
        }

        [HttpPost("{characterName}")]
        public IActionResult Create(string characterName)
        {
            _logger.Log("In create with parameter " + characterName);
            var myCharac = _service.Create(_name, characterName);
            var response = new CharacterViewModel(myCharac);
            return Ok(response);
        }

    }
}