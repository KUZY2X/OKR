using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace teamdevelopment
{
    public partial class Form1 : Form
    {
        private List<People> people;
        private List<PictureBox> pictureBoxs;
        private readonly int gap = 200;
        private readonly int width = 50;
        private readonly int height = 100;

        public Form1()
        {
            InitializeComponent();
        }

        private Bitmap b;

        void CreatePlates()
        {
            var counter = people.Count;
            var enter = 0;
            var i = 1;
            while (counter > 0)
            {
                var pb = new PictureBox {Size = new Size(width, height)};
                pb.BorderStyle = BorderStyle.FixedSingle;
                if (width + gap * (i - 1) > ClientSize.Width)
                {
                    enter += gap;
                    i = 1;
                }
                pb.Location = new Point(width + gap * (i - 1), height + enter);
                var bm = new Bitmap(pb.Size.Width, pb.Size.Height);
                var g = Graphics.FromImage(bm);
                g.DrawEllipse(Pens.Blue, bm.Width / 4, bm.Height / 4, bm.Width * 3 / 4, bm.Height * 3 / 4);
                pb.Image = bm;
                b = bm;
                pb.Name = $"pb{people.Count - counter + 1}";
                Controls.Add(pb);
                pictureBoxs.Add(pb);
                i++;
                counter--;
            }

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            people = new List<People>();
            pictureBoxs = new List<PictureBox>();
            people.Add(new People("KURWA", 3, "KURWA", b));
            people.Add(new People("KURWA", 3, "KURWA", b));
            people.Add(new People("KURWA", 3, "KURWA", b));
            people.Add(new People("KURWA", 3, "KURWA", b));
            people.Add(new People("KURWA", 3, "KURWA", b));
            people.Add(new People("KURWA", 3, "KURWA", b));
            people.Add(new People("KURWA", 3, "KURWA", b));
            people.Add(new People("KURWA", 3, "KURWA", b));
            people.Add(new People("KURWA", 3, "KURWA", b));
            people.Add(new People("KURWA", 3, "KURWA", b));
            people.Add(new People("KURWA", 3, "KURWA", b));
            people.Add(new People("KURWA", 3, "KURWA", b));
            people.Add(new People("KURWA", 3, "KURWA", b));
            people.Add(new People("KURWA", 3, "KURWA", b));
            people.Add(new People("KURWA", 3, "KURWA", b));
            CreatePlates();
            for (int i = 0; i < people.Count; i++)
            {
                people[i].Image = new Bitmap(pictureBoxs[i].Image);
            }
            foreach (Control p in this.Controls)
            {
                if (p is PictureBox)
                    p.MouseClick += new MouseEventHandler(PictureBox_MouseClick);
            }

        }

        /// <summary>
        /// attcount in the cycle - number of lines in RichTextBox (attributes of people)
        /// </summary>
        public void PictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            var c = (Control) sender;
            for (int i = 0; i < pictureBoxs.Count; i++)
            {
                if (pictureBoxs[i].Name == c.Name)
                {
                    Info info = new Info(people[i]);
                    info.ShowDialog();
                }
            }
        }
    }
}
