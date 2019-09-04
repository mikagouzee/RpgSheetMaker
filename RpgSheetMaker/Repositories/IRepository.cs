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
        //bool HasName(string name);

        List<Character> GetAll(string context);

        Character GetByName(string name);

        //Character Create(string name);

        Character CreateRandomly(RandomCharacterCreationObject premade, string context);

        Character Create(CharacterCreationObject premade, string context, bool includeSkills);

        Character CreateEmpty(string context);

        Character Edit(CharacterViewModel newVersion, Character oldVersion, string context);

        void Save(Character character);

        void Delete(string characterName);

        List<Career> GetCareers(string context);

    }
}
