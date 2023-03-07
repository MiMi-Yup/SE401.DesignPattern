using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Abstract_Factory
{
    internal class MacFormSubmit : IAbstractFactoryFormSubmit
    {
        public IButton CreateButton() => new MacButton();

        public ITextBox CreateTextBox() => new MacTextBox();
    }
}
