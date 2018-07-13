using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.CommonObjects;
using Library.ViewModels;
using RpgSheetMaker.Tools;

namespace RpgSheetMaker.Repositories
{
    public class FalloutRepository : IRepository
    {
        private readonly IEnumerable<CharacterFactory> _factories;
        private readonly CharacterFactory _factory;
        private readonly IArchivist _archivist;

        private readonly string _name;

        public FalloutRepository(IEnumerable<CharacterFactory> factories, IArchivist archivist)
        {
            _factories = factories;

            _factory = factories.SingleOrDefault(x => x.HasName("Fallout"));

            _archivist = archivist;
            _name = "Fallout";
        }

        public bool HasName(string name)
        {
            return name == _name;
        }

        public Character Create(string name)
        {
            var hero = _factory.CreateCharacter(name);
            _archivist.SaveCharacterAsJson(hero);
            return hero;
        }

        public Character Create(CharacterCreationObject premade)
        {
            var hero = _factory.CreateCharacter(premade);
            _archivist.SaveCharacterAsJson(hero);
            return hero;
        }

        public List<Character> GetAll()
        {
            return _archivist.ReadAll();
        }

        public Character GetByName(string name)
        {
            return _archivist.ReadCharacterFromJson(name);
        }

        public Character Edit(CharacterViewModel newVersion, Character oldVersion)
        {
            _archivist.ArchiveCharacter(oldVersion.Name);

            var edited = _factory.Edit(newVersion, oldVersion);

            _archivist.SaveCharacterAsJson(edited);

            return edited;
        }

        public void Save(Character character)
        {
            _archivist.SaveCharacterAsJson(character);
        }

        public void Delete(string characterName)
        {
            _archivist.DeleteAndArchiveCharacter(characterName);
        }
        
        public List<Career> GetCareers()
        {
            return _factory.Professions;
        }

    }
}
