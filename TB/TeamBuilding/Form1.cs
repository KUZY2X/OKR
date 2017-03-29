using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Net.Mail;
using System.Windows.Forms;

namespace TeamBuilding
{
    public partial class Form1 : Form
    {
        private const int MinimalLength = 6;
        private const int MaximalLength = 15;
        public static int SelectedUser;

        public Form1()
        {
            InitializeComponent();  
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            try
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

            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            try
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

            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
                Environment.Exit(0);
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            var teamBuildingEntities = new TeamBuildingEntities1();
            var usersList = new ObservableCollection<Users>(teamBuildingEntities.Users);

            try
            {
                if (!bunifuCustomLabel6.Visible && !bunifuCustomLabel9.Visible && !bunifuCustomLabel10.Visible
                    && bunifuMetroTextbox1.Text != "" && bunifuMetroTextbox2.Text != "" && bunifuMetroTextbox3.Text != "")
                {
                    Users user = new Users
                    {
                        UsrId = teamBuildingEntities.Users.Count() + 1,
                        Name = bunifuMetroTextbox1.Text,
                        RegMail = bunifuMetroTextbox2.Text,
                        Password = bunifuMetroTextbox3.Text,
                        PicturePath = "0.jpg",
                        Registered = DateTime.Now
                    };

                    teamBuildingEntities.Users.Add(user);
                    teamBuildingEntities.SaveChanges();
                    SelectedUser = user.UsrId;

                    MessageBox.Show("Sueccussfully registered");

                    var form2 = new Form2();
                    Hide();
                    form2.Show();
                }
                else
                {
                    MessageBox.Show("Something is wrong");
                }
            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }

        private void bunifuThinButton26_Click(object sender, EventArgs e)
        {
            var teamBuildingEntities = new TeamBuildingEntities1();
            bool sueccessfullLogin = false;

            try
            {
                foreach (Users user in teamBuildingEntities.Users)
                {
                    if (bunifuMetroTextbox5.Text == user.RegMail && bunifuMetroTextbox4.Text == user.Password)
                    {
                        SelectedUser = user.UsrId;
                        sueccessfullLogin = true;
                        var form2 = new Form2();
                        Hide();
                        form2.Show();
                    }
                }

                if (!sueccessfullLogin)
                    MessageBox.Show("No such account found");
            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }

        private void bunifuMetroTextbox2_OnValueChanged(object sender, EventArgs e)
        {
            var email = bunifuMetroTextbox2.Text;

            try
            {
                var address = new MailAddress(email);
                bunifuCustomLabel9.Visible = false;
            }

            catch (Exception)
            {
                bunifuCustomLabel9.Visible = true;
            }
        }

        private void bunifuMetroTextbox1_OnValueChanged(object sender, EventArgs e)
        {
            var name = bunifuMetroTextbox1.Text;
            bool meetsLengthRequirements = name.Length >= MinimalLength && name.Length <= MaximalLength;

            if (meetsLengthRequirements)
                bunifuCustomLabel6.Visible = false;

            else
                bunifuCustomLabel6.Visible = true;
        }

        private void bunifuMetroTextbox3_OnValueChanged(object sender, EventArgs e)
        {
            var password = bunifuMetroTextbox3.Text;

            bool meetsLengthRequirements = password.Length >= MinimalLength && password.Length <= MaximalLength;
            bool hasUpperCaseLetter = false;
            bool hasLowerCaseLetter = false;
            bool hasDecimalDigit = false;

            if (meetsLengthRequirements)
            {
                foreach (char c in password)
                {
                    if (char.IsUpper(c)) hasUpperCaseLetter = true;
                    else if (char.IsLower(c)) hasLowerCaseLetter = true;
                    else if (char.IsDigit(c)) hasDecimalDigit = true;
                }
            }

            bool isValid = meetsLengthRequirements && hasUpperCaseLetter && hasLowerCaseLetter && hasDecimalDigit;

            if (isValid)
                bunifuCustomLabel10.Visible = false;

            else
                bunifuCustomLabel10.Visible = true;
        }
    }
}