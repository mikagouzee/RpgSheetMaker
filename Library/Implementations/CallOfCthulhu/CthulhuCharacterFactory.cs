using Library.CommonObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Implementations.CallOfCthulhu
{
    public class CthulhuCharacterFactory : CharacterFactory
    {
        public CthulhuCharacterFactory()
        {
            FactoryName = "CallOfCthulhu";
            Professions = new List<Career>();
        }

        public override bool HasName(string name)
        {
            return name == FactoryName;
        }

        public override Character CreateCharacter(string name)
        {
            if (string.IsNullOrEmpty(name))
                name = "Will Notbenamed";

            var charac = new Character(name);

            SetBaseAttr(charac);
            SetSpendablePoints(charac);
            SetSkills(charac);
            SetStats(charac);
            SetCareerSkills(charac);

            return charac;
        }

        public override void SetBaseAttr(Character charac)
        {
            Caracteristic appearance = new Caracteristic("appearance", 18);
            Caracteristic constitution = new Caracteristic("constitution", 18);
            Caracteristic strength = new Caracteristic("strength", 18);
            Caracteristic dexterity = new Caracteristic("dexterity", 18);
            Caracteristic power = new Caracteristic("power", 18);
            Caracteristic size = new Caracteristic("size", 18);
            Caracteristic intelligence = new Caracteristic("intelligence", 18);
            Caracteristic education = new Caracteristic("education", 24);

            charac.BaseAttributes.Add(appearance);
            charac.BaseAttributes.Add(constitution);
            charac.BaseAttributes.Add(strength);
            charac.BaseAttributes.Add(dexterity);
            charac.BaseAttributes.Add(power);
            charac.BaseAttributes.Add(size);
            charac.BaseAttributes.Add(intelligence);
            charac.BaseAttributes.Add(education);

            Random r = new Random();

            foreach (var batr in charac.BaseAttributes)
            {
                batr.BaseValue = r.Next(3, batr.Maximum + 1);

                if (batr.Name == "size" || batr.Name == "intelligence" || batr.Name == "education")
                    batr.BaseValue += 6;
            }
            
        }

        public override void SetCareerSkills(Character charac)
        {
            throw new NotImplementedException();
        }

        public override void SetSkills(Character charac)
        {
            Caracteristic art = new Caracteristic("art", 100, 5);
            Caracteristic artisanat = new Caracteristic("artisanat", 100, 5);
            Caracteristic baratin = new Caracteristic("baratin", 100, 5);
            Caracteristic bibliotheque = new Caracteristic("bibliotheque", 100, 5);
            Caracteristic comptabilite = new Caracteristic("comptabilite", 100, 10);
            Caracteristic concocterPotion = new Caracteristic("concocter potion", 100, 1);
            Caracteristic conduireAttelage = new Caracteristic("conduire attelage", 100, 20);
            Caracteristic coupDePied = new Caracteristic("coup de pied", 100, 25);
            Caracteristic coupDePoing = new Caracteristic("coup de poing", 100, 50);
            Caracteristic coupDeTete = new Caracteristic("coup de tete", 100, 10);
            Caracteristic discretion = new Caracteristic("discretion", 100, 10);
            Caracteristic dissimulation = new Caracteristic("dissimulation", 100, 15);
            Caracteristic ecouter = new Caracteristic("ecouter", 100, 25);
            Caracteristic ecrireUneLangue = new Caracteristic("ecrire une langue", 100, 1);
            Caracteristic esquiver = new Caracteristic("esquiver", 100, 5);
            Caracteristic grimper = new Caracteristic("grimper", 100, 40);
            Caracteristic lancer = new Caracteristic("lancer", 100, 25);
            Caracteristic langueEtrangere = new Caracteristic("langue etrangere", 100, 1);
            Caracteristic langueNatale = new Caracteristic("langue natale", 100, 5);
            Caracteristic lutte = new Caracteristic("lutte", 100, 25);
            Caracteristic marchandage = new Caracteristic("marchandage", 100, 5);
            Caracteristic mondeNaturel = new Caracteristic("monde naturel", 100, 10);
            Caracteristic monterACheval = new Caracteristic("monter a cheval", 100, 5);
            Caracteristic mytheDeCthulhu = new Caracteristic("mythe de Cthulhu", 100, 0);
            Caracteristic nager = new Caracteristic("nager", 100, 25);
            Caracteristic navigation = new Caracteristic("navigation", 100, 10);
            Caracteristic occultisme = new Caracteristic("occultisme", 100, 5);
            Caracteristic persuasion = new Caracteristic("persuasion", 100, 15);
            Caracteristic piloterBateau = new Caracteristic("piloter bateau", 100, 1);
            Caracteristic premiersSoins = new Caracteristic("premiers soins", 100, 30);
            Caracteristic reparerConcevoir = new Caracteristic("reparer concevoir", 100, 20);
            Caracteristic royaumeNatal = new Caracteristic("royaume natal", 100, 20);
            Caracteristic royaumesEtrangers = new Caracteristic("royaumes etrangers", 100, 1);
            Caracteristic sagacite = new Caracteristic("sagacite", 100, 5);
            Caracteristic sauter = new Caracteristic("sauter", 100, 25);
            Caracteristic science = new Caracteristic("science", 100, 1);
            Caracteristic se_cacher = new Caracteristic("se cacher", 100, 10);
            Caracteristic statut = new Caracteristic("statut", 100, 15);
            Caracteristic suivrePiste = new Caracteristic("suivre une piste", 100, 10);
            Caracteristic trouverObjetCache = new Caracteristic("trouver objet cache", 100, 25);

            charac.Skills.Add(art);
            charac.Skills.Add(artisanat);
            charac.Skills.Add(baratin);
            charac.Skills.Add(bibliotheque);
            charac.Skills.Add(comptabilite);
            charac.Skills.Add(concocterPotion);
            charac.Skills.Add(conduireAttelage);
            charac.Skills.Add(coupDePied);
            charac.Skills.Add(coupDePoing);
            charac.Skills.Add(coupDeTete);
            charac.Skills.Add(discretion);
            charac.Skills.Add(dissimulation);
            charac.Skills.Add(ecouter);
            charac.Skills.Add(ecrireUneLangue);
            charac.Skills.Add(esquiver);
            charac.Skills.Add(grimper);
            charac.Skills.Add(lancer);
            charac.Skills.Add(langueEtrangere);
            charac.Skills.Add(langueNatale);
            charac.Skills.Add(lutte);
            charac.Skills.Add(marchandage);
            charac.Skills.Add(mondeNaturel);
            charac.Skills.Add(monterACheval);
            charac.Skills.Add(mytheDeCthulhu);
            charac.Skills.Add(nager);
            charac.Skills.Add(navigation);
            charac.Skills.Add(occultisme);
            charac.Skills.Add(persuasion);
            charac.Skills.Add(piloterBateau);
            charac.Skills.Add(premiersSoins);
            charac.Skills.Add(reparerConcevoir);
            charac.Skills.Add(royaumeNatal);
            charac.Skills.Add(royaumesEtrangers);
            charac.Skills.Add(sagacite);
            charac.Skills.Add(sauter);
            charac.Skills.Add(science);
            charac.Skills.Add(se_cacher);
            charac.Skills.Add(statut);
            charac.Skills.Add(suivrePiste);
            charac.Skills.Add(trouverObjetCache);

            #region gameCareers
            Career artisan = new Career("artisan");
            artisan.JobSkills.Add(baratin);
            artisan.JobSkills.Add(marchandage);
            artisan.JobSkills.Add(mondeNaturel);
            artisan.JobSkills.Add(royaumeNatal);
            artisan.JobSkills.Add(sagacite);
            artisan.JobSkills.Add(statut);
            this.Professions.Add(artisan);

            Career clerc = new Career("clerc");
            clerc.JobSkills.Add(bibliotheque);
            clerc.JobSkills.Add(langueEtrangere);
            clerc.JobSkills.Add(persuasion);
            clerc.JobSkills.Add(royaumeNatal);
            clerc.JobSkills.Add(statut);
            clerc.JobSkills.Add(ecrireUneLangue);
            this.Professions.Add(clerc);

            Career ermite = new Career("ermite");
            ermite.JobSkills.Add(mondeNaturel);
            ermite.JobSkills.Add(occultisme);
            ermite.JobSkills.Add(persuasion);
            ermite.JobSkills.Add(sagacite);
            ermite.JobSkills.Add(sagacite);
            ermite.JobSkills.Add(se_cacher);
            ermite.JobSkills.Add(trouverObjetCache);
            ermite.JobSkills.Add(ecouter);
            this.Professions.Add(ermite);

            Career erudit = new Career("erudit");
            erudit.JobSkills.Add(bibliotheque);
            erudit.JobSkills.Add(ecrireUneLangue);
            erudit.JobSkills.Add(persuasion);
            erudit.JobSkills.Add(royaumeNatal);
            erudit.JobSkills.Add(science);
            erudit.JobSkills.Add(statut);
            this.Professions.Add(erudit);

            Career fermier = new Career("fermier");
            fermier.JobSkills.Add(artisanat);
            fermier.JobSkills.Add(conduireAttelage);
            fermier.JobSkills.Add(ecouter);
            fermier.JobSkills.Add(marchandage);
            fermier.JobSkills.Add(mondeNaturel);
            fermier.JobSkills.Add(suivrePiste);
            this.Professions.Add(fermier);

            Career forestier = new Career("forestier");
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
            this.Professions.Add(forestier);

            Career garde = new Career("garde");
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
            this.Professions.Add(garde);

            Career guerisseur = new Career("guerisseur");
            guerisseur.JobSkills.Add(concocterPotion);
            guerisseur.JobSkills.Add(mondeNaturel);
            guerisseur.JobSkills.Add(occultisme);
            guerisseur.JobSkills.Add(premiersSoins);
            guerisseur.JobSkills.Add(sagacite);
            guerisseur.JobSkills.Add(trouverObjetCache);
            guerisseur.JobSkills.Add(ecouter);
            this.Professions.Add(guerisseur);

            Career marchand = new Career("marchand");
            marchand.JobSkills.Add(baratin);
            marchand.JobSkills.Add(conduireAttelage);
            marchand.JobSkills.Add(langueEtrangere);
            marchand.JobSkills.Add(marchandage);
            marchand.JobSkills.Add(navigation);
            marchand.JobSkills.Add(royaumeNatal);
            marchand.JobSkills.Add(sagacite);
            this.Professions.Add(marchand);

            Career menestrel = new Career("menestrel");
            menestrel.JobSkills.Add(art);
            menestrel.JobSkills.Add(baratin);
            menestrel.JobSkills.Add(marchandage);
            menestrel.JobSkills.Add(persuasion);
            menestrel.JobSkills.Add(royaumeNatal);
            menestrel.JobSkills.Add(sagacite);
            this.Professions.Add(menestrel);

            Career marin = new Career("marin");
            marin.JobSkills.Add(baratin);
            marin.JobSkills.Add(grimper);
            marin.JobSkills.Add(mondeNaturel);
            marin.JobSkills.Add(navigation);
            marin.JobSkills.Add(piloterBateau);
            marin.JobSkills.Add(royaumesEtrangers);
            this.Professions.Add(marin);

            Career mendiant = new Career("mendiant");
            mendiant.JobSkills.Add(baratin);
            mendiant.JobSkills.Add(dissimulation);
            mendiant.JobSkills.Add(marchandage);
            mendiant.JobSkills.Add(sagacite);
            mendiant.JobSkills.Add(ecouter);
            mendiant.JobSkills.Add(trouverObjetCache);
            this.Professions.Add(mendiant);

            Career moine = new Career("moine");
            moine.JobSkills.Add(art);
            moine.JobSkills.Add(bibliotheque);
            moine.JobSkills.Add(ecouter);
            moine.JobSkills.Add(ecrireUneLangue);
            moine.JobSkills.Add(langueEtrangere);
            moine.JobSkills.Add(occultisme);
            this.Professions.Add(moine);

            Career negociant = new Career("negociant");
            negociant.JobSkills.Add(baratin);
            negociant.JobSkills.Add(comptabilite);
            negociant.JobSkills.Add(ecrireUneLangue);
            negociant.JobSkills.Add(langueEtrangere);
            negociant.JobSkills.Add(marchandage);
            negociant.JobSkills.Add(royaumesEtrangers);
            negociant.JobSkills.Add(royaumeNatal);
            this.Professions.Add(negociant);

            Career pelerin = new Career("pelerin");
            pelerin.JobSkills.Add(discretion);
            pelerin.JobSkills.Add(marchandage);
            pelerin.JobSkills.Add(mondeNaturel);
            pelerin.JobSkills.Add(navigation);
            pelerin.JobSkills.Add(royaumeNatal);
            this.Professions.Add(pelerin);

            Career pretre = new Career("pretre");
            pretre.JobSkills.Add(baratin);
            pretre.JobSkills.Add(langueEtrangere);
            pretre.JobSkills.Add(occultisme);
            pretre.JobSkills.Add(persuasion);
            pretre.JobSkills.Add(sagacite);
            pretre.JobSkills.Add(statut);
            this.Professions.Add(pretre);

            Career sergent = new Career("sergent");
            sergent.JobSkills.Add(baratin);
            sergent.JobSkills.Add(discretion);
            sergent.JobSkills.Add(marchandage);
            sergent.JobSkills.Add(sagacite);
            sergent.JobSkills.Add(statut);
            sergent.JobSkills.Add(trouverObjetCache);
            this.Professions.Add(sergent);

            Career serviteur = new Career("serviteur");
            serviteur.JobSkills.Add(artisanat);
            serviteur.JobSkills.Add(baratin);
            serviteur.JobSkills.Add(discretion);
            serviteur.JobSkills.Add(dissimulation);
            serviteur.JobSkills.Add(ecouter);
            serviteur.JobSkills.Add(trouverObjetCache);
            this.Professions.Add(serviteur);

            #endregion

        }

        public override void SetSpendablePoints(Character charac)
        {
            Caracteristic healthPoints = new Caracteristic("health points", 18);
            Caracteristic woundLimit = new Caracteristic("wound limit", 9);
            Caracteristic magicPoints = new Caracteristic("magic points", 18);
            Caracteristic occupationSkillPoints = new Caracteristic("Occupation skill points", 480);
            Caracteristic personalInterestSkillPoints = new Caracteristic("Personal interest skill points", 180);

            charac.SpendablePoints.Add(healthPoints);
            charac.SpendablePoints.Add(woundLimit);
            charac.SpendablePoints.Add(magicPoints);
            charac.SpendablePoints.Add(occupationSkillPoints);
            charac.SpendablePoints.Add(personalInterestSkillPoints);

            charac.SpendablePoints.FirstOrDefault(s => s.Name == "health points").BaseValue =
                   (charac.BaseAttributes.FirstOrDefault(b => b.Name == "constitution").BaseValue +
                   charac.BaseAttributes.FirstOrDefault(b => b.Name == "size").BaseValue)/ 2;

            charac.SpendablePoints.FirstOrDefault(s => s.Name == "wound limit").BaseValue = charac.SpendablePoints.FirstOrDefault(s => s.Name == "health points").BaseValue / 2;
            charac.SpendablePoints.FirstOrDefault(s => s.Name == "magic points").BaseValue = charac.BaseAttributes.FirstOrDefault(b => b.Name == "power").BaseValue;
            charac.SpendablePoints.FirstOrDefault(s => s.Name == "Occupation skill points").BaseValue = charac.BaseAttributes.FirstOrDefault(b => b.Name == "education").BaseValue * 20;
            charac.SpendablePoints.FirstOrDefault(s => s.Name == "Personal interest skill points").BaseValue = charac.BaseAttributes.FirstOrDefault(b => b.Name == "intelligence").BaseValue * 10;

        }

        public override void SetStats(Character charac)
        {
            Caracteristic prestance = new Caracteristic("prestance", 90);
            Caracteristic endurance = new Caracteristic("endurance", 90);
            Caracteristic agility = new Caracteristic("agility", 90);
            Caracteristic brawlpower = new Caracteristic("brawl power", 90);
            Caracteristic height = new Caracteristic("height", 90);
            Caracteristic knowledge = new Caracteristic("knowledge", 120);
            Caracteristic idea = new Caracteristic("idea", 90);
            Caracteristic willpower = new Caracteristic("will power", 90);
            Caracteristic sanity = new Caracteristic("sanity", 90);

            charac.Stats.Add(prestance);
            charac.Stats.Add(endurance);
            charac.Stats.Add(agility);
            charac.Stats.Add(brawlpower);
            charac.Stats.Add(height);
            charac.Stats.Add(knowledge);
            charac.Stats.Add(idea);
            charac.Stats.Add(willpower);
            charac.Stats.Add(sanity);

            charac.Stats.FirstOrDefault(s => s.Name == "prestance").BaseValue = charac.BaseAttributes.FirstOrDefault(b => b.Name == "appearance").BaseValue * 5;
            charac.Stats.FirstOrDefault(s => s.Name == "endurance").BaseValue = charac.BaseAttributes.FirstOrDefault(b => b.Name == "constitution").BaseValue * 5;
            charac.Stats.FirstOrDefault(s => s.Name == "agility").BaseValue = charac.BaseAttributes.FirstOrDefault(b => b.Name == "dexterity").BaseValue * 5;
            charac.Stats.FirstOrDefault(s => s.Name == "brawl power").BaseValue = charac.BaseAttributes.FirstOrDefault(b => b.Name == "strength").BaseValue * 5;
            charac.Stats.FirstOrDefault(s => s.Name == "height").BaseValue = charac.BaseAttributes.FirstOrDefault(b => b.Name == "size").BaseValue * 5;
            charac.Stats.FirstOrDefault(s => s.Name == "knowledge").BaseValue = charac.BaseAttributes.FirstOrDefault(b => b.Name == "education").BaseValue * 5;
            charac.Stats.FirstOrDefault(s => s.Name == "idea").BaseValue = charac.BaseAttributes.FirstOrDefault(b => b.Name == "intelligence").BaseValue * 5;
            charac.Stats.FirstOrDefault(s => s.Name == "will power").BaseValue = charac.BaseAttributes.FirstOrDefault(b => b.Name == "power").BaseValue * 5;
            charac.Stats.FirstOrDefault(s => s.Name == "sanity").BaseValue = charac.BaseAttributes.FirstOrDefault(b => b.Name == "power").BaseValue * 5;
        }
    }
}
