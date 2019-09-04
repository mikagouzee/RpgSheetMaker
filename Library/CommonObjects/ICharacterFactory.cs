using Library.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.CommonObjects
{
    public interface ICharacterFactory
    {
        List<Career> GetCareers(string context);
        Character CreateCharacterRandomly(RandomCharacterCreationObject premade, string context);
        Character CreateCharacterWithSkills(CharacterCreationObject preamde, string context);
        Character CreateCharacterWithBaseAttributes(CharacterCreationObject premade, string context);
        Character CreateEmpty(string context);
        Character Edit(CharacterViewModel newVersion, Character oldversion, string context);

    }
}
