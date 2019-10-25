using AuthExceptionLibrary;
using EBookDat.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WcfBookServiceLibrary.Book;
using WcfBookServiceLibrary.GoogleApi;
using WcfBookServiceLibrary.Services;

namespace EBookDat.View
{
    /// <summary>
    /// Interaction logic for AddBookWindow.xaml
    /// </summary>
    public partial class AddBookWindow : Window
    {
        public Database database;

        public AddBookWindow(Database database) {
            InitializeComponent();
            this.database = database;
            SetComponenets();
        }

        #region SetComponents
        private void SetComponenets() {
            AddWKDEvents();
            RenderComboBoxses();
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
                    AddButton_Click(sender, e);
                    break;
            }
        }

        private void RenderComboBoxses() {
            foreach (EGC ed in database.egcManager.defaultEditions) editionComboBox.Items.Add(ed.Name);
            foreach (EGC ed in database.egcManager.editions) editionComboBox.Items.Add(ed.Name);
            foreach (EGC ge in database.egcManager.defaultGenres) genreComboBox.Items.Add(ge.Name);
            foreach (EGC ge in database.egcManager.genres) genreComboBox.Items.Add(ge.Name); ;
            foreach (EGC co in database.egcManager.defaultCompanies) companyComboBox.Items.Add(co.Name);
            foreach (EGC co in database.egcManager.companies) companyComboBox.Items.Add(co.Name);
            editionComboBox.SelectedValue = editionComboBox.Items[0];
            genreComboBox.SelectedValue = genreComboBox.Items[0];
            companyComboBox.SelectedValue = companyComboBox.Items[0];
        }
        #endregion

        #region AddButton
        private void AddButton_Click(object sender, RoutedEventArgs e) {
            try {
                database.bookManager.AddBook(titleTextBox.Text, authorTextBox.Text, editionComboBox.Text, genreComboBox.Text, publishYearTextBox.Text, publishLocationTextBox.Text, publisherTextBox.Text, isbnTextBox.Text, pagesNumberTextBox.Text, billingNumberTextBox.Text, companyComboBox.Text, noteTextBox.Text);
                Close();
            }
            catch (AuthException aEx) {
                MessageBox.Show(aEx.Message, aEx.block, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion

        #region IsbnButton
        private void AddIsbnButton_Click(object sender, RoutedEventArgs e) {
            if (string.IsNullOrWhiteSpace(isbnTextBox.Text)) {
                string errorMessage = String.Format("Nenašla se knížka. Zkuste znovu zadat ISBN.", isbnTextBox.Text);
                MessageBox.Show(errorMessage, "Knížka nenalezena", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            try {
                BookSearchService bookSearchService = new BookSearchService(new GoogleApiIsbnSearchInvoker());
                string jsonBookInfo = bookSearchService.GetBookInfo(isbnTextBox.Text);

                if (jsonBookInfo == null) {
                    string errorMessage = String.Format("Nenašla se knížka polde ISBN: '{0}'. Zkuste znovu zadat ISBN.", isbnTextBox.Text);
                    MessageBox.Show(errorMessage, "Knížka nenalezena", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else {
                    JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
                    IBookInfo bookInfo = jsSerializer.Deserialize<BookInfo>(jsonBookInfo);

                    titleTextBox.Text = bookInfo.Title;
                    authorTextBox.Text = String.Join(", ", bookInfo.Authors);
                    noteTextBox.Text = bookInfo.Description;
                }
            }
            catch {
                string errorMessage = String.Format("Nelze se připojit k serveru. Zkontrolujte připojení k internetu");
                MessageBox.Show(errorMessage, "Knížka nenalezena", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion

    }
}
