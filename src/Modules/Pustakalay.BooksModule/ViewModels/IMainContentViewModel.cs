using System.Collections.Generic;
using Pustakalay.Data;
using Pustakalay.Infrastructure;

namespace Pustakalay.BooksModule.ViewModels
{
    public interface IMainContentViewModel:IViewModel
    {
        IList<Book> Books { get; set; }
    }
}
