using Pustakalay.Data;
using Pustakalay.Infrastructure;
using Microsoft.Practices.Prism.Commands;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Windows.Data;

namespace Pustakalay.BooksModule.ViewModels
{
	public class MainContentViewModel :ViewModelBase, IMainContentViewModel
	{
		private readonly PustakalayModelContext _ctx = new PustakalayModelContext();

		private ObservableCollection<Book> _booksInternal;

		private CollectionView _books;

		public ObservableCollection<Book> BooksInternal
		{
			get { return _booksInternal ?? (_booksInternal = new ObservableCollection<Book>()); }
			set
			{
				_booksInternal = value;
			}
		}

		public CollectionView Books
		{
			get { return _books ?? (_books = new CollectionView(_booksInternal)); }
		    set { _books = value; }
		}

		public DelegateCommand AddCommand { get; set; }

		public DelegateCommand SaveCommand { get; set; } 
		
		public MainContentViewModel()
		{
			AddCommand = new DelegateCommand(OnAdd, CanAdd);
			SaveCommand = new DelegateCommand(OnSave, CanSave);
			Initialize();
			
		}

		public void Initialize()
		{


			//Author aAut = new Author() { FirstName = "Jithendra", LastName = "Bhat", Id = 2 };
			//Publisher aPub = new Publisher() { Id=2, Name="Jit Publication"};
			//BookInfo aBookInfo = new BookInfo() { Title="Introduction to C#", Isbn=123456789013,Author=aAut,Publisher=aPub};
			//Purchase aPur = new Purchase() { Date = DateTime.Now, Id=Guid.NewGuid()};
			//PurchaseItems aPI = new PurchaseItems() { Id = aPur.Id, Purchase = aPur };
			//Book aBook = new Book() { Id = Guid.NewGuid(), Details = aBookInfo, Earning = 0, PurchaseItem = aPI };

			//ctx.Books.Add(aBook);
			//ctx.SaveChanges();
			_ctx.Books.Include(p => p.Details).Include(p => p.Details.Author).Include(p => p.Details.Publisher).Load();
			_booksInternal = _ctx.Books.Local;

		}
		
		private bool CanSave()
		{
			return true;
		}

		private void OnSave()
		{
			_ctx.SaveChanges();
		}

		private void OnAdd()
		{
			var aBook = new Book
				{
					Isbn = 1111111111111,
					Details = new BookInfo {Publisher = new Publisher(), Author = new Author()},
					PurchaseItem = new PurchaseItems()
				};
			_ctx.Books.Add(aBook);
		}

		private bool CanAdd()
		{
			return true;
		}

	}
}
