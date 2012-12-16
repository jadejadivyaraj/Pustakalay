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
                    Book abook = new Book();
                    abook.Id = Guid.NewGuid();
                    abook.Title = "TBBT";
                    abook.Isbn = "1234567";
                    abook.BookInfo = BookInfo.CreateBookInfo(new Random().Next(1,999999).ToString(), "TBBT", "aTBBTAuthor");
                    apmc.AddToBooks(abook);
                    apmc.SaveChanges();
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
