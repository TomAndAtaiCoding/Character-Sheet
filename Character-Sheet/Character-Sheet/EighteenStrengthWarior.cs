using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Character_Sheet
{
    public partial class EighteenStrengthWarior : Form
    {
        public EighteenStrengthWarior()
        {
            InitializeComponent();
        }

        bool RngRoll = true;
        bool IsValid(string str)

        {
            foreach (char c in str)
            {
                if (!char.IsDigit(c))
                    return false;
            }

            if (str == "")
                return false;

            return true;
        }

        private void FinishButton_Click(object sender, EventArgs e)
        {
            if(RngRoll)
            {
                Random rnd = new Random();
                int Result = rnd.Next(1, 101);
                Globals.CurrentCharacter.EighteenStrengthPercentile = Result;
                MessageBox.Show("Your Result was...\n{0}!", Convert.ToString(Result));
                this.Close();
            }

            else
            {
                string Result = RollBox.Text;
                if (!IsValid(Result))
                {
                    MessageBox.Show("Please Write a Number!","You did not write a number!",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }
                else
                {
                    Globals.CurrentCharacter.EighteenStrengthPercentile = int.Parse(Result);
                    this.Close();
                }
            }
        }
        private void RNGRollCheck_CheckedChanged(object sender, EventArgs e)
        {
            RngRoll = !(RngRoll);
            RollBox.Enabled = !(RollBox.Enabled);
        }
    }
}
