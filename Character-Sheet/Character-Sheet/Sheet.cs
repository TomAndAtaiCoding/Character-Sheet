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
            Globals.HpPercenteBar = HPPercentBar;
        }

        private void SetAcbutton_Click(object sender, EventArgs e)
        {
            string l_Armour = "";
            ArmourPart
                HeadArmour = new ArmourPart("Head", Character.kHeadBaseArmour, character.HeadArmourBonus, int.Parse(HeadArmourBox.Text)),
                ChestArmour = new ArmourPart("Chest", Character.kChestBaseArmour, character.ChestArmourBonus, int.Parse(ChestArmourBox.Text)),
                StomachArmour = new ArmourPart("Stomach", Character.kStomachBaseArmour, character.StomachArmourBonus, int.Parse(StomachArmourBox.Text)),
                RightHandArmour = new ArmourPart("Right Hand", Character.kHandBaseArmour, character.RightHandArmourBonus, int.Parse(RHandArmourBox.Text)),
                LeftHandArmour = new ArmourPart("Left Hand", Character.kHandBaseArmour, character.LeftHandArmourBonus, int.Parse(LHandArmourBox.Text)),
                RightFootArmour = new ArmourPart("Right Foot", Character.kLegBaseArmour, character.RightFootArmourBonus, int.Parse(RLegArmourBox.Text)),
                LeftFootArmour = new ArmourPart("Left Foot", Character.kLegBaseArmour, character.LeftFootArmourBonus, int.Parse(LLegArmourBox.Text));

            l_Armour += Format("General Armour: {0} --> {1}", character.GetAC(), Globals.NewArmourBonuses.Sum());
            foreach (ArmourPart armourPart in Globals.CurrentArmourParts)
            {
                if (armourPart.HasDifference())
                {
                    l_Armour += Format("{0} Armour Bonus: {1} --> {2}\n", armourPart.Part, armourPart.CurrentValue, armourPart.CurrentAimedValue);
                    l_Armour += Format("Aimed {0} Armour: {1} --> {2}\n", armourPart.Part, armourPart.CurrentAimedValue, armourPart.NewAimedValue);
                }
            }
            
            DialogResult l_Ans = MessageBox.Show(Format("Are you sure you want to change your Armour Class? to preview the changes:\n{0)", l_Armour), "Are You  Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(l_Ans == DialogResult.Yes)
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

        private void SetHPButton_Click(object sender, EventArgs e)
        {
            HPTab HPTab = new HPTab();
            HPTab.Show();
            this.Hide();
        }
    }
}
