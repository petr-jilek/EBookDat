using EBookDat.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBookDat
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }

        public EGC edition;
        public string EditionName { get => edition.Name; set { } }

        public EGC genre;
        public string GenreName { get => genre.Name; set { } }

        public string PublishYear { get; set; }
        public string Publisher { get; set; }
        public string PublishLocation { get; set; }
        public string Isbn { get; set; }
        public string PagesNumber { get; set; }

        public string Note { get; set; }

        public Book(string title, string author, EGC edition, EGC genre, string publishYear, string publishLocation, string publisher, string isbn, string pagesNumber,string note) {
            Title = title;
            Author = author;
            this.edition = edition;
            this.genre = genre;
            PublishYear = publishYear;
            Publisher = publisher;
            PublishLocation = publishLocation;
            Isbn = isbn;
            PagesNumber = pagesNumber;   
            Note = note;
            if (string.IsNullOrEmpty(Title)) Title = "-";
            if (string.IsNullOrEmpty(Author)) Author = "-";
            if (string.IsNullOrEmpty(PublishYear)) PublishYear = "-";
            if (string.IsNullOrEmpty(Publisher)) Publisher = "-";
            if (string.IsNullOrEmpty(PublishLocation)) PublishLocation = "-";
            if (string.IsNullOrEmpty(Isbn)) Isbn = "-";
            if (string.IsNullOrEmpty(PagesNumber)) PagesNumber = "-";        
            if (string.IsNullOrEmpty(Note)) Note = "-";
        }

        public override string ToString() {
            return Title;
        }

    }
}
