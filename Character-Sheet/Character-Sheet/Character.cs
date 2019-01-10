using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Convert;
using static System.Random;

namespace Character_Sheet
{

    /// <summary>
    /// 
    /// </summary>
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

        //Base Armours
        public const int
            kBaseArmour = 50,
            kHeadBaseArmour = 130,
            kChestBaseArmour = 65,
            kStomachBaseValue = 65,
            kHandBaseArmour = 80,
            kLegBaseArmour = 70;
        public int[] ArmourConstArray = { kHeadBaseArmour, kChestBaseArmour, kStomachBaseValue, kHandBaseArmour, kLegBaseArmour };

        //Armour Bonuss
        public int
            LeftHandArmourBonus,
            RightHandArmourBonus,
            ChestArmourBonus,
            StomachArmourBonus,
            HeadArmourBonus,
            RightFootArmourBonus,
            LeftFootArmourBonus;

        //Aimed and  General Armour
        private int
            AC,
            AimedHeadArmour,
            AimedChestArmour,
            AimedStomachArmour,
            AimedLeftHandArmour,
            AimedRightHandArmour,
            AimedLeftFootArmour,
            AimedRightFootArmour;

        public bool EvenDisributAC;


        public void SetArmour()
        {
            AC = kBaseArmour + HeadArmourBonus + ChestArmourBonus + StomachArmourBonus + RightHandArmourBonus +
                LeftHandArmourBonus + RightFootArmourBonus + LeftFootArmourBonus;
            AimedHeadArmour = kHeadBaseArmour + 5 * HeadArmourBonus;
            AimedChestArmour = kChestBaseArmour + 5 * ChestArmourBonus;
            AimedStomachArmour = kStomachBaseValue + 5 * StomachArmourBonus;
            AimedRightHandArmour = kHandBaseArmour + 5 * RightHandArmourBonus;
            AimedLeftHandArmour = kHandBaseArmour + 5 * LeftHandArmourBonus;
            AimedRightFootArmour = kLegBaseArmour + 5 * RightFootArmourBonus;
            AimedLeftHandArmour = kLegBaseArmour + 5 * LeftFootArmourBonus;

        }
        public int GetAC()
        {
            return AC;
        }
        public int GetAimedHead()
        {
            return AimedHeadArmour;
        }
        public int getAimedChest()
        {
            return AimedChestArmour;
        }
        public int GetAimedStomach()
        {
            return AimedStomachArmour;
        }
        public int GetAimedRightHand()
        {
            return AimedRightHandArmour;
        }
        public int GetAimedLeftHand()
        {
            return AimedLeftHandArmour;
        }
        public int GetAimedRightfoot()
        {
            return AimedRightFootArmour;
        }
        public int GetAimedLeftFoot()
        {
            return AimedLeftFootArmour;
        }

        //Strength:
        private int Strength;
        private bool ExceptionalStrength = false;
        public int EighteenStrengthPercentile; //For characters with Exceptional Strength.
        private int StrengthHitBonus;
        private int StrengthDamageBonus;
        private int DoorOpeningChance;
        private int MagcDoorOpening;
        private int BarBend;

        private void CalaculateStrengthHitBonus()
        {
            int l_Val = Strength;
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
            int l_Val = Strength;
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
            int l_Val = Strength;
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

            int l_Val = Strength;
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
        private void CalculateHPInitBonus()
        {
            int l_Val = Endurance;
            if (l_Val == 3)
                HPInitbonus = -5;
            else if (l_Val == 4)
                HPInitbonus = -4;
            else if (l_Val == 5)
                HPInitbonus = -2;
            else if (l_Val == 6)
                HPInitbonus = -1;
            else if (l_Val > 6 && l_Val < 12)
                HPInitbonus = 0;
            else if (l_Val == 12)
                HPInitbonus = 2;
            else if (l_Val == 13)
                HPInitbonus = 3;
            else if (l_Val == 14)
                HPInitbonus = 5;
            else if (l_Val == 15)
                HPInitbonus = 7;
            else if(Potentials["Fighting"])
            {
                if (l_Val == 16)
                    HPInitbonus = 9;
                else if (l_Val == 17)
                    HPInitbonus = 12;
                else if (l_Val == 18)
                    HPInitbonus = 15;
                else if (l_Val == 19)
                    HPInitbonus = 17;
            }
            else
            {

                if (l_Val == 16)
                    HPInitbonus = 8;
                else if (l_Val == 17)
                    HPInitbonus = 10;
                else if (l_Val == 18)
                    HPInitbonus = 11;
                else if (l_Val == 19)
                    HPInitbonus = 12;
            }

        }
        private void CalculateSystemShock()
        {
            int l_Val = Endurance;
            if (l_Val == 1)
                SystemShock = 25;
            else if (l_Val == 2)
                SystemShock = 30;
            else if (l_Val == 3)
                SystemShock = 35;
            else if (l_Val == 4)
                SystemShock = 40;
            else if (l_Val == 5)
                SystemShock = 45;
            else if (l_Val == 6)
                SystemShock = 50;
            else if (l_Val == 7)
                SystemShock = 55;
            else if (l_Val == 8)
                SystemShock = 60;
            else if (l_Val == 9)
                SystemShock = 65;
            else if (l_Val == 10)
                SystemShock = 70;
            else if (l_Val == 11)
                SystemShock = 75;
            else if (l_Val == 12)
                SystemShock = 80;
            else if (l_Val == 13)
                SystemShock = 85;
            else if (l_Val == 14)
                SystemShock = 88;
            else if (l_Val == 15)
                SystemShock = 90;
            else if (l_Val == 16)
                SystemShock = 95;
            else if (l_Val == 17)
                SystemShock = 97;
            else if (l_Val == 18)
                SystemShock = 99;
            else if (l_Val == 19)
                SystemShock = 99;
        }
        private void CalculateResurrectionSurvival()
        {
            int l_Val = Endurance;
            if (l_Val == 1)
                ResurretionSurvival = 30;
            else if (l_Val == 2)
                ResurretionSurvival = 35;
            else if (l_Val == 3)
                ResurretionSurvival = 40;
            else if (l_Val == 4)
                ResurretionSurvival = 45;
            else if (l_Val == 5)
                ResurretionSurvival = 50;
            else if (l_Val == 6)
                ResurretionSurvival = 55;
            else if (l_Val == 7)
                ResurretionSurvival = 60;
            else if (l_Val == 8)
                ResurretionSurvival = 65;
            else if (l_Val == 9)
                ResurretionSurvival = 70;
            else if (l_Val == 10)
                ResurretionSurvival = 75;
            else if (l_Val == 11)
                ResurretionSurvival = 80;
            else if (l_Val == 12)
                ResurretionSurvival = 85;
            else if (l_Val == 13)
                ResurretionSurvival = 90;
            else if (l_Val == 14)
                ResurretionSurvival = 92;
            else if (l_Val == 15)
                ResurretionSurvival = 94;
            else if (l_Val == 16)
                ResurretionSurvival = 96;
            else if (l_Val == 17)
                ResurretionSurvival = 98;
            else if (l_Val == 18 || l_Val == 19)
                ResurretionSurvival = 100;
        }


        //Intelligence
        private int Intelligence;
        public int XpInitBonus;
        public int XpCostMultiplayer;
        public int ManaBonus;
        public int LearnSpellChance;
        private void CalculateXpInitBonus()
        {
            int l_Val = Intelligence;
            if (l_Val == 1)
                XpInitBonus = 0;
            else if (l_Val>=2 && l_Val<=8)
                XpInitBonus = 300;
            else if (l_Val >= 9 && l_Val<=11)
                XpInitBonus = 600;
            else if (l_Val == 12 || l_Val==13)
                XpInitBonus = 900;
            else if (l_Val == 14 || l_Val == 15)
                XpInitBonus = 1200;
            else if (l_Val == 16)
                XpInitBonus = 1500;
            else if (l_Val == 17)
                XpInitBonus = 1800;
            else if (l_Val == 18)
                XpInitBonus = 2100;
            else if (l_Val == 19)
                XpInitBonus = 2400;
        }
        private void CalculateXpCostChange()
        {
            int l_Val = Intelligence;
            if (l_Val == 1)
                XpCostMultiplayer = 20;
            else if (l_Val == 2)
                XpCostMultiplayer = 15;
            else if (l_Val == 3)
                XpCostMultiplayer = 10;
            else if (l_Val == 4)
                XpCostMultiplayer = 5;
            else if (l_Val >= 5 && l_Val < 15)
                XpCostMultiplayer = 0;
            else if (l_Val == 15)
                XpCostMultiplayer = -2;
            else if (l_Val == 16)
                XpCostMultiplayer = -5;
            else if (l_Val == 17)
                XpCostMultiplayer = -10;
            else if (l_Val == 18)
                XpCostMultiplayer = -15;
            else if (l_Val == 19)
                XpCostMultiplayer = -20;
        }
        private void CalculateManaBonus()
        {
            int l_Val = Intelligence;
            if (l_Val < 15)
                ManaBonus = 0;
            else if (true) { }
        }
        private void CalculateLearnSpellChance() { }


        private int Perception;
        private Dictionary<string, bool> Potentials = new Dictionary<string, bool>()
        {
            {"Fighting", false},
            {"Priesthood", false},
            {"Magic", false }
        };


        private bool AttributeValid(int NewAttributeValue, ref int Attribute)
        {
            if (NewAttributeValue > 3 && NewAttributeValue < 18)
            {
                Attribute = NewAttributeValue;
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
            if (AttributeValid(str, ref Strength) == true)
            {
                if(Strength>=18 && Potentials["Fighting"] && !ExceptionalStrength)
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
            if(AttributeValid(dex, ref Dexterity))
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
            AttributeValid(end, ref Endurance);
            CalculateHPInitBonus();
            CalculateResurrectionSurvival();
            CalculateSystemShock();
        }
        public int GetEndurance()
        {
            return Endurance;
        }
        public void SetIntelligence(int Int)
        {
            AttributeValid(Int, ref Intelligence);
        }
        public int GetIntelligence()
        {
            return Intelligence;
        }
        public void SetPerception(int per)
        {
            AttributeValid(per, ref Perception);
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
