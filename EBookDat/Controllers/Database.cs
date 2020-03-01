using EBookDat.Controllers.ItemsManagers;
using EBookDat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBookDat
{
    public class Database
    {
        public BookManager bookManager;
        public EGCManager egcManager;

        public AppDataFileManager appDataFileManager;
        public ExcelFileManager excelFileManager;

        public Settings settings = new Settings();

        public Clone clone;

        public Database() {
            bookManager = new BookManager(this);
            egcManager = new EGCManager(this);

            appDataFileManager = new AppDataFileManager(this);
            excelFileManager = new ExcelFileManager(this);

            clone = new Clone(this);
        }


        public void SaveAllToXML() {
            appDataFileManager.SaveEditionsToXML();
            appDataFileManager.SaveGenresToXML();
            appDataFileManager.SaveBooksToXML();
            settings.SaveSettingsToXML();
            clone.MakeClone();
        }

        public void LoadAllFromXML() {
            appDataFileManager.LoadEditionsFromXML();
            appDataFileManager.LoadGenresFromXML();
            appDataFileManager.LoadBooksFromXML();
            settings.LoadSettingsFromXML();
        }

        public void ClearDatabase() {
            egcManager.editions.Clear();
            egcManager.genres.Clear();
            bookManager.books.Clear();
            settings = new Settings();
            bookManager.DuringAction();
            egcManager.DuringAction("edition");
            egcManager.DuringAction("genre");
        }

    }
}
