using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TeamBuilding
{
    public partial class Form2 : Form
    {
        private readonly List<Dictionary<string, Color>> _templates = new List<Dictionary<string, Color>>();
        public static UserControl _currentControl;
        public static UserControl _projectControl;
        private readonly int _currentTemplate = 0;

        public Form2()
        {
            InitializeComponent();

            loader.Dock = DockStyle.Fill;

            var template = new Dictionary<string, Color>
            {
                {"bottomleft", Color.FromArgb(39, 50, 56)},
                {"bottomright", Color.FromArgb(39, 50, 56)},
                {"topleft", Color.FromArgb(39, 50, 56)},
                {"topright", Color.FromArgb(39, 50, 56)}
            };

            projectListTab1.ShowProjects();

            _templates.Add(template);
            projectListTab1.Visible = true;
            _currentControl = projectListTab1;
            Loading();

            LoadTemplate(_templates[_currentTemplate]);
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            try
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

            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        public void LoadTemplate(Dictionary<string, Color> theme)
        {
            bunifuGradientPanel1.GradientBottomLeft = theme["bottomleft"];
            bunifuGradientPanel1.GradientBottomRight = theme["bottomright"];
            bunifuGradientPanel1.GradientTopLeft = theme["topleft"];
            bunifuGradientPanel1.GradientTopRight = theme["topright"];  
        }

        public void Loading()
        {
            try
            {
                _currentControl.Hide();
                loader.Visible = true;
                var random = new Random();
                timer1.Interval = random.Next(0, 1500);
                timer1.Start();
            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                timer1.Stop();
                loader.Visible = false;
                _currentControl.Show();
            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            try
            {
                _currentControl.Visible = false;
                projectListTab1.Controls.Clear();
                projectListTab1.ShowProjects();
                projectListTab1.Visible = true;
                _currentControl = projectListTab1;
                Loading();
                projectListTab1.Counter = 0;
            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            try
            {
                _currentControl.Visible = false;
                categoriesTab1.Controls.Clear();
                categoriesTab1.FillButtons(475, 85);
                categoriesTab1.FillButtons(475, 235);
                categoriesTab1.FillButtons(475, 385);
                categoriesTab1.FillButtons(475, 535);
                categoriesTab1.FillButtons(475, 685);
                categoriesTab1.Visible = true;
                _currentControl = categoriesTab1;
                Loading();
                categoriesTab1.Counter = 0;
            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }

        private void bunifuFlatButton2_Click_1(object sender, EventArgs e)
        {
            try
            {
                _currentControl.Visible = false;
                activityTab1.LoadProjects(Form1.SelectedUser - 1);
                activityTab1.Visible = true;
                _currentControl = activityTab1;
                Loading();
            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            try
            {
                _currentControl.Visible = false;
                searchTab1.Visible = true;
                _currentControl = searchTab1;
                Loading();
            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            try
            {
                _currentControl.Visible = false;
                ProjectTab.Instance.Visible = false;
                profileTab1.LoadUserData(Form1.SelectedUser - 1);
                profileTab1.Visible = true;
                _currentControl = profileTab1;
                Loading();
            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            var r = new Random();

            var template = new Dictionary<string, Color>
            {
                {"bottomleft", Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255))},
                {"bottomright", Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255))},
                {"topleft", Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255))},
                {"topright", Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255))}
            };


            LoadTemplate(template);

            _templates.Add(template);
        }
    }
}