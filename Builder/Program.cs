using Builder.ConcreteBuilder;
using Builder.Director;
using Builder.Product;
using System;
using System.Text;

namespace Builder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HouseBuilder builder = new HouseBuilder();
            NormalDirector director = new NormalDirector();
            director.Director(builder);
            House product= builder.GetProduct();
            Console.WriteLine(string.Join("\n-->", product.step));
        }
    }
}
