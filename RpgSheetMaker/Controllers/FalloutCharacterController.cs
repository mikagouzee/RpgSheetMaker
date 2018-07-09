using System.Collections.Generic;
using Library.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using RpgSheetMaker.Services;
using RpgSheetMaker.Tools;

namespace RpgSheetMaker.Controllers
{
    [Produces("application/json")]
    [Route("api/FalloutCharacter")]
    [EnableCors("AllowAll")]
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

        //CREATE
        [HttpPost("{characterName}")]
        public IActionResult Create(string characterName)
        {
            _logger.Log("In create with parameter " + characterName);
            var myCharac = _service.Create(_name, characterName);
            var response = new CharacterViewModel(myCharac);
            return Ok(response);
        }


        //READ ALL
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


        //READ ONE BY NAME
        [HttpGet("{characterName}")]
        public IActionResult GetbyName(string characterName)
        {
            _logger.Log("In get with parameter " + characterName);

            var myCharac = _service.GetByName(_name, characterName);
            var response = new CharacterViewModel(myCharac);
            return Ok(response);
        }


        //UPDATE
        [HttpPut()]
        public IActionResult Edit([FromBody]CharacterViewModel newVersion)
        {
            _logger.Log("In Edit with parameter " + newVersion);

            var oldVersion = _service.GetByName(_name, newVersion.Name);
            if (oldVersion == null)
                return NotFound();

            var edited = _service.Edit(_name, newVersion, oldVersion);

            return Ok(edited);
        }


        [HttpDelete("{characterName}")]
        public IActionResult Delete(string characterName)
        {
            _logger.Log("In Delete with parameter " + characterName);

            _service.Delete(_name, characterName);

            return Ok();
        }

    }
}