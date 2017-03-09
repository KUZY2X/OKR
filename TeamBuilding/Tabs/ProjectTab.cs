using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeamBuilding.Tabs
{
    public partial class ProjectTab : UserControl
    {
        List<Dictionary<string, Color>> templates = new List<Dictionary<string, Color>>();

        public ProjectTab()
        {
            InitializeComponent();

            var template = new Dictionary<string, Color>();

            template.Add("bottomleft", Color.FromArgb(39, 50, 56));
            template.Add("bottomright", Color.FromArgb(39, 50, 56));
            template.Add("topleft", Color.FromArgb(39, 50, 56));
            template.Add("topright", Color.FromArgb(39, 50, 56));

            templates.Add(template);

            for (int i = 0; i < 10; i++)
            {
                button1.PerformClick();
            }

            load_theme(templates[cur_template]);
        }

        int cur_template = 0;

        public void load_theme(Dictionary<string, Color> theme)
        {

            bunifuGradientPanel1.GradientBottomLeft = theme["bottomleft"];
            bunifuGradientPanel1.GradientBottomRight = theme["bottomright"];
            bunifuGradientPanel1.GradientTopLeft = theme["topleft"];
            bunifuGradientPanel1.GradientTopRight = theme["topright"];

            bunifuGradientPanel2.GradientBottomLeft = theme["bottomleft"];
            bunifuGradientPanel2.GradientBottomRight = theme["bottomright"];
            bunifuGradientPanel2.GradientTopLeft = theme["topleft"];
            bunifuGradientPanel2.GradientTopRight = theme["topright"];

            bunifuGradientPanel3.GradientBottomLeft = theme["bottomleft"];
            bunifuGradientPanel3.GradientBottomRight = theme["bottomright"];
            bunifuGradientPanel3.GradientTopLeft = theme["topleft"];
            bunifuGradientPanel3.GradientTopRight = theme["topright"];

            bunifuGradientPanel4.GradientBottomLeft = theme["bottomleft"];
            bunifuGradientPanel4.GradientBottomRight = theme["bottomright"];
            bunifuGradientPanel4.GradientTopLeft = theme["topleft"];
            bunifuGradientPanel4.GradientTopRight = theme["topright"];

            bunifuGradientPanel5.GradientBottomLeft = theme["bottomleft"];
            bunifuGradientPanel5.GradientBottomRight = theme["bottomright"];
            bunifuGradientPanel5.GradientTopLeft = theme["topleft"];
            bunifuGradientPanel5.GradientTopRight = theme["topright"];

            bunifuGradientPanel6.GradientBottomLeft = theme["bottomleft"];
            bunifuGradientPanel6.GradientBottomRight = theme["bottomright"];
            bunifuGradientPanel6.GradientTopLeft = theme["topleft"];
            bunifuGradientPanel6.GradientTopRight = theme["topright"];

            bunifuGradientPanel7.GradientBottomLeft = theme["bottomleft"];
            bunifuGradientPanel7.GradientBottomRight = theme["bottomright"];
            bunifuGradientPanel7.GradientTopLeft = theme["topleft"];
            bunifuGradientPanel7.GradientTopRight = theme["topright"];

            bunifuGradientPanel8.GradientBottomLeft = theme["bottomleft"];
            bunifuGradientPanel8.GradientBottomRight = theme["bottomright"];
            bunifuGradientPanel8.GradientTopLeft = theme["topleft"];
            bunifuGradientPanel8.GradientTopRight = theme["topright"];

            bunifuGradientPanel9.GradientBottomLeft = theme["bottomleft"];
            bunifuGradientPanel9.GradientBottomRight = theme["bottomright"];
            bunifuGradientPanel9.GradientTopLeft = theme["topleft"];
            bunifuGradientPanel9.GradientTopRight = theme["topright"];
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            Random r = new Random();
            //lets add asome templates
            Dictionary<string, Color> template = new Dictionary<string, Color>();

            template.Add("bottomleft", Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255)));
            template.Add("bottomright", Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255)));
            template.Add("topleft", Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255)));
            template.Add("topright", Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255)));

            load_theme(template);

            templates.Add(template);
        }
    }
}
