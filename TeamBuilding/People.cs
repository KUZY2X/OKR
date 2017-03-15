using System.Drawing;

namespace TeamBuilding
{
    public class People
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Activities { get; set; }

        public Bitmap Image { get; set; }

        public People(string name, int age, string activity, Bitmap bitmap)
        {
            Name = name;
            Age = age;
            Activities = activity;
            Image = bitmap;
        }
    }
}