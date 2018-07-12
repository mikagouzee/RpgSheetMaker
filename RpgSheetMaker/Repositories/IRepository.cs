using Library.CommonObjects;
using Library.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RpgSheetMaker.Repositories
{
    public interface IRepository
    {
        bool HasName(string name);

        List<Character> GetAll();

        Character GetByName(string name);

        Character Create(string name);

        Character Edit(CharacterViewModel newVersion, Character oldVersion);

        void Save(Character character);

        void Delete(string characterName);

        List<Career> GetCareers();

    }
}
