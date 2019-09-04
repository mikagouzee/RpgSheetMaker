using System;
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
        public IActionResult CreateRandomly(string game, [FromBody]RandomCharacterCreationObject charac)
        {
            if (charac == null)
                charac = new RandomCharacterCreationObject();

            _logger.Log("In create randomly with parameter " + charac.Name);

            //charac.GameName = game;

            var myCharac = _service.CreateRandomly(game, charac);
            var response = new CharacterViewModel(myCharac);
            return Ok(response);
        }

        [HttpPost("{game}/myCreation/{includeSkills}")]
        public IActionResult Create(string game, [FromBody]CharacterCreationObject premade, bool includeSkills)
        {
            _logger.Log("In create with parameter " + premade.Name);
            try
            {
                var myCharac = _service.Create(game, premade, includeSkills);
                var response = new CharacterViewModel(myCharac);
                return Ok(response);
            }catch(Exception ex)
            {
                _logger.Log("Error in character creation process : " + ex.Message + Environment.NewLine + ex.InnerException);
                return BadRequest();
            }
        }

        [HttpGet("{game}/Newbie")]
        public IActionResult GetEmptyCharacter(string game)
        {
            _logger.Log($"Expecting empty character for {game}");

            var empty = _service.CreateEmpty(game);

            var emptyViewModel = new CharacterViewModel(empty);

            return Ok(emptyViewModel);

        }

        //READ ALL
        [HttpGet("{game}")]
        public IActionResult GetAll(string game)
        {
            _logger.Log("In Fallout Controller GetAll with arg " + game);

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
        [HttpPut("{game}/edit/{characterName}")]
        public IActionResult Update(string game, [FromBody]CharacterViewModel newVersion)
        {
            _logger.Log("In Edit with parameter " + newVersion.Name);

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