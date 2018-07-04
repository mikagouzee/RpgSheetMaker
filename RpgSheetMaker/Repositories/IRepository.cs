using Library.CommonObjects;
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

        void Save(Character character);
    }
}
