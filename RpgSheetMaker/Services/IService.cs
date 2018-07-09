using Library.CommonObjects;
using Library.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RpgSheetMaker.Services
{
    public interface IService
    {
        Character GetByName(string contextName, string characName);

        List<Character> Get(string contextName);

        Character Create(string contextName, string characName);

        Character Edit(string contextName, CharacterViewModel newVersion, Character oldVersion);

        void Delete(string contextName, string characterName);
    }
}
