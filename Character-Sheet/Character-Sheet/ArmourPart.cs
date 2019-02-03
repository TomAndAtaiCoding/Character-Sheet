using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Character_Sheet
{
    class ArmourPart
    {
        public string Part;
        public int Base;
        public int CurrentValue;
        public int NewValue;
        public int CurrentAimedValue;
        public int NewAimedValue;
        private static int counter = 0;

        public ArmourPart(string Part, int Base, int CurrentValue, int NewValue)
        {
            this.Part = Part;
            this.Base = Base;
            this.CurrentValue = CurrentValue;
            this.NewValue = NewValue;
            CurrentAimedValue = Base + 5 * CurrentValue;
            NewAimedValue = Base + 5 * NewValue;
            Globals.CurrentArmourParts[counter] = this;
            Globals.NewArmourBonuses[counter] = NewValue;
            counter++;
            if (counter > 7)
                counter = 0;
        }

        public bool HasDifference()
        {
            return CurrentValue != NewValue;
        }


    }
}
