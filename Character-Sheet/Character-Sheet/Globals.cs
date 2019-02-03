using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Character_Sheet
{
    static class Globals
    {
        public static Character CurrentCharacter; //For refrencing the current character with forms prompted from the class methos themselves.
        public static ProgressBar HpPercenteBar;
        public static ArmourPart[] CurrentArmourParts = new ArmourPart[7];
        public static int[] NewArmourBonuses = new int[7];
        public static int HPAmount;
    }
}
