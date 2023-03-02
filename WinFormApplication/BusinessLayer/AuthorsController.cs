using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormApplication.DataLayer;
using WinFormApplication.Models;

namespace WinFormApplication.BusinessLayer
{
    internal class AuthorsController
    {
        private AuthorsContext authCont = new AuthorsContext();
        public AuthorsController() { }

        public List<Author> GetAllAuthors()
        {
            return authCont.GetAllAuthors();
        }

        public bool AddAuthor(String name)
        {
            return authCont.AddAuthor(new Author { Name = name});
        }
    }
}
