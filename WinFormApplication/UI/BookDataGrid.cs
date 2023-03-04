using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormApplication.BusinessLayer;
using WinFormApplication.DataLayer;
using WinFormApplication.Models;

namespace WinFormApplication.UI
{
    public partial class BookDataGrid : Form
    {
        private List<Book> booksList = new List<Book>();
        private BookContext booksController = new BookContext();
        public BookDataGrid()
        {
            InitializeComponent();
            Rectangle screenSize = System.Windows.Forms.Screen.PrimaryScreen.Bounds;
            this.Location = new Point(screenSize.Width - this.Width, screenSize.Height - this.Height);
            booksList = booksController.GetAllBooks();
            dataGridView1.DataSource = booksList;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
