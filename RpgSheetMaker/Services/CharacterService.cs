using Library.CommonObjects;
using RpgSheetMaker.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RpgSheetMaker.Services
{
    public class CharacterService : IService
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
    }
}
