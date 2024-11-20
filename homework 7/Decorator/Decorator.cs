using System;

namespace Patterns.Decorator
{
    class MainApp
    {
        //static void Main()
        //{
        //    Tree christmasTree = new ConcreteTree();

        //    TreeWithOrnamentsDecorator treeWithOrnaments = new TreeWithOrnamentsDecorator();
        //    treeWithOrnaments.SetTree(christmasTree);
        //    treeWithOrnaments.AddOrnament("star");
        //    treeWithOrnaments.AddOrnament("candy cane");
        //    treeWithOrnaments.AddOrnament("tinsel");
        //    treeWithOrnaments.AddOrnament("angel");

        //    TreeWithLightsDecorator treeWithLights = new TreeWithLightsDecorator("blink");
        //    treeWithLights.SetTree(treeWithOrnaments);

        //    treeWithLights.Display();

        //    Console.ReadKey();
        //}
    }

    abstract class Tree
    {
        public abstract void Display();
    }

    class ConcreteTree : Tree
    {
        public override void Display()
        {
            Console.Write("Christmas Tree ");
        }
    }

    abstract class TreeDecorator : Tree
    {
        protected Tree tree;

        public void SetTree(Tree tree)
        {
            this.tree = tree;
        }

        public override void Display()
        {
            if (tree != null)
            {
                tree.Display();
            }
        }
    }

    class TreeWithOrnamentsDecorator : TreeDecorator
    {
        private List<string> ornaments = new List<string>();

        public void AddOrnament(string ornament)
        {
            ornaments.Add(ornament);
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine("with ornament:");
            foreach (var ornament in ornaments)
            {
                Console.WriteLine($"- {ornament}");
            }
        }
    }

    class TreeWithLightsDecorator : TreeDecorator
    {
        private string lightMode;

        public TreeWithLightsDecorator(string mode = "still")
        {
            lightMode = mode;
        }

        public override void Display()
        {
            base.Display();
            ToggleLights();
        }

        private void ToggleLights()
        {
            if (lightMode == "blink")
            {
                Console.WriteLine("blinking");
            }
            else
            {
                Console.WriteLine("glowing");
            }
        }
    }
}
