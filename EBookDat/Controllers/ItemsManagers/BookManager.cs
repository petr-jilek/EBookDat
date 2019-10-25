using AuthExceptionLibrary;
using EBookDat.Models.Items;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EBookDat
{
    public class BookManager : INotifyPropertyChanged
    {
        public Database database;

        public BookCollection books = new BookCollection();
        public int BooksCount { get => books.Count; set { } }

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler Action;

        public BookManager(Database database) {
            this.database = database;
        }

        public void DuringAction() {
            if (database.settings.SortBooks) {
                if (database.settings.SortBy == "Title") books.SortByTitle();
                else if (database.settings.SortBy == "Author") books.SortByAuthor();
                else if (database.settings.SortBy == "Edition") books.SortByEdition();
                else if (database.settings.SortBy == "Genre") books.SortByGenre();
                else if (database.settings.SortBy == "Note") books.SortByNote();
            }
            Action?.Invoke(this, EventArgs.Empty);
            MakeChange("BooksCount");
        }
        protected void MakeChange(string what) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(what));
        }

        public void AddBook(string title, string author, string editionName, string genreName, string publishYear, string publishLocation, string publisher, string isbn, string pagesNumber, string billingCode, string companyName, string note) {
            InputCheck.CheckBookInput(title, author, publishYear, publishLocation, publisher, isbn, pagesNumber, billingCode, note);
            EGC edition = AddEGC(editionName, "edition");
            EGC genre = AddEGC(genreName, "genre");
            EGC company = AddEGC(companyName, "company");
            if (edition == null) edition = database.egcManager.defaultEditions[0];
            if (genre == null) genre = database.egcManager.defaultGenres[0];
            if (company == null) company = database.egcManager.defaultCompanies[0];
            Book book = new Book(title, author, edition, genre, publishYear, publishLocation, publisher, isbn, pagesNumber, billingCode, company, note);
            books.Add(book);
            DuringAction();
        }
        public void EditBook(Book book, string title, string author, string editionName, string genreName, string publishYear, string publishLocation, string publisher, string isbn, string pagesNumber, string billingCode, string companyName, string note) {
            InputCheck.CheckBookInput(title, author, publishYear, publishLocation, publisher, isbn, pagesNumber, billingCode, note);
            if (string.IsNullOrEmpty(publishYear)) publishYear = "-";
            if (string.IsNullOrEmpty(publishLocation)) publishLocation = "-";
            if (string.IsNullOrEmpty(publisher)) publisher = "-";
            if (string.IsNullOrEmpty(isbn)) isbn = "-";
            if (string.IsNullOrEmpty(pagesNumber)) pagesNumber = "-";
            if (string.IsNullOrEmpty(billingCode)) billingCode = "-";
            if (string.IsNullOrEmpty(note)) note = "-";
            book.Title = title;
            book.Author = author;
            book.edition = AddEGC(editionName, "edition");
            book.genre = AddEGC(genreName, "genre");
            book.PublishYear = publishYear;
            book.PublishLocation = publishLocation;
            book.Publisher = publisher;
            book.Isbn = isbn;
            book.PagesNumber = pagesNumber;
            book.BillingCode = billingCode;
            book.company = AddEGC(companyName, "company");
            book.Note = note;
            if (book.edition == null) book.edition = database.egcManager.defaultEditions[0];
            if (book.genre == null) book.genre = database.egcManager.defaultGenres[0];
            if (book.company == null) book.company = database.egcManager.defaultCompanies[0];
            DuringAction();
        }
        public void DeleteBook(Book book) {
            books.Remove(book);
            DuringAction();
        }
        public void LoadBook(string title, string author, string editionName, string genreName, string publishYear, string publishLocation, string publisher, string isbn, string pagesNumber, string billingCode, string companyName, string note) {
            EGC edition = AddEGC(editionName, "edition");
            EGC genre = AddEGC(genreName, "genre");
            EGC company = AddEGC(companyName, "company");
            if (edition == null) {
                try {
                    InputCheck.CheckEGCInput(editionName);
                    EGC newEdition = new EGC(editionName);
                    database.egcManager.editions.Add(newEdition);
                    edition = newEdition;
                }
                catch { edition = database.egcManager.defaultEditions[0]; }
            }
            if (genre == null) {
                try {
                    InputCheck.CheckEGCInput(genreName);
                    EGC newGenre = new EGC(genreName);
                    database.egcManager.genres.Add(newGenre);
                    genre = newGenre;
                }
                catch { genre = database.egcManager.defaultGenres[0]; }
            }
            if (company == null) {
                try {
                    InputCheck.CheckEGCInput(companyName);
                    EGC newCompany = new EGC(companyName);
                    database.egcManager.companies.Add(newCompany);
                    company = newCompany;
                }
                catch { company = database.egcManager.defaultCompanies[0]; }
            }

            try {
                Book book = new Book(title, author, edition, genre, publishYear, publishLocation, publisher, isbn, pagesNumber, billingCode, company, note);
                books.Add(book);
            }
            catch { }
        }

        public EGC AddEGC(string name, string type) {
            switch (type) {
                case "edition":
                    foreach (EGC ed in database.egcManager.defaultEditions) {
                        if (ed.Name == name)
                            return ed;
                    }
                    foreach (EGC ed in database.egcManager.editions) {
                        if (ed.Name == name)
                            return ed;
                    }
                    break;
                case "genre":
                    foreach (EGC ge in database.egcManager.defaultGenres) {
                        if (ge.Name == name)
                            return ge;
                    }
                    foreach (EGC ge in database.egcManager.genres) {
                        if (ge.Name == name)
                            return ge;
                    }
                    break;
                case "company":
                    foreach (EGC co in database.egcManager.defaultCompanies) {
                        if (co.Name == name)
                            return co;
                    }
                    foreach (EGC co in database.egcManager.companies) {
                        if (co.Name == name)
                            return co;
                    }
                    break;
            }
            return null;
        }

    }
}
