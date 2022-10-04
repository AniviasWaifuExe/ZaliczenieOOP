using DBLib;
using DBLib.Models;
using DBLib.Services;
using projectuwu.Windows;
using System;
using System.Windows;
using System.Windows.Controls;

namespace projectuwu.Views
{
    /// <summary>
    /// Logika i funckje dla UsersView.xaml
    /// pozwala dodawać i usuwać użytkowników
    /// </summary>
    public partial class Users : Page
    {
        private readonly UserService _service;
        /// <summary>
        /// Koncturktor widoku
        /// </summary>
        public Users()
        {
            InitializeComponent();
            _service = new UserService(new AppDbContextFactory());
            GetAllUsers();
        }
        /// <summary>
        /// Pobiera userów i wyświetla ich w liście
        /// </summary>
        public void GetAllUsers()
        {
            var items = _service.GetAll();
            UsersList.ItemsSource = items;
        }
        /// <summary>
        /// Zajmuje się wydarzeniem kliku przycisku do usuwania
        /// </summary>
        public void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            dynamic content = ((Button)sender).DataContext;
            var result = _service.RemoveByIdStatus(content.UserId);
            if (result)
            {
                MessageBox.Show("Usunięto użytkownika!");
                GetAllUsers();
            }
            else
            {
                MessageBox.Show("Nie można usunąć użytkownika!");
            }
        }
        /// <summary>
        /// Zajmuje się wydarzeniem kliku przycisku do aktualizowania
        /// </summary>
        public void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            dynamic content = ((Button)sender).DataContext;
            Window window = new UserUpdate(content.UserId, _service);
            window.Closed += new EventHandler(Refresh);
            window.Show();

        }

        private void Refresh(object sender, EventArgs e)
        {
            GetAllUsers();
        }
        /// <summary>
        /// Zajmuje się wydarzeniem kliku przycisku do odświeżania
        /// </summary>
        public void Refresh_Click(object sender, RoutedEventArgs e)
        {
            GetAllUsers();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(UserName.Text))
            {
                _service.AddAsync(new User() { UserName = UserName.Text });
                UserName.Text = null;
                GetAllUsers();
            }
        }
    }
}
