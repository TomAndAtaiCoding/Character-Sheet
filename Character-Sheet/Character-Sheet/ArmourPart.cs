using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Character_Sheet
{
    /// <summary>
    /// This is a class for Armour parts. <para /> Generally, there are eight parts of the body which have a unique armour class - 
    /// head, chest, stomach, right hand, left hand, right foot and left foot. 
    /// the sum of all of their values combined with the base armour, creates the general and main AC. <para />
    /// For each part, there is also an aimed value, which is the armour class needed to be surpassed in order to hit it in an aimed strike.
    /// this is calculated as the base value of the parts plus five times their armour value. <para />
    /// This class is mainly used for setting the AC on the sheet and so has current and new value members.
    /// </summary>
    class ArmourPart
    {
        /// <summary>
        /// The string name part of the body this armour part protects.
        /// </summary>
        public string Part;
        /// <summary>
        /// the base value of the part. There are unique base values for head, chest and stimach, hands and legs, which are
        /// kept in the nested ArmourPart class BaseValues.
        /// </summary>
        public int Base;
        /// <summary>
        /// The value this part currently has.
        /// </summary>
        public int CurrentValue;
        /// <summary>
        /// The value requested to set - in the Sheet, this is the value in the apropriate TextBox when the set button is pressed
        /// </summary>
        public int NewValue;
        /// <summary>
        /// The aimed armour value calculated from the current value.
        /// </summary>
        public int CurrentAimedValue;
        /// <summary>
        /// The aimed value calculated from the new armour bonus.
        /// </summary>
        public int NewAimedValue;
        private static int counter = 0;

        /// <summary>
        /// The constuctor for the ArmopurPart class. <para />
        /// Sets the members by the parameters given and add the parts and their vlaues to the apropriate arrays in globals,
        /// for easy access between classes and forms.
        /// </summary>
        /// <param name="Part"> The name of the body part this armour part protects - 
        /// usually ead, chest, stomach, right hand, left hand, right foot or left foot. </param>
        /// <param name="Base"> The base armour class value of this part. This can be taken from the base value nested class of ArmourPart,
        /// but if this is a homebrewed version, be costume. </param>
        /// <param name="CurrentValue">The value the armour part has now, probably taken from a Character object.</param>
        /// <param name="NewValue"> A value to be set. Probably taken from an apropriate </param>
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

        public static class BaseValues
        {
            public const int kBaseArmour = 50,
                kHeadBaseArmour = 130,
                kChestBaseArmour = 65,
                kStomachBaseArmour = 65,
                kHandBaseArmour = 80,
                kLegBaseArmour = 70;
        }


    }
}
