using DBLib.Models;
using DBLib.Services;
using System.Windows;


namespace projectuwu.Windows
{
    /// <summary>
    /// Interaction logic for CategoryUpdate.xaml
    /// allows to update categories
    /// </summary>
    public partial class CategoryUpdate : Window
    {
        private readonly CategoryService _service;
        private int Id;
        public CategoryUpdate(int id, CategoryService service)
        {
            InitializeComponent();
            Id = id;
            _service = service;
            GetById(Id);
        }

        private void GetById(int id)
        {
            var item = _service.GetById(id);
            Name.Text = item.Name;
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Name.Text))
            {
                Category category = _service.GetById(Id);
                category.Name = Name.Text;
                _service.Update(category);
                Close();
                MessageBox.Show("Edycja udana!");
            }
            else
            {
                MessageBox.Show("Nazwa nie może być pusta!");
            }
        }
    }
}
