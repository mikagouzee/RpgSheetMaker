using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.CommonObjects
{
    public class Species
    {
        public string Name { get; set; }
        public List<KeyValuePair<Caracteristic, int>> Modificators { get; set; }

        public void ApplyModificators(List<Caracteristic> caracs)
        {
            foreach (var aCarac in caracs)
            {
                if (Modificators.Any(x => x.Key.Equals(aCarac)))
                {
                    aCarac.BaseValue += Modificators.FirstOrDefault(x => x.Key.Equals(aCarac)).Value;
                    aCarac.CurrentValue += Modificators.FirstOrDefault(x => x.Key.Equals(aCarac)).Value;
                    aCarac.Maximum += Modificators.FirstOrDefault(x => x.Key.Equals(aCarac)).Value;
                    aCarac.Minimum += Modificators.FirstOrDefault(x => x.Key.Equals(aCarac)).Value;
                    if (aCarac.Minimum < 0)
                        aCarac.Minimum = 1;
                }
            }
        }
    }
}
