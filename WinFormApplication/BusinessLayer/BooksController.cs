using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormApplication.DataLayer;
using WinFormApplication.Models;

namespace WinFormApplication.BusinessLayer
{
    class BooksController
    {
        private BookContext bookCont = new BookContext();
        public BooksController() { }

        public List<Book> GetAllAuthors()
        {
            return bookCont.GetAllBooks();
        }

        public bool AddAuthor(String name)
        {
            return bookCont.AddBook(new Book { Name = name });
        }
    }
}
