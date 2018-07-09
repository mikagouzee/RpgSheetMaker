using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.CommonObjects;
using Library.ViewModels;
using RpgSheetMaker.Tools;

namespace RpgSheetMaker.Repositories
{
    public class CallOfCthulhuRepository : IRepository
    {
        private readonly IEnumerable<CharacterFactory> _factories;
        private readonly CharacterFactory _factory;
        private readonly IArchivist _archivist;

        private readonly string _name;

        public CallOfCthulhuRepository(IEnumerable<CharacterFactory> factories, IArchivist archivist)
        {
            _factories = factories;

            _factory = _factories.SingleOrDefault(x => x.HasName("CallOfCthulhu"));

            _archivist = archivist;
            _name = "CallOfCthulhu";
        }

        public bool HasName(string name)
        {
            return _name == name;
        }

        public Character Create(string name)
        {
            return _factory.CreateCharacter(name);
        }

        public List<Character> GetAll()
        {
            return _archivist.ReadAll();
        }

        public Character GetByName(string name)
        {
            return _archivist.ReadCharacterFromJson(name);
        }

        public void Save(Character character)
        {
            _archivist.SaveCharacterAsJson(character);
        }

        public Character Edit(CharacterViewModel newVersion, Character oldVersion)
        {
            throw new NotImplementedException();
        }

        public void Delete(string characterName)
        {
            _archivist.DeleteAndArchiveCharacter(characterName);
        }

    }
}
