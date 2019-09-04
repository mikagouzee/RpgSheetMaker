using Library.CommonObjects;
using Library.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Implementations.CallOfCthulhu
{
    public class CallOfCthulhuGame : IGame
    {

        public string Name { get; set; }
        public List<Career> Professions { get; set; }
        public List<Species> SpeciesList { get; set; }

        public List<Caracteristic> BaseAttributes { get; set; }
        public List<Caracteristic> Stats { get; set; }
        public List<Caracteristic> Skills { get; set; }
        public List<Caracteristic> SpendablePoints { get; set; }

        public string Rules { get; set; }


        public CallOfCthulhuGame()
        {
            Name = "CallOfCthulhu";
            //Professions = new CthulhuCharacterFactory().Professions;

            #region BaseAttributes
            BaseAttributes = new List<Caracteristic>();
            Caracteristic appearance = new Caracteristic("appearance", 3, 18);
            Caracteristic constitution = new Caracteristic("constitution", 3, 18);
            Caracteristic strength = new Caracteristic("strength", 3, 18);
            Caracteristic dexterity = new Caracteristic("dexterity", 3, 18);
            Caracteristic power = new Caracteristic("power", 3, 18);
            Caracteristic size = new Caracteristic("size", 3, 18);
            Caracteristic intelligence = new Caracteristic("intelligence", 3, 18);
            Caracteristic education = new Caracteristic("education", 9, 24);
            BaseAttributes.Add(appearance);
            BaseAttributes.Add(constitution);
            BaseAttributes.Add(strength);
            BaseAttributes.Add(dexterity);
            BaseAttributes.Add(power);
            BaseAttributes.Add(size);
            BaseAttributes.Add(intelligence);
            BaseAttributes.Add(education);
            #endregion

            #region Stats
            Stats = new List<Caracteristic>();
            Caracteristic prestance = new Caracteristic("prestance", 1, 100); //max 90
            Caracteristic endurance = new Caracteristic("endurance", 1, 100); //max 90
            Caracteristic agility = new Caracteristic("agility", 1, 100); //max 90
            Caracteristic brawlpower = new Caracteristic("brawl power", 1, 100); //max 90
            Caracteristic height = new Caracteristic("height", 1, 100); //max 90
            Caracteristic knowledge = new Caracteristic("knowledge", 1, 100); //max 120
            Caracteristic idea = new Caracteristic("idea", 1, 100); //max 90
            Caracteristic willpower = new Caracteristic("will power", 1, 100); //max 90
            Caracteristic sanity = new Caracteristic("sanity", 1, 100); //max 90

            Stats.Add(prestance);
            Stats.Add(endurance);
            Stats.Add(agility);
            Stats.Add(brawlpower);
            Stats.Add(height);
            Stats.Add(knowledge);
            Stats.Add(idea);
            Stats.Add(willpower);
            Stats.Add(sanity);
            #endregion

            #region Skills
            Skills = new List<Caracteristic>();
            Caracteristic art = new Caracteristic("art", 5, 100);
            Caracteristic artisanat = new Caracteristic("artisanat", 5, 100);
            Caracteristic baratin = new Caracteristic("baratin", 5, 100);
            Caracteristic bibliotheque = new Caracteristic("bibliotheque", 5, 100);
            Caracteristic comptabilite = new Caracteristic("comptabilite", 10, 100);
            Caracteristic concocterPotion = new Caracteristic("concocter potion", 1, 100);
            Caracteristic conduireAttelage = new Caracteristic("conduire attelage", 20, 100);
            Caracteristic coupDePied = new Caracteristic("coup de pied", 25, 100);
            Caracteristic coupDePoing = new Caracteristic("coup de poing", 50, 100);
            Caracteristic coupDeTete = new Caracteristic("coup de tete", 10, 100);
            Caracteristic discretion = new Caracteristic("discretion", 10, 100);
            Caracteristic dissimulation = new Caracteristic("dissimulation", 15, 100);
            Caracteristic ecouter = new Caracteristic("ecouter", 25, 100);
            Caracteristic ecrireUneLangue = new Caracteristic("ecrire une langue", 1, 100);
            Caracteristic esquiver = new Caracteristic("esquiver", 5, 100);
            Caracteristic grimper = new Caracteristic("grimper", 40, 100);
            Caracteristic lancer = new Caracteristic("lancer", 25, 100);
            Caracteristic langueEtrangere = new Caracteristic("langue etrangere", 1, 100);
            Caracteristic langueNatale = new Caracteristic("langue natale", 5, 100);
            Caracteristic lutte = new Caracteristic("lutte", 25, 100);
            Caracteristic marchandage = new Caracteristic("marchandage", 5, 100);
            Caracteristic mondeNaturel = new Caracteristic("monde naturel", 10, 100);
            Caracteristic monterACheval = new Caracteristic("monter a cheval", 5, 100);
            Caracteristic mytheDeCthulhu = new Caracteristic("mythe de Cthulhu", 0, 100);
            Caracteristic nager = new Caracteristic("nager", 25, 100);
            Caracteristic navigation = new Caracteristic("navigation", 10, 100);
            Caracteristic occultisme = new Caracteristic("occultisme", 5, 100);
            Caracteristic persuasion = new Caracteristic("persuasion", 15, 100);
            Caracteristic piloterBateau = new Caracteristic("piloter bateau", 1, 100);
            Caracteristic premiersSoins = new Caracteristic("premiers soins", 30, 100);
            Caracteristic reparerConcevoir = new Caracteristic("reparer concevoir", 20, 100);
            Caracteristic royaumeNatal = new Caracteristic("royaume natal", 20, 100);
            Caracteristic royaumesEtrangers = new Caracteristic("royaumes etrangers", 1, 100);
            Caracteristic sagacite = new Caracteristic("sagacite", 5, 100);
            Caracteristic sauter = new Caracteristic("sauter", 25, 100);
            Caracteristic science = new Caracteristic("science", 1, 100);
            Caracteristic se_cacher = new Caracteristic("se cacher", 10, 100);
            Caracteristic statut = new Caracteristic("statut", 15, 100);
            Caracteristic suivrePiste = new Caracteristic("suivre une piste", 10, 100);
            Caracteristic trouverObjetCache = new Caracteristic("trouver objet cache", 25, 100);

            Skills.Add(art);
            Skills.Add(artisanat);
            Skills.Add(baratin);
            Skills.Add(bibliotheque);
            Skills.Add(comptabilite);
            Skills.Add(concocterPotion);
            Skills.Add(conduireAttelage);
            Skills.Add(coupDePied);
            Skills.Add(coupDePoing);
            Skills.Add(coupDeTete);
            Skills.Add(discretion);
            Skills.Add(dissimulation);
            Skills.Add(ecouter);
            Skills.Add(ecrireUneLangue);
            Skills.Add(esquiver);
            Skills.Add(grimper);
            Skills.Add(lancer);
            Skills.Add(langueEtrangere);
            Skills.Add(langueNatale);
            Skills.Add(lutte);
            Skills.Add(marchandage);
            Skills.Add(mondeNaturel);
            Skills.Add(monterACheval);
            Skills.Add(mytheDeCthulhu);
            Skills.Add(nager);
            Skills.Add(navigation);
            Skills.Add(occultisme);
            Skills.Add(persuasion);
            Skills.Add(piloterBateau);
            Skills.Add(premiersSoins);
            Skills.Add(reparerConcevoir);
            Skills.Add(royaumeNatal);
            Skills.Add(royaumesEtrangers);
            Skills.Add(sagacite);
            Skills.Add(sauter);
            Skills.Add(science);
            Skills.Add(se_cacher);
            Skills.Add(statut);
            Skills.Add(suivrePiste);
            Skills.Add(trouverObjetCache);


            #endregion

            #region spendable points
            SpendablePoints = new List<Caracteristic>();
            Caracteristic healthPoints = new Caracteristic("health points", 3, 18); //max 18
            Caracteristic woundLimit = new Caracteristic("wound limit", 1, 9); //max 9 
            Caracteristic magicPoints = new Caracteristic("magic points", 3, 9); //max 18
            Caracteristic occupationSkillPoints = new Caracteristic("Occupation skill points", 0, 480); //max 480
            Caracteristic personalInterestSkillPoints = new Caracteristic("Personal interest skill points", 0, 180); //max 180

            SpendablePoints.Add(healthPoints);
            SpendablePoints.Add(woundLimit);
            SpendablePoints.Add(magicPoints);
            SpendablePoints.Add(occupationSkillPoints);
            SpendablePoints.Add(personalInterestSkillPoints);

            #endregion

            #region init careers
            Professions = new List<Career>();

            Career artisan = new Career("artisan");
            Professions.Add(artisan);

            Career clerc = new Career("clerc");
            Professions.Add(clerc);

            Career ermite = new Career("ermite");
            Professions.Add(ermite);

            Career erudit = new Career("erudit");
            Professions.Add(erudit);

            Career fermier = new Career("fermier");
            Professions.Add(fermier);

            Career forestier = new Career("forestier");
            Professions.Add(forestier);

            Career garde = new Career("garde");
            Professions.Add(garde);

            Career guerisseur = new Career("guerisseur");
            Professions.Add(guerisseur);

            Career marchand = new Career("marchand");
            Professions.Add(marchand);

            Career menestrel = new Career("menestrel");
            Professions.Add(menestrel);

            Career marin = new Career("marin");
            Professions.Add(marin);

            Career mendiant = new Career("mendiant");
            Professions.Add(mendiant);

            Career moine = new Career("moine");
            Professions.Add(moine);

            Career negociant = new Career("negociant");
            Professions.Add(negociant);

            Career pelerin = new Career("pelerin");
            Professions.Add(pelerin);

            Career pretre = new Career("pretre");
            Professions.Add(pretre);

            Career sergent = new Career("sergent");
            Professions.Add(sergent);

            Career serviteur = new Career("serviteur");
            Professions.Add(serviteur);

            #region gameCareers
            artisan.JobSkills.Add(baratin);
            artisan.JobSkills.Add(marchandage);
            artisan.JobSkills.Add(mondeNaturel);
            artisan.JobSkills.Add(royaumeNatal);
            artisan.JobSkills.Add(sagacite);
            artisan.JobSkills.Add(statut);

            clerc.JobSkills.Add(bibliotheque);
            clerc.JobSkills.Add(langueEtrangere);
            clerc.JobSkills.Add(persuasion);
            clerc.JobSkills.Add(royaumeNatal);
            clerc.JobSkills.Add(statut);
            clerc.JobSkills.Add(ecrireUneLangue);

            ermite.JobSkills.Add(mondeNaturel);
            ermite.JobSkills.Add(occultisme);
            ermite.JobSkills.Add(persuasion);
            ermite.JobSkills.Add(sagacite);
            ermite.JobSkills.Add(se_cacher);
            ermite.JobSkills.Add(trouverObjetCache);
            ermite.JobSkills.Add(ecouter);

            erudit.JobSkills.Add(bibliotheque);
            erudit.JobSkills.Add(ecrireUneLangue);
            erudit.JobSkills.Add(persuasion);
            erudit.JobSkills.Add(royaumeNatal);
            erudit.JobSkills.Add(science);
            erudit.JobSkills.Add(statut);

            fermier.JobSkills.Add(artisanat);
            fermier.JobSkills.Add(conduireAttelage);
            fermier.JobSkills.Add(ecouter);
            fermier.JobSkills.Add(marchandage);
            fermier.JobSkills.Add(mondeNaturel);
            fermier.JobSkills.Add(suivrePiste);

            forestier.JobSkills.Add(artisanat);
            forestier.JobSkills.Add(lancer);
            forestier.JobSkills.Add(mondeNaturel);
            forestier.JobSkills.Add(nager);
            forestier.JobSkills.Add(discretion);
            forestier.JobSkills.Add(navigation);
            forestier.JobSkills.Add(piloterBateau);
            forestier.JobSkills.Add(suivrePiste);
            forestier.JobSkills.Add(trouverObjetCache);
            forestier.JobSkills.Add(ecouter);

            garde.JobSkills.Add(coupDePoing);
            garde.JobSkills.Add(coupDePied);
            garde.JobSkills.Add(coupDeTete);
            garde.JobSkills.Add(lutte);
            garde.JobSkills.Add(discretion);
            garde.JobSkills.Add(lancer);
            garde.JobSkills.Add(royaumeNatal);
            garde.JobSkills.Add(statut);
            garde.JobSkills.Add(trouverObjetCache);
            garde.JobSkills.Add(ecouter);

            guerisseur.JobSkills.Add(concocterPotion);
            guerisseur.JobSkills.Add(mondeNaturel);
            guerisseur.JobSkills.Add(occultisme);
            guerisseur.JobSkills.Add(premiersSoins);
            guerisseur.JobSkills.Add(sagacite);
            guerisseur.JobSkills.Add(trouverObjetCache);
            guerisseur.JobSkills.Add(ecouter);

            marchand.JobSkills.Add(baratin);
            marchand.JobSkills.Add(conduireAttelage);
            marchand.JobSkills.Add(langueEtrangere);
            marchand.JobSkills.Add(marchandage);
            marchand.JobSkills.Add(navigation);
            marchand.JobSkills.Add(royaumeNatal);
            marchand.JobSkills.Add(sagacite);

            menestrel.JobSkills.Add(art);
            menestrel.JobSkills.Add(baratin);
            menestrel.JobSkills.Add(marchandage);
            menestrel.JobSkills.Add(persuasion);
            menestrel.JobSkills.Add(royaumeNatal);
            menestrel.JobSkills.Add(sagacite);

            marin.JobSkills.Add(baratin);
            marin.JobSkills.Add(grimper);
            marin.JobSkills.Add(mondeNaturel);
            marin.JobSkills.Add(navigation);
            marin.JobSkills.Add(piloterBateau);
            marin.JobSkills.Add(royaumesEtrangers);

            mendiant.JobSkills.Add(baratin);
            mendiant.JobSkills.Add(dissimulation);
            mendiant.JobSkills.Add(marchandage);
            mendiant.JobSkills.Add(sagacite);
            mendiant.JobSkills.Add(ecouter);
            mendiant.JobSkills.Add(trouverObjetCache);

            moine.JobSkills.Add(art);
            moine.JobSkills.Add(bibliotheque);
            moine.JobSkills.Add(ecouter);
            moine.JobSkills.Add(ecrireUneLangue);
            moine.JobSkills.Add(langueEtrangere);
            moine.JobSkills.Add(occultisme);

            negociant.JobSkills.Add(baratin);
            negociant.JobSkills.Add(comptabilite);
            negociant.JobSkills.Add(ecrireUneLangue);
            negociant.JobSkills.Add(langueEtrangere);
            negociant.JobSkills.Add(marchandage);
            negociant.JobSkills.Add(royaumesEtrangers);
            negociant.JobSkills.Add(royaumeNatal);

            pelerin.JobSkills.Add(discretion);
            pelerin.JobSkills.Add(marchandage);
            pelerin.JobSkills.Add(mondeNaturel);
            pelerin.JobSkills.Add(navigation);
            pelerin.JobSkills.Add(royaumeNatal);

            pretre.JobSkills.Add(baratin);
            pretre.JobSkills.Add(langueEtrangere);
            pretre.JobSkills.Add(occultisme);
            pretre.JobSkills.Add(persuasion);
            pretre.JobSkills.Add(sagacite);
            pretre.JobSkills.Add(statut);

            sergent.JobSkills.Add(baratin);
            sergent.JobSkills.Add(discretion);
            sergent.JobSkills.Add(marchandage);
            sergent.JobSkills.Add(sagacite);
            sergent.JobSkills.Add(statut);
            sergent.JobSkills.Add(trouverObjetCache);

            serviteur.JobSkills.Add(artisanat);
            serviteur.JobSkills.Add(baratin);
            serviteur.JobSkills.Add(discretion);
            serviteur.JobSkills.Add(dissimulation);
            serviteur.JobSkills.Add(ecouter);
            serviteur.JobSkills.Add(trouverObjetCache);

            #endregion
            #endregion

            #region species
            SpeciesList = new List<Species>();

            Species human = new Species
            {
                Name = "human",
                Modificators = new List<KeyValuePair<Caracteristic, int>>()
            };
            SpeciesList.Add(human);

            #endregion

            #region rules
            Rules = "Roll 3D6 for Str, Con, Pow and Dex. ";
            Rules += "Then roll 2D6 + 6 for Siz and Int. ";
            Rules += "Finally, roll 3D6 + 3 for Edu. ";
            Rules += "Your stats are simply 5 times the corresponding attribute. ";
            Rules += "The system will calculate the value of other statistics. ";
            Rules += "You will be granted 20 times your education score to spend in your professionnal occupation. ";
            Rules += "As per your personal interest skill, you will receive 10 times your intelligence score to spend. ";
            #endregion
        }

        public bool HasName(string name)
        {
            return name.ToLower() == Name.ToLower();
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

        public bool ValidateCreation(Character newbie)
        {
            bool isLegit = true;

            #region VALIDATE SKILLS POINTS
            int persInterest = newbie.SpendablePoints.FirstOrDefault(s => s.Name == "Personal interest skill points").BaseValue;
            if (persInterest > 180)
                return false;

            int occupInterest = newbie.SpendablePoints.FirstOrDefault(s => s.Name == "Occupation skill points").BaseValue;
            if (occupInterest > 480)
                return false;

            //ensure points are up to date in profession
            SetCareerSkills(newbie);
            foreach (var aSkill in newbie.Profession.JobSkills)
            {
                occupInterest -= (aSkill.CurrentValue - aSkill.Minimum);
            }

            if (occupInterest < 0)
                return false;


            foreach (var ask in newbie.Skills)
            {
                if (!newbie.Profession.JobSkills.Any(x => x.Name.ToLower() == ask.Name.ToLower()))
                    persInterest -= (ask.CurrentValue - ask.Minimum);
            }
            if (persInterest < 0)
                return false;

            #endregion

            return isLegit;
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

        public void SetupCharacter(Character target)
        {
            target.GameName = Name;
            target.BaseAttributes = BaseAttributes.Select(b => new Caracteristic(b)).ToList();
            target.SpendablePoints = SpendablePoints.Select(sp => new Caracteristic(sp)).ToList();
            target.Skills = Skills.Select(s => new Caracteristic(s)).ToList();
            target.Stats = Stats.Select(s => new Caracteristic(s)).ToList();
        }

        public void RandomlySetBaseAttr(Character target)
        {

            Random r = new Random();

            foreach (var baseAttr in BaseAttributes)
            {
                Caracteristic current = target.BaseAttributes.FirstOrDefault(b => b.Equals(baseAttr));
                current.BaseValue = r.Next(3, current.Maximum + 1);

                if (current.Name == "size" || current.Name == "intelligence" || current.Name == "education")
                    current.BaseValue += 6;


                current.CurrentValue = current.BaseValue;
            }
        }

        public void SetCareerSkills(Character target)
        {
            var prof = Professions.FirstOrDefault(x => x.Name.ToLower() == target.Profession.Name.ToLower());

            if (prof == null)
                target.Profession = Professions.FirstOrDefault(x => x.Name == "mendiant");

            foreach (var sk in target.Profession.JobSkills)
            {
                sk.CurrentValue = sk.BaseValue = target.Skills.FirstOrDefault(x => x.Name.ToLower() == sk.Name.ToLower()).CurrentValue;
            }
        }

        public void SetDefaultSpendablePoints(Character target)
        {
            //hp = const + size / 2
            target.SpendablePoints.FirstOrDefault(s => s.Name.ToLower() == "health points").BaseValue =
                   (target.BaseAttributes.FirstOrDefault(b => b.Name.ToLower() == "constitution").BaseValue +
                   target.BaseAttributes.FirstOrDefault(b => b.Name.ToLower() == "size").BaseValue) / 2;

            target.SpendablePoints.FirstOrDefault(s => s.Name == "wound limit").BaseValue = target.SpendablePoints.FirstOrDefault(s => s.Name.ToLower() == "health points").BaseValue / 2;
            target.SpendablePoints.FirstOrDefault(s => s.Name == "magic points").BaseValue = target.BaseAttributes.FirstOrDefault(b => b.Name.ToLower() == "power").BaseValue;
            target.SpendablePoints.FirstOrDefault(s => s.Name == "Occupation skill points").BaseValue = target.BaseAttributes.FirstOrDefault(b => b.Name.ToLower() == "education").BaseValue * 20;
            target.SpendablePoints.FirstOrDefault(s => s.Name == "Personal interest skill points").BaseValue = target.BaseAttributes.FirstOrDefault(b => b.Name.ToLower() == "intelligence").BaseValue * 10;


            foreach (var sp in target.SpendablePoints)
            {
                sp.CurrentValue = sp.BaseValue;
            }
        }

        public void SetDefaultSkills(Character target)
        {
            foreach (var askill in target.Skills)
            {
                askill.BaseValue = askill.CurrentValue = askill.Minimum;
            }

            //foreach (var aSkill in Skills)
            //{
            //    Caracteristic current = target.Skills.FirstOrDefault(s => s.Name.ToLower() == aSkill.Name.ToLower());
            //    current.BaseValue = current.CurrentValue = current.Minimum;
            //}
        }

        public void SetChosenSkills(List<CaracteristicViewModel> premadeSkills, Character target)
        {
            var occupationSkill = target.SpendablePoints.FirstOrDefault(x => x.Name == "Occupation skill points");
            var personalSkill = target.SpendablePoints.FirstOrDefault(x => x.Name == "Personal interest skill points");

            var maxOccupationAllocation = occupationSkill.BaseValue;
            var maxPersonnalAllocation = personalSkill.BaseValue;

            var totalOccupationSpent = 0;
            var totalPersonnalSpent = 0;

            //create a temporary list to manipulate.
            var tempList = target.Skills.ConvertAll(x => new Caracteristic(x));

            foreach (var s in premadeSkills)
            {
                s.Score = Math.Abs(s.Score);

                //get targetSkill and it's minimum value
                var tempSkill = tempList.FirstOrDefault(x => x.Name.ToLower() == s.Name.ToLower());
                var min = tempSkill.Minimum;

                if (s.Score < min)
                    s.Score = min;
                if (s.Score < tempSkill.CurrentValue)
                    s.Score = tempSkill.CurrentValue;

                //check how much was spent in the skills
                var spent = s.Score - min;

                //remove that amount from pool
                if (IsJobSkill(tempSkill, target.Profession))
                    totalOccupationSpent += spent;
                else
                    totalPersonnalSpent += spent;

                //assign value
                tempSkill.CurrentValue = s.Score;
            }

            //If not too many points were assigned
            if(totalOccupationSpent <= maxOccupationAllocation &&
                totalPersonnalSpent <= maxPersonnalAllocation)
            {
                foreach (var s in target.Skills)
                {
                    s.Setvalue(tempList.SingleOrDefault(x => x.Equals(s)).CurrentValue);
                }
                occupationSkill.CurrentValue = occupationSkill.BaseValue - totalOccupationSpent;
                personalSkill.CurrentValue = personalSkill.BaseValue - totalPersonnalSpent;
            }

        }

        public bool IsJobSkill(Caracteristic skill, Career job)
        {
            return job.JobSkills.Any(s => s.Equals(skill));
        }

        public void SetDefaultStats(Character target)
        {
            target.Stats.FirstOrDefault(s => s.Name == "prestance").BaseValue = target.BaseAttributes.FirstOrDefault(b => b.Name == "appearance").BaseValue * 5;
            target.Stats.FirstOrDefault(s => s.Name == "endurance").BaseValue = target.BaseAttributes.FirstOrDefault(b => b.Name == "constitution").BaseValue * 5;
            target.Stats.FirstOrDefault(s => s.Name == "brawl power").BaseValue = target.BaseAttributes.FirstOrDefault(b => b.Name == "strength").BaseValue * 5;
            target.Stats.FirstOrDefault(s => s.Name == "agility").BaseValue = target.BaseAttributes.FirstOrDefault(b => b.Name == "dexterity").BaseValue * 5;
            target.Stats.FirstOrDefault(s => s.Name == "will power").BaseValue = target.BaseAttributes.FirstOrDefault(b => b.Name == "power").BaseValue * 5;
            target.Stats.FirstOrDefault(s => s.Name == "height").BaseValue = target.BaseAttributes.FirstOrDefault(b => b.Name == "size").BaseValue * 5;
            target.Stats.FirstOrDefault(s => s.Name == "knowledge").BaseValue = target.BaseAttributes.FirstOrDefault(b => b.Name == "education").BaseValue * 5;
            target.Stats.FirstOrDefault(s => s.Name == "idea").BaseValue = target.BaseAttributes.FirstOrDefault(b => b.Name == "intelligence").BaseValue * 5;

            target.Stats.FirstOrDefault(s => s.Name == "sanity").BaseValue = target.BaseAttributes.FirstOrDefault(b => b.Name == "power").BaseValue * 5;

            foreach (var item in target.Stats)
            {
                item.CurrentValue = item.BaseValue;
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
        }
    }
}
