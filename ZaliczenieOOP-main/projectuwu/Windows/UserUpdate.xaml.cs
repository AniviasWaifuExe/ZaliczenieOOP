using DBLib.Models;
using DBLib.Services;
using System.Windows;


namespace projectuwu.Windows
{
    /// <summary>
    /// Interaction logic for UserUpdate.xaml
    /// allows to update users
    /// </summary>
    public partial class UserUpdate : Window
    {
        private readonly UserService _service;
        private readonly int Id;
        public UserUpdate(int id, UserService service)
        {
            InitializeComponent();
            Id = id;
            _service = service;
            GetById(Id);
        }

        private void GetById(int id)
        {
            var item = _service.GetById(id);
            Name.Text = item.UserName;
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Name.Text))
            {
                User user = _service.GetById(Id);
                user.UserName = Name.Text;
                _service.Update(user);
                this.Close();
                MessageBox.Show("Edit successfull!");
            }
            else
            {
                MessageBox.Show("Name cannot be empty!");
            }
        }
    }
}
