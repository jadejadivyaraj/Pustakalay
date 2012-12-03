using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pustakalay.Data;

namespace Pustakalay.BooksModule.ViewModels
{
    class MainContentViewModel : IMainContentViewModel
    {
        public MainContentViewModel()
        {
            Title = "123";
            test();
        }

        private void test()
        {
            PustakalayModelContainer apmc = new PustakalayModelContainer();
            Book abook = new Book(){Id = Guid.NewGuid()};
            apmc.Books.AddObject(abook);
            Title = abook.Id.ToString();
        }

        public string Title { get; set; }
    }
}
