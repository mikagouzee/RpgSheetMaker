using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.CommonObjects;
using Library.ViewModels;
using RpgSheetMaker.Tools;

namespace RpgSheetMaker.Repositories
{
    public class Repository : IRepository
    {
        private readonly IArchivist _archivist;
        private ILogMachine _logger;
        private readonly ICharacterFactory _factory;

        public Repository(ICharacterFactory factory, IArchivist archivist, ILogMachine logMachine)
        {
            _factory = factory;
            _archivist = archivist;
            _logger = logMachine;
        }

        public Character Create(CharacterCreationObject premade, string context, bool includeSkills)
        {
            var hero = includeSkills ?
                _factory.CreateCharacterWithSkills(premade, context) : 
                _factory.CreateCharacterWithBaseAttributes(premade, context);

            _archivist.SaveCharacterAsJson(hero);
            return hero;
        }

        public Character CreateEmpty(string context)
        {
            return _factory.CreateEmpty(context);
        }

        public Character CreateRandomly(RandomCharacterCreationObject premade, string context)
        {
            var hero = _factory.CreateCharacterRandomly(premade, context);
            _archivist.SaveCharacterAsJson(hero);
            return hero;
        }


        public Character Edit(CharacterViewModel newVersion, Character oldVersion, string context)
        {
            _archivist.ArchiveCharacter(oldVersion.Name);

            var edited = _factory.Edit(newVersion, oldVersion, context);

            _archivist.SaveCharacterAsJson(edited);

            return edited;
        }

        public List<Character> GetAll(string context)
        {
            var allChar = _archivist.ReadAll();

            if (allChar.Count > 0)
                _logger.Log($"Found {allChar.Count} characters");
            else
                _logger.Log($"No character found for {context}");

            return allChar.Where(c => c.GameName.ToLower() == context.ToLower()).ToList();
        }

        public List<Career> GetCareers(string context)
        {
            return _factory.GetCareers(context);
        }

        public Character GetByName(string name)
        {
            return _archivist.ReadCharacterFromJson(name);
        }

        public void Save(Character character)
        {
            _archivist.SaveCharacterAsJson(character);
        }

        public void Delete(string characterName)
        {
            _archivist.DeleteAndArchiveCharacter(characterName);
        }
    }
}
