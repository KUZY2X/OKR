using System;
using System.Windows.Forms;

namespace TeamBuilding
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            if (slideB.Left == 360)
            {
                bunifuSeparator1.Left = bunifuThinButton22.Left;
                bunifuSeparator1.Width = bunifuThinButton22.Width;

                bunifuTransition1.HideSync(slideA);
                slideA.Left = 360;

                slideB.Visible = false;
                slideB.Left = 10;

                bunifuTransition1.ShowSync(slideB);
            }
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (slideA.Left == 360)
            {
                bunifuSeparator1.Left = bunifuThinButton21.Left;
                bunifuSeparator1.Width = bunifuThinButton21.Width;

                bunifuTransition1.HideSync(slideB);
                slideB.Left = 360;

                slideA.Visible = false;
                slideA.Left = 10;

                bunifuTransition1.ShowSync(slideA);
            }
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            Hide();
            form2.Show();
        }

        private void bunifuThinButton26_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            Hide();
            form2.Show();
        }
    }
}