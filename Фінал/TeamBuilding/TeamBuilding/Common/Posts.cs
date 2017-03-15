using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TeamBuilding.Common
{
    public partial class Posts : Form
    {
        public TeamBuilding2Entities TB = new TeamBuilding2Entities();
       // public ObservableCollection<Users> UsersList = new ObservableCollection<Users>();
        public ObservableCollection<Projects> ProjectList = new ObservableCollection<Projects>();

        //public TeamBuildingEntities TB_NextForm = new TeamBuildingEntities();
        //public ObservableCollection<User> UserList = new ObservableCollection<User>();

        public Posts()
        {
            //db
            InitializeComponent();
            ProjectList = new ObservableCollection<Projects>(TB.Projects);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Form size
            this.Width = 650;
            this.Height = 490;
            CreatePost();
            this.AutoScroll = true;

        }

        public void CreatePost()
        {
            
        //панель для скролу, яка є на задньому фоні
        Panel back_basis = new Panel();
            back_basis.Name = "back_basis";
           // back_basis.BackColor = Color.Green;
            back_basis.Width = 640;
            back_basis.Height = 480;
            back_basis.AutoScroll = true;

            //створення постів
            var len = ProjectList.Count;


   //         List<Button> buttons = new List<Button>();
            for (int j = 0; j <= len; j++)
            {
                //інкремента на назви елеменітів
                int i = 1;
                i++;

                //db elements from list

                #region variable
                var idProject = ProjectList.ElementAt(j).PrjtId;
                var description = ProjectList.ElementAt(j).PrjtDescription;
                var createdTime = ProjectList.ElementAt(j).PrjtCreated;
                var creator = ProjectList.ElementAt(j).PrjtCreatedBy;
                var projectName = ProjectList.ElementAt(j).PrjtName;
                var user = ProjectList.ElementAt(j).Users;
                var imagePath = ProjectList.ElementAt(j).PrjtImagePath;
                var likeCount = ProjectList.ElementAt(j).PjrtLikeCounter;
                #endregion

                //String Parametrs = idProject + "_" + description + "_" + createdTime + "_" + creator + "_" + projectName + "_" + user + "_" + imagePath + "_" + likeCount;
                #region basicPanel
                Panel basis = new Panel();
                basis.Name = "basis" + i;
                basis.BackColor = Color.DimGray ;
                basis.Location = new Point(10, j * 280);
                basis.Size = new Size(610, 250);
                #endregion

               
                #region descriptionProject
                Label descriptionText = new Label();
                descriptionText.Text = description;
                //descriptionText.Location = new Point(basis.Left + 5, basis.Top + 10);
                //descriptionText.Width = descriptionPanel.Width - 20;
                //descriptionText.Height = descriptionPanel.Height - 20;
                descriptionText.Left = basis.Left + 220 ;
                descriptionText.Top = basis.Top + 40;
                descriptionText.Size = new Size(370, 130);
                descriptionText.BringToFront();
                #endregion

                #region decriptionPanel
                Panel descriptionPanel = new Panel();
                descriptionPanel.Name = "description" + i;
                descriptionPanel.Left = basis.Left + 220;
                descriptionPanel.Top = basis.Top + 170;
             //   descriptionPanel.Location = new Point(210, (j * 280));
                descriptionPanel.BackColor = Color.Gray;
                descriptionPanel.Size = new Size(370, 20);
                descriptionPanel.SendToBack();
                #endregion

                #region imageToProject
                PictureBox header = new PictureBox();
                header.Left = basis.Left + 10;
                header.Top = basis.Top + 10;
                header.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                header.TabIndex = 1;
                header.Width = 180;
                header.Height = 180;
                header.TabStop = false;
                header.Image = new Bitmap(@"..\..\Pictures\1.jpg");
                //  header.Image = new Bitmap(@"..\..\Pictures\" + imagePath);
                header.BackColor = Color.Red;
                #endregion

                #region information(CreateDate)
                Label information = new Label();
                information.Text = createdTime.ToString();
                information.Left = basis.Left + 240;
                information.Top = (basis.Top + 210);
                information.BringToFront();
                #endregion

                #region nameProject
                Label name = new Label();
                name.Text = projectName;
                name.Left = basis.Left + 220;
                name.Top = basis.Top + 20;
                name.Font = new Font(new FontFamily(System.Drawing.Text.GenericFontFamilies.Serif), 10);
                name.Width = descriptionPanel.Width;
                name.BringToFront();
                #endregion

                #region buttons

                // foreach (var z in TB.Users.ToList()[idProject].LikedProject.ToString())
                {
                    //   needSkill += (z.ToString());
                }

                Button buttonLike = new Button();
                //buttons.Add(buttonLike);
                
                buttonLike.Text = "Like" + " " + likeCount + "+";                
                buttonLike.Size = new System.Drawing.Size(180, 41);
                buttonLike.Left = (basis.Left + 10);
                buttonLike.Top = (basis.Top + 200);
                buttonLike.BackColor = Color.Blue;
                buttonLike.Click+=  new EventHandler(delegate (Object o, EventArgs a)
                {
                    buttonLike.Text = "Like" + " " + (likeCount + 1).ToString();
                    buttonLike.Enabled = false;
                    buttonLike.BackColor = Color.Green;

                    var Inc_likeCounter = TB.Projects.Where(c => c.PrjtId == idProject).FirstOrDefault();

                    Inc_likeCounter.PjrtLikeCounter = ++likeCount;

                    TB.SaveChanges();
                });

                Button buttonNext = new Button();
                buttonNext.Text = "FullPost";
                buttonNext.Size = new System.Drawing.Size(180, 41);
                buttonNext.Left = (basis.Left + 400);
                buttonNext.Top = (basis.Top + 200);
                buttonNext.Click += new EventHandler(this.Button_Click_Next);
                buttonNext.BackColor = Color.BlueViolet;
                buttonNext.Tag = (object)ProjectList.ElementAt(j);
                #endregion

                #region addElementsOnControl
               
                //this.Controls.Add(back_basis);               
               // this.Controls.Add(descriptionText);

                this.Controls.Add(descriptionPanel);
                this.Controls.Add(descriptionText);

                this.Controls.Add(header);
                this.Controls.Add(information);
                this.Controls.Add(name);

                this.Controls.Add(buttonLike);
                this.Controls.Add(buttonNext);
                this.Controls.Add(basis);
                #endregion

                this.AutoScroll = true;
            }
        }
        
        private void Button_Click_Next(object sender, EventArgs e)
        {
            Form FullInformation = new Form();
            FullInformation.Width = 640;
            FullInformation.Height = 550;
            FullInformation.Show();

            String needSkill = "";
            var kurva = returnTag(((Control)sender).Tag);

            TeamBuilding2Entities TB_NextForm = new TeamBuilding2Entities();
            var userName = TB_NextForm.Users.Where(u => u.UsrId == kurva.PrjtCreatedBy).ToList();

            //foreach (var i in TB.Projects.ToList()[kurva.PrjtId].Skills)
            {
                //   needSkill += (i.SklName.ToString());
            }


            #region Elements
            PictureBox IgemagePost = new PictureBox();
            IgemagePost.Left = 10;
            IgemagePost.Top = 10;
            IgemagePost.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            IgemagePost.TabIndex = 1;
            IgemagePost.Width = 180;
            IgemagePost.Height = 180;
            IgemagePost.TabStop = false;
            IgemagePost.BackColor = Color.Red;
            IgemagePost.Image = new Bitmap(@"..\..\Pictures\1.jpg");
            //IgemagePost.Image = Image.FromFile(kurva.PrjtImagePath.ToString());

            Panel HeaderPanel = new Panel();
            HeaderPanel.Name = "ProjectInf";
            HeaderPanel.Left = 200;
            HeaderPanel.Top = 10;
            HeaderPanel.BackColor = Color.CadetBlue;
            HeaderPanel.Size = new Size(420, 180);

            Panel MiddlePanel = new Panel();
            MiddlePanel.Name = "descriptionOnFormNext";
            MiddlePanel.Left = 10;
            MiddlePanel.Top = 200;
            MiddlePanel.BackColor = Color.CadetBlue;
            MiddlePanel.Size = new Size(610, 120);
            MiddlePanel.AutoScroll = true;

            Panel FooterPanel = new Panel();
            FooterPanel.Name = "Skills";
            FooterPanel.Left = 10;
            FooterPanel.Top = 330;
            FooterPanel.BackColor = Color.CadetBlue;
            FooterPanel.Size = new Size(610, 120);
            FooterPanel.AutoScroll = true;

            Label NameProject = new Label();
            NameProject.Text = kurva.PrjtName;
            NameProject.Location = new Point(HeaderPanel.Left - (int)(HeaderPanel.Width / 2.4), HeaderPanel.Top);
            NameProject.Width = HeaderPanel.Width - 20;
            NameProject.Height = 20;
            NameProject.Font = new Font(new FontFamily(System.Drawing.Text.GenericFontFamilies.Serif), 12);
            NameProject.BringToFront();

            Label Creator = new Label();
            Creator.Text = "Проект користувача" + ": " + userName[0].Name;
            Creator.Location = new Point(HeaderPanel.Left - (int)(HeaderPanel.Width / 2.4), HeaderPanel.Top + ((int)(HeaderPanel.Height / 5)));
            Creator.Width = HeaderPanel.Width - 20;
            Creator.Height = 20;
            Creator.Font = new Font(new FontFamily(System.Drawing.Text.GenericFontFamilies.Serif), 10);
            Creator.BringToFront();

            Label TimeCreate = new Label();
            TimeCreate.Text = kurva.PrjtCreated.ToString();
            TimeCreate.Location = new Point(HeaderPanel.Left - (int)(HeaderPanel.Width / 2.4), HeaderPanel.Top + ((int)(HeaderPanel.Height / 2.5)));
            TimeCreate.Width = HeaderPanel.Width - 20;
            TimeCreate.Height = 20;
            TimeCreate.Font = new Font(new FontFamily(System.Drawing.Text.GenericFontFamilies.Serif), 10);
            TimeCreate.BringToFront();

            Label Liked = new Label();
            Liked.Text = "Like " + kurva.PjrtLikeCounter.ToString();
            Liked.Location = new Point(HeaderPanel.Left - (int)(HeaderPanel.Width / 2.4), HeaderPanel.Top + ((int)(HeaderPanel.Height / 1.5)));
            Liked.Width = HeaderPanel.Width - 20;
            Liked.Height = 20;
            Liked.Font = new Font(new FontFamily(System.Drawing.Text.GenericFontFamilies.Serif), 10);
            Liked.BringToFront();

            Label descriptionText = new Label();
            descriptionText.Text = kurva.PrjtDescription;
            descriptionText.Location = new Point(MiddlePanel.Left, MiddlePanel.Top + 20);
            descriptionText.Width = MiddlePanel.Width - 20;
            descriptionText.Height = MiddlePanel.Height - 20;
            descriptionText.BringToFront();

            Label descriptionSkills = new Label();
            descriptionSkills.Text = needSkill;
            descriptionSkills.Location = new Point(FooterPanel.Left, FooterPanel.Top + 20);
            descriptionSkills.Width = FooterPanel.Width - 20;
            descriptionSkills.Height = FooterPanel.Height - 20;
            descriptionSkills.BringToFront();

            Button buttonClose = new Button();
            buttonClose.Text = "Close";
            buttonClose.Size = new System.Drawing.Size(180, 41);
            buttonClose.Left = (430);
            buttonClose.Top = (460);
            buttonClose.BackColor = Color.Red;
            buttonClose.Click  += new EventHandler(delegate (Object o, EventArgs a)
            {
                FullInformation.Close();
            });
            #endregion

            #region addElements
            FullInformation.Controls.Add(IgemagePost);
            FullInformation.Controls.Add(HeaderPanel);
            FullInformation.Controls.Add(MiddlePanel);
            FullInformation.Controls.Add(FooterPanel);
            FullInformation.Controls.Add(buttonClose);
            HeaderPanel.Controls.Add(NameProject);
            HeaderPanel.Controls.Add(Creator);
            HeaderPanel.Controls.Add(TimeCreate);
            HeaderPanel.Controls.Add(Liked);
            MiddlePanel.Controls.Add(descriptionText);
            FooterPanel.Controls.Add(descriptionSkills);
            #endregion
        }

        private Projects returnTag(object tag)
        {
            return (Projects)(tag);
        }

        private void Button_Click_Close(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
