using AuthExceptionLibrary;
using EBookDat.Models.Collections;
using EBookDat.Models.Items;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EBookDat.Controllers.ItemsManagers
{
    public class EGCManager : INotifyPropertyChanged
    {
        public Database database;

        public EGCcollection defaultEditions = new EGCcollection(true);
        public EGCcollection editions = new EGCcollection();
        public int EditionsCount { get => editions.Count; set { } }

        public EGCcollection defaultGenres = new EGCcollection(true);
        public EGCcollection genres = new EGCcollection();
        public int GenresCount { get => genres.Count; set { } }

        public EGCcollection defaultCompanies = new EGCcollection(true);
        public EGCcollection companies = new EGCcollection();
        public int CompaniesCount { get => companies.Count; set { } }

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler Action;

        public EGCManager(Database database) {
            this.database = database;
        }

        public void DuringAction(string type) {
            switch (type) {
                case "edition":
                    if (database.settings.SortEditions) {
                        if (database.settings.SortUpEditions)
                            editions.SortByName(true);
                        else
                            editions.SortByName(false);
                    }
                    Action?.Invoke(this, EventArgs.Empty);
                    MakeChange("EditionsCount");
                    break;
                case "genre":
                    if (database.settings.SortGenres) {
                        if (database.settings.SortUpGenres)
                            genres.SortByName(true);
                        else
                            genres.SortByName(false);
                    }
                    Action?.Invoke(this, EventArgs.Empty);
                    MakeChange("GenresCount");
                    break;
                case "company":
                    if (database.settings.SortCompanies) {
                        if (database.settings.SortUpCompanies)
                            companies.SortByName(true);
                        else
                            companies.SortByName(false);
                    }
                    Action?.Invoke(this, EventArgs.Empty);
                    MakeChange("CompaniesCount");
                    break;
            }
        }

        protected void MakeChange(string what) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(what));
        }

        public void AddEGC(string name, string type) {
            InputCheck.CheckEGCInput(name);
            IsEGCAlmoustExist(name, type);
            switch (type) {
                case "edition":
                    editions.Add(new EGC(name));
                    break;
                case "genre":
                    genres.Add(new EGC(name));
                    break;
                case "company":
                    companies.Add(new EGC(name));
                    break;
            }
            DuringAction(type);
        }
        public void EditEGC(EGC editingEGC, string name, string type) {
            InputCheck.CheckEGCInput(name);
            IsEGCAlmoustExist(name, type);

            editingEGC.Name = name;
            DuringAction(type);
            database.bookManager.DuringAction();

        }
        public void DeleteEGC(EGC egc, string type) {
            switch (type) {
                case "edition":
                    editions.Remove(egc);
                    foreach (Book b in database.bookManager.books) {
                        if (b.edition == egc) b.edition = defaultEditions[0];
                    }
                    break;
                case "genre":
                    genres.Remove(egc);
                    foreach (Book b in database.bookManager.books) {
                        if (b.genre == egc) b.genre = defaultGenres[0];
                    }
                    break;
                case "company":
                    companies.Remove(egc);
                    foreach (Book b in database.bookManager.books) {
                        if (b.company == egc) b.company = defaultCompanies[0];
                    }
                    break;
            }
            database.bookManager.DuringAction();
            DuringAction(type);
        }
        public void LoadEGC(string name, string type) {
            try {
                InputCheck.CheckEGCInput(name);
                IsEGCAlmoustExist(name, type);
                switch (type) {
                    case "edition":
                        editions.Add(new EGC(name));
                        break;
                    case "genre":
                        genres.Add(new EGC(name));
                        break;
                    case "company":
                        companies.Add(new EGC(name));
                        break;
                }
            }
            catch { }
        }

        public void IsEGCAlmoustExist(string name, string type) {
            switch (type) {
                case "edition":
                    foreach (EGC ed in defaultEditions) {
                        if (ed.Name == name) throw new AuthException(AuthException.EList.IsExist, "Edice");
                    }
                    foreach (EGC ed in editions) {
                        if (ed.Name == name) throw new AuthException(AuthException.EList.IsExist, "Edice");
                    }
                    break;
                case "genre":
                    foreach (EGC ge in defaultGenres) {
                        if (ge.Name == name) throw new AuthException(AuthException.EList.IsExist, "Žánr");
                    }
                    foreach (EGC ge in genres) {
                        if (ge.Name == name) throw new AuthException(AuthException.EList.IsExist, "Žánr");
                    }
                    break;
                case "company":
                    foreach (EGC co in defaultCompanies) {
                        if (co.Name == name) throw new AuthException(AuthException.EList.IsExist, "Společnost");
                    }
                    foreach (EGC co in companies) {
                        if (co.Name == name) throw new AuthException(AuthException.EList.IsExist, "Společnost");
                    }
                    break;
            }
        }

    }
}
