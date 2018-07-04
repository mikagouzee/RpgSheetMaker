using Library.CommonObjects;
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
    }
}
