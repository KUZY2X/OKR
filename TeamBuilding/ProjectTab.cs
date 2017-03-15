using System.Windows.Forms;

namespace TeamBuilding
{
    public partial class ProjectTab : UserControl
    {
        public ProjectTab(People people)
        {
            InitializeComponent();
            pictureBox1.Image = people.Image;
            label1.Text = people.Name;
            richTextBox1.Text = $"Age: {people.Age}\nActivities: {people.Activities}";
        }

        public ProjectTab()
        {
            InitializeComponent();
        }
    }
}