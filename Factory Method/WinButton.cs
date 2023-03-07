﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Factory_Method
{
    internal class WinButton : IButton
    {
        public string OnClick(string text)
        {
            return $"Win button clicked. Message: {text}";
        }

        public string Render()
        {
            return "Rendering Win button...";
        }
    }
}
