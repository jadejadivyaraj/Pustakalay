using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Windows.Data;
using Microsoft.Practices.Prism.Commands;
using Pustakalay.Data;
using Pustakalay.Infrastructure;

namespace Pustakalay.InventoryModule.ViewModels
{
	public class InventoryViewModel : ViewModelBase, IInventoryViewModel
	{
	   private readonly PustakalayModelContext _ctx = new PustakalayModelContext();

		private ObservableCollection<Book> _booksInternal;

		private CollectionView _books;

		private ObservableCollection<Purchase> _purchases;

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

		public ObservableCollection<Purchase> Purchases { get; private set; }

		public DelegateCommand AddCommand { get; set; }

		public DelegateCommand SaveCommand { get; set; }

		public DelegateCommand DeleteCommand { get; set; }

		public InventoryViewModel()
		{
			AddCommand = new DelegateCommand(OnAdd, CanAdd);
			SaveCommand = new DelegateCommand(OnSave, CanSave);
			DeleteCommand = new DelegateCommand(OnDelete,CanDelete);
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
			InitializePurchase();

		}

		private void InitializePurchase()
		{
			_ctx.Purchases.Include(p=>p.PurchaseItems).Include(p=>p.PurchaseItems.Books).Load();
		    Purchases = _ctx.Purchases.Local;
		}
		
		private bool CanSave()
		{
			return true;
		}

		private void OnSave()
		{
			try
			{
				_ctx.SaveChanges();
			}
			catch (DbEntityValidationException dbEx)
			{
				foreach (var validationErrors in dbEx.EntityValidationErrors)
				{
					foreach (var validationError in validationErrors.ValidationErrors)
					{
						Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
					}
				}
			}
		}

		private void OnAdd()
		{
			//var aBook = new Book
			//    {
			//        Isbn = 1111111111111,
			//        Details = new BookInfo {Publisher = new Publisher(), Author = new Author()},
			//        PurchaseItem = new PurchaseItems()
			//    };
			//_ctx.Books.Add(aBook);
			var aAut = new Author { FirstName = "<Enter First Name>", LastName = "<Enter Last Name>" };
			var aPub = new Publisher {  Name="<Enter Publisher>"};
			var aBookInfo = new BookInfo { Title = "<Enter Title>", Author = aAut, Publisher = aPub, Isbn = 1};
			var aPur = new Purchase { Date = DateTime.Now, Id=Guid.NewGuid()};
			var aPi = new PurchaseItems { Id = aPur.Id, Purchase = aPur };
			//var abi = _ctx.BookInfoes.Find(aBookInfo.Isbn);
			//if (abi == null) _ctx.BookInfoes.Add(aBookInfo);
			//abi = _ctx.BookInfoes.Find(aBookInfo.Isbn);
			var aBook = new Book { Id = Guid.NewGuid(), Details = aBookInfo, Earning = 0, PurchaseItem = aPi };
		   _ctx.Books.Add(aBook);
			_books.MoveCurrentTo(aBook);
		}

		private bool CanAdd()
		{
			return true;
		}

		private bool CanDelete()
		{
			return true;
		}

		private void OnDelete()
		{
			var aBook = _books.CurrentItem as Member;
			if(aBook!=null)
				_ctx.Members.Remove(aBook);
		}
	}
}
