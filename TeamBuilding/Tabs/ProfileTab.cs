using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows.Forms;

namespace TeamBuilding.Tabs
{
    public partial class ProfileTab : UserControl
    {
        public TeamBuildingEntities TeamBuildingEntities = new TeamBuildingEntities();
        public ObservableCollection<Users> UsersList;

        public ProfileTab()
        {
            InitializeComponent();
        }

        public bool LoadUserData(int selected)
        {
            try
            {
                UsersList = new ObservableCollection<Users>(TeamBuildingEntities.Users);

                var chosenOne = UsersList[selected];
                pictureBox1.Image = new Bitmap(@"..\..\Pictures\" + chosenOne.PicturePath);
                bunifuCustomLabel2.Text = chosenOne.Name;
                bunifuCustomLabel3.Text = "Joined: " + chosenOne.Registered;
                bunifuCustomLabel4.Text = "Your projects: " + chosenOne.Projects1.Count;

                try
                {
                    var userContacts = UsersList[selected].Contacts;
                    {
                        if (userContacts.PublicMail != null)
                            bunifuCustomLabel5.Text = "Contacts: Email: " + userContacts.PublicMail + "; ";
                        if (userContacts.Facebook != null)
                            bunifuCustomLabel5.Text += "Facebook: " + userContacts.Facebook + "; ";
                        if (userContacts.VKId != null)
                            bunifuCustomLabel5.Text += "VK: " + userContacts.VKId + "; ";
                        if (userContacts.Linkedin != null)
                            bunifuCustomLabel5.Text += "LinkedIn: " + userContacts.Linkedin + "; ";
                    }
                }

                catch (Exception)
                {
                    bunifuCustomLabel5.Text = "Contacts: none";
                }
            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }

            return true;
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            ProjectTab.Instance.Visible = true;
            ProjectTab.Instance.StartInfo();
            Controls.Add(ProjectTab.Instance);
            ProjectTab.Instance.Dock = DockStyle.Fill;
            ProjectTab.Instance.BringToFront();
        }
<<<<<<< HEAD
=======

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            SettingTab.Instance.Visible = true;
            SettingTab.Instance.StartInfo();
            Controls.Add(SettingTab.Instance);
            SettingTab.Instance.Dock = DockStyle.Fill;
            SettingTab.Instance.BringToFront();
        }
>>>>>>> 0fe1a52926726e58c3d1944c7f290c847d845902
    }
}