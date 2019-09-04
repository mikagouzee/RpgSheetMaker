using Library.CommonObjects;
using Library.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Implementations
{
    public class CharacterFactory : ICharacterFactory
    {
        private readonly IEnumerable<IGame> _games;

        public CharacterFactory(IEnumerable<IGame> games)
        {
            _games = games;
        }

        public Character CreateCharacterWithBaseAttributes(CharacterCreationObject premade, string context)
        {
            var _game = _games.SingleOrDefault(g => g.HasName(context));

            Character result = new Character();
            result.Name = premade.Name;
            _game.SetCareer(result, premade.CareerName);
            result.GameName = premade.GameName;

            //Template character for the game
            _game.SetupCharacter(result);
            //Set base attributes from premade
            _game.SetCaracteristicFromCaracteristicViewModel(result.BaseAttributes, premade.BaseAttributes);
            _game.SetSpecies(result, premade.SpeciesName);

            //_game.SetCaracteristicFromCaracteristicViewModel(result.Skills, premade.Skills);
            _game.SetDefaultSkills(result);
            _game.SetCareerSkills(result);
            _game.SetDefaultSpendablePoints(result);
            _game.SetDefaultStats(result);

            if (_game.ValidateCreation(result))
                return result;
            else
                throw new ArgumentException(nameof(premade));
        }

        public Character CreateCharacterWithSkills(CharacterCreationObject premade, string context)
        {
            var _game = _games.SingleOrDefault(g => g.HasName(context));

            Character result = CreateCharacterWithBaseAttributes(premade, context);

            _game.SetChosenSkills(premade.Skills, result);

            return result;
        }

        public Character CreateCharacterRandomly(RandomCharacterCreationObject premade, string context)
        {
            var _game = _games.SingleOrDefault(x => x.HasName(context));

            var charac = new Character(premade);

            _game.SetCareer(charac, premade.CareerName);
            _game.SetupCharacter(charac);
            _game.RandomlySetBaseAttr(charac);
            _game.SetSpecies(charac, premade.SpeciesName);
            _game.SetDefaultSpendablePoints(charac);
            _game.SetDefaultSkills(charac);
            _game.SetDefaultStats(charac);
            _game.SetCareerSkills(charac);

            return charac;
        }

        public Character CreateEmpty(string context)
        {
            var _game = _games.SingleOrDefault(g => g.HasName(context));

            var newbie = new Character
            {
                Name = "DefaultName",
            };

            _game.SetCareer(newbie, null);

            _game.SetupCharacter(newbie);
            return newbie;
        }

        public Character Edit(CharacterViewModel newVersion, Character oldversion, string contextName)
        {
            var _game = _games.SingleOrDefault(g => g.HasName(contextName));

            _game.SetCaracteristicFromCaracteristicViewModel(oldversion.BaseAttributes, newVersion.BaseAttributes);

            //rewrite method chosenskills to accept a list of carac instead of a charactercreationobject 
            _game.SetChosenSkills(newVersion.Skills, oldversion);

            //_game.SetCaracteristicFromCaracteristicViewModel(oldversion.Skills, newVersion.Skills);
            _game.SetDefaultStats(oldversion);
            //_game.SetDefaultSpendablePoints(oldversion);

            return oldversion;
        }

        public List<Career> GetCareers(string context)
        {
            return _games.SingleOrDefault(g => g.HasName(context)).GetCareers();
        }

        public bool ValidateCreation(Character charac, string context)
        {
            throw new NotImplementedException();
        }
    }
}
