using EBookDat.Models.Collections;
using EBookDat.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBookDat.Models
{
    public class Clone
    {
        public Database database;

        private BookCollection books = new BookCollection();
        private EGCcollection editions = new EGCcollection();
        private EGCcollection genres = new EGCcollection();
        private EGCcollection companies = new EGCcollection();
        private Settings settings = new Settings();

        public Clone(Database database) {
            this.database = database;
            MakeClone();
        }

        public void MakeClone() {
            books.Clear();
            editions.Clear();
            genres.Clear();
            companies.Clear();

            foreach (Book b in database.bookManager.books) books.Add(new Book(b.Title, b.Author, b.edition, b.genre, b.PublishYear, b.PublishLocation, b.Publisher, b.Isbn, b.PagesNumber, b.Note));
            foreach (EGC e in database.egcManager.editions) editions.Add(new EGC(e.Name));
            foreach (EGC g in database.egcManager.genres) genres.Add(new EGC(g.Name));

            settings.SortBy = database.settings.SortBy;
            settings.SortUp = database.settings.SortUp;

            settings.SortUpEditions = database.settings.SortUpEditions;
            settings.SortUpGenres = database.settings.SortUpGenres;

            settings.SortBooks = database.settings.SortBooks;
            settings.SortEditions = database.settings.SortEditions;
            settings.SortGenres = database.settings.SortGenres;
        }

        public bool IsTheSame() {
            if (settings.SortBy != database.settings.SortBy) return false;
            if (settings.SortUp != database.settings.SortUp) return false;

            if (settings.SortUpEditions != database.settings.SortUpEditions) return false;
            if (settings.SortUpGenres != database.settings.SortUpGenres) return false;

            if (settings.SortBooks != database.settings.SortBooks) return false;
            if (settings.SortEditions != database.settings.SortEditions) return false;
            if (settings.SortGenres != database.settings.SortGenres) return false;

            if (database.bookManager.books.Count != books.Count) return false;
            if (database.egcManager.editions.Count != editions.Count) return false;
            if (database.egcManager.genres.Count != genres.Count) return false;

            for (int i = 0; i < books.Count; i++) {
                if (books[i].Title != database.bookManager.books[i].Title) return false;
                if (books[i].Author != database.bookManager.books[i].Author) return false;
                if (books[i].edition.Name != database.bookManager.books[i].edition.Name) return false;
                if (books[i].genre.Name != database.bookManager.books[i].genre.Name) return false;
                if (books[i].PublishYear != database.bookManager.books[i].PublishYear) return false;
                if (books[i].PublishLocation != database.bookManager.books[i].PublishLocation) return false;
                if (books[i].Publisher != database.bookManager.books[i].Publisher) return false;
                if (books[i].Isbn != database.bookManager.books[i].Isbn) return false;
                if (books[i].PagesNumber != database.bookManager.books[i].PagesNumber) return false;     
                if (books[i].Note != database.bookManager.books[i].Note) return false;
            }

            for (int i = 0; i < editions.Count; i++) {
                if (editions[i].Name != database.egcManager.editions[i].Name) return false;
            }
            for (int i = 0; i < genres.Count; i++) {
                if (genres[i].Name != database.egcManager.genres[i].Name) return false;
            }
         
            return true;
        }
    }
}
