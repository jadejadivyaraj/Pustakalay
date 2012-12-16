using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Pustakalay.Infrastructure;

namespace Pustakalay.Inventory.ViewModels
{
    class PurchaseBooksViewModel:ViewModelBase,IPurchaseBooksViewModel
    {
        private IEventAggregator _aggregator;

        public PurchaseBooksViewModel(IEventAggregator aggregator)
        {
            _aggregator = aggregator;
        }

       
        
    }
}
