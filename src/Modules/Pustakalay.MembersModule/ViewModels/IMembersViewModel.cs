using Pustakalay.Data;
using Pustakalay.Infrastructure;
using System.Collections.ObjectModel;
using System.Windows.Data;

namespace Pustakalay.MembersModule.ViewModels
{
    public interface IMembersViewModel:IViewModel
    {
        ObservableCollection<Member> MembersInternal { get;  }
        CollectionView Members { get; }
    }
}
