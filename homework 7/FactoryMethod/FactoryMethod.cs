using System;

namespace Patterns.FactoryMethod
{
    public abstract class DocumentCreator
    {
        public abstract Document FactoryMethod(int type);
    }

    public class ConcreteDocumentCreator : DocumentCreator
    {
        public override Document FactoryMethod(int type)
        {
            switch (type)
            {
                case 1:
                    return new Report();
                case 2:
                    return new Letter();
                default:
                    throw new ArgumentException("Invalid type.", nameof(type));
            }
        }
    }

    public abstract class Document
    {
        public abstract void Print();
    }

    public class Report : Document
    {
        public override void Print()
        {
            Console.WriteLine("Report Created ");
        }
    }

    public class Letter : Document
    {
        public override void Print()
        {
            Console.WriteLine("Letter Created ");
        }
    }

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        DocumentCreator creator = new ConcreteDocumentCreator();

    //        Document doc1 = creator.FactoryMethod(1);
    //        doc1.Print();

    //        Document doc2 = creator.FactoryMethod(2);
    //        doc2.Print();

    //        Console.ReadKey();
    //    }
    //}
}
