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
    /// Logika i funckje dlaBooksView.xaml
    /// pozwala dodawać i usuwać ksiązki z kategoriami, autorami i tytułem
    /// </summary>
    public partial class Books : Page
    {
        private readonly BookService BookService;
        private readonly AuthorService AuthorService;
        private readonly CategoryService CategoryService;
        private readonly UserService UserService;
        /// <summary>
        /// Konsturktor widoku
        /// </summary>
        public Books()
        {
            InitializeComponent();
            BookService = new BookService(new AppDbContextFactory());
            AuthorService = new AuthorService(new AppDbContextFactory());
            CategoryService = new CategoryService(new AppDbContextFactory());
            UserService = new UserService(new AppDbContextFactory());
            GetInitialItems();
        }
        /// <summary>
        /// Pobiera książki z autorami i kategoriami
        /// </summary>
        public void GetInitialItems()
        {
            LoadBooks();
            var authors = AuthorService.GetAll();
            Author.ItemsSource = authors;
            var categories = CategoryService.GetAll();
            Category.ItemsSource = categories;
        }
        private void LoadBooks()
        {
            var items = BookService.GetAll();
            BooksList.ItemsSource = items;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Author selectedAuthor = (Author)Author.SelectedItem;
            Category selectedCategory = (Category)Category.SelectedItem;

            if (!string.IsNullOrEmpty(BookName.Text) && selectedAuthor != null && selectedCategory != null)
            {
                var book = new Book() { Title = BookName.Text, AuthorId = selectedAuthor.AuthorId, CategoryId = selectedCategory.CategoryId };
                BookService.AddAsync(book);
                ClearInput();
                LoadBooks();
            }
            else
            {
                MessageBox.Show("Error, fix data!");
            }
        }
        /// <summary>
        /// Czyszenie pola do wpisywania tekstu
        /// </summary>
        public void ClearInput()
        {
            Author.SelectedItem = null;
            Category.SelectedItem = null;
            BookName.Text = null;
        }
        /// <summary>
        /// Zajmuje się wydarzeniem kliku przycisku do aktualizowania
        /// </summary>
        public void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            dynamic content = ((Button)sender).DataContext;
            Window window = new BookUpdate(content, BookService, AuthorService, CategoryService, UserService);
            window.Closed += new EventHandler(Refresh);
            window.Show();
        }
        /// <summary>
        /// Zajmuje się wydarzeniem kliku przycisku do usuwania
        /// </summary>
        public void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            dynamic content = ((Button)sender).DataContext;
            BookService.RemoveById(content.BookId);
            LoadBooks();
        }
        /// <summary>
        /// Zajmuje się wydarzeniem kliku przycisku do odświeżania
        /// </summary>
        public void Refresh_Click(object sender, RoutedEventArgs e)
        {
            LoadBooks();
        }
        private void Refresh(object sender, EventArgs e)
        {
            LoadBooks();
        }
    }

}
