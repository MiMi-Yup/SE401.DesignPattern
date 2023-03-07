using DesignPattern.Abstract_Factory;
using DesignPattern.Factory_Method;
using System;

namespace DesignPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ExampleFactoryMethod();
            ExampleAbstractFactory();
        }

        static void ExampleAbstractFactory()
        {
            string arg = "mac";
            IAbstractFactoryFormSubmit formSubmit = null;

            switch (arg)
            {
                case "mac":
                    formSubmit = new MacFormSubmit();
                    break;
                case "win":
                    formSubmit = new WinFormSubmit();
                    break;
            }

            if (formSubmit != null)
            {
                Abstract_Factory.IButton button = formSubmit.CreateButton();
                Abstract_Factory.ITextBox textbox = formSubmit.CreateTextBox();

                Console.WriteLine(button.Render());
                Console.WriteLine(textbox.Render());
                Console.WriteLine(textbox.OnTextChange("Yoh"));
                Console.WriteLine(button.OnClick("Submit"));
            }
        }

        static void ExampleFactoryMethod()
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
