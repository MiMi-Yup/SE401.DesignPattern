using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Factory_Method
{
    internal interface IButton
    {
        string Render();
        string OnClick(string text);
    }
}
