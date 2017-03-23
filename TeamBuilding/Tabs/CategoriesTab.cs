using System;
using ns1;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows.Forms;

namespace TeamBuilding.Tabs
{
    public partial class CategoriesTab : UserControl
    {
        public TeamBuildingEntities TeamBuildingEntities = new TeamBuildingEntities();
        public ObservableCollection<Classes> ClassesList;

        public int Counter = 0;

        Random random = new Random();

        public CategoriesTab()
        {
            InitializeComponent();
        }

        public void FillButtons(int x, int y)
        {
            try
            {
                ClassesList = new ObservableCollection<Classes>(TeamBuildingEntities.Classes);
                var chosenClass = ClassesList[0];

                for (int i = 0; i < 2; i++)
                {
                    BunifuTileButton tileButton = new BunifuTileButton { Name = "button" + i };
                    chosenClass = ClassesList[Counter];
                    tileButton.LabelText = chosenClass.ClassName;
                    tileButton.Size = new Size(250, 125);
                    tileButton.Location = new Point(x, y);
                    x -= 350;
                    tileButton.LabelPosition = 75;
                    tileButton.Image = null;
                    tileButton.color = Color.FromArgb(random.Next(255), random.Next(255), random.Next(255));
                    tileButton.BackColor = tileButton.color;
                    tileButton.colorActive = Color.Transparent;
                    tileButton.Font = new Font("Century Gothic", 12);
                    tileButton.ForeColor = Color.Black;
                    Controls.Add(tileButton);
                    ++Counter;
                }
            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }
    }
}