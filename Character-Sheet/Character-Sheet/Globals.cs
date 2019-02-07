using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Character_Sheet
{
    static class Globals //This class is mainly used to pass variables between classes - for the character code to get the controls from the current sheet, and so on.
    {
        //--------------------Aiders--------------------

        public static Character CurrentCharacter; //For refrencing the current character with forms prompted from the class methos themselves.

        //----------Character----------
        public static ProgressBar HpPercenteBar; //For refrencing the HP Percent Bar in the character.cs methods - SetHP()

        //--------Sheet----------
        public static ArmourPart[] CurrentArmourParts = new ArmourPart[7]; //For the SetACButton - the Armour parts just add themselves in construction, so you don't need to create another array. and initilize the values.
        public static int[] NewArmourBonuses = new int[7]; //Also for the SetACButton - same thing. ArmourParts add their NewValue value here in construction.

    }
}
