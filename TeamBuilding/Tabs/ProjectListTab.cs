using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TeamBuilding.Tabs
{
    public partial class ProjectListTab : UserControl
    {
        private List<People> _people;
        private List<PictureBox> _pictureBoxes;
        private readonly int _gap = 200;
        private readonly int _width = 50;
        private readonly int _height = 100;
        private Bitmap _bitmap;

        public ProjectListTab()
        {
            InitializeComponent();
        }

        public void CreatePlates()
        {
            var counter = _people.Count;
            var enter = 0;
            var i = 1;

            while (counter > 0)
            {
                var pictureBox = new PictureBox
                {
                    Size = new Size(_width, _height),
                    BorderStyle = BorderStyle.FixedSingle
                };

                if (_width + _gap * (i - 1) > ClientSize.Width)
                {
                    enter += _gap;
                    i = 1;
                }

                pictureBox.Location = new Point(_width + _gap * (i - 1), _height + enter);

                var bitMap = new Bitmap(pictureBox.Size.Width, pictureBox.Size.Height);
                var graphics = Graphics.FromImage(bitMap);

                graphics.DrawEllipse(Pens.Blue, bitMap.Width / 4, bitMap.Height / 4, bitMap.Width * 3 / 4, bitMap.Height * 3 / 4);
                pictureBox.Image = bitMap;
                _bitmap = bitMap;
                pictureBox.Name = $"pb{_people.Count - counter + 1}";
                Controls.Add(pictureBox);
                _pictureBoxes.Add(pictureBox);

                i++;
                counter--;
            }
        }

        private void ProjectListTab_Load(object sender, System.EventArgs e)
        {
            _people = new List<People>();
            _pictureBoxes = new List<PictureBox>();

            _people.Add(new People("KURWA1", 1, "KURWA1", _bitmap));
            _people.Add(new People("KURWA2", 2, "KURWA2", _bitmap));
            _people.Add(new People("KURWA3", 3, "KURWA3", _bitmap));
            CreatePlates();

            for (int i = 0; i < _people.Count; i++)
            {
                _people[i].Image = new Bitmap(_pictureBoxes[i].Image);
            }

            foreach (Control p in this.Controls)
            {
                if (p is PictureBox)
                    p.MouseClick += new MouseEventHandler(PictureBox_MouseClick);
            }
        }

        public void PictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            var c = (Control)sender;
            for (int i = 0; i < _pictureBoxes.Count; i++)
            {
                if (_pictureBoxes[i].Name == c.Name)
                {
                    Form2._currentControl.Visible = false;
                    Form2._projectControl = new ProjectTab(_people[i]);
                    Form2._projectControl.Visible = true;
                    Form2._currentControl = Form2._projectControl;
                }
            }
        }
    }
}