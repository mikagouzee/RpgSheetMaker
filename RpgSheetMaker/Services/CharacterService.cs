using Library.CommonObjects;
using Library.ViewModels;
using RpgSheetMaker.Repositories;
using RpgSheetMaker.Tools;
using System.Collections.Generic;
using System.Linq;

namespace RpgSheetMaker.Services
{
    public class CharacterService : ICharacterService
    {
        //private readonly IEnumerable<IRepository> _repositories;
        private ILogMachine _logger;
        private readonly IRepository _repo;

        public CharacterService(IRepository repo, ILogMachine logmachine)
        {
            //_repositories = repositories;
            _repo = repo;
            _logger = logmachine;
        }

        public Character GetByName(string contextName, string characName)
        {
            //var _repo = _repositories.SingleOrDefault(x => x.HasName(contextName));
            //_logger.Log("Repo : " + _repo.GetType());

            return _repo.GetByName(characName);
        }

        public List<Character> Get(string contextName)
        {
            //var _repo = _repositories.SingleOrDefault(x => x.HasName(contextName));
            //_logger.Log("Repo : " + _repo.GetType());

            return _repo.GetAll(contextName);
        }

        public Character CreateRandomly(string contextName, RandomCharacterCreationObject charac)
        {
            //var _repo = _repositories.SingleOrDefault(x => x.HasName(contextName));

            return _repo.CreateRandomly(charac, contextName);
        }

        public Character Create(string contextName, CharacterCreationObject charac, bool includeSkills)
        {
            //var _repo = _repositories.SingleOrDefault(x => x.HasName(contextName));

            return _repo.Create(charac, contextName, includeSkills);
        }

        public Character CreateEmpty(string contextName)
        {
            //var _repo = _repositories.SingleOrDefault(x => x.HasName(contextName));

            return _repo.CreateEmpty(contextName);
        }

        public Character Edit(string contextName, CharacterViewModel newVersion, Character oldVersion)
        {
            //var _repo = _repositories.SingleOrDefault(x => x.HasName(contextName));

            return _repo.Edit(newVersion, oldVersion, contextName);
                       
        }


        public void Delete(string contextName, string characterName)
        {
            //var _repo = _repositories.SingleOrDefault(x => x.HasName(contextName));

            _repo.Delete(characterName);
        }


        public List<Career> GetCareers(string contextName)
        {
            //var _repo = _repositories.SingleOrDefault(x => x.HasName(contextName));

            return _repo.GetCareers(contextName);
        }


    }
}
