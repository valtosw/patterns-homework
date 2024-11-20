using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Patterns.Prototype
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    IFigure figure = new Rectangle(10, 20);
        //    IFigure clonedFigure = figure.Clone();
        //    figure.GetInfo();
        //    clonedFigure.GetInfo();

        //    figure = new Circle(15);
        //    clonedFigure = figure.Clone();
        //    figure.GetInfo();
        //    clonedFigure.GetInfo();

        //    figure = new Triangle(3, 4, 5);
        //    clonedFigure = figure.Clone();
        //    figure.GetInfo();
        //    clonedFigure.GetInfo();

        //    Console.Read();
        //}
    }
    interface IFigure
    {
        IFigure Clone();
        void GetInfo();
    }
    class Rectangle : IFigure
    {
        int width;
        int height;
        public Rectangle(int w, int h)
        {
            width = w;
            height = h;
        }
        public IFigure Clone()
        {
            return new Rectangle(width, height);
        }
        public void GetInfo()
        {
            Console.WriteLine("Rectangle with height {0} and width {1}", height, width);
        }
    }
    class Circle : IFigure
    {
        int radius;
        public Circle(int r)
        {
            radius = r;
        }
        public IFigure Clone()
        {
            return new Circle(radius);
        }
        public void GetInfo()
        {
            Console.WriteLine("Circle with radius {0}", radius);
        }
    }
    class Triangle : IFigure
    {
        int side1;
        int side2;
        int side3;

        public Triangle(int a, int b, int c)
        {
            if (!(a + b > c && a + c > b && b + c > a))
            {
                throw new ArgumentException("Triangle with such sides does not exist");
            }

            side1 = a;
            side2 = b;
            side3 = c;
        }
        public IFigure Clone()
        {
            return new Triangle(side1, side2, side3);
        }
        public void GetInfo()
        {
            Console.WriteLine("Triangle with sides {0}, {1}, {2}", side1, side2, side3);
        }
    }
}
