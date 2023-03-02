using WinFormApplication.BusinessLayer;
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
            string Name = textBox2.Text + textBox1.Text + textBox3.Text;
            AuthorsController authorsController = new AuthorsController();
            authorsController.AddAuthor(Name);
            Update();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}