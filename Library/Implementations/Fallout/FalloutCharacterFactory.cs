using Library.CommonObjects;
using Library.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Implementations.Fallout
{
    public class FalloutCharacterFactory : CharacterFactory
    {
        public FalloutCharacterFactory()
        {
            FactoryName = "Fallout";
            Professions = new List<Career>();

            Career fighter = new Career("fighter");
            Professions.Add(fighter);
            Career wanderer = new Career("wanderer");
            Professions.Add(wanderer);
            Career merchant = new Career("merchant");
            Professions.Add(merchant);
            Career mendiant = new Career("mendiant");
            Professions.Add(mendiant);
            Career scientist = new Career("scientist");
            Professions.Add(scientist);

        }

        public override bool HasName(string name)
        {
            return name == FactoryName;
        }

        public override void SetBaseAttr(Character charac)
        {
            #region setup base attributes
            Caracteristic Strength = new Caracteristic("strength", 0, 10, 1);
            Caracteristic Perception = new Caracteristic("perception", 0, 10, 1);
            Caracteristic Endurance = new Caracteristic("endurance", 0, 10, 1);
            Caracteristic Charisma = new Caracteristic("charism", 0, 10, 1);
            Caracteristic Intelligence = new Caracteristic("intelligence", 0, 10, 1);
            Caracteristic Agility = new Caracteristic("agility", 0, 10, 1);
            Caracteristic Luck = new Caracteristic("luck", 0, 10, 1);

            charac.BaseAttributes.Add(Strength);
            charac.BaseAttributes.Add(Perception);
            charac.BaseAttributes.Add(Endurance);
            charac.BaseAttributes.Add(Charisma);
            charac.BaseAttributes.Add(Intelligence);
            charac.BaseAttributes.Add(Agility);
            charac.BaseAttributes.Add(Luck);
            #endregion

            Random r = new Random();

            //int max = charac.SpendablePoints.FirstOrDefault(s => s.Name == "creation points").CurrentValue;
            int max = 25;

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

            //charac.SpendablePoints.FirstOrDefault(s => s.Name == "creation points").CurrentValue = 0;
        }

        public override void SetCareerSkills(Character charac)
        {
            if (charac.Profession == null)
                charac.Profession = Professions.FirstOrDefault(x => x.Name == "mendiant");

            if (!charac.Profession.JobSkills.Any())
                return;

            foreach (var jobSkill in charac.Profession.JobSkills)
            {
                charac.Skills.Find(x => x.Name == jobSkill.Name).BaseValue += 20;
                charac.Skills.Find(x => x.Name == jobSkill.Name).CurrentValue = charac.Skills.Find(x => x.Name == jobSkill.Name).BaseValue;
            }

        }

        public override void SetSpendablePoints(Character charac)
        {
            //charac.SpendablePoints = SpendablePoints;

            #region Set SpendablePoints

            Caracteristic healthPoints = new Caracteristic("health points", 0);
            Caracteristic woundLimit = new Caracteristic("wound limit", 0);
            Caracteristic skillPoints = new Caracteristic("skill points", 0);
            //Caracteristic creationPoints = new Caracteristic("creation points", 5, 35, 25);

            charac.SpendablePoints.Add(healthPoints);
            charac.SpendablePoints.Add(woundLimit);
            charac.SpendablePoints.Add(skillPoints);
            //charac.SpendablePoints.Add(creationPoints);

            #endregion spendable points


            int str = charac.BaseAttributes.FirstOrDefault(b => b.Name == "strength").BaseValue;
            int endu = charac.BaseAttributes.FirstOrDefault(b => b.Name == "endurance").BaseValue;

            charac.SpendablePoints.FirstOrDefault(s => s.Name == "health points").BaseValue = 15 + str + (2 * endu);

            charac.SpendablePoints.FirstOrDefault(s => s.Name == "wound limit").BaseValue = 0;

            charac.SpendablePoints.FirstOrDefault(s => s.Name == "skill points").BaseValue = 0;

            foreach (var point in charac.SpendablePoints)
            {
                point.CurrentValue = point.BaseValue;
            }
        }

        public override void SetSkills(Character charac)
        {

            //charac.Skills = Skills;

            #region set skills

            Caracteristic smallGuns = new Caracteristic("small guns", 25, 100);
            Caracteristic bigGuns = new Caracteristic("big guns", 10, 100);
            Caracteristic energyWeapons = new Caracteristic("energy weapons", 10, 100);
            Caracteristic unarmed = new Caracteristic("unarmed", 50, 100);
            Caracteristic meleeWeapon = new Caracteristic("melee weapons", 40, 100);
            Caracteristic throwing = new Caracteristic("throwing", 20, 100);
            Caracteristic firstAid = new Caracteristic("first aid", 20, 100);
            Caracteristic doctor = new Caracteristic("doctor", 15, 100);
            Caracteristic sneak = new Caracteristic("sneak", 20, 100);
            Caracteristic lockpick = new Caracteristic("lockpick", 20, 100);
            Caracteristic steal = new Caracteristic("steal", 15, 100);
            Caracteristic traps = new Caracteristic("traps", 20, 100);
            Caracteristic science = new Caracteristic("science", 20, 100);
            Caracteristic repair = new Caracteristic("repair", 15, 100);
            Caracteristic pilot = new Caracteristic("pilot", 20, 100);
            Caracteristic speech = new Caracteristic("speech", 35, 100);
            Caracteristic barter = new Caracteristic("barter", 20, 100);
            Caracteristic gambling = new Caracteristic("gambling", 25, 100);
            Caracteristic outdoorsman = new Caracteristic("outdoorsman", 20, 100);
            Caracteristic radiationResist = new Caracteristic("radiation resistance", 0, 100);
            Caracteristic poisonResist = new Caracteristic("poison resistance", 0, 100);
            Caracteristic damageResist = new Caracteristic("damage resistance", 0, 100);
            Caracteristic electricResist = new Caracteristic("electric resistance", 0, 100);

            charac.Skills.Add(smallGuns);
            charac.Skills.Add(bigGuns);
            charac.Skills.Add(energyWeapons);
            charac.Skills.Add(unarmed);
            charac.Skills.Add(meleeWeapon);
            charac.Skills.Add(throwing);
            charac.Skills.Add(firstAid);
            charac.Skills.Add(doctor);
            charac.Skills.Add(sneak);
            charac.Skills.Add(lockpick);
            charac.Skills.Add(steal);
            charac.Skills.Add(traps);
            charac.Skills.Add(science);
            charac.Skills.Add(repair);
            charac.Skills.Add(pilot);
            charac.Skills.Add(speech);
            charac.Skills.Add(barter);
            charac.Skills.Add(gambling);
            charac.Skills.Add(outdoorsman);
            charac.Skills.Add(radiationResist);
            charac.Skills.Add(poisonResist);
            charac.Skills.Add(damageResist);
            charac.Skills.Add(electricResist);

            #endregion game skills

            #region game careers

            Career fighter = Professions.SingleOrDefault(x => x.Name == "fighter");
            fighter.JobSkills.Clear();
            fighter.JobSkills.Add(smallGuns);
            fighter.JobSkills.Add(bigGuns);
            fighter.JobSkills.Add(firstAid);

            Career wanderer = Professions.SingleOrDefault(x => x.Name == "wanderer");
            wanderer.JobSkills.Clear();
            wanderer.JobSkills.Add(outdoorsman);
            wanderer.JobSkills.Add(firstAid);
            wanderer.JobSkills.Add(repair);

            Career merchant = Professions.SingleOrDefault(x => x.Name == "merchant");
            merchant.JobSkills.Clear();
            merchant.JobSkills.Add(barter);
            merchant.JobSkills.Add(gambling);
            merchant.JobSkills.Add(speech);
            
            Career mendiant = Professions.SingleOrDefault(x => x.Name == "mendiant");
            mendiant.JobSkills.Clear();
            mendiant.JobSkills.Add(sneak);
            mendiant.JobSkills.Add(barter);
            mendiant.JobSkills.Add(steal);

            Career scientist = Professions.SingleOrDefault(x => x.Name == "scientist");
            scientist.JobSkills.Clear();
            scientist.JobSkills.Add(science);
            scientist.JobSkills.Add(energyWeapons);
            scientist.JobSkills.Add(repair);

            #endregion game careers

            int str = charac.BaseAttributes.FirstOrDefault(b => b.Name.ToLower() == "strength").BaseValue;
            int per = charac.BaseAttributes.FirstOrDefault(b => b.Name.ToLower() == "perception").BaseValue;
            int end = charac.BaseAttributes.FirstOrDefault(b => b.Name.ToLower() == "endurance").BaseValue;
            int cha = charac.BaseAttributes.FirstOrDefault(b => b.Name.ToLower() == "charism").BaseValue;
            int inte = charac.BaseAttributes.FirstOrDefault(b => b.Name.ToLower() == "intelligence").BaseValue;
            int agi = charac.BaseAttributes.FirstOrDefault(b => b.Name.ToLower() == "agility").BaseValue;
            int lck = charac.BaseAttributes.FirstOrDefault(b => b.Name.ToLower() == "luck").BaseValue;

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

        public override void SetStats(Character charac)
        {
            //charac.Stats = Stats;
            #region  setup Stats
            Caracteristic ActionPoints = new Caracteristic("Action points");
            Caracteristic Karma = new Caracteristic("Karma");
            Caracteristic ArmorClass = new Caracteristic("Armor Class");
            Caracteristic CarryWeight = new Caracteristic("Carry Weight", 0, 500);
            Caracteristic MeleeDamage = new Caracteristic("Melee Damage", 0);
            Caracteristic Sequence = new Caracteristic("Sequence");
            Caracteristic HealingRate = new Caracteristic("Healing Rate");

            charac.Stats.Add(ActionPoints);
            charac.Stats.Add(Karma);
            charac.Stats.Add(ArmorClass);
            charac.Stats.Add(CarryWeight);
            charac.Stats.Add(MeleeDamage);
            charac.Stats.Add(Sequence);
            charac.Stats.Add(HealingRate);
            #endregion


            charac.Stats.FirstOrDefault(s => s.Name.ToLower() == "karma").BaseValue = 0;
            int AP = 0;

            int str = charac.BaseAttributes.FirstOrDefault(b => b.Name.ToLower() == "strength").BaseValue;
            int endu = charac.BaseAttributes.FirstOrDefault(b => b.Name.ToLower() == "endurance").BaseValue;
            int agi = (charac.BaseAttributes.FirstOrDefault(b => b.Name.ToLower() == "agility").BaseValue != 0 ?
                charac.BaseAttributes.FirstOrDefault(b => b.Name.ToLower() == "agility").BaseValue :
                0);

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

            int MD = 5 + (str - 10);
            int per = charac.BaseAttributes.FirstOrDefault(b => b.Name.ToLower() == "perception").BaseValue;
            int HR = 0;

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

        //public override Character CreateCharacter(string name)
        //{
        //    if (string.IsNullOrEmpty(name))
        //        name = "Toby Determined";

        //    CharacterCreationObject temp = new CharacterCreationObject
        //    {
        //        Name = name,
        //        CareerName = "mendiant",
        //        GameName = FactoryName
        //    };

        //    var charac = new Character(temp);

        //    SetBaseAttr(charac);
        //    SetSpendablePoints(charac);
        //    SetSkills(charac);
        //    SetStats(charac);
        //    SetCareerSkills(charac);

        //    return charac;
        //}

        public override Character CreateCharacter(CharacterCreationObject premade)
        {
            var charac = new Character(premade);

            charac.Profession = Professions.SingleOrDefault(x => x.Name == premade.CareerName);

            SetBaseAttr(charac);
            SetSpendablePoints(charac);
            SetSkills(charac);
            SetStats(charac);
            SetCareerSkills(charac);

            return charac;
        }

        //Todo rework
        public override Character Edit(CharacterViewModel newVersion, Character oldVersion)
        {
            
            oldVersion.Update(newVersion.BaseAttributes);
            oldVersion.Update(newVersion.Stats);
            oldVersion.Update(newVersion.Skills);
            oldVersion.Update(newVersion.spendablePoints);

            oldVersion.AdaptSkills(oldVersion);

            //oldVersion.Name = newVersion.Name;

            return oldVersion;

        }

    }
}
