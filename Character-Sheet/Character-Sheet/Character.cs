using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Convert;

namespace Character_Sheet
{
    public class Character
    {
        //Basic Details:
        public string name;
        public string PlayerName;
        public int age;
        public bool RightHanded;
        public int height;
        public int weight;
        public string nationality;
        public string CityOfBirth;
        public string race;

        //AC
        private const int kBaseArmour = 50;
        private int AC;
        private const int kHandBaseArmour = 80;
        private int RightHandArmour;
        private int LeftHandArmour;
        private const int kLegBaseArmour = 70;
        private int RightFootArmour;
        private int LeftFootArmour;
        private const int kStomachBaseValue = 65;
        private const int kChestBaseArmour = 65;
        private int ChestArmour;
        private int StomachAC;
        private const int kHeadBaseArmour = 130;
        private int HeadAArmour;
        private bool EvenDisributAC;

        //Strength:
        private int Strength = new IntVariable();
        private bool ExceptionalStrength = false;
        public int EighteenStrengthPercentile; //For characters with Exceptional Strength.
        private int StrengthHitBonus;
        private int StrengthDamageBonus;
        private int DoorOpeningChance;
        private int MagcDoorOpening;
        private int BarBend;

        private void CalaculateStrengthHitBonus()
        {
            int l_Val = Strength.Value;
            if (l_Val == 1)
                StrengthHitBonus = -25;
            else if (l_Val == 2 || l_Val == 3)
                StrengthHitBonus = -15;
            else if (l_Val == 4 || l_Val == 5)
                StrengthHitBonus = -10;
            else if (l_Val == 6 || l_Val == 7)
                StrengthHitBonus = -5;
            else if (l_Val > 7 && l_Val < 17)
                StrengthHitBonus = 0;
            else if (l_Val == 17 || l_Val == 18 && !Potentials.Keys.Contains<string>("fighting"))
                StrengthHitBonus = 1;
            else if (l_Val == 18 && Potentials.Keys.Contains<string>("Fighting"))
            {
                int l_Per = EighteenStrengthPercentile;
                if (l_Per >= 1 && l_Per <= 50)
                    StrengthHitBonus = 1;
                else if (l_Per != 100)
                    StrengthHitBonus = 2;
                else
                    StrengthHitBonus = 3;
            }

        }
        private void CalculateStrengthDamageBonus()
        {
            int l_Val = Strength.Value;
            if (l_Val == 1)
                StrengthDamageBonus = -4;
            else if (l_Val == 2)
                StrengthDamageBonus = -2;
            else if (l_Val == 4 || l_Val == 3 || l_Val == 5)
                StrengthDamageBonus = -1;
            else if (l_Val >= 6 && l_Val <= 16)
                StrengthDamageBonus = 0;
            else if (l_Val == 17)
                StrengthDamageBonus = 1;
            else if (l_Val == 18 && !Potentials["Fighting"])
                StrengthDamageBonus = 2;
            else if (l_Val == 18 && Potentials["Fighting"])
            {
                int l_Per = EighteenStrengthPercentile;
                if (l_Per >= 1 && l_Per <= 75)
                    StrengthDamageBonus = 3;
                else if (l_Per > 75 && l_Per <= 90)
                    StrengthDamageBonus = 4;
                else if (l_Per > 90 && l_Per != 100)
                    StrengthDamageBonus = 5;
                else
                    StrengthDamageBonus = 6;
            }
        }
        private void CalculateOpenDoors()
        {
            int l_Val = Strength.Value;
            if (l_Val == 1 || l_Val == 2)
                DoorOpeningChance = 1;
            else if (l_Val == 3)
                DoorOpeningChance = 2;
            else if (l_Val == 4 || l_Val == 5)
                DoorOpeningChance = 3;
            else if (l_Val == 6 || l_Val == 7)
                DoorOpeningChance = 4;
            else if (l_Val == 8 || l_Val == 9)
                DoorOpeningChance = 5;
            else if (l_Val == 10 || l_Val == 11)
                DoorOpeningChance = 6;
            else if (l_Val == 12 || l_Val == 13)
                DoorOpeningChance = 7;
            else if (l_Val == 14 || l_Val == 15)
                DoorOpeningChance = 8;
            else if (l_Val == 16)
                DoorOpeningChance = 9;
            else if (l_Val == 17)
                DoorOpeningChance = 10;
            else if (l_Val == 18 && !ExceptionalStrength)
                DoorOpeningChance = 11;
            else if (ExceptionalStrength)
            {
                int l_Per = EighteenStrengthPercentile;
                if (l_Per >= 1 && l_Per <= 50)
                    DoorOpeningChance = 12;
                if (l_Per > 50 && l_Per <= 75)
                    DoorOpeningChance = 13;
                else if (l_Per > 75 && l_Per <= 90)
                    DoorOpeningChance = 14;
                else if (l_Per > 90 && l_Per != 100)
                {
                    DoorOpeningChance = 15;
                    MagcDoorOpening = 3;
                }
                else
                {
                    DoorOpeningChance = 16;
                    MagcDoorOpening = 6;
                }
            }
        }
        private void CalaculateBarBending()
        {

            int l_Val = Strength.Value;
            if (l_Val < 8)
                BarBend = 0;
            else if (l_Val == 8 || l_Val == 9)
                BarBend = 1;
            else if (l_Val == 10 || l_Val == 11)
                BarBend = 2;
            else if (l_Val == 12 || l_Val == 13)
                BarBend = 4;
            else if (l_Val == 14 || l_Val == 15)
                BarBend = 7;
            else if (l_Val == 16)
                BarBend = 10;
            else if (l_Val == 17)
                BarBend = 13;
            else if (l_Val == 18 && !ExceptionalStrength)
                BarBend = 16;
            else if (ExceptionalStrength)
            {
                int l_Per = EighteenStrengthPercentile;
                if (l_Per >= 1 && l_Per <= 50)
                    BarBend = 20;
                if (l_Per > 50 && l_Per <= 75)
                    BarBend = 25;
                else if (l_Per > 75 && l_Per <= 90)
                    BarBend = 30;
                else if (l_Per > 90 && l_Per != 100)
                {
                    BarBend = 35;
                }
                else
                {
                    BarBend = 40;
                }
            }
        }

        //Dexterity
        private int Dexterity;
        public int ArmourDexBonus;
        public int DexInitiative;
        public int DexProjectileBonus;
        public int SneakySkillsDexBonus;
        private void CalculateArmourDexBonus()
        {
            int l_Val = Dexterity;

            if (l_Val == 1 || l_Val == 2)
                ArmourDexBonus = -25;
            else if (l_Val == 3)
                ArmourDexBonus = -20;
            else if (l_Val == 4)
                ArmourDexBonus = -15;
            else if (l_Val == 5)
                ArmourDexBonus = -10;
            else if (l_Val == 6)
                ArmourDexBonus = -5;
            else if (l_Val >= 7 && l_Val < 15)
                ArmourDexBonus = 0;
            else if (l_Val == 15)
                ArmourDexBonus = 5;
            else if (l_Val == 16)
                ArmourDexBonus = 10;
            else if (l_Val == 17)
                ArmourDexBonus = 15;
            else if (l_Val > 17 && l_Val < 21)
                ArmourDexBonus = 20;
            else if (l_Val > 20 && l_Val < 25)
                ArmourDexBonus = 25;
            else if (l_Val == 25)
                ArmourDexBonus = 30;
        }
        private void CalculateDexInitiative()
        {
            int l_Val = Dexterity;
            if (l_Val == 1)
                DexInitiative = -6;
            else if (l_Val == 2)
                DexInitiative = -4;
            else if (l_Val == 3)
                DexInitiative = -3;
            else if (l_Val == 4)
                DexInitiative = -2;
            else if (l_Val == 5)
                DexInitiative = -1;
            else if (l_Val >= 6 && l_Val < 16)
                DexInitiative = 0;
            else if (l_Val == 16)
                DexInitiative = 1;
            else if (l_Val == 17 || l_Val == 18)
                DexInitiative = 2;
            else if (l_Val == 19 || l_Val == 20)
                DexInitiative = 3;
            else if (l_Val > 20 && l_Val < 24)
                DexInitiative = 4;
            else if (l_Val == 24 || l_Val == 25)
                DexInitiative = 5;
        }
        private void CalculateDexProjectileBonus()
        {
            int l_Val = Dexterity;
            if (l_Val == 1)
                DexProjectileBonus = -30;
            else if (l_Val == 2)
                DexProjectileBonus = -20;
            else if (l_Val == 3)
                DexProjectileBonus = -15;
            else if (l_Val == 4)
                DexProjectileBonus = -10;
            else if (l_Val == 5)
                DexProjectileBonus = -5;
            else if (l_Val >= 6 && l_Val < 16)
                DexProjectileBonus = 0;
            else if (l_Val == 16)
                DexProjectileBonus = 5;
            else if (l_Val == 17 || l_Val == 18)
                DexProjectileBonus = 10;
            else if (l_Val == 19 || l_Val == 20)
                DexProjectileBonus = 15;
            else if (l_Val > 20 && l_Val < 24)
                DexProjectileBonus = 20;
            else if (l_Val == 24 || l_Val == 25)
                DexProjectileBonus = 25;
        }
        private void CalculateSneakySkillsDexBonus()
        {
            int l_Val = Dexterity;
            if (l_Val == 3)
                SneakySkillsDexBonus = -90;
            else if (l_Val == 4)
                SneakySkillsDexBonus = -60;
            else if (l_Val == 5)
                SneakySkillsDexBonus = -50;
            else if (l_Val == 6)
                SneakySkillsDexBonus = -30;
            else if (l_Val == 7)
                SneakySkillsDexBonus = -20;
            else if (l_Val == 8)
                SneakySkillsDexBonus = -10;
            else if (l_Val == 9)
                SneakySkillsDexBonus = -5;
            else if (l_Val > 9 && l_Val < 14)
                SneakySkillsDexBonus = 0;
            else if (l_Val == 14)
                SneakySkillsDexBonus = 3;
            else if (l_Val == 15)
                SneakySkillsDexBonus = 5;
            else if (l_Val == 16)
                SneakySkillsDexBonus = 10;
            else if (l_Val == 17)
                SneakySkillsDexBonus = 12;
            else if (l_Val == 18)
                SneakySkillsDexBonus = 15;
            else if (l_Val == 19)
                SneakySkillsDexBonus = 20;
        }

        //Endurance
        private int Endurance;
        public int HPInitbonus;
        public int SystemShock;
        public int ResurretionSurvival;
        public int EndurancePoisonSaveBonus;

        private void CalculateHPInitBonus() { }
        private void CalculateSystemShock() { }
        private void CalculaaResurrectionSurvival() { }
        private void CalculateEnduranceSaveBonus() { }

        private int Intelligence;
        private int Perception;
        private Dictionary<string, bool> Potentials = new Dictionary<string, bool>()
        {
            {"Fighting", false},
            {"Priesthood", false},
            {"Magic", false }
        };


        private bool AttributeValid(int NewAttributeValue, out int Attribute)
        {
            if (NewAttributeValue > 3 && NewAttributeValue < 18)
            {
                Attribute.Value = NewAttributeValue;
                return true;
            }
            else
            {
                MessageBox.Show("Attributes must be between 3 and 18.\nPlease insert another value.", "Invalid value!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        public void SetStength(int str)
        {
            if (AttributeValid(str, out Strength) == true)
            {
                if(Strength.Value>=18 && Potentials["Fighting"] && !ExceptionalStrength)
                {
                    ExceptionalStrength = true;
                    Globals.CurrentCharacter = this;
                    EighteenStrengthWarior l_Dialog = new EighteenStrengthWarior();
                    l_Dialog.ShowDialog();
                }
                CalaculateStrengthHitBonus();
                CalculateStrengthDamageBonus();
                CalculateOpenDoors();
                CalaculateBarBending();

            }
        }
        public int GetStrength()
        {
            return Strength;
        }
        public void SetDexterity(int dex)
        {
            if(AttributeValid(dex, out Dexterity))
            {
                CalculateArmourDexBonus();
                CalculateDexInitiative();
                CalculateDexProjectileBonus();
                CalculateSneakySkillsDexBonus();
            }
        }
        public int GetDexterity()
        {
            return Dexterity;
        }
        public void  SetEndurace(int end)
        {
            AttributeValid(end, out Endurance);
        }
        public int GetEndurance()
        {
            return Endurance;
        }
        public void SetIntelligence(int Int)
        {
            AttributeValid(Int, out Intelligence);
        }
        public int GetIntelligence()
        {
            return Intelligence;
        }
        public void SetPerception(int per)
        {
            AttributeValid(per, out Perception);
        }
        public int GetPerception()
        {
            return Perception;
        }

        private int CurHP;
        private int MaxHP;
        private int hpd;
        private int AllXP;
        private int CurXP;
        public void SetMaxHP(int maxhp)
        {
            if(maxhp>0)
            {
                MaxHP = maxhp;
            }
            else
            {
                MessageBox.Show("Maximum HP must be positive!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
