using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;

namespace TeamBuilding.Tabs
{
    public partial class ActivityTab : UserControl
    {
        public TeamBuildingEntities TeamBuildingEntities = new TeamBuildingEntities();
        public ObservableCollection<Users> UsersList = new ObservableCollection<Users>();
        public ObservableCollection<LikedProjects> LikedProjects = new ObservableCollection<LikedProjects>();

        private List<ListBox> ListBoxes;
        private int selectedUser = Form1.SelectedUser - 1;
        private int i = 0;

        public ActivityTab()
        {
            InitializeComponent();
        }

        public void LoadProjects(int selected)
        {
           // ProjectTab.Instance.Hide();
            UsersList = new ObservableCollection<Users>(TeamBuildingEntities.Users);
            var chosenUser = UsersList[selected];
            ListBoxes = new List<ListBox>();

            foreach (var control in Controls)
            {
                if (control is ListBox)
                    ListBoxes.Add((ListBox) control);
            }

            foreach (var listBox in ListBoxes)
            {
                listBox.Items.Clear();
            }

            try
            {
                foreach (var project in chosenUser.Projects2)
                {
                    listBox1.Items.Add(project.PrjtName);
                }

                foreach (var project in chosenUser.Projects1)
                {
                    listBox2.Items.Add(project.PrjtName);
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
                TeamBuildingEntities.Users.ToList()[selectedUser].Projects2.Remove(
                    UsersList[selectedUser].Projects2.ToList()[listBox1.SelectedIndex]);
                TeamBuildingEntities.SaveChanges();
                LoadProjects(selectedUser);
            }

            catch (Exception)
            {
                MessageBox.Show("Choose a project");
            }
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            try
            {
                //Controls.Add(ProjectTab.Instance);
               // ProjectTab.Instance.Dock = DockStyle.Fill;
               // ProjectTab.Instance.BringToFront();
            }

            catch (Exception)
            {
                MessageBox.Show("Choose a project");
            }
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            try
            {
                TeamBuildingEntities.Skills.ToList()[selectedUser].Projects.Remove(
                    UsersList[selectedUser].Projects.ToList()[listBox2.SelectedIndex]);
                TeamBuildingEntities.Projects.Remove(
                    UsersList[selectedUser].Projects.ToList()[listBox2.SelectedIndex]);
                TeamBuildingEntities.SaveChanges();
                LoadProjects(selectedUser);
            }

            catch (Exception)
            {
                MessageBox.Show("Choose a project");
            }
        }
    }
}