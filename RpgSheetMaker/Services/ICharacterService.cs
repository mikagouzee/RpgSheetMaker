using Library.CommonObjects;
using Library.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RpgSheetMaker.Services
{
    public interface ICharacterService
    {
        Character GetByName(string contextName, string characName);

        List<Character> Get(string contextName);

        //Character Create(string contextName, string characName);

        Character CreateRandomly(string contextName, RandomCharacterCreationObject charac);

        Character Create(string contextName, CharacterCreationObject charac, bool includeSkills);

        Character CreateEmpty(string contextName);

        Character Edit(string contextName, CharacterViewModel newVersion, Character oldVersion);

        void Delete(string contextName, string characterName);

        List<Career> GetCareers(string contextName);
    }
}
