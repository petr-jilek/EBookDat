using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBookDat
{
    public class BookCollection : ObservableCollection<Book>
    {
        public BookCollection() { }

        public void SortByTitle() {
            for (int i = 0; i < this.Count - 1; i++) {
                if (CzechAsciiSorter.CompareTwoStringsIsFirstUpToSecond(this[i + 1].Title, this[i].Title)) {
                    Book buffer = this[i];
                    this[i] = this[i + 1];
                    this[i + 1] = buffer;
                    if (i > 0) {
                        i -= 2;
                    }
                }
            }
        }

        public void SortByAuthor() {
            for (int i = 0; i < this.Count - 1; i++) {
                if (CzechAsciiSorter.CompareTwoStringsIsFirstUpToSecond(this[i + 1].Author, this[i].Author)) {
                    Book buffer = this[i];
                    this[i] = this[i + 1];
                    this[i + 1] = buffer;
                    if (i > 0) {
                        i -= 2;
                    }
                }
            }
        }

        public void SortByEdition() {
            for (int i = 0; i < this.Count - 1; i++) {
                if (CzechAsciiSorter.CompareTwoStringsIsFirstUpToSecond(this[i + 1].EditionName, this[i].EditionName)) {
                    Book buffer = this[i];
                    this[i] = this[i + 1];
                    this[i + 1] = buffer;
                    if (i > 0) {
                        i -= 2;
                    }
                }
            }
        }

        public void SortByGenre() {
            for (int i = 0; i < this.Count - 1; i++) {
                if (CzechAsciiSorter.CompareTwoStringsIsFirstUpToSecond(this[i + 1].GenreName, this[i].GenreName)) {
                    Book buffer = this[i];
                    this[i] = this[i + 1];
                    this[i + 1] = buffer;
                    if (i > 0) {
                        i -= 2;
                    }
                }
            }
        }

        public void SortByNote() {
            for (int i = 0; i < this.Count - 1; i++) {
                if (CzechAsciiSorter.CompareTwoStringsIsFirstUpToSecond(this[i + 1].Note, this[i].Note)) {
                    Book buffer = this[i];
                    this[i] = this[i + 1];
                    this[i + 1] = buffer;
                    if (i > 0) {
                        i -= 2;
                    }
                }
            }
        }

    }
}
