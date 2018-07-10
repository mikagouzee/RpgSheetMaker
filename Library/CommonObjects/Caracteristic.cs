using Library.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.CommonObjects
{
    public class Caracteristic
    {
        public int Minimum { get; set; }
        public int Maximum { get; set; }
        public int CurrentValue { get; set; }
        public int BaseValue { get; set; }
        public string Name { get; set; }

        public Caracteristic()
        {
        }

        public Caracteristic(string name)
            : this()
        {
            Name = name;
        }

        public Caracteristic(string name, int min)
            : this(name)
        {
            Minimum = min;
        }

        public Caracteristic(string name, int min, int max)
            : this(name, min)
        {
            if (max < min)
                max = min;

            Maximum = max;
        }

        public Caracteristic(string name, int min, int max, int baseValue)
            : this(name, min, max)
        {
            BaseValue = (baseValue <= max && baseValue >= min) ?
                baseValue :
                min;
            CurrentValue = BaseValue;
        }

        #region notused
        public void Increment()
        {
            if (!(CurrentValue >= Maximum))
                CurrentValue++;
        }

        public void Decrement()
        {
            if (!(CurrentValue <= Minimum))
                CurrentValue--;
        }
        #endregion

        public bool Validate(int stressValue)
        {
            return (stressValue <= Maximum && stressValue >= Minimum);
        }

        public void Setvalue(int newValue)
        {
            if (Validate(newValue))
                CurrentValue = newValue;
        }
    }
}
