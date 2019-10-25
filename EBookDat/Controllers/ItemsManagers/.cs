using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBookDat
{
    public class EditionManager : INotifyPropertyChanged
    {
        public Database database;

        public EditionCollection defaultEditions = new EditionCollection(true);
        public EditionCollection editions = new EditionCollection();

        public int EditionsCount { get => editions.Count; set { } }

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler Action;

        public EditionManager(Database database) {
            this.database = database;
        }

        public void DuringAction() {
            if (database.settings.SortEditions) {
                if (database.settings.SortUpEditions)
                    editions.SortByName(true);
                else
                    editions.SortByName(false);
            }
            Action?.Invoke(this, EventArgs.Empty);
            MakeChange("EditionsCount");
        }
        protected void MakeChange(string what) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(what));
        }

        public void AddEdition(string czechName) {
            editions.Add(new Edition(czechName));
            DuringAction();
        }
        public void EditEdition(Edition editingEdition, string czechName) {
            editingEdition.Name = czechName;
            DuringAction();
            database.bookManager.DuringAction();
        }
        public void DeleteEdition(Edition edition) {
            editions.Remove(edition);
            foreach (Book b in database.bookManager.books) {
                if (b.edition == edition) b.edition = defaultEditions[0];
            }
            database.bookManager.DuringAction();
            DuringAction();
        }
        public void LoadEdition(string czechName) {
            Edition edition = new Edition(czechName);
            if (CheckerBookInput.CheckEditionGenreInput(true, czechName) && !IsEditionAlmoustExist(edition)) editions.Add(edition);
        }

        public bool IsEditionAlmoustExist(Edition edition) {
            foreach (Edition ed in defaultEditions) {
                if (ed.Name == edition.Name) return true;
            }
            foreach (Edition ed in editions) {
                if (ed.Name == edition.Name) return true;
            }
            return false;
        }

    }
}
