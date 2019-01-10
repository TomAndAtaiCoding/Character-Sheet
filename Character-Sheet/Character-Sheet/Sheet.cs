using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.String;

namespace Character_Sheet
{
    public partial class Sheet : Form
    {
        public Sheet()
        {
            InitializeComponent();
        }
        Character character =  Globals.CurrentCharacter;

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void SetAcbutton_Click(object sender, EventArgs e)
        {
            string l_Armour = "";
            string[] ChangeNameArr = { "Head", "Chest", "Stomach", "Right Hand", "Left Hand", "Right Foot", "Left Foot" };
            int[] ArmourArray = { character.HeadArmourBonus, character.GetAimedHead(), character.StomachArmourBonus,
                character.GetAimedStomach(), character.RightHandArmourBonus, character.GetAimedRightHand(),
                character.LeftHandArmourBonus, character.GetAimedLeftHand(), character.RightFootArmourBonus,
                character.GetAimedRightfoot(), character.LeftFootArmourBonus, character.GetAimedLeftFoot() };
            int ArmourCounter = 0;
            if (int.Parse(HeadArmourBox.Text) != character.HeadArmourBonus)
                for(int i = 0;i<7;i++)
                {
                    if(i%2==0)
                        l_Armour += Format("{0} Armour Bonus: {1} --> {2}\n", ChangeNameArr[ArmourCounter], ArmourArray[ArmourCounter], HeadArmourBox.Text);
                    else:
                        l_Armour += Format("Aimed {0} Armour: {1} --> {2}\n", ChangeNameArr[ArmourCounter], ArmourArray[ArmourCounter], ( Character. 5*int.Parse(HeadArmourBox.Text)));

                }
            DialogResult l_Ans = MessageBox.Show(String.Format("Are you sure you want to change your Armour Class? to preview the changes:\n{0)"));
            /* I don't need to do exercies to understand what is taught. At best I need them to remember it.
             * And for that pourpose just rereading it ten miutes before a test is honestly equivalent.
             * Also, regardless, it is litreally INSANE to expect anyone to do homework while at a SCHOOL activity
             * which leaves them with roughly 2 hours a day at max to bth do homeworl=k an have their free time. 
             */
        }
        
    }
}
