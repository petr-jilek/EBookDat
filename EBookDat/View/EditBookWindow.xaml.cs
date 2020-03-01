using AuthExceptionLibrary;
using EBookDat.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EBookDat.View
{
    /// <summary>
    /// Interaction logic for EditBookWindow.xaml
    /// </summary>
    public partial class EditBookWindow : Window
    {
        private Database database;
        private Book editingBook;
        private Book editBook;

        public EditBookWindow(Database database, Book editingBook) {
            InitializeComponent();
            this.database = database;
            this.editingBook = editingBook;
            SetComponents();
        }

        #region SetComponents
        private void SetComponents() {
            editBook = new Book(editingBook.Title, editingBook.Author, editingBook.edition, editingBook.genre, editingBook.PublishYear, editingBook.PublishLocation, editingBook.Publisher, editingBook.Isbn, editingBook.PagesNumber, editingBook.Note);
            AddWKDEvents();
            RenderComboBoxes();
            DataContext = editBook;
        }
        private void AddWKDEvents() {
            this.KeyDown += new KeyEventHandler(MainWindow__KeyPushed);
        }
        private void MainWindow__KeyPushed(object sender, KeyEventArgs e) {
            switch (e.Key) {
                case Key.Escape:
                    Close();
                    break;
                case Key.Enter:
                    EditButton_Click(sender, e);
                    break;
            }
        }

        private void RenderComboBoxes() {
            foreach (EGC ed in database.egcManager.defaultEditions) editionComboBox.Items.Add(ed.Name);
            foreach (EGC ed in database.egcManager.editions) editionComboBox.Items.Add(ed.Name);
            foreach (EGC ge in database.egcManager.defaultGenres) genreComboBox.Items.Add(ge.Name);
            foreach (EGC ge in database.egcManager.genres) genreComboBox.Items.Add(ge.Name); ;
            editionComboBox.SelectedValue = editionComboBox.Items[GetIndexOfBookEGC("edition")];
            genreComboBox.SelectedValue = genreComboBox.Items[GetIndexOfBookEGC("genre")];
        }
        private int GetIndexOfBookEGC(string type) {
            int together = 0;
            switch (type) {
                case "edition":
                    for (int i = 0; i < database.egcManager.defaultEditions.Count; i++, together++) {
                        if (database.egcManager.defaultEditions[i].Name == editBook.edition.Name) return together;
                    }
                    for (int j = 0; j < database.egcManager.editions.Count; j++, together++) {
                        if (database.egcManager.editions[j].Name == editBook.edition.Name) return together;
                    }
                    return 0;
                case "genre":
                    for (int i = 0; i < database.egcManager.defaultGenres.Count; i++, together++) {
                        if (database.egcManager.defaultGenres[i].Name == editBook.genre.Name) return together;
                    }
                    for (int j = 0; j < database.egcManager.genres.Count; j++, together++) {
                        if (database.egcManager.genres[j].Name == editBook.genre.Name) return together;
                    }
                    return 0;
            }
            return 0;
        }
        #endregion

        #region EditButton
        private void EditButton_Click(object sender, RoutedEventArgs e) {
            try {
                database.bookManager.EditBook(editingBook, titleTextBox.Text, authorTextBox.Text, editionComboBox.Text, genreComboBox.Text, publishYearTextBox.Text, publishLocationTextBox.Text, publisherTextBox.Text, isbnTextBox.Text, pagesNumberTextBox.Text, noteTextBox.Text);
                Close();
            }
            catch (AuthException aEx) {
                MessageBox.Show(aEx.Message, aEx.block, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion

    }
}
