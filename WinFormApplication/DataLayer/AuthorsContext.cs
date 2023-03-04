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

    internal class AuthorsContext
    {
        private string _connectionString;
        public AuthorsContext() 
        {
            _connectionString = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
        }

        public List<Author> GetAllAuthors()
        {
            return GetAllAuthors(0);
        }
        
        public List<Author> GetAllAuthors(int Id)
        {
            List<Author> listAuthor = new List<Author>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string proc = "[dbo].[AuthorGetAll]";
                SqlCommand sqlCommand = new SqlCommand( proc,  conn );
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter par = new SqlParameter("@Id", Id);
                sqlCommand.Parameters.Add(par);

                conn.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var author = new Author();

                    author.Id = reader.GetInt32("Id");
                    author.Name = reader.GetString("Name");

                    listAuthor.Add(author);
                }
                reader.Close();
                conn.Close();
            }
            return listAuthor;
        }

        public Author? GetAuthorById(int id)
        {
            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString))
            {
                string proc = "GetAuthorsById";
                SqlCommand sqlCommand = new SqlCommand(proc, conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter par = new SqlParameter("@Id", id);
                sqlCommand.Parameters.Add(par);

                conn.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                var author = new Author();
                if (reader.Read())
                {
                    author.Id = reader.GetInt32("Id");
                    author.Name = reader.GetString("Name");
                }
                reader.Close();
                conn.Close();
                return author;
            }
        }

        public Author? GetAuthorByName(string name)
        {
            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString))
            {
                string proc = "GetAuthorsByName";
                SqlCommand sqlCommand = new SqlCommand(proc, conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter par = new SqlParameter("@Name", name);
                sqlCommand.Parameters.Add(par);

                conn.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                var author = new Author();
                if (reader.Read())
                {
                    author.Id = reader.GetInt32("Id");
                    author.Name = reader.GetString("Name");
                }
                reader.Close();
                conn.Close();
                return author;
            }
        }

        public bool AddAuthor(Author author)
        {
            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString))
            {
                string proc = "AuthorInsert";
                SqlCommand sqlCommand = new SqlCommand(proc, conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter par = new SqlParameter("@autor_name", author.Name);
                sqlCommand.Parameters.Add(par);

                conn.Open();
                bool isOk = sqlCommand.ExecuteReader().HasRows;
                conn.Close();
                return isOk;
            }
        }

        public bool DeleteAuthor(Author author)
        {
            int id = author.Id;
            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString))
            {
                string proc = "AuthorDelete";
                SqlCommand sqlCommand = new SqlCommand(proc, conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter par = new SqlParameter("@Id", id);
                sqlCommand.Parameters.Add(par);

                conn.Open();
                bool res = sqlCommand.ExecuteReader().HasRows;
                conn.Close();
                return res;
            }
        }

        public bool UpdateAuthor(Author ex_Author, Author new_Author)
        {
            int id = ex_Author.Id;
            string? name = new_Author.Name;
            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString))
            {
                string proc = "AuthorUpdate";
                SqlCommand sqlCommand = new SqlCommand(proc, conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter par = new SqlParameter("@Id", id);
                SqlParameter par1 = new SqlParameter("@Name", name);
                sqlCommand.Parameters.Add(par);
                sqlCommand.Parameters.Add(par1);




                conn.Open();
                bool res = sqlCommand.ExecuteReader().HasRows;
                conn.Close();
                return res;
            }
        }
    }
}
