using Library.CommonObjects;
using Library.ViewModels;
using RpgSheetMaker.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace RpgSheetMaker.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly IEnumerable<IRepository> _repositories;
        //private readonly IRepository _repo;

        public CharacterService(IEnumerable<IRepository> repositories)
        {
            _repositories = repositories;
        }

        public Character GetByName(string contextName, string characName)
        {
            var _repo = _repositories.SingleOrDefault(x => x.HasName(contextName));

            return _repo.GetByName(characName);
        }

        public List<Character> Get(string contextName)
        {
            var _repo = _repositories.SingleOrDefault(x => x.HasName(contextName));

            return _repo.GetAll();
        }

        public Character Create(string contextName, string characName)
        {
            var _repo = _repositories.SingleOrDefault(x => x.HasName(contextName));

            return _repo.Create(characName);
        }


        public Character Edit(string contextName, CharacterViewModel newVersion, Character oldVersion)
        {
            var _repo = _repositories.SingleOrDefault(x => x.HasName(contextName));

            return _repo.Edit(newVersion, oldVersion);
                       
        }


        public void Delete(string contextName, string characterName)
        {
            var _repo = _repositories.SingleOrDefault(x => x.HasName(contextName));

            _repo.Delete(characterName);
        }


        public List<Career> GetCareers(string contextName)
        {
            var repo = _repositories.SingleOrDefault(x => x.HasName(contextName));

            return repo.GetCareers();
        }

    }
}
