using Library.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.CommonObjects
{
    public abstract class CharacterFactory
    {
        public string FactoryName { get; set; }

        public abstract bool HasName(string name);

        public List<Career> Professions { get; set; }

        public abstract Character CreateCharacter(string name);

        public abstract Character Edit(CharacterViewModel newVersion, Character oldversion);

        public abstract void SetBaseAttr(Character charac);
        public abstract void SetCareerSkills(Character charac);
        public abstract void SetStats(Character charac);
        public abstract void SetSpendablePoints(Character charac);
        public abstract void SetSkills(Character charac);
    }
}
