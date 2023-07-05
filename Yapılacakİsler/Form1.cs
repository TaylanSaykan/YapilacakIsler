using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Windows.Forms;

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
            clbToDos.ItemCheck -= clbToDos_ItemCheck!;
            foreach (var item in db.ToDoItems.Where(x => !x.Deleted).OrderBy(x => x.Done))
            {
                clbToDos.Items.Add(item, item.Done);
            }
            clbToDos.DisplayMember = "Title";
            clbToDos.ItemCheck += clbToDos_ItemCheck!;

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

        private void clbToDos_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Indeterminate) { return; }
            ToDoItem selectedTodoItem = (ToDoItem)clbToDos.Items[e.Index];
            bool yeniDurum = e.NewValue == CheckState.Checked;
            selectedTodoItem.Done = yeniDurum;
            db.SaveChanges();
            BeginInvoke(Listele);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (clbToDos.SelectedIndex == -1) return;

            ToDoItem selectedToDoItem = (ToDoItem)clbToDos.SelectedItem;
            db.Remove(selectedToDoItem);
            db.SaveChanges();
            Listele();
        }
    }
}