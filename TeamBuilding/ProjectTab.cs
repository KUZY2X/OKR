using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace TeamBuilding
{
    public partial class ProjectTab : UserControl
    {
        public TeamBuildingEntities TeamBuildingEntities = new TeamBuildingEntities();
        public ObservableCollection<Users> UsersList;

        private static ProjectTab _instance;
        private Panel _currentPanel;
        private String _imagePath = "";
        private Projects ExistedProject = null;
        private Projects _newProject;

        public static ProjectTab Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ProjectTab();
                return _instance;
            }
        }

        public ProjectTab()
        {
            InitializeComponent();
            _currentPanel = panel1;
        }

        private void bunifuThinButton21_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (_currentPanel == panel1 && bunifuMetroTextbox1.Text != "")
                {
                    bunifuTransition1.HideSync(panel1);
                    panel1.Visible = false;

                    panel2.Location = panel1.Location;

                    bunifuTransition1.ShowSync(panel2);
                    _currentPanel = panel2;
                }

                else if (_currentPanel == panel2 && bunifuMetroTextbox2.Text != "")
                {
                    bunifuTransition1.HideSync(panel2);
                    panel2.Visible = false;

                    panel3.Location = panel2.Location;

                    bunifuTransition1.ShowSync(panel3);
                    _currentPanel = panel3;
                }

                else if (_currentPanel == panel3)
                {
                    bunifuTransition1.HideSync(panel3);
                    panel3.Visible = false;

                    panel4.Location = panel3.Location;

                    bunifuTransition1.ShowSync(panel4);
                    _currentPanel = panel4;
                }

                else if (_currentPanel == panel4)
                {
                    bunifuTransition1.HideSync(panel4);
                    panel4.Visible = false;

                    panel5.Location = panel4.Location;

                    bunifuTransition1.ShowSync(panel5);
                    _currentPanel = panel5;

                    bunifuThinButton21.ButtonText = "Finish";
                }

                else if (_currentPanel == panel5 && listBox1.Items.Count > 0)
                {
                    MessageBox.Show("Project sueccesfully added");
                    Visible = false;
                    Projects NewProject = CreateBaseForProject();
                    CreateOrUpdate(NewProject);
                }
            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.ShowDialog();
                if (File.Exists(openFileDialog1.FileName))
                {
                    pictureBox1.Image = new Bitmap(openFileDialog1.FileName);
                    _imagePath = openFileDialog1.SafeFileName;
                }
            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }

        public void StartInfo()
        {
            try
            {
                foreach (var clas in TeamBuildingEntities.Classes)
                {
                    checkedListBox1.Items.Add(clas.ClassName);
                }
                pictureBox1.Image = new Bitmap(@"..\..\Pictures\default.jpg");
            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox1.Text != "")
            {
                listBox1.Items.Add(bunifuMaterialTextbox1.Text);
            }
            else
            {
                MessageBox.Show("Type a skill");
            }
        }

        private Projects CreateBaseForProject()
        {
            try
            {
                UsersList = new ObservableCollection<Users>(TeamBuildingEntities.Users);
               
                int projectId;
                if (ExistedProject == null)
                {
                    projectId =
                        TeamBuildingEntities.Projects.ToList()[TeamBuildingEntities.Projects.Count() - 1].PrjtId + 1;
                }
                else
                    projectId = ExistedProject.PrjtId;

                if (!File.Exists(openFileDialog1.FileName) && ExistedProject == null)
                    _imagePath = "default.jpg";

                _newProject = new Projects()
                {
                    PrjtId = projectId,
                    PrjtName = bunifuMetroTextbox1.Text,
                    PrjtDescription = bunifuMetroTextbox2.Text,
                    PrjtCreated =
                        (ExistedProject == null) ? Convert.ToDateTime(DateTime.Today) : ExistedProject.PrjtCreated,
                    PrjtImagePath = _imagePath,
                    PrjtCreatedBy =
                        (ExistedProject == null)
                            ? UsersList[Form1.SelectedUser - 1].UsrId
                            : ExistedProject.PrjtCreatedBy,
                    PjrtLikeCounter = (ExistedProject == null) ? 0 : ExistedProject.PjrtLikeCounter
                };

                _newProject.Users2.Clear();
                _newProject.Users2.Add(UsersList[Form1.SelectedUser - 1]);

                if (File.Exists(openFileDialog1.FileName) ||
                    ExistedProject != null && ExistedProject.PrjtImagePath != _imagePath)
                {
                    Image Img = new Bitmap(openFileDialog1.FileName);
                    Img.Save(@"..\..\Pictures\" + openFileDialog1.SafeFileName);
                }

                if (ExistedProject != null)
                {
                    ExistedProject.PrjtClasses.Clear();
                    ExistedProject.Skills.Clear();
                }

                for (int i = 0; i < listBox1.Items.Count; i++)
                    _newProject.Skills.Add(TeamBuildingEntities.Skills.ToList()[i]);

                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                    if (checkedListBox1.GetItemChecked(i))
                        _newProject.PrjtClasses.Add(new PrjtClasses()
                        {
                            ClClassId = i,
                            ClPrjtId = _newProject.PrjtId,
                            ClPeopleNeeded = "1",
                            Classes = TeamBuildingEntities.Classes.ToList()[i],
                            Projects = _newProject
                        });
            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }

            return _newProject;
        }

        private void CreateOrUpdate(Projects newProject)
        {
            try
            {
                if (ExistedProject != null)
                    TeamBuildingEntities.Projects.Remove(ExistedProject);

                TeamBuildingEntities.Projects.Add(newProject);

                if (ExistedProject != null)
                    UsersList[Form1.SelectedUser - 1].Projects1.Add(newProject);

                if (ExistedProject == null)
                {
                    UsersList[Form1.SelectedUser - 1].Projects1.Add(newProject);
                }
            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }
    }
}