using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace teamdevelopment
{
    public class People
    {
        private string _name;
        private string _activiies;

        public string Name {
            get { return _name; }
            set { _name = value.ToString(); }
        }

        public int Age { get; set; }
        public string Activities
        {
            get { return _activiies; }
            set { _activiies = value.ToString(); }
        }

        public Bitmap Image { get; set; }

        public People(string n, int a, string act,Bitmap bm)
        {
            Name = n;
            Age = a;
            Activities = act;
            Image = bm;
        }
    }
}
