using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormApplication.Models;

namespace WinFormApplication.DataLayer
{
    class BookContext
    {
        private string _connectionString;
        public BookContext()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
        }

        public List<Book> GetAllBooks()
        {
            List<Book> listBooks = new List<Book>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string proc = "[dbo].[BookGetAll]";
                SqlCommand sqlCommand = new SqlCommand(proc, conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var book = new Book();

                    book.Id = reader.GetInt32("book_id");
                    book.Name = reader.GetString("book_name");

                    listBooks.Add(book);
                }
                reader.Close();
                conn.Close();
            }
            return listBooks;
        }

        public bool AddBook(Book book)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string proc = "[dbo].[BookInsert]";
                SqlCommand sqlCommand = new SqlCommand(proc, conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                var sqlcom = new SqlParameter("@book_name", book.Name);
                sqlCommand.Parameters.Add(sqlcom);

                conn.Open();
                bool isOk = sqlCommand.ExecuteReader().HasRows;
                conn.Close();
                return isOk;
            }
        }

    }
}

