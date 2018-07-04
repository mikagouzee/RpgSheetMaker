using Library.CommonObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RpgSheetMaker.Tools
{
    public interface IArchivist
    {
        void WriteSummary(Character charac);

        void SaveCharacterAsJson(Character charac);

        Character ReadCharacterFromJson(string name);

        List<Character> ReadAll();


    }
}
