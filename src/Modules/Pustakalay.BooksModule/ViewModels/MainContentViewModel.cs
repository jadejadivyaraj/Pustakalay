using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Pustakalay.Data;
using Pustakalay.Infrastructure;

namespace Pustakalay.BooksModule.ViewModels
{
    public class MainContentViewModel :ViewModelBase, IMainContentViewModel
    {
        public MainContentViewModel()
        {
            Title = "123";
            Initialize();
        }

        public void Initialize()
        {
            using ( PustakalayModelContainer apmc = new PustakalayModelContainer())
            {

                try
                {
                    Supplier aS = Supplier.CreateSupplier(Guid.NewGuid());
                    apmc.AddToSuppliers(aS);
                    apmc.SaveChanges();
                    Purchase aP = Purchase.CreatePurchase(Guid.NewGuid(), aS.Id);
                    apmc.AddToPurchases(aP);
                    apmc.SaveChanges();
                    Book abook = Book.CreateBook(Guid.NewGuid(), aP.Id);
                    apmc.AddToBooks(abook);
                    apmc.SaveChanges();
                    BookInfo bookInfo = BookInfo.CreateBookInfo(new Random().Next(1, 999999).ToString(),"Harry Potter","Jadeja");
                    apmc.AddToBookInfoes(bookInfo);
                    abook.Isbn = bookInfo.Isbn;
                    apmc.SaveChanges();
                    PurchaseDetail apd = PurchaseDetail.CreatePurchaseDetail(aP.Id, abook.Id, aS.Id,Guid.NewGuid());
                    apmc.AddToPurchaseDetails(apd);
                    //PurchaseDetail apd = new PurchaseDetail();
                    //apd.BookId = abook.Id;
                    //apd.Id = aP.Id;
                    //apd.SupplierId = aS.Id;
                    //apmc.PurchaseDetails.AddObject(apd);
                    apmc.SaveChanges();
                    //abook.BookInfo = bookInfo;
                    //abook.PurchaseDetails.Add(aPD);
                    //apmc.Books.AddObject(abook);
                    //apmc.SaveChanges();
                    Title = abook.Id.ToString()+ " added";
                }

                catch (System.Data.UpdateException e)
                {
                    var a = e.InnerException;
                    if (a.GetType() == typeof(SqlException))
                    {
                        //handles DB shits here
                        Title = e.Message + e.InnerException.Message;
                    }
                    
                }


                }
            //Title = Books.First().Id.ToString();
        }

        private void test()
        {
            PustakalayModelContainer apmc = new PustakalayModelContainer();
            Book abook = new Book(){Id = Guid.NewGuid()};
            apmc.Books.AddObject(abook);
            Title = abook.Id.ToString();
        }

        public string Title { get; set; }

        public IList<Book> Books { get; set; }

        
    }
}
