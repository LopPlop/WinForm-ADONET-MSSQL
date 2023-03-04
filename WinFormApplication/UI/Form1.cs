using WinFormApplication.BusinessLayer;
using WinFormApplication.DataLayer;
using WinFormApplication.UI;

namespace WinFormApplication
{
    public partial class Form1 : Form
    {

        delegate void Update();
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            AuthorDataGrid authorDataGrid = new AuthorDataGrid();
            authorDataGrid.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string Name = textBox1.Text + " " + textBox2.Text+ " " + textBox3.Text;
            AuthorsController authorsController = new AuthorsController();
            authorsController.AddAuthor(Name);
            textBox1.Clear(); textBox2.Clear();  textBox3.Clear();

            pictureBox2.Visible = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            BookDataGrid bookDataGrid = new BookDataGrid();
            bookDataGrid.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var str = textBox5.Text;

            var booContr = new BooksController();

            booContr.AddAuthor(str);

            textBox5.Clear();

            pictureBox1.Visible = true;
        }
    }
}