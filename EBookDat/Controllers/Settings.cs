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
    public class Settings
    {
        public string fileRoad = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"EBookDat\");

        public string SortBy { get; set; }
        public bool SortUp { get; set; }

        public bool SortUpEditions { get; set; }
        public bool SortUpGenres { get; set; }

        public bool SortBooks { get; set; }
        public bool SortEditions { get; set; }
        public bool SortGenres { get; set; }

        public Settings() {
            SortBy = "Title";
            SortUp = true;
            SortUpEditions = true;
            SortUpGenres = true;
            SortBooks = true;
            SortEditions = true;
            SortGenres = true;
        }

        public void DuringAction() {
            SaveSettingsToXML();
        }

        public void SaveSettingsToXML() {
            Directory.CreateDirectory(fileRoad);
            XmlWriterSettings settingsXML = new XmlWriterSettings { Indent = true };
            try {
                using (XmlWriter xw = XmlWriter.Create(fileRoad + @"settings.xml", settingsXML)) {
                    xw.WriteStartDocument();
                    xw.WriteStartElement("settings");
                    xw.WriteStartElement("settings");
                    xw.WriteElementString("sortBy", SortBy);
                    xw.WriteElementString("sortUp", SortUp.ToString());
                    xw.WriteElementString("sortUpEditions", SortUpEditions.ToString());
                    xw.WriteElementString("sortUpGenres", SortUpGenres.ToString());
                    xw.WriteElementString("sortBooks", SortBooks.ToString());
                    xw.WriteElementString("sortEditions", SortEditions.ToString());
                    xw.WriteElementString("sortGenres", SortGenres.ToString());
                    xw.WriteEndElement();
                    xw.WriteEndElement();
                    xw.WriteEndDocument();
                    xw.Flush();
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void LoadSettingsFromXML() {
            if (File.Exists(fileRoad + @"settings.xml")) {
                try {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(fileRoad + @"settings.xml");
                    XmlNode root = doc.DocumentElement;
                    foreach (XmlNode node in root.ChildNodes) {
                        if (node.Name == "settings") {
                            XmlElement edition = (XmlElement)node;
                            SortBy = edition.GetElementsByTagName("sortBy")[0].InnerText;
                            string sortUp = edition.GetElementsByTagName("sortUp")[0].InnerText;
                            string sortUpEditions = edition.GetElementsByTagName("sortUpEditions")[0].InnerText;
                            string sortUpGenres = edition.GetElementsByTagName("sortUpGenres")[0].InnerText;
                            string sortBooks = edition.GetElementsByTagName("sortBooks")[0].InnerText;
                            string sortEditions = edition.GetElementsByTagName("sortEditions")[0].InnerText;
                            string sortGenres = edition.GetElementsByTagName("sortGenres")[0].InnerText;
                            if (sortUp == "False")
                                SortUp = false;
                            if (sortUpEditions == "False")
                                SortUpEditions = false;
                            if (sortUpGenres == "False")
                                SortUpGenres = false;                        
                            if (sortBooks == "False")
                                SortBooks = false;
                            if (sortEditions == "False")
                                SortEditions = false;
                            if (sortGenres == "False")
                                SortGenres = false;
                            return;
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
