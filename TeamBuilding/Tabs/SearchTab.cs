using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ns1;

namespace TeamBuilding.Tabs
{
    public partial class SearchTab : UserControl
    {
        public ObservableCollection<Projects> ProjectsList;
        public TeamBuildingEntities TeamBuildingEntities = new TeamBuildingEntities();
        private int lblcount;
        public SearchTab()
        {
            InitializeComponent();
        }

        private void bunifuMaterialTextbox1_KeyUp_1(object sender, KeyEventArgs e)
        {
            ProjectsList = new ObservableCollection<Projects>(TeamBuildingEntities.Projects);
            var i = 0;
            for (int j = 0; j < lblcount; j++)
            {
                Controls.RemoveByKey($"bunifulabel{j}");
            }
            var counter = 0;
            foreach (var items in ProjectsList)
            {
                if (bunifuMaterialTextbox1.Text != "" &&
                    items.PrjtName.ToLower().Contains(bunifuMaterialTextbox1.Text.ToLower()))
                {
                    BunifuCustomLabel label = new BunifuCustomLabel
                    {
                        Text = items.PrjtName,
                        Location = new Point(50, 100 + counter),
                        Height = 50,
                        Width = bunifuMaterialTextbox1.Width,
                        Name = $"bunifulabel{i}",
                        Font = new Font("Century Gothic", 12)
                    };
                    counter += 50;
                    i++;
                    Controls.Add(label);
                }
            }
            lblcount = i + 1;
        }

        private void SearchTab_Load_1(object sender, EventArgs e)
        {
            
        }
    }
}
