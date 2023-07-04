using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Yapılacakİsler
{
    public partial class Form1 : Form
    {
        DbTodoListContext db = new DbTodoListContext();
        public Form1()
        {
            InitializeComponent();
            Listele();


        }

        private void Listele()
        {
            clbToDos.Items.Clear();
            foreach (var item in db.ToDoItems.OrderBy(x => x.Done))
            {
                clbToDos.Items.Add(item, item.Done);
            }
            clbToDos.DisplayMember = "Title";

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text.Trim();
            if (title == "")
                return;
            ToDoItem newItem = new ToDoItem() { Title = title, Done = false };
            db.ToDoItems.Add(newItem);
            db.SaveChanges();

            Listele();
        }
    }
}