using System;
using System.Collections.ObjectModel;
using System.Drawing;
<<<<<<< HEAD
using System.IO;
=======
<<<<<<< HEAD
>>>>>>> master
using System.Windows.Forms;
using ns1;

namespace TeamBuilding.Tabs
{
    public partial class ProjectListTab : UserControl
    {
        public TeamBuildingEntities TeamBuildingEntities = new TeamBuildingEntities();
        public ObservableCollection<Projects> ProjectsList;

        public int Counter = 0;
        private bool Liked = false;

<<<<<<< HEAD
=======
=======
using System.IO;
using System.Windows.Forms;
using ns1;
using System.Linq;

namespace TeamBuilding.Tabs
{

    public partial class ProjectListTab : UserControl
    {
        public TeamBuildingEntities TeamBuildingEntities = new TeamBuildingEntities();
        public ObservableCollection<Users> UsersList = new ObservableCollection<Users>();
        public ObservableCollection<Projects> ProjectsList;
      
        private int selectedUser = Form1.SelectedUser - 1;
        public int Counter = 0;
     
>>>>>>> 0fe1a52926726e58c3d1944c7f290c847d845902
>>>>>>> master
        public ProjectListTab()
        {
            InitializeComponent();
        }

<<<<<<< HEAD
        public void ShowProjects()
        {
            try
            {
                ProjectsList = new ObservableCollection<Projects>(TeamBuildingEntities.Projects);
                var chosenProject = ProjectsList[0];
=======
<<<<<<< HEAD
        public void ShowProjects()
        {
=======

        public void ShowProjects()
        {
            
>>>>>>> 0fe1a52926726e58c3d1944c7f290c847d845902
            try
            {
                ProjectsList = new ObservableCollection<Projects>(TeamBuildingEntities.Projects);
>>>>>>> master
                var thinButtonY = 325;
                var pictureBoxY = 75;
                var separatorY = 375;
                var customLabelY = 400;
                var likeButtonY = 395;
<<<<<<< HEAD

                for (int i = 0; i < ProjectsList.Count; i++)
                {
                    BunifuThinButton2 thinButton = new BunifuThinButton2 { Name = "thinButton" + i };
                    chosenProject = ProjectsList[Counter];
=======
<<<<<<< HEAD

                for (int i = 0; i < ProjectsList.Count; i++)
                {
=======
                UsersList = new ObservableCollection<Users>(TeamBuildingEntities.Users);
                var chosenUser = UsersList[selectedUser];
                var tempuserId = chosenUser.UsrId;
                Counter = 0;

                for (int i = 0; i < ProjectsList.Count; i++)
                {
                    #region variable
                    var idProject = ProjectsList.ElementAt(i).PrjtId;
                    var likeCount = ProjectsList.ElementAt(i).PjrtLikeCounter;
                    #endregion

>>>>>>> 0fe1a52926726e58c3d1944c7f290c847d845902
                    BunifuThinButton2 thinButton = new BunifuThinButton2 { Name = "thinButton" + i };
                    var chosenProject = ProjectsList[Counter];
>>>>>>> master
                    thinButton.ButtonText = chosenProject.PrjtName;
                    thinButton.Size = new Size(655, 55);
                    thinButton.IdleLineColor = Color.White;
                    thinButton.IdleCornerRadius = 1;
                    thinButton.IdleForecolor = Color.Black;
                    thinButton.ActiveCornerRadius = 1;
                    thinButton.ActiveFillColor = Color.White;
                    thinButton.ActiveLineColor = Color.Black;
                    thinButton.ActiveForecolor = Color.FromArgb(12, 185, 102);
                    thinButton.TextAlign = ContentAlignment.MiddleLeft;
                    thinButton.Location = new Point(50, thinButtonY);
                    thinButtonY += 400;
                    thinButton.Font = new Font("Century Gothic", 12);

                    PictureBox pictureBox = new PictureBox();
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox.Size = new Size(655, 250);
<<<<<<< HEAD
                    pictureBox.Location = new Point(50, pictureBoxY);
                    if (File.Exists(@"..\..\Pictures\" + chosenProject.PrjtImagePath))
                    pictureBox.Image = new Bitmap(@"..\..\Pictures\" + chosenProject.PrjtImagePath);
                    else pictureBox.Image = new Bitmap(@"..\..\Pictures\default.jpg");
=======
<<<<<<< HEAD
                    pictureBox.Location = new Point(50, pictureBoxY);
                    pictureBox.Image = new Bitmap(@"..\..\Pictures\default.jpg");
=======
                    pictureBox.Location = new Point(50, pictureBoxY);                    
					if (File.Exists(@"..\..\Pictures\" + chosenProject.PrjtImagePath))
                    pictureBox.Image = new Bitmap(@"..\..\Pictures\" + chosenProject.PrjtImagePath);
                    else pictureBox.Image = new Bitmap(@"..\..\Pictures\default.jpg");
>>>>>>> 0fe1a52926726e58c3d1944c7f290c847d845902
>>>>>>> master
                    pictureBoxY += 400;

                    BunifuSeparator separator = new BunifuSeparator();
                    separator.Size = new Size(655, 15);
                    separator.LineColor = Color.FromArgb(12, 185, 102);
                    separator.LineThickness = 3;
                    separator.Location = new Point(50, separatorY);
                    separatorY += 400;

                    BunifuCustomLabel customLabel = new BunifuCustomLabel();
                    customLabel.Font = new Font("Century Gothic", 12);
                    customLabel.Text = "Likes: " + chosenProject.PjrtLikeCounter;
                    customLabel.Location = new Point(50, customLabelY);
                    customLabelY += 400;

                    BunifuImageButton likeButton = new BunifuImageButton() { Name = "imageButton" + i };
                    likeButton.Zoom = 15;
                    likeButton.Size = new Size(30, 30);
                    likeButton.BackColor = Color.Transparent;
                    likeButton.SizeMode = PictureBoxSizeMode.StretchImage;
                    likeButton.Image = bunifuImageButton2.Image;
                    likeButton.Location = new Point(675, likeButtonY);
                    likeButtonY += 400;
<<<<<<< HEAD
                    likeButton.Click += new EventHandler(bunifuImageButton2_Click);
=======
<<<<<<< HEAD
                    likeButton.Click += new EventHandler(bunifuImageButton2_Click);
=======

                    var kurwa_LikePrj = TeamBuildingEntities.LikedProjects.Where(c => c.LkdPrjtId == idProject && c.LkdUserId == tempuserId).FirstOrDefault();
                    
                    if (kurwa_LikePrj == null)
                    {
                        likeButton.Image = bunifuImageButton2.Image;
                    }
                    else
                    {
                        likeButton.Image = bunifuImageButton1.Image;
                    }
                    
                    likeButton.Click  += new EventHandler(delegate (Object o, EventArgs a)
                    {
                       
                            var kurwa2_LikePrj = TeamBuildingEntities.LikedProjects.Where(c => c.LkdPrjtId == idProject && c.LkdUserId == tempuserId).FirstOrDefault();

                        try
                           {
                            if (kurwa2_LikePrj == null)
                            {
                                likeButton.Image = bunifuImageButton1.Image;

                                var Inc_likeCounter = TeamBuildingEntities.Projects.Where(c => c.PrjtId == idProject).FirstOrDefault();
                                Inc_likeCounter.PjrtLikeCounter = ++likeCount;

                                customLabel.Text = "Likes: " + chosenProject.PjrtLikeCounter;

                                LikedProjects likedproject = new LikedProjects
                                {
                                    LkdPrjtId = idProject,
                                    LkdUserId = tempuserId
                                };

                                TeamBuildingEntities.LikedProjects.Add(likedproject);

                                TeamBuildingEntities.SaveChanges();
                            }
                        }
                        catch
                        {
                            //MessageBox.Show("like is delete from activity");
                        }

                        if (kurwa2_LikePrj != null)
                            {

                                likeButton.Image = bunifuImageButton2.Image;

                                var Inc_likeCounter = TeamBuildingEntities.Projects.Where(c => c.PrjtId == idProject).FirstOrDefault();
                                Inc_likeCounter.PjrtLikeCounter = --likeCount;

                                customLabel.Text = "Likes: " + chosenProject.PjrtLikeCounter;

                                var delLike = TeamBuildingEntities.LikedProjects.Where(c => c.LkdPrjtId == idProject && c.LkdUserId == tempuserId).FirstOrDefault();

                                if (delLike != null)
                                {
                                    //   TeamBuildingEntities.LikedProjects.Attach(delLike);
                                    TeamBuildingEntities.LikedProjects.Remove(delLike);
                                }

                                TeamBuildingEntities.SaveChanges();
                            }
                       
                    });
>>>>>>> 0fe1a52926726e58c3d1944c7f290c847d845902
>>>>>>> master

                    Controls.Add(thinButton);
                    Controls.Add(pictureBox);
                    Controls.Add(separator);
                    Controls.Add(customLabel);
                    Controls.Add(likeButton);
                    ++Counter;
                }
            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }

<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> master
        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            BunifuImageButton button = sender as BunifuImageButton;

            if (!Liked)
            {
                button.Image = bunifuImageButton1.Image;
                Liked = true;
            }
            else
            {
                button.Image = bunifuImageButton2.Image;
                Liked = false;
            }
<<<<<<< HEAD
=======
=======
        private void ProjectListTab_Load(object sender, EventArgs e)
        {

>>>>>>> 0fe1a52926726e58c3d1944c7f290c847d845902
>>>>>>> master
        }
    }
}