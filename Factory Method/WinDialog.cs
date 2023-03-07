using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Factory_Method
{
    internal class WinDialog : Dialog
    {
        public override IButton CreateButton()
        {
            return new WinButton();
        }
    }
}
