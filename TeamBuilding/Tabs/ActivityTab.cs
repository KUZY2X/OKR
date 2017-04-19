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
<<<<<<< HEAD
        public ObservableCollection<LikedProjects> LikedProjects = new ObservableCollection<LikedProjects>();
=======
<<<<<<< HEAD
        public ObservableCollection<LikedProjects> LikedProjects = new ObservableCollection<LikedProjects>();
=======
        public ObservableCollection<LikedProjects> likePrjcList = new ObservableCollection<LikedProjects>();
>>>>>>> 0fe1a52926726e58c3d1944c7f290c847d845902
>>>>>>> master

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
<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
            var tempuserId = chosenUser.UsrId;
            likePrjcList = new ObservableCollection<LikedProjects>(TeamBuildingEntities.LikedProjects.Where(c => c.LkdUserId == tempuserId));

>>>>>>> 0fe1a52926726e58c3d1944c7f290c847d845902
>>>>>>> master

            foreach (var control in Controls)
            {
                if (control is ListBox)
<<<<<<< HEAD
                    ListBoxes.Add((ListBox) control);
=======
<<<<<<< HEAD
                    ListBoxes.Add((ListBox) control);
=======
                ListBoxes.Add((ListBox) control);
>>>>>>> 0fe1a52926726e58c3d1944c7f290c847d845902
>>>>>>> master
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
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> master
            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
<<<<<<< HEAD
=======
=======

                foreach (var like in likePrjcList)
                {

                    var tempProject = TeamBuildingEntities.Projects.Where(c => c.PrjtId == like.LkdPrjtId).FirstOrDefault();
                    listBox3.Items.Add(tempProject.PrjtName);

                }

            }

           catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }


>>>>>>> 0fe1a52926726e58c3d1944c7f290c847d845902
>>>>>>> master
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            try
            {
                TeamBuildingEntities.Users.ToList()[selectedUser].Projects2.Remove(
<<<<<<< HEAD
                    UsersList[selectedUser].Projects2.ToList()[listBox1.SelectedIndex]);
=======
<<<<<<< HEAD
                    UsersList[selectedUser].Projects2.ToList()[listBox1.SelectedIndex]);
=======
                UsersList[selectedUser].Projects2.ToList()[listBox1.SelectedIndex]);
>>>>>>> 0fe1a52926726e58c3d1944c7f290c847d845902
>>>>>>> master
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
<<<<<<< HEAD
=======
<<<<<<< HEAD
=======

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {

            UsersList = new ObservableCollection<Users>(TeamBuildingEntities.Users);
            var chosenUser = UsersList[selectedUser];
            var tempuserId = chosenUser.UsrId;

            try
            {
            var tempProjectId = TeamBuildingEntities.Projects.Where(c => c.PrjtName == listBox3.SelectedItem).FirstOrDefault();
            var tempId = tempProjectId.PrjtId;

            var likeInProject = TeamBuildingEntities.Projects.Where(c => c.PrjtId == tempId).FirstOrDefault();
            int countLike = (int)likeInProject.PjrtLikeCounter;
            countLike--;
            likeInProject.PjrtLikeCounter = countLike;

            var delLike = TeamBuildingEntities.LikedProjects.Where(c => c.LkdPrjtId == tempProjectId.PrjtId && c.LkdUserId == tempuserId).FirstOrDefault();

          //   TeamBuildingEntities.LikedProjects.Attach(delLike);
               TeamBuildingEntities.LikedProjects.Remove(delLike);
                
               listBox3.Items.Clear();

               TeamBuildingEntities.SaveChanges();
            }
            catch (Exception exception)
                {
                    MessageBox.Show("Choose unlike element");
                    listBox3.Items.Clear();
            }

            likePrjcList = new ObservableCollection<LikedProjects>(TeamBuildingEntities.LikedProjects.Where(c => c.LkdUserId == tempuserId));

            if (likePrjcList != null)
            {
                try
                {
                    foreach (var like in likePrjcList)
                    {
                        var tempProject = TeamBuildingEntities.Projects.Where(c => c.PrjtId == like.LkdPrjtId).FirstOrDefault();
                        listBox3.Items.Add(tempProject.PrjtName);
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.ToString());
                }
            }
        }
>>>>>>> 0fe1a52926726e58c3d1944c7f290c847d845902
>>>>>>> master
    }
}