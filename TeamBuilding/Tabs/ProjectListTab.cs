using System;
using System.Collections.ObjectModel;
using System.Drawing;
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
     
        public ProjectListTab()
        {
            InitializeComponent();
        }


        public void ShowProjects()
        {
            
            try
            {
                ProjectsList = new ObservableCollection<Projects>(TeamBuildingEntities.Projects);
                var thinButtonY = 325;
                var pictureBoxY = 75;
                var separatorY = 375;
                var customLabelY = 400;
                var likeButtonY = 395;
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

                    BunifuThinButton2 thinButton = new BunifuThinButton2 { Name = "thinButton" + i };
                    var chosenProject = ProjectsList[Counter];
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
                    pictureBox.Location = new Point(50, pictureBoxY);                    
					if (File.Exists(@"..\..\Pictures\" + chosenProject.PrjtImagePath))
                    pictureBox.Image = new Bitmap(@"..\..\Pictures\" + chosenProject.PrjtImagePath);
                    else pictureBox.Image = new Bitmap(@"..\..\Pictures\default.jpg");
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

        private void ProjectListTab_Load(object sender, EventArgs e)
        {

        }
    }
}