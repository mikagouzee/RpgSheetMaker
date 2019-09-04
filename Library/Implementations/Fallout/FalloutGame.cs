using Library.CommonObjects;
using Library.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Implementations.Fallout
{
    public class FalloutGame : IGame
    {

        public string Name { get; set; }
        public List<Career> Professions { get; set; }
        public List<Species> SpeciesList { get; set; }

        public List<Caracteristic> BaseAttributes { get; set; }
        public List<Caracteristic> Stats { get; set; }
        public List<Caracteristic> Skills { get; set; }
        public List<Caracteristic> SpendablePoints { get; set; }

        public string Rules { get; set; }

        public FalloutGame()
        {
            Name = "Fallout";
            //Professions = new FalloutCharacterFactory().Professions;

            #region species
            SpeciesList = new List<Species>();

            Species human = new Species
            {
                Name = "human",
                Modificators = new List<KeyValuePair<Caracteristic, int>>()
            };
            SpeciesList.Add(human);

            Species mutant = new Species
            {
                Name = "mutant",
                Modificators = new List<KeyValuePair<Caracteristic, int>>
                {
                    new KeyValuePair<Caracteristic, int>(new Caracteristic("strength"), 2),
                    new KeyValuePair<Caracteristic, int>(new Caracteristic("intelligence"), -2)
                }
            };
            SpeciesList.Add(mutant);

            Species ghoul = new Species
            {
                Name = "ghoul",
                Modificators = new List<KeyValuePair<Caracteristic, int>>()
                //{
                //    new KeyValuePair<Caracteristic, int>(new Caracteristic("strength"), -2),
                //    new KeyValuePair<Caracteristic, int>(new Caracteristic("endurance"), 2)
                //}
            };
            var modOne = new KeyValuePair<Caracteristic, int>(new Caracteristic("strength"), -2);
            var modTwo = new KeyValuePair<Caracteristic, int>(new Caracteristic("endurance"), 2);
            ghoul.Modificators.Add(modOne);
            ghoul.Modificators.Add(modTwo);
            SpeciesList.Add(ghoul);
            #endregion

            #region base attributes
            BaseAttributes = new List<Caracteristic>();
            Caracteristic Strength = new Caracteristic("strength", 1, 10);
            Caracteristic Perception = new Caracteristic("perception", 1, 10);
            Caracteristic Endurance = new Caracteristic("endurance", 1, 10);
            Caracteristic Charisma = new Caracteristic("charism", 1, 10);
            Caracteristic Intelligence = new Caracteristic("intelligence", 1, 10);
            Caracteristic Agility = new Caracteristic("agility", 1, 10);
            Caracteristic Luck = new Caracteristic("luck", 1, 10);

            BaseAttributes.Add(Strength);
            BaseAttributes.Add(Perception);
            BaseAttributes.Add(Endurance);
            BaseAttributes.Add(Charisma);
            BaseAttributes.Add(Intelligence);
            BaseAttributes.Add(Agility);
            BaseAttributes.Add(Luck);
            #endregion

            #region stats
            Stats = new List<Caracteristic>();
            Caracteristic ActionPoints = new Caracteristic("Action points", 0, 10);
            Caracteristic Karma = new Caracteristic("Karma", -100, 100);
            Caracteristic ArmorClass = new Caracteristic("Armor Class", 1, 10);
            Caracteristic CarryWeight = new Caracteristic("Carry Weight", 0, 500);
            Caracteristic MeleeDamage = new Caracteristic("Melee Damage", 0, 6);
            Caracteristic Sequence = new Caracteristic("Sequence", 2, 20);
            Caracteristic HealingRate = new Caracteristic("Healing Rate", 1, 4);

            Stats.Add(ActionPoints);
            Stats.Add(Karma);
            Stats.Add(ArmorClass);
            Stats.Add(CarryWeight);
            Stats.Add(MeleeDamage);
            Stats.Add(Sequence);
            Stats.Add(HealingRate);
            #endregion

            #region skills
            Skills = new List<Caracteristic>();
            Caracteristic smallGuns = new Caracteristic("small guns", 9, 150);
            Caracteristic bigGuns = new Caracteristic("big guns", 2, 150);
            Caracteristic energyWeapons = new Caracteristic("energy weapons", 2, 150);
            Caracteristic unarmed = new Caracteristic("unarmed", 34, 150);
            Caracteristic meleeWeapon = new Caracteristic("melee weapons", 24, 150);
            Caracteristic throwing = new Caracteristic("throwing", 4, 150);
            Caracteristic firstAid = new Caracteristic("first aid", 4, 150);
            Caracteristic doctor = new Caracteristic("doctor", 7, 150);
            Caracteristic sneak = new Caracteristic("sneak", 8, 150);
            Caracteristic lockpick = new Caracteristic("lockpick", 12, 150);
            Caracteristic steal = new Caracteristic("steal", 3, 150);
            Caracteristic traps = new Caracteristic("traps", 12, 150);
            Caracteristic science = new Caracteristic("science", 4, 150);
            Caracteristic repair = new Caracteristic("repair", 3, 150);
            Caracteristic pilot = new Caracteristic("pilot", 4, 150);
            Caracteristic speech = new Caracteristic("speech", 5, 150);
            Caracteristic barter = new Caracteristic("barter", 4, 150);
            Caracteristic gambling = new Caracteristic("gambling", 5, 150);
            Caracteristic outdoorsman = new Caracteristic("outdoorsman", 4, 150);
            Caracteristic radiationResist = new Caracteristic("radiation resistance", 0, 150);
            Caracteristic poisonResist = new Caracteristic("poison resistance", 0, 150);
            Caracteristic damageResist = new Caracteristic("damage resistance", 0, 150);
            Caracteristic electricResist = new Caracteristic("electric resistance", 0, 150);

            Skills.Add(smallGuns);
            Skills.Add(bigGuns);
            Skills.Add(energyWeapons);
            Skills.Add(unarmed);
            Skills.Add(meleeWeapon);
            Skills.Add(throwing);
            Skills.Add(firstAid);
            Skills.Add(doctor);
            Skills.Add(sneak);
            Skills.Add(lockpick);
            Skills.Add(steal);
            Skills.Add(traps);
            Skills.Add(science);
            Skills.Add(repair);
            Skills.Add(pilot);
            Skills.Add(speech);
            Skills.Add(barter);
            Skills.Add(gambling);
            Skills.Add(outdoorsman);
            Skills.Add(radiationResist);
            Skills.Add(poisonResist);
            Skills.Add(damageResist);
            Skills.Add(electricResist);
            #endregion

            #region spendable points
            SpendablePoints = new List<Caracteristic>();
            Caracteristic healthPoints = new Caracteristic("health points", 18, 50);
            Caracteristic woundLimit = new Caracteristic("wound limit", 0, 20);
            Caracteristic skillPoints = new Caracteristic("skill points", 0, 30);
            //Caracteristic creationPoints = new Caracteristic("creation points", 5, 35, 25);

            //SpendablePoints.Add(creationPoints);

            SpendablePoints.Add(healthPoints);
            SpendablePoints.Add(woundLimit);
            SpendablePoints.Add(skillPoints);
            #endregion

            #region Career

            Professions = new List<Career>();

            Career fighter = new Career("fighter");
            Professions.Add(fighter);
            fighter.JobSkills.Clear();
            fighter.JobSkills.Add(smallGuns);
            fighter.JobSkills.Add(bigGuns);
            fighter.JobSkills.Add(firstAid);

            Career rogue = new Career("rogue");
            Professions.Add(rogue);
            rogue.JobSkills.Clear();
            rogue.JobSkills.Add(steal);
            rogue.JobSkills.Add(sneak);
            rogue.JobSkills.Add(lockpick);

            Career wanderer = new Career("wanderer");
            Professions.Add(wanderer);
            wanderer.JobSkills.Clear();
            wanderer.JobSkills.Add(outdoorsman);
            wanderer.JobSkills.Add(firstAid);
            wanderer.JobSkills.Add(repair);

            Career merchant = new Career("merchant");
            Professions.Add(merchant);
            merchant.JobSkills.Clear();
            merchant.JobSkills.Add(barter);
            merchant.JobSkills.Add(gambling);
            merchant.JobSkills.Add(speech);

            Career mendiant = new Career("mendiant");
            Professions.Add(mendiant);
            mendiant.JobSkills.Clear();
            mendiant.JobSkills.Add(sneak);
            mendiant.JobSkills.Add(barter);
            mendiant.JobSkills.Add(steal);

            Career scientist = new Career("scientist");
            Professions.Add(scientist);
            scientist.JobSkills.Clear();
            scientist.JobSkills.Add(science);
            scientist.JobSkills.Add(energyWeapons);
            scientist.JobSkills.Add(repair);
            #endregion

            Rules = "You have 35 points to allocate between your S.P.E.C.I.A.L., in a range of 1 to 10. ";
            Rules += "Then, you can allocate a number of points in your skills. Currently, that number has been fixed to 3 times your Intelligence score. ";
            Rules += "But you might be able to cheat your way in. ;-) ";
        }

        public GameViewModel ToViewModel()
        {
            return new GameViewModel
            {
                Name = Name,
                jobs = Professions.Select(p => p.Name).ToList(),
                species = SpeciesList.Select(s => s.Name).ToList(),
                rules = Rules
            };
        }

        public List<Career> GetCareers()
        {
            return this.Professions;
        }

        public bool HasName(string context)
        {
            return context.ToLower() == Name.ToLower();
        }

        public void SetupCharacter(Character target)
        {
            target.GameName = Name;
            target.BaseAttributes = BaseAttributes.Select(b => new Caracteristic(b)).ToList();
            target.SpendablePoints = SpendablePoints.Select(s => new Caracteristic(s)).ToList();
            target.Skills = Skills.Select(s => new Caracteristic(s)).ToList();
            target.Stats = Stats.Select(s => new Caracteristic(s)).ToList();
        }
        public void RandomlySetBaseAttr(Character charac)
        {
            Random r = new Random();

            int max = 35; //todo : set max value of creation point in config file.

            for (int i = 0; i < max; i++)
            {
                int j = r.Next(0, charac.BaseAttributes.Count);

                if (charac.BaseAttributes[j].BaseValue < charac.BaseAttributes[j].Maximum)
                {
                    charac.BaseAttributes[j].BaseValue += 1;
                }
            }

            foreach (var attr in charac.BaseAttributes)
            {
                attr.CurrentValue = attr.BaseValue;
            }

        }
        public void SetCareerSkills(Character charac)
        {
            if (charac.Profession == null)
                charac.Profession = Professions.ElementAt(new Random().Next(0, Professions.Count));

            if (!charac.Profession.JobSkills.Any())
                return;

            foreach (var jobSkill in charac.Profession.JobSkills)
            {
                charac.Skills.Find(x => x.Name == jobSkill.Name).BaseValue += 20;
                charac.Skills.Find(x => x.Name == jobSkill.Name).CurrentValue = charac.Skills.Find(x => x.Name == jobSkill.Name).BaseValue;
            }

        }
        public void SetDefaultSpendablePoints(Character charac)
        {
            int str = charac.BaseAttributes.FirstOrDefault(b => b.Name == "strength").BaseValue;
            int endu = charac.BaseAttributes.FirstOrDefault(b => b.Name == "endurance").BaseValue;
            int intel = charac.BaseAttributes.FirstOrDefault(b => b.Name == "intelligence").BaseValue;

            charac.SpendablePoints.FirstOrDefault(s => s.Name == "health points").BaseValue = 15 + str + (2 * endu);

            charac.SpendablePoints.FirstOrDefault(s => s.Name == "wound limit").BaseValue = 0;

            charac.SpendablePoints.FirstOrDefault(s => s.Name == "skill points").BaseValue = 5 + (intel * 2);

            foreach (var point in charac.SpendablePoints)
            {
                point.CurrentValue = point.BaseValue;
            }
        }
        public void SetDefaultSkills(Character charac)
        {

            //charac.Skills = Skills;
            int str = charac.BaseAttributes.FirstOrDefault(b => b.Name.ToLower() == "strength").BaseValue;
            int per = charac.BaseAttributes.FirstOrDefault(b => b.Name.ToLower() == "perception").BaseValue;
            int end = charac.BaseAttributes.FirstOrDefault(b => b.Name.ToLower() == "endurance").BaseValue;
            int cha = charac.BaseAttributes.FirstOrDefault(b => b.Name.ToLower() == "charism").BaseValue;
            int inte = charac.BaseAttributes.FirstOrDefault(b => b.Name.ToLower() == "intelligence").BaseValue;
            int agi = charac.BaseAttributes.FirstOrDefault(b => b.Name.ToLower() == "agility").BaseValue;
            int lck = charac.BaseAttributes.FirstOrDefault(b => b.Name.ToLower() == "luck").BaseValue;

            foreach (var skill in charac.Skills)
            {
                skill.BaseValue = skill.Minimum;
            }

            charac.Skills.FirstOrDefault(s => s.Name.ToLower() == "small guns").BaseValue = 5 + agi * 4;
            charac.Skills.FirstOrDefault(s => s.Name.ToLower() == "big guns").BaseValue = 0 + (agi * 2);
            charac.Skills.FirstOrDefault(s => s.Name.ToLower() == "energy weapons").BaseValue = 0 + (agi * 2);
            charac.Skills.FirstOrDefault(s => s.Name.ToLower() == "unarmed").BaseValue = 30 + 2 * (agi + str);
            charac.Skills.FirstOrDefault(s => s.Name.ToLower() == "melee weapons").BaseValue = 20 + 2 * (agi + str);
            charac.Skills.FirstOrDefault(s => s.Name.ToLower() == "throwing").BaseValue = 0 + 4 * agi;
            charac.Skills.FirstOrDefault(s => s.Name.ToLower() == "first aid").BaseValue = 0 + 2 * (per + end);
            charac.Skills.FirstOrDefault(s => s.Name.ToLower() == "doctor").BaseValue = 5 + (per + inte);
            charac.Skills.FirstOrDefault(s => s.Name.ToLower() == "sneak").BaseValue = 5 + (3 * agi);
            charac.Skills.FirstOrDefault(s => s.Name.ToLower() == "lockpick").BaseValue = 10 + (per + agi);
            charac.Skills.FirstOrDefault(s => s.Name.ToLower() == "steal").BaseValue = 0 + (3 * agi);
            charac.Skills.FirstOrDefault(s => s.Name.ToLower() == "traps").BaseValue = 10 + (per + agi);
            charac.Skills.FirstOrDefault(s => s.Name.ToLower() == "science").BaseValue = 0 + 4 * inte;
            charac.Skills.FirstOrDefault(s => s.Name.ToLower() == "repair").BaseValue = 0 + 3 * inte;
            charac.Skills.FirstOrDefault(s => s.Name.ToLower() == "pilot").BaseValue = 0 + 2 * (agi + per);
            charac.Skills.FirstOrDefault(s => s.Name.ToLower() == "speech").BaseValue = 0 + 5 * cha;
            charac.Skills.FirstOrDefault(s => s.Name.ToLower() == "barter").BaseValue = 0 + 4 * cha;
            charac.Skills.FirstOrDefault(s => s.Name.ToLower() == "gambling").BaseValue = 0 + 5 * lck;
            charac.Skills.FirstOrDefault(s => s.Name.ToLower() == "outdoorsman").BaseValue = 0 + 2 * (end + inte);
            charac.Skills.FirstOrDefault(s => s.Name.ToLower() == "radiation resistance").BaseValue = 0;
            charac.Skills.FirstOrDefault(s => s.Name.ToLower() == "poison resistance").BaseValue = 0;
            charac.Skills.FirstOrDefault(s => s.Name.ToLower() == "damage resistance").BaseValue = 0;
            charac.Skills.FirstOrDefault(s => s.Name.ToLower() == "electric resistance").BaseValue = 0;

            foreach (var skill in charac.Skills)
            {
                skill.CurrentValue = skill.BaseValue;
            }

        }
        public void SetDefaultStats(Character charac)
        {

            int str = charac.BaseAttributes.FirstOrDefault(b => b.Name.ToLower() == "strength").BaseValue;
            int per = charac.BaseAttributes.FirstOrDefault(b => b.Name.ToLower() == "perception").BaseValue;
            int endu = charac.BaseAttributes.FirstOrDefault(b => b.Name.ToLower() == "endurance").BaseValue;
            int agi = charac.BaseAttributes.FirstOrDefault(b => b.Name.ToLower() == "agility").BaseValue;

            int MD = 5 + (str - 10);
            int AP = 0;
            int HR = 0;

            switch (agi)
            {
                case 1:
                    AP = 5;
                    break;

                case 2:
                case 3:
                    AP = 6;
                    break;

                case 4:
                case 5:
                    AP = 7;
                    break;

                case 6:
                case 7:
                    AP = 8;
                    break;

                case 8:
                case 9:
                    AP = 9;
                    break;

                case 10:
                    AP = 10;
                    break;

                default:
                    AP = 1;
                    break;
            }

            switch (endu)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                    HR = 1;
                    break;

                case 6:
                case 7:
                case 8:
                    HR = 2;
                    break;

                case 9:
                case 10:
                    HR = 3;
                    break;

                default:
                    HR = 4;
                    break;
            }

            charac.Stats.FirstOrDefault(s => s.Name.ToLower() == "karma").BaseValue = 0;
            charac.Stats.FirstOrDefault(s => s.Name.ToLower() == "action points").BaseValue = AP;
            charac.Stats.FirstOrDefault(s => s.Name.ToLower() == "armor class").BaseValue = agi;
            charac.Stats.FirstOrDefault(s => s.Name.ToLower() == "carry weight").BaseValue = 25 + (25 * str);
            charac.Stats.FirstOrDefault(s => s.Name.ToLower() == "melee damage").BaseValue = (MD > 0 ? MD : 1);
            charac.Stats.FirstOrDefault(s => s.Name.ToLower() == "sequence").BaseValue = 2 * per;
            charac.Stats.FirstOrDefault(s => s.Name.ToLower() == "healing rate").BaseValue = HR;

            foreach (var stat in charac.Stats)
            {
                stat.CurrentValue = stat.BaseValue;
            }
        }
        public void SetCaracteristicFromCaracteristicViewModel(List<Caracteristic> resultList, List<CaracteristicViewModel> premadeList)
        {
            foreach (var item in resultList)
            {
                var premadeItem = premadeList.FirstOrDefault(x => x.EqualsCaracteristic(item));

                item.BaseValue = premadeItem == null ?
                    item.Minimum :
                    item.Validate(premadeItem.Score) ?
                        premadeItem.Score :
                        item.Minimum;

                item.CurrentValue = item.BaseValue;
            }
            //return resultList;
        }
        public void SetCareer(Character target, string careerName)
{
            if (careerName != null && careerName != "default occupation")
                target.Profession = Professions.SingleOrDefault(x => x.Name.ToLower() == careerName.ToLower());
            else
                target.Profession = Professions.ElementAt(new Random().Next(0, Professions.Count));
        }
        public void SetSpecies(Character target, string speciesName)
        {
            if (speciesName != null)
                target.Species = SpeciesList.FirstOrDefault(x => x.Name.ToLower() == speciesName.ToLower());
            else
                target.Species = SpeciesList.ElementAt(new Random().Next(0, SpeciesList.Count));

            target.Species.ApplyModificators(target.BaseAttributes);
        }
        public bool ValidateCreation(Character newbie)
        {
            bool IsLegit = true;

            #region CHECK SKILL POINTS
            var basicIntel = newbie.BaseAttributes.FirstOrDefault(ba => ba.Name == "intelligence").CurrentValue;

            var multiplicator = 3; //TODO REPLACE THIS BY A CONFIG FILE VALUE

            var basicPointPool = basicIntel * multiplicator;

            int spendedPoints = 0;

            foreach (var aSkill in newbie.Skills)
            {
                if (newbie.Profession.JobSkills.Any(s => s.Name == aSkill.Name))
                {
                    //if it's a job skill, there's a hardcoded 20 points bonus that does not come from spendable points.
                    spendedPoints += (aSkill.CurrentValue - aSkill.BaseValue - 20);
                }
                else
                {
                    spendedPoints += (aSkill.CurrentValue - aSkill.BaseValue);
                }
            }

            //todo : move spendable skill points assignation out of validation process.
            newbie.SpendablePoints.FirstOrDefault(s => s.Name == "skill points").CurrentValue = basicPointPool -= spendedPoints;

            IsLegit = spendedPoints <= basicPointPool;
            if (!IsLegit)
                return false;
            #endregion

            #region CHECK SPECIAL

            int maxSpecial = 35; // TODO REPLACE WITH VALUE FROM CONFIG

            int allocated = 0;

            foreach (var spec in newbie.BaseAttributes)
            {
                allocated += spec.BaseValue - 1;
            }

            IsLegit = maxSpecial >= allocated;

            #endregion

            return IsLegit;
        }
        public void SetChosenSkills(List<CaracteristicViewModel> premadeSkills, Character target)
        {
            var skillPoint = target.SpendablePoints.FirstOrDefault(x => x.Name == "skill points");
            var maxAllocatable = skillPoint.BaseValue;
            var allocated = 0;

            var tempList = target.Skills.ConvertAll(x => new Caracteristic(x));

            foreach (var s in premadeSkills)
            {
                s.Score = Math.Abs(s.Score);

                var tempSkill = tempList.FirstOrDefault(x => x.Name.ToLower() == s.Name.ToLower());
                var min = tempSkill.Minimum;

                if (s.Score < min)
                    s.Score = min;
                if (s.Score < tempSkill.CurrentValue)
                    s.Score = tempSkill.CurrentValue;

                var spent = s.Score - min;

                allocated += IsJobSkill(tempSkill, target.Profession) ?
                    spent - 20 :
                    spent;
            }

            if (allocated < maxAllocatable)
            {
                foreach (var s in target.Skills)
                {
                    s.Setvalue(tempList.SingleOrDefault(x => x.Equals(s)).CurrentValue);
                }
                skillPoint.CurrentValue = maxAllocatable - allocated;
            }

        }
        public bool IsJobSkill(Caracteristic skill, Career job)
        {
            return job.JobSkills.Any(s => s.Equals(skill));
        }

    }
}
