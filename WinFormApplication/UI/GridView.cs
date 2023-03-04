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
using WinFormApplication.Models;

namespace WinFormApplication.UI
{
    public partial class AuthorDataGrid : Form
    {
        public delegate void dbUpdate();
        private List<Author> authorsList = new List<Author>();
        private AuthorsController authorsController = new AuthorsController();

        public AuthorDataGrid()
        {
            InitializeComponent();
            Rectangle screenSize = System.Windows.Forms.Screen.PrimaryScreen.Bounds;
            this.Location = new Point(screenSize.Width - this.Width, screenSize.Height - this.Height);
            authorsList = authorsController.GetAllAuthors();
            dgvAuthor.DataSource = authorsList;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
