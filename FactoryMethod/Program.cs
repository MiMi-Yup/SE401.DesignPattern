using FactoryMethod.ConcreteCreator;
using FactoryMethod.Creator;
using System;

namespace FactoryMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string arg = "win";
            Dialog dialog = null;

            switch (arg)
            {
                case "mac":
                    dialog = new MacDialog();
                    break;
                case "win":
                    dialog = new WinDialog();
                    break;
            }

            if (dialog != null)
            {
                Console.WriteLine(dialog.DoSomething("Yoh"));
            }
        }
    }
}
