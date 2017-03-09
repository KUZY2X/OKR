using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TeamBuilding
{
    public partial class Form2 : Form
    {
        List<Dictionary<string, Color>> templates = new List<Dictionary<string, Color>>();
        public UserControl currentControl;

        public Form2()
        {
            InitializeComponent();

            loader.Dock = DockStyle.Fill;

            var template = new Dictionary<string, Color>();

            template.Add("bottomleft", Color.FromArgb(39, 50, 56));
            template.Add("bottomright", Color.FromArgb(39, 50, 56));
            template.Add("topleft", Color.FromArgb(39, 50, 56));
            template.Add("topright", Color.FromArgb(39, 50, 56));

            templates.Add(template);
            projectTab1.Visible = true;
            currentControl = projectTab1;
            Loading();

            LoadTemplate(templates[currentTemplate]);
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            if (bunifuGradientPanel1.Width == 200)
            {
                bunifuTransition2.Hide(pictureBox1);
                bunifuCustomLabel1.Visible = false;   
                bunifuGradientPanel1.Visible = false;
                bunifuGradientPanel1.Width = 50;
                bunifuTransition1.ShowSync(bunifuGradientPanel1);
                bunifuImageButton1.Location = new Point(10, 5);
            }
            else
            {      
                bunifuGradientPanel1.Visible = false;
                bunifuImageButton1.Location = new Point(165, 5);
                bunifuGradientPanel1.Width = 200;
                bunifuTransition1.ShowSync(bunifuGradientPanel1);
                bunifuTransition2.ShowSync(pictureBox1);
                bunifuCustomLabel1.Visible = true;
            }
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        int currentTemplate = 0;

        public void LoadTemplate(Dictionary<string, Color> theme)
        {
            bunifuGradientPanel1.GradientBottomLeft = theme["bottomleft"];
            bunifuGradientPanel1.GradientBottomRight = theme["bottomright"];
            bunifuGradientPanel1.GradientTopLeft = theme["topleft"];
            bunifuGradientPanel1.GradientTopRight = theme["topright"];  
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            Random r = new Random();

            Dictionary<string, Color> template = new Dictionary<string, Color>();

            template.Add("bottomleft", Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255)));
            template.Add("bottomright", Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255)));
            template.Add("topleft", Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255)));
            template.Add("topright", Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255)));

            LoadTemplate(template);

            templates.Add(template);
        }

        public void Loading()
        {
            currentControl.Hide();
            loader.Visible = true;
            var random = new Random();
            timer1.Interval = random.Next(0, 1500);
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            loader.Visible = false;
            currentControl.Show();
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            currentControl.Visible = false;
            projectTab1.Visible = true;
            currentControl = projectTab1;
            Loading();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            currentControl.Visible = false;
            categoriesTab1.Visible = true;
            currentControl = categoriesTab1;
            Loading();
        }

        private void bunifuFlatButton2_Click_1(object sender, EventArgs e)
        {
            currentControl.Visible = false;
            activityTab1.Visible = true;
            currentControl = activityTab1;
            Loading();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            currentControl.Visible = false;
            searchTab1.Visible = true;
            currentControl = searchTab1;
            Loading();
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            currentControl.Visible = false;
            profileTab1.Visible = true;
            currentControl = profileTab1;
            Loading();
        }
    }
}