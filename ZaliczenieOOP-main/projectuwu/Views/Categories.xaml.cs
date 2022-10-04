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
    /// Logika i funckje dla CategoriesView.xaml
    /// pozwala dodawać i usuwać kategorie
    /// </summary>
    public partial class Categories : Page
    {
        private readonly CategoryService _service;
        /// <summary>
        /// Konsturktor widoku
        /// </summary>
        public Categories()
        {
            InitializeComponent();
            _service = new CategoryService(new AppDbContextFactory());
            GetAllCategories();
        }
        /// <summary>
        /// Pobiera kategorie i wyświetla je w liście
        /// </summary>
        public void GetAllCategories()
        {
            var items = _service.GetAll();
            CategoriesList.ItemsSource = items;
        }

        /// <summary>
        /// Zajmuje się wydarzeniem kliku przycisku do usuwania
        /// </summary>
        public void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            dynamic content = ((Button)sender).DataContext;
            var result = _service.RemoveByIdStatus(content.CategoryId);
            if (result)
            {
                MessageBox.Show("Usunięto kategorię!");
                GetAllCategories();
            }
            else
            {
                MessageBox.Show("Nie można usunąć kategorii!");
            }
        }
        /// <summary>
        /// Zajmuje się wydarzeniem kliku przycisku do aktualizowania
        /// </summary>
        public void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            dynamic content = ((Button)sender).DataContext;
            Window window = new CategoryUpdate(content.CategoryId, _service);
            window.Closed += new EventHandler(Refresh);
            window.Show();

        }
        private void Refresh(object sender, EventArgs e)
        {
            GetAllCategories();
        }
        /// <summary>
        /// Zajmuje się wydarzeniem kliku przycisku do odświeżania
        /// </summary>
        public void Refresh_Click(object sender, RoutedEventArgs e)
        {
            GetAllCategories();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(CategoryName.Text))
            {
                _service.AddAsync(new Category() { Name = CategoryName.Text });
                CategoryName.Text = "";
                GetAllCategories();
            }
        }
    }
}
