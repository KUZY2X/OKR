using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace teamdevelopment
{
    public partial class Info : Form
    {
        public Info(People people)
        {
            InitializeComponent();
            pictureBox1.Image = people.Image;
            label1.Text = people.Name;
            richTextBox1.Text = $"Age: {people.Age}\nActivities: {people.Activities}";
        }
        private void Info_Load(object sender, EventArgs e)
        {

        }
    }
}
