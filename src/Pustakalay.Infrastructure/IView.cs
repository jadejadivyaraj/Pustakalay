﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pustakalay.Infrastructure
{
    public interface IView
    {
        IViewModel ViewModel { get; set; }
    }
}