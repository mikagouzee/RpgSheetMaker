using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.CommonObjects;
using Library.Implementations.CallOfCthulhu;
using Library.Implementations.Fallout;

namespace RpgSheetMaker.Services
{
    public class GameService : IGameService
    {
        public GameService()
        {

        }

        public List<IGame> GetAll()
        {
            return new List<IGame> {
                new FalloutGame(),
                new CallOfCthulhuGame()
            };
        }
    }
}
