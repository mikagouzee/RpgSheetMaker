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
            if (Maximum < Minimum)
                Maximum = Minimum + 1;
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

        public Caracteristic(Caracteristic other)
        {
            Name = other.Name;
            Minimum = other.Minimum;
            Maximum = other.Maximum;
            CurrentValue = other.CurrentValue;
            BaseValue = other.BaseValue;
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

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Caracteristic);
        }

        public bool Equals(Caracteristic carac)
        {
            if (object.ReferenceEquals(carac, null))
                return false;

            if (object.ReferenceEquals(this, carac))
                return true;

            if (this.GetType() != carac.GetType())
                return false;

            return this.Name.ToLower() == carac.Name.ToLower();
        }

    }
}
