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
            Globals.HpPercenteBar = HPPercentBar; //Passes the current Hp Percentage Bar to globals, where Character will be able to use it.
        }

        private void SetAcbutton_Click(object sender, EventArgs e) //Asks for confirmation and if confirmed changes all armour bonuses by their apropriate textBox
        {
            string l_ChangesText = ""; //This is the text that will be in the message asking for confirmation.
            /*Creates an apropriate ArmourPart variable for every armour part, (taking new values from their proper textboxes), which are added to Globals.CurrentArmourParts in constructions,
             together with their new values to Globals.NewArmourBonuses*/
            ArmourPart
                HeadArmour = new ArmourPart("Head", Character.kHeadBaseArmour, character.HeadArmourBonus, int.Parse(HeadArmourBox.Text)),
                ChestArmour = new ArmourPart("Chest", Character.kChestBaseArmour, character.ChestArmourBonus, int.Parse(ChestArmourBox.Text)),
                StomachArmour = new ArmourPart("Stomach", Character.kStomachBaseArmour, character.StomachArmourBonus, int.Parse(StomachArmourBox.Text)),
                RightHandArmour = new ArmourPart("Right Hand", Character.kHandBaseArmour, character.RightHandArmourBonus, int.Parse(RHandArmourBox.Text)),
                LeftHandArmour = new ArmourPart("Left Hand", Character.kHandBaseArmour, character.LeftHandArmourBonus, int.Parse(LHandArmourBox.Text)),
                RightFootArmour = new ArmourPart("Right Foot", Character.kLegBaseArmour, character.RightFootArmourBonus, int.Parse(RLegArmourBox.Text)),
                LeftFootArmour = new ArmourPart("Left Foot", Character.kLegBaseArmour, character.LeftFootArmourBonus, int.Parse(LLegArmourBox.Text));

            l_ChangesText += Format("General Armour: {0} --> {1}", character.GetAC(), Globals.NewArmourBonuses.Sum()); //Adds the change to general armour to the message.
            foreach (ArmourPart armourPart in Globals.CurrentArmourParts) //Iterates through the armour parts.
            {
                if (armourPart.HasDifference()) //Checks if the value from the textbox is different from the current vaklue, and if not, adds the changes to the message.
                {
                    l_ChangesText += Format("{0} Armour Bonus: {1} --> {2}\n", armourPart.Part, armourPart.CurrentValue, armourPart.CurrentAimedValue);
                    l_ChangesText += Format("Aimed {0} Armour: {1} --> {2}\n", armourPart.Part, armourPart.CurrentAimedValue, armourPart.NewAimedValue);
                }
            }
            
            DialogResult l_Ans = MessageBox.Show(Format("Are you sure you want to change your Armour Class? to preview the changes:\n{0)", l_ChangesText), "Are You  Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning); //The message asking for confirmation

            if (l_Ans == DialogResult.Yes) //If the confirmation is given, set the value apropriatly.
            {
                character.HeadArmourBonus = HeadArmour.NewValue;
                character.ChestArmourBonus = ChestArmour.NewValue;
                character.StomachArmourBonus = StomachArmour.NewValue;
                character.RightHandArmourBonus = RightHandArmour.NewValue;
                character.LeftHandArmourBonus = LeftHandArmour.NewValue;
                character.RightFootArmourBonus = RightFootArmour.NewValue;
                character.LeftFootArmourBonus = LeftFootArmour.NewValue;
                character.SetArmour();
            }
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();

        }
    }
}
