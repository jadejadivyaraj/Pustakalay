using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.Events;

namespace Pustakalay.Infrastructure
{
    public class LayoutChangeEvent:CompositePresentationEvent<string>
    {
    }
}
