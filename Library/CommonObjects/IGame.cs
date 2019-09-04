using Library.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.CommonObjects
{
    public interface IGame
    {
        bool HasName(string name);

        GameViewModel ToViewModel();

        void SetupCharacter(Character target);
        void SetCareer(Character target, string careerName);

        void SetSpecies(Character target, string speciesName);

        void RandomlySetBaseAttr(Character target);
        void SetCareerSkills(Character target);
        void SetDefaultSpendablePoints(Character target);
        void SetDefaultSkills(Character target);
        void SetDefaultStats(Character target);
        void SetCaracteristicFromCaracteristicViewModel(List<Caracteristic> resultList, List<CaracteristicViewModel> premadeList);

        void SetChosenSkills(List<CaracteristicViewModel> premadeSkills, Character target);


        List<Career> GetCareers();

        bool ValidateCreation(Character target);


    }
}
