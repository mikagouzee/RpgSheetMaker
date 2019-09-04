using Library.CommonObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RpgSheetMaker.Services
{
    public interface IGameService
    {
        List<IGame> GetAll();
    }
}
