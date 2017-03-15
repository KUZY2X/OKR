using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeamBuilding
{
    public partial class CreateProject : Form
    {
        private UserProfile UserProfile;
        private Projects ExistedProject = null;
        private String ImagePath = "";
        public CreateProject(UserProfile Usr_Prf)
        {
            InitializeComponent();
            UserProfile = Usr_Prf;
            foreach (var i in UserProfile.TB.Classes)
            {
                checkedListBox1.Items.Add(i.ClassName.ToString());
            }
            foreach (var i in UserProfile.TB.Skills.ToList())
            {
                checkedListBox2.Items.Add(i.SklName.ToString());
            }
            pictureBox1.Image = new Bitmap(@"..\..\Pictures\default.jpg");
        }

        public CreateProject(UserProfile Usr_Prf, Projects prjt)
        {
            InitializeComponent();
            UserProfile = Usr_Prf;
            foreach (var i in UserProfile.TB.Classes)
            {
                checkedListBox1.Items.Add(i.ClassName.ToString());
            }
            for (int i = 0; i < prjt.PrjtClasses.Count; i++)
            {
                checkedListBox1.SetItemChecked(prjt.PrjtClasses.ToList()[i].ClClassId-1, true);
            }
            foreach (var i in UserProfile.TB.Skills.ToList())
            {
                checkedListBox2.Items.Add(i.SklName.ToString());
            }
            for (int i = 0; i < prjt.Skills.Count; i++)
            {
                checkedListBox2.SetItemChecked(prjt.Skills.ToList()[i].SklId-1, true);
            }
            pictureBox1.Image = Image.FromFile(@"..\..\Pictures\" + prjt.PrjtImagePath);
            ImagePath = prjt.PrjtImagePath;
            richTextBox1.Text = prjt.PrjtName;
            richTextBox2.Text = prjt.PrjtDescription;
            ExistedProject = prjt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if (File.Exists(openFileDialog1.FileName))
            {
                pictureBox1.Image = new Bitmap(openFileDialog1.FileName);
                ImagePath = openFileDialog1.SafeFileName;
            }
        }

        private void CreateProject_FormClosed(object sender, FormClosedEventArgs e)
        {
            UserProfile.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "" || richTextBox2.Text == "")
            {
                MessageBox.Show("Введіть дані", "Помилка");
                return;
            }
           Projects NewProject=CreateBaseForProject();
           CreateOrUpdate(NewProject);
        }

        private void CreateOrUpdate(Projects New_Project)
        {
            if (ExistedProject != null)//якшо обновляєм - то старий видаляєм
                UserProfile.TB.Projects.Remove(ExistedProject);
            UserProfile.TB.Projects.Add(New_Project);
            if (ExistedProject != null)//якшо обновили - то нову ссилку для юзера
                UserProfile.UsersList[UserProfile.SelectedUser].Projects1.Add(New_Project);
            //тово гівно треба для дебага
            try
            {
                UserProfile.TB.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        MessageBox.Show(validationError.PropertyName +
                                                validationError.ErrorMessage);
                    }
                }
            }
            UserProfile.LoadUserData(UserProfile.SelectedUser);
            Close();
        }

        private Projects CreateBaseForProject()
        {
            int For_id; //id проекту
            if (ExistedProject == null)
            {
                For_id = UserProfile.TB.Projects.ToList()[UserProfile.TB.Projects.Count() - 1].PrjtId + 1;
            }
            else For_id = ExistedProject.PrjtId;
            if (!File.Exists(openFileDialog1.FileName) && ExistedProject == null)
                ImagePath = "default.jpg";
            Projects New_Project = new Projects()
            {
                PrjtId = For_id,
                PrjtName = richTextBox1.Text,
                PrjtDescription = richTextBox2.Text,
                PrjtCreated = (ExistedProject==null)?Convert.ToDateTime(DateTime.Today):ExistedProject.PrjtCreated,
                PrjtImagePath =ImagePath,
                PrjtCreatedBy = (ExistedProject == null) ? UserProfile.UsersList[UserProfile.SelectedUser].UsrId:ExistedProject.PrjtCreatedBy,
                PjrtLikeCounter = (ExistedProject == null) ? 0:ExistedProject.PjrtLikeCounter
            };
            New_Project.Users2.Clear();
            New_Project.Users2.Add(UserProfile.UsersList[UserProfile.SelectedUser]);
            if (ExistedProject == null)
            {
                UserProfile.UsersList[UserProfile.SelectedUser].Projects1.Add(New_Project);
            }
            if (File.Exists(openFileDialog1.FileName) || (ExistedProject!=null && ExistedProject.PrjtImagePath!=ImagePath))
            {
                Image Img = new Bitmap(openFileDialog1.FileName);
                Img.Save(@"..\..\Pictures\" + openFileDialog1.SafeFileName);
            }
            if (ExistedProject != null)
            {
                ExistedProject.PrjtClasses.Clear();
                ExistedProject.Skills.Clear();
            }
            ObservableCollection<PrjtClasses> Class = new ObservableCollection<PrjtClasses>(UserProfile.TB.PrjtClasses);
            for (int i = 0; i < checkedListBox2.Items.Count; i++)
                if (checkedListBox2.GetItemChecked(i))
                    New_Project.Skills.Add(UserProfile.TB.Skills.ToList()[i]);
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                if (checkedListBox1.GetItemChecked(i))
                    New_Project.PrjtClasses.Add(new PrjtClasses()
                    {
                        ClClassId = i,
                        ClPrjtId = New_Project.PrjtId,
                        ClPeopleNeeded = "1",
                        Classes = UserProfile.TB.Classes.ToList()[i],
                        Projects = New_Project
                    });
            return New_Project;
        }
    }
}
