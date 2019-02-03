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
    public partial class HPTab : Form
    {
        public HPTab()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e) //When finish button is clicked this asks the user if he/she is sure that they want to finish. They answer no, it doesn't do anything. answer yes, show the main sheet and close this one.
        {
            DialogResult finishOrNot = MessageBox.Show("Are you sure you're finished?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (finishOrNot == DialogResult.Yes)
            {
                Globals.HPAmount = int.Parse(textBox1.Text);
                Sheet mainSheet = new Sheet();
                mainSheet.Show();
                this.Hide();
            }
        }
    }
}
