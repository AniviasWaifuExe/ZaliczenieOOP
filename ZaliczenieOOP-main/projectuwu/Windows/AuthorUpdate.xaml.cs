using DBLib.Models;
using DBLib.Services;

using System.Windows;


namespace projectuwu.Windows
{
    /// <summary>
    /// Interaction logic for AuthorUpdate.xaml
    /// </summary>
    public partial class AuthorUpdate : Window
    {
        private readonly AuthorService _service;
        private readonly int Id;
        public AuthorUpdate(int id, AuthorService service)
        {
            InitializeComponent();
            Id = id;
            _service = service;
            GetById(Id);
        }

        private void GetById(int id)
        {
            var item = _service.GetById(id);
            Name.Text = item.AuthorName;
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Name.Text))
            {
                Author author = _service.GetById(Id);
                author.AuthorName = Name.Text;
                _service.Update(author);
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
