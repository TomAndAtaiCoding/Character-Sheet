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
        Random HPRoll = new Random();

        public HPTab()
        {
            InitializeComponent();
        }

        private void RemoveHP_Click(object sender, EventArgs e)
        {

        }

        private void AddHP_Click(object sender, EventArgs e)
        {

        }

        private void AddMaxHP_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = true;
            textBox2.ReadOnly = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int ActualRoll = HPRoll.Next(1, 5);
            textBox3.Text = Convert.ToString(ActualRoll);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
