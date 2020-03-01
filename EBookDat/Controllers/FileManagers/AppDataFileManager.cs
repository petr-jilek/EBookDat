using EBookDat.Controllers.ItemsManagers;
using EBookDat.Models.Items;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;

namespace EBookDat
{
    public class AppDataFileManager
    {
        public string fileRoad = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"EBookDat\");

        public Database database;
        public BookManager bookManager;
        public EGCManager egcManager;

        public AppDataFileManager(Database database) {
            this.database = database;
            bookManager = database.bookManager;
            egcManager = database.egcManager;
        }

        public void SaveEditionsToXML() {
            Directory.CreateDirectory(fileRoad);
            XmlWriterSettings settings = new XmlWriterSettings { Indent = true };
            try {
                using (XmlWriter xw = XmlWriter.Create(fileRoad + @"editions.xml", settings)) {
                    xw.WriteStartDocument();
                    xw.WriteStartElement("editions");
                    foreach (EGC ed in egcManager.editions) {
                        xw.WriteStartElement("edition");
                        xw.WriteElementString("Name", ed.Name);
                        xw.WriteEndElement();
                    }
                    xw.WriteEndElement();
                    xw.WriteEndDocument();
                    xw.Flush();
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void SaveGenresToXML() {
            Directory.CreateDirectory(fileRoad);
            XmlWriterSettings settings = new XmlWriterSettings { Indent = true };
            try {
                using (XmlWriter xw = XmlWriter.Create(fileRoad + @"genres.xml", settings)) {
                    xw.WriteStartDocument();
                    xw.WriteStartElement("genres");
                    foreach (EGC ge in egcManager.genres) {
                        xw.WriteStartElement("genre");
                        xw.WriteElementString("Name", ge.Name);
                        xw.WriteEndElement();
                    }
                    xw.WriteEndElement();
                    xw.WriteEndDocument();
                    xw.Flush();
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void SaveBooksToXML() {
            Directory.CreateDirectory(fileRoad);
            XmlWriterSettings settings = new XmlWriterSettings {
                Indent = true
            };
            try {
                using (XmlWriter xw = XmlWriter.Create(fileRoad + @"books.xml", settings)) {
                    xw.WriteStartDocument();
                    xw.WriteStartElement("books");
                    foreach (Book b in bookManager.books) {
                        xw.WriteStartElement("book");
                        xw.WriteElementString("title", b.Title);
                        xw.WriteElementString("author", b.Author);
                        xw.WriteElementString("edition", b.EditionName);
                        xw.WriteElementString("genre", b.GenreName);
                        xw.WriteElementString("publishYear", b.PublishYear);
                        xw.WriteElementString("publishLocation", b.PublishLocation);
                        xw.WriteElementString("publisher", b.Publisher);
                        xw.WriteElementString("isbn", b.Isbn);
                        xw.WriteElementString("pagesNumber", b.PagesNumber);
                        xw.WriteElementString("note", b.Note);
                        xw.WriteEndElement();
                    }
                    xw.WriteEndElement();
                    xw.WriteEndDocument();
                    xw.Flush();
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void LoadEditionsFromXML() {
            if (File.Exists(fileRoad + @"editions.xml")) {
                try {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(fileRoad + @"editions.xml");
                    XmlNode root = doc.DocumentElement;
                    foreach (XmlNode node in root.ChildNodes) {
                        if (node.Name == "edition") {
                            XmlElement edition = (XmlElement)node;
                            string name = edition.GetElementsByTagName("Name")[0].InnerText;
                            egcManager.LoadEGC(name, "edition");
                        }
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message, "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else { }
        }
        public void LoadGenresFromXML() {
            if (File.Exists(fileRoad + @"genres.xml")) {
                try {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(fileRoad + @"genres.xml");
                    XmlNode root = doc.DocumentElement;
                    foreach (XmlNode node in root.ChildNodes) {
                        if (node.Name == "genre") {
                            XmlElement genre = (XmlElement)node;
                            string name = genre.GetElementsByTagName("Name")[0].InnerText;
                            egcManager.LoadEGC(name, "genre");
                        }
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message, "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else { }
        }
        public void LoadBooksFromXML() {
            if (File.Exists(fileRoad + @"books.xml")) {
                try {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(fileRoad + @"books.xml");
                    XmlNode root = doc.DocumentElement;
                    foreach (XmlNode node in root.ChildNodes) {
                        if (node.Name == "book") {
                            XmlElement book = (XmlElement)node;
                            string title = book.GetElementsByTagName("title")[0].InnerText;
                            string author = book.GetElementsByTagName("author")[0].InnerText;
                            string editionName = book.GetElementsByTagName("edition")[0].InnerText;
                            string genreName = book.GetElementsByTagName("genre")[0].InnerText;
                            string publishYear = book.GetElementsByTagName("publishYear")[0].InnerText;
                            string publishLocation = book.GetElementsByTagName("publishLocation")[0].InnerText;
                            string publisher = book.GetElementsByTagName("publisher")[0].InnerText;
                            string isbn = book.GetElementsByTagName("isbn")[0].InnerText;
                            string pagesNumber = book.GetElementsByTagName("pagesNumber")[0].InnerText;
                            string note = book.GetElementsByTagName("note")[0].InnerText;
                            database.bookManager.LoadBook(title, author, editionName, genreName, publishYear, publishLocation, publisher, isbn, pagesNumber, note);
                        }
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message, "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else { }
        }

    }
}
