using Pustakalay.Data;
using Pustakalay.Infrastructure;
using System.Collections.ObjectModel;
using System.Windows.Data;

namespace Pustakalay.BooksModule.ViewModels
{
    public interface IMainContentViewModel:IViewModel
    {
        ObservableCollection<Book> BooksInternal { get; set; }
        CollectionView Books { get; set; }
    }
}
