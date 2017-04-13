using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Validation;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace TeamBuilding
{
    public partial class SettingTab : UserControl
    {
        public TeamBuildingEntities TeamBuildingEntities = new TeamBuildingEntities();
        public ObservableCollection<Users> UsersList;
        public Users _user = null;
        private static SettingTab _instance;
        private Panel _currentPanel;
        private String _imagePath = "";
        private Projects ExistedProject = null;
        private Projects _newProject;

        public static SettingTab Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SettingTab();
                return _instance;
            }
        }

        public SettingTab()
        {
            InitializeComponent();
            _user = TeamBuildingEntities.Users.ToList()[Form1.SelectedUser - 1];
            _currentPanel = panel1;
        }

        private void bunifuThinButton21_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (_currentPanel == panel1 && bunifuMetroTextbox0.Text != "" && bunifuMetroTextbox1.Text != "")
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
                    MessageBox.Show("Your personal data is changed");
                    Visible = false;
                    UpdateData();
                }
            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }

        private void UpdateData()
        {
            _user.Name = bunifuMetroTextbox0.Text;
            _user.LastName = bunifuMetroTextbox1.Text;
            _user.RegMail = bunifuMetroTextbox2.Text;
            _user.Classes.Clear();
            _user.Skills.Clear();
            if (_imagePath!=_user.PicturePath)
                if (File.Exists(openFileDialog1.FileName))
                {
                    Image Img = new Bitmap(openFileDialog1.FileName);
                    Img.Save(@"..\..\Pictures\" + openFileDialog1.SafeFileName);
                    _user.PicturePath = openFileDialog1.SafeFileName;
                }
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                Skills skill;
                var check = TeamBuildingEntities.Skills.ToList().Where(k => k.SklName == listBox1.Items[i].ToString());
                if (check.ToList().Count > 0)
                {
                    _user.Skills.Add(check.ToList()[0]);
                }
                else
                {
                    TeamBuildingEntities.Skills.Add(new Skills()
                    {
                        Projects = new List<Projects>(),
                        SklId = TeamBuildingEntities.Skills.Count() + 1,
                        SklName = listBox1.Items[i].ToString(),
                        Users = new List<Users>()
                    });
                    TeamBuildingEntities.SaveChanges();
                    _user.Skills.Add(TeamBuildingEntities.Skills.ToList().Last());
                }
            }

            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                if (checkedListBox1.GetItemChecked(i))
                    _user.Classes.Add(TeamBuildingEntities.Classes.ToList()[i]);
            TeamBuildingEntities.SaveChanges();
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
                _imagePath = _user.PicturePath;
                listBox1.Items.Clear();
                bunifuMetroTextbox0.Text = _user.Name;
                bunifuMetroTextbox1.Text = _user.LastName;
                bunifuMetroTextbox2.Text = _user.RegMail;
                checkedListBox1.Items.Clear();
                foreach (var clas in TeamBuildingEntities.Classes)
                {
                    checkedListBox1.Items.Add(clas.ClassName);
                }
                for (int i = 0; i < _user.Classes.Count; i++)
                {
                    checkedListBox1.SetItemChecked(_user.Classes.ToList()[i].ClassId - 1, true);
                }
                foreach (var VARIABLE in _user.Skills)
                {
                    listBox1.Items.Add(VARIABLE.SklName);
                }
                pictureBox1.Image = new Bitmap(@"..\..\Pictures\"+_user.PicturePath);
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
                bunifuMaterialTextbox1.Text = "";
            }
            else
            {
                MessageBox.Show("Type a skill");
            }
        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > -1)
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                listBox1.SelectedIndex = -1;
            }
        }
    }
}