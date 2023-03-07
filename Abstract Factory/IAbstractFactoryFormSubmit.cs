﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Abstract_Factory
{
    internal interface IAbstractFactoryFormSubmit
    {
        IButton CreateButton();
        ITextBox CreateTextBox();
    }
}
