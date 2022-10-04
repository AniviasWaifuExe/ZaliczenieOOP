using DBLib.Services;
using DBLib;
using System;
using System.Windows;
using System.Windows.Controls;
using DBLib.Models;
using projectuwu.Windows;

namespace projectuwu.Views
{
    /// <summary>
    /// Logika interakcji dla klasy Authors.xaml
    /// </summary>
    public partial class Authors : Page
    {
        private readonly AuthorService _service;
        /// <summary>
        /// Konsturktor widoku
        /// </summary>
        public Authors()
        {
            InitializeComponent();
            _service = new AuthorService(new AppDbContextFactory());
            GetAllAuthors();
        }

        /// <summary>
        /// Pobiera autorów i wyświetla je w liście
        /// </summary>
        public void GetAllAuthors()
        {
            var items = _service.GetAll();
            AuthorsList.ItemsSource = items;
        }
        /// <summary>
        /// Zajmuje się wydarzeniem kliku przycisku do usuwania
        /// </summary>
        public void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            dynamic content = ((Button)sender).DataContext;
            var result = _service.RemoveByIdStatus(content.AuthorId);
            if (result)
            {
                MessageBox.Show("Usunięto autora!");
                GetAllAuthors();
            }
            else
            {
                MessageBox.Show("Nie można usunąć autora!");
            }
        }
        /// <summary>
        /// Zajmuje się wydarzeniem kliku przycisku do aktualizowania
        /// </summary>
        public void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            dynamic content = ((Button)sender).DataContext;
            Window window = new AuthorUpdate(content.AuthorId, _service);
            window.Closed += new EventHandler(Refresh);
            window.Show();

        }

        private void Refresh(object sender, EventArgs e)
        {
            GetAllAuthors();
        }
        /// <summary>
        /// Zajmuje się wydarzeniem kliku przycisku do odświeżania
        /// </summary>
        public void Refresh_Click(object sender, RoutedEventArgs e)
        {
            GetAllAuthors();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(AuthorName.Text))
            {
                _service.AddAsync(new Author() { AuthorName = AuthorName.Text });
                AuthorName.Text = null;
                GetAllAuthors();
            }
        }
    }
}
