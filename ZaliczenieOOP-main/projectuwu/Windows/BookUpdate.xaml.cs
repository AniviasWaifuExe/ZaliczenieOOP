using DBLib.Models;
using DBLib.Services;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace projectuwu.Windows
{
    /// <summary>
    /// Interaction logic for BookUpdate.xaml
    /// Allows to update book and lend book to users
    /// </summary>
    public partial class BookUpdate : Window
    {
        private readonly BookService BookService;
        private readonly AuthorService AuthorService;
        private readonly CategoryService CategoryService;
        private readonly UserService UserService;
        List<Author> authors;
        List<Category> categories;
        List<User> users;
        Book book;

        public BookUpdate(Book book, BookService bookService, AuthorService authorService, CategoryService categoryService, UserService userService)
        {
            InitializeComponent();
            BookService = bookService;
            AuthorService = authorService;
            CategoryService = categoryService;
            UserService = userService;
            GetInitialData();
            this.book = book;
            GetById(book.BookId);

        }

        private void GetInitialData()
        {
            authors = AuthorService.GetAll();
            Author.ItemsSource = authors;
            categories = CategoryService.GetAll();
            Category.ItemsSource = categories;
            users = UserService.GetAll();
            Borrower.ItemsSource = users;
        }
        private void GetById(int id)
        {
            book = BookService.GetById(id);

            if (book != null)
            {
                Name.Text = book.Title;
            }
        }

        private void CategoryDropdown_Loaded(object sender, RoutedEventArgs e)
        {
            var cb = (ComboBox)sender;
            cb.SelectedItem = cb.Items.OfType<dynamic>().FirstOrDefault(tb => tb.CategoryId == book.CategoryId);
        }

        private void AuthorDropdown_Loaded(object sender, RoutedEventArgs e)
        {
            var cb = (ComboBox)sender;
            cb.SelectedItem = cb.Items.OfType<dynamic>().FirstOrDefault(tb => tb.AuthorId == book.AuthorId);
        }
        private void BorrowerDropdown_Loaded(object sender, RoutedEventArgs e)
        {
            var cb = (ComboBox)sender;
            //int userId = Book.UserId ?? 0;
            cb.SelectedItem = cb.Items.OfType<dynamic>().FirstOrDefault(tb => tb.UserId == book.UserId);
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            Author selectedAuthor = (Author)Author.SelectedItem;
            Category selectedCategory = (Category)Category.SelectedItem;

            if (selectedAuthor != null && selectedCategory != null && !string.IsNullOrEmpty(Name.Text))
            {
                Book dbBook = BookService.GetById(book.BookId);
                dbBook.Title = Name.Text;
                dbBook.CategoryId = selectedCategory.CategoryId;
                dbBook.Category = null;
                dbBook.AuthorId = selectedAuthor.AuthorId;
                dbBook.Author = null;
                BookService.Update(dbBook);
                MessageBox.Show("Book updated!");
                Close();
            }
        }

        private void Borrow_Click(object sender, RoutedEventArgs e)
        {
            User selectedUser = (User)Borrower.SelectedItem;
            if (selectedUser != null && selectedUser.UserId != book.UserId)
            {
                Book dbBook = BookService.GetById(book.BookId);
                dbBook.UserId = selectedUser.UserId;
                dbBook.User = null;
                BookService.Update(dbBook);
                MessageBox.Show("Pożyczający zmieniony!");
                Close();
            }
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {

            Book dbBook = BookService.GetById(book.BookId);
            if (dbBook.UserId != null)
            {
                dbBook.UserId = null;
                dbBook.User = null;
                BookService.Update(dbBook);
                MessageBox.Show("Książka zwrócona!");
                Close();
            }
        }


    }
}
