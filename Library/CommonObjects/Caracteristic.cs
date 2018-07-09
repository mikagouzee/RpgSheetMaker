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
        public int CurrentValue { get { return BaseValue + TempBonus; } set { } }
        public int BaseValue { get; set; }
        public string Name { get; set; }
        public int TempBonus { get; set; }

        public Caracteristic()
        {
            TempBonus = 0;
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

        public bool Validate()
        {
            return (CurrentValue <= Maximum && CurrentValue >= Minimum);
        }

        public void Setvalue(int newValue)
        {
            var before = CurrentValue;

            CurrentValue = newValue;

            if (!Validate())
                CurrentValue = before;
        }
    }
}
