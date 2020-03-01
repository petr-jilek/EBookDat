using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EBookDat
{
    public class ExcelFileManager
    {
        public Database database;

        public ExcelFileManager(Database database) {
            this.database = database;
        }

        public void ExportToExcel() {
            SaveFileDialog saveExcelDialog = new SaveFileDialog {
                Filter = "Text Files | *.csv",
                DefaultExt = "csv"
            };
            bool? result = saveExcelDialog.ShowDialog();
            if (result == true) {
                System.IO.Stream fileStream = saveExcelDialog.OpenFile();
                try {
                    using (StreamWriter sw = new StreamWriter(fileStream, Encoding.UTF8)) {
                        string[] topValues = { "Název", "Autor", "Edice", "Žánr", "Rok vydání", "Nakladatelství", "Místo vydání", "ISBN", "Počet stran", "Poznámka" };
                        string topRow = String.Join(";", topValues);
                        sw.WriteLine(topRow);
                        foreach (Book b in database.bookManager.books) {
                            string[] sValues = { b.Title, b.Author, b.edition.Name, b.genre.Name, b.PublishYear, b.PublishLocation, b.Publisher, b.Isbn, b.PagesNumber, b.Note };
                            string row = String.Join(";", sValues);
                            sw.WriteLine(row);
                        }
                        sw.Flush();
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message, "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        public void ImportFormExcel(bool makeNew) {
            OpenFileDialog openExcelDialog = new OpenFileDialog {
                Filter = "Excel Worksheets|*.csv"
            };
            openExcelDialog.ShowDialog();
            if (openExcelDialog.FileName != "") {
                try {
                    using (StreamReader sr = new StreamReader(openExcelDialog.FileName)) {
                        if (makeNew) {
                            database.bookManager.books.Clear();
                        }
                        int i = 0;
                        string row;
                        while ((row = sr.ReadLine()) != null) {
                            if (i == 0) {
                                i++;
                                continue;
                            }
                            string[] splited = row.Split(';');
                            string title = splited[0];
                            string author = splited[1];
                            string editionName = splited[2];
                            string genreName = splited[3];
                            string publishYear = splited[4];
                            string publishLocation = splited[5];
                            string publisher = splited[6];
                            string isbn = splited[7];
                            string pagesNumber = splited[8];
                            string note = splited[9];
                            database.bookManager.LoadBook(title, author, editionName, genreName, publishYear, publishLocation, publisher, isbn, pagesNumber, note);
                        }
                        database.bookManager.DuringAction();
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message, "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }


    }
}
