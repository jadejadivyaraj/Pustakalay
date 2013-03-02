using System.Collections.ObjectModel;
using System.Windows.Data;
using Pustakalay.Data;
using Pustakalay.Infrastructure;

namespace Pustakalay.InventoryModule.ViewModels
{
    public interface IInventoryViewModel:IViewModel
    {
        ObservableCollection<Book> BooksInternal { get; set; }
        CollectionView Books { get; set; }
        ObservableCollection<Purchase> Purchases { get;}
    }
}
