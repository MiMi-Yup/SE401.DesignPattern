﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Abstract_Factory
{
    internal class MacButton : IButton
    {
        public string OnClick(string text)
        {
            return $"Mac button clicked. Message: {text}";
        }

        public string Render()
        {
            return "Rendering Mac button...";
        }
    }
}
