using System.Collections.Generic;
using Library.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using RpgSheetMaker.Services;
using RpgSheetMaker.Tools;

namespace RpgSheetMaker.Controllers
{
    [Produces("application/json")]
    [Route("api/Character")]
    //[EnableCors("AllowAll")]
    public class CharacterController : Controller
    {
        private readonly ILogMachine _logger;
        private readonly ICharacterService _service;

        public CharacterController(ICharacterService service, ILogMachine logMachine)
        {
            _logger = logMachine;
            _service = service;
        }

        //CREATE
        [HttpPost("{game}/creation")]
        public IActionResult Create(string game, [FromBody]CharacterCreationObject charac)
        {
            _logger.Log("In create with parameter " + charac.Name);

            //charac.GameName = game;

            var myCharac = _service.Create(game, charac);
            var response = new CharacterViewModel(myCharac);
            return Ok(response);
        }


        //READ ALL
        [HttpGet("{game}")]
        public IActionResult GetAll(string game)
        {
            _logger.Log("In Fallout Controller GetAll");

            var allCharac = _service.Get(game);

            List<CharacterViewModel> allDto = new List<CharacterViewModel>();
            foreach (var charac in allCharac)
            {
                CharacterViewModel dto = new CharacterViewModel(charac);
                allDto.Add(dto);
            }

            return Ok(allDto);
        }


        //READ ONE BY NAME
        [HttpGet("{game}/{characterName}")]
        public IActionResult GetbyName(string game, string characterName)
        {
            _logger.Log("In get with parameter " + characterName);

            var myCharac = _service.GetByName(game, characterName);
            var response = new CharacterViewModel(myCharac);
            return Ok(response);
        }


        //UPDATE
        [HttpPost("{game}/edit/{characterName}")]
        public IActionResult Update(string game, [FromBody]CharacterViewModel newVersion)
        {
            _logger.Log("In Edit with parameter " + newVersion);

            var oldVersion = _service.GetByName(game, newVersion.Name);
            if (oldVersion == null)
                return NotFound();

            if (newVersion.GameName != oldVersion.GameName)
                return BadRequest();

            var edited = _service.Edit(game, newVersion, oldVersion);

            CharacterViewModel editedAnswer = new CharacterViewModel(edited);

            return Ok(editedAnswer);
        }


        [HttpDelete("{game}/{characterName}")]
        public IActionResult Delete(string game, string characterName)
        {
            _logger.Log("In Delete with parameter " + characterName);

            _service.Delete(game, characterName);

            return Ok();
        }

    }
}