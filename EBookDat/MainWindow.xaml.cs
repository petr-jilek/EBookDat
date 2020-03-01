using System;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using EBookDat;
using System.Windows.Input;
using System.Linq;
using System.Collections.Generic;
using EBookDat.Models.Items;
using EBookDat.View;
using System.Globalization;
using System.Collections.ObjectModel;

namespace EBookDat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Database database;

        public MainWindow() {
            InitializeComponent();
            database = new Database();
            database.LoadAllFromXML();
            AddWKDEvents();
            DataContext = database.bookManager;
            FormateSortSettingsItemsAndUpDownButtons();
            FormateComboBoxes();
            database.bookManager.DuringAction();
            database.clone.MakeClone();
        }

        #region SetComponents

        private void AddWKDEvents() {
            database.bookManager.Action += AddSearchingItems;
            Closing += OnWindowClosing;
            this.KeyDown += new KeyEventHandler(MainWindow__KeyPushed);
        }
        private void MainWindow__KeyPushed(object sender, KeyEventArgs e) {
            switch (e.Key) {
                case Key.Delete:
                    DeleteButton_Click(sender, e);
                    break;
                case Key.Enter:
                    EditButton_Click(sender, e);
                    break;
                case Key.S:
                    if (e.Key == Key.S && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control) SaveMenuItem_Click(sender, e);
                    break;
                case Key.A:
                    if (e.Key == Key.A && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
                        booksListBox.SelectAll();
                    break;
            }
        }

        public void FormateSortSettingsItemsAndUpDownButtons() {
            ownSortBooksMenuItem.IsChecked = database.settings.SortBooks;
            ownSortEditionsMenuItem.IsChecked = database.settings.SortEditions;
            ownSortGenresMenuItem.IsChecked = database.settings.SortGenres;
            upDownStackPanel.Visibility = database.settings.SortBooks ? Visibility.Hidden : Visibility.Visible;
        }
        public void FormateComboBoxes() {
            viewEditionComboBox.Items.Clear();
            viewEditionComboBox.Items.Add("Vše");
            foreach (EGC ed in database.egcManager.defaultEditions)
                viewEditionComboBox.Items.Add(ed.Name);
            foreach (EGC ed in database.egcManager.editions)
                viewEditionComboBox.Items.Add(ed.Name);
            viewEditionComboBox.SelectedIndex = 0;
            viewGenreComboBox.Items.Clear();
            viewGenreComboBox.Items.Add("Vše");
            foreach (EGC ge in database.egcManager.defaultGenres)
                viewGenreComboBox.Items.Add(ge.Name);
            foreach (EGC ge in database.egcManager.genres)
                viewGenreComboBox.Items.Add(ge.Name);
            viewGenreComboBox.SelectedIndex = 0;
        }

        public void OnWindowClosing(object sender, CancelEventArgs e) {
            if (!database.clone.IsTheSame()) {
                MessageBoxResult result = MessageBox.Show("Chcete uložit změny?", "Uložit", MessageBoxButton.YesNo, MessageBoxImage.Question);
                switch (result) {
                    case MessageBoxResult.Yes:
                        database.SaveAllToXML();
                        break;
                    default:
                        break;
                }
            }
        }

        #endregion

        #region FileMenu

        private void NewMenuItem_Click(object sender, RoutedEventArgs e) {
            database.ClearDatabase();
        }

        private void CloseMenuItem_Click(object sender, RoutedEventArgs e) {
            Close();
        }

        private void SaveMenuItem_Click(object sender, RoutedEventArgs e) {
            database.SaveAllToXML();
        }

        #endregion

        #region DataMenu
        private void DataExportExcelMenuItem_Click(object sender, RoutedEventArgs e) { database.excelFileManager.ExportToExcel(); }
        private void DataImportExcelMenuItem_Click(object sender, RoutedEventArgs e) { database.excelFileManager.ImportFormExcel(false); }
        #endregion

        #region ManagersMenu
        private void EditEditionsMenuItem_Click(object sender, RoutedEventArgs e) { EGCManagerWindowShow("edition"); }
        private void EditGenresMenuItem_Click(object sender, RoutedEventArgs e) { EGCManagerWindowShow("genre"); }
        public void EGCManagerWindowShow(string type) {
            EGCManagerWindow egcManagerWindow = new EGCManagerWindow(database.egcManager, database.settings, type);
            egcManagerWindow.ShowDialog();
            FormateComboBoxes();
        }
        #endregion

        #region SettingsMenu
        private void OwnSortBooksMenuItem_Click(object sender, RoutedEventArgs e) {
            if (database.settings.SortBooks == true) database.settings.SortBooks = false;
            else database.settings.SortBooks = true;
            database.settings.SaveSettingsToXML();
            upDownStackPanel.Visibility = database.settings.SortBooks ? Visibility.Hidden : Visibility.Visible;
        }
        private void OwnSortEditionsMenuItem_Click(object sender, RoutedEventArgs e) {
            if (database.settings.SortEditions == true) database.settings.SortEditions = false;
            else database.settings.SortEditions = true;
            database.settings.SaveSettingsToXML();
        }
        private void OwnSortGenresMenuItem_Click(object sender, RoutedEventArgs e) {
            if (database.settings.SortGenres == true) database.settings.SortGenres = false;
            else database.settings.SortGenres = true;
            database.settings.SaveSettingsToXML();
        }     
        #endregion

        #region OtherMenu

        private void ManualMenuItem_Click(object sender, RoutedEventArgs e) {
            ManualWindow manualWindow = new ManualWindow();
            manualWindow.ShowDialog();
        }

        #endregion

        #region AddEditDeleteBook
        private void AddButton_Click(object sender, RoutedEventArgs e) {
            AddBookWindow addBookWindow = new AddBookWindow(database);
            addBookWindow.ShowDialog();
        }
        private void EditButton_Click(object sender, RoutedEventArgs e) {
            if (booksListBox.SelectedItem != null) {
                Book book = (Book)booksListBox.SelectedItem;
                EditBookWindow editBookWindow = new EditBookWindow(database, book);
                editBookWindow.ShowDialog();
                booksListBox.SelectedItem = book;
            }
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e) {
            List<Book> deleteBooks = new List<Book>();
            foreach (Book b in booksListBox.SelectedItems) deleteBooks.Add(b);
            foreach (Book b in deleteBooks) database.bookManager.DeleteBook(b);
        }
        #endregion

        #region UpDownButtons
        private void UpButton_Click(object sender, RoutedEventArgs e) {
            if (database.settings.SortBooks == false) {
                if (booksListBox.SelectedItem != null) {
                    int index = booksListBox.SelectedIndex;
                    if (index == 0) return;
                    Book buffer = (Book)booksListBox.SelectedItem;
                    for (int i = 1; i < database.bookManager.books.Count; i++) {
                        if (buffer == database.bookManager.books[i]) {
                            database.bookManager.books[i] = database.bookManager.books[i - 1];
                            database.bookManager.books[i - 1] = buffer;
                            break;
                        }
                    }
                    database.bookManager.DuringAction();
                    booksListBox.SelectedIndex = index - 1;
                }
            }
        }
        private void DownButton_Click(object sender, RoutedEventArgs e) {
            if (database.settings.SortBooks == false) {
                if (booksListBox.SelectedItem != null) {
                    int index = booksListBox.SelectedIndex;
                    if (index == database.bookManager.books.Count - 1) return;
                    Book buffer = (Book)booksListBox.SelectedItem;
                    for (int i = 0; i < database.bookManager.books.Count - 1; i++) {
                        if (buffer == database.bookManager.books[i]) {
                            database.bookManager.books[i] = database.bookManager.books[i + 1];
                            database.bookManager.books[i + 1] = buffer;
                            break;
                        }
                    }
                    database.bookManager.DuringAction();
                    booksListBox.SelectedIndex = index + 1;
                }
            }
        }
        #endregion

        #region SortingSettingsBy
        private void TitleGridViewColumnHeader_Click(object sender, RoutedEventArgs e) { AddSortingBooksSettings("Title"); }
        private void AuthorGridViewColumnHeader_Click(object sender, RoutedEventArgs e) { AddSortingBooksSettings("Author"); }
        private void EditionGridViewColumnHeader_Click(object sender, RoutedEventArgs e) { AddSortingBooksSettings("Edition"); }
        private void GenreGridViewColumnHeader_Click(object sender, RoutedEventArgs e) { AddSortingBooksSettings("Genre"); }
        private void NoteGridViewColumnHeader_Click(object sender, RoutedEventArgs e) { AddSortingBooksSettings("Note"); }
        public void AddSortingBooksSettings(string by) {
            if (database.settings.SortBooks == true) {
                if (database.settings.SortBy != by) { database.settings.SortBy = by; database.settings.SortUp = true; }
                else if (database.settings.SortUp == true) database.settings.SortUp = false;
                else if (database.settings.SortUp == false) database.settings.SortUp = true;
                database.settings.SaveSettingsToXML();
                database.bookManager.DuringAction();
            }
        }
        #endregion

        #region SearchBooksAndAddingIt

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e) { AddSearchingItems(sender, e); }
        private void FilterButton_Click(object sender, RoutedEventArgs e) { AddSearchingItems(sender, e); }
        private void AddSearchingItems(Object sender, EventArgs e) {
            string EditionName = viewEditionComboBox.Text;
            string GenreName = viewGenreComboBox.Text;
            ObservableCollection<Book> searchBooks = new ObservableCollection<Book>();
            switch (searchComboBox.Text) {
                case "Titul":
                    foreach (Book b in database.bookManager.books) {
                        if (b.Title.ToLowerInvariant().Contains(searchTextBox.Text.ToLowerInvariant()) && (b.EditionName == EditionName || EditionName == "Vše") && (b.GenreName == GenreName || GenreName == "Vše"))
                            searchBooks.Add(b);
                    }
                    break;
                case "Autor":
                    foreach (Book b in database.bookManager.books) {
                        if (b.Author.ToLowerInvariant().Contains(searchTextBox.Text.ToLowerInvariant()) && (b.EditionName == EditionName || EditionName == "Vše") && (b.GenreName == GenreName || GenreName == "Vše"))
                            searchBooks.Add(b);
                    }
                    break;
                case "Edice":
                    foreach (Book b in database.bookManager.books) {
                        if (b.edition.Name.ToLowerInvariant().Contains(searchTextBox.Text.ToLowerInvariant()) && (b.EditionName == EditionName || EditionName == "Vše") && (b.GenreName == GenreName || GenreName == "Vše"))
                            searchBooks.Add(b);
                    }
                    break;
                case "Žánr":
                    foreach (Book b in database.bookManager.books) {
                        if (b.genre.Name.ToLowerInvariant().Contains(searchTextBox.Text.ToLowerInvariant()) && (b.EditionName == EditionName || EditionName == "Vše") && (b.GenreName == GenreName || GenreName == "Vše"))
                            searchBooks.Add(b);
                    }
                    break;
                case "Rok vydání":
                    foreach (Book b in database.bookManager.books) {
                        if (b.PublishYear.ToLowerInvariant().Contains(searchTextBox.Text.ToLowerInvariant()) && (b.EditionName == EditionName || EditionName == "Vše") && (b.GenreName == GenreName || GenreName == "Vše"))
                            searchBooks.Add(b);
                    }
                    break;
                case "Místo vydání":
                    foreach (Book b in database.bookManager.books) {
                        if (b.PublishLocation.ToLowerInvariant().Contains(searchTextBox.Text.ToLowerInvariant()) && (b.EditionName == EditionName || EditionName == "Vše") && (b.GenreName == GenreName || GenreName == "Vše"))
                            searchBooks.Add(b);
                    }
                    break;
                case "Nakladatelství":
                    foreach (Book b in database.bookManager.books) {
                        if (b.Publisher.ToLowerInvariant().Contains(searchTextBox.Text.ToLowerInvariant()) && (b.EditionName == EditionName || EditionName == "Vše") && (b.GenreName == GenreName || GenreName == "Vše"))
                            searchBooks.Add(b);
                    }
                    break;
                case "ISBN":
                    foreach (Book b in database.bookManager.books) {
                        if (b.Isbn.ToLowerInvariant().Contains(searchTextBox.Text.ToLowerInvariant()) && (b.EditionName == EditionName || EditionName == "Vše") && (b.GenreName == GenreName || GenreName == "Vše"))
                            searchBooks.Add(b);
                    }
                    break;
                case "Počet stran":
                    foreach (Book b in database.bookManager.books) {
                        if (b.PagesNumber.ToLowerInvariant().Contains(searchTextBox.Text.ToLowerInvariant()) && (b.EditionName == EditionName || EditionName == "Vše") && (b.GenreName == GenreName || GenreName == "Vše"))
                            searchBooks.Add(b);
                    }
                    break;              
                case "Poznámka":
                    foreach (Book b in database.bookManager.books) {
                        if (b.Note.ToLowerInvariant().Contains(searchTextBox.Text.ToLowerInvariant()) && (b.EditionName == EditionName || EditionName == "Vše") && (b.GenreName == GenreName || GenreName == "Vše"))
                            searchBooks.Add(b);
                    }
                    break;
            }
            booksListBox.Items.Clear();
            if (database.settings.SortUp) {
                foreach (Book b in searchBooks) {
                    booksListBox.Items.Add(b);
                }
            }
            else {
                for (int b = searchBooks.Count - 1; b > -1; b--) {
                    booksListBox.Items.Add(searchBooks[b]);
                }
            }
        }

        #endregion

    }
}
