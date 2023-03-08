using FactoryMethod.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod.Creator
{
    internal abstract class Dialog
    {
        public abstract IButton CreateButton();

        public string DoSomething(string text)
        {
            IButton button = CreateButton();
            return $"{button.Render()} ---> {button.OnClick(text)}";
        }
    }
}
