namespace Composite
{
    using System.ComponentModel;

    public class Element
    {
        protected string name;

        // Constructor
        public Element(string name)
        {
            this.name = name;
        }

//        public void Add(Component c);
//        public void Remove(Component c);
//        public void Display(int depth);
    }
}