using AuthExceptionLibrary;
using EBookDat.Controllers.ItemsManagers;
using EBookDat.Models.Items;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace EBookDat.View
{
    /// <summary>
    /// Interaction logic for EGCManagerWindow.xaml
    /// </summary>
    public partial class EGCManagerWindow : Window
    {
        private EGCManager egcManager;
        private Settings settings;
        string type;

        public EGCManagerWindow(EGCManager egcManager, Settings settings, string type) {
            InitializeComponent();
            this.egcManager = egcManager;
            this.settings = settings;
            this.type = type;
            SetComponents();
        }

        #region SetComponenets
        private void SetComponents() {
            AddWKDEvents();
            DataContext = egcManager;
            switch (type) {
                case "edition":
                    upDownStackPanel.Visibility = settings.SortEditions ? Visibility.Hidden : Visibility.Visible;
                    Title = "Správce edic";
                    mainTitle.Text = "Seznam edic";
                    countTitle.Text = "Počet edic:";
                    countVariableText.SetBinding(TextBlock.TextProperty, new Binding("EditionsCount") {
                        Source = egcManager,
                        Mode = BindingMode.TwoWay
                    });
                    break;
                case "genre":
                    upDownStackPanel.Visibility = settings.SortGenres ? Visibility.Hidden : Visibility.Visible;
                    Title = "Správce žánrů";
                    mainTitle.Text = "Seznam žánrů";
                    countTitle.Text = "Počet žánrů:";
                    countVariableText.SetBinding(TextBlock.TextProperty, new Binding("GenresCount") {
                        Source = egcManager,
                        Mode = BindingMode.TwoWay
                    });
                    break;
            }
            egcManager.DuringAction(type);
        }
        private void AddWKDEvents() {
            egcManager.Action += AddSearchingItems;
            this.KeyDown += new KeyEventHandler(MainWindow__KeyPushed);
        }
        private void MainWindow__KeyPushed(object sender, KeyEventArgs e) {
            switch (e.Key) {
                case Key.Escape:
                    Close();
                    break;
                case Key.Enter:
                    if (nameEditTextBox.IsSelectionActive) EditButton_Click(sender, e);
                    else if (nameTextBox.IsSelectionActive) AddButton_Click(sender, e);
                    break;
                case Key.Delete:
                    DeleteButton_Click(sender, e);
                    break;
                case Key.A:
                    if (e.Key == Key.A && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
                        egcListBox.SelectAll();
                    break;
            }
        }
        private void EgcListBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (egcListBox.SelectedItem != null) {
                EGC egc = (EGC)egcListBox.SelectedItem;
                nameEditTextBox.Text = egc.Name;
            }
        }
        #endregion

        #region ListViewHeader
        private void TitleGridViewColumnHeader_Click(object sender, RoutedEventArgs e) {
            switch (type) {
                case "edition":
                    if (settings.SortEditions == true) {
                        if (settings.SortUpEditions == true) settings.SortUpEditions = false;
                        else if (settings.SortUpEditions == false) settings.SortUpEditions = true;
                    }
                    break;
                case "genre":
                    if (settings.SortGenres == true) {
                        if (settings.SortUpGenres == true) settings.SortUpGenres = false;
                        else if (settings.SortUpGenres == false) settings.SortUpGenres = true;
                    }
                    break;
            }
            settings.SaveSettingsToXML();
            egcManager.DuringAction(type);

        }
        #endregion

        #region Search
        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e) {
            AddSearchingItems(sender, e);
        }
        public void AddSearchingItems(Object sender, EventArgs e) {
            egcListBox.Items.Clear();
            switch (type) {
                case "edition":
                    foreach (EGC ed in egcManager.editions) {
                        if (ed.Name.ToLowerInvariant().Contains(searchTextBox.Text.ToLowerInvariant())) egcListBox.Items.Add(ed);
                    }
                    break;
                case "genre":
                    foreach (EGC ge in egcManager.genres) {
                        if (ge.Name.ToLowerInvariant().Contains(searchTextBox.Text.ToLowerInvariant())) egcListBox.Items.Add(ge);
                    }
                    break;             
            }
        }
        #endregion

        #region AddEditDeleteButtons
        private void AddButton_Click(object sender, RoutedEventArgs e) {
            try {
                egcManager.AddEGC(nameTextBox.Text, type);
                nameTextBox.Text = "";
            }
            catch (AuthException aEx) {
                MessageBox.Show(aEx.Message, aEx.block + " (Přidat)", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void EditButton_Click(object sender, RoutedEventArgs e) {
            if (egcListBox.SelectedItem != null) {
                try {
                    egcManager.EditEGC((EGC)egcListBox.SelectedItem, nameEditTextBox.Text, type);
                }
                catch (AuthException aEx) {
                    MessageBox.Show(aEx.Message, type + " (Upravit)", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e) {
            List<EGC> deleteEGC = new List<EGC>();
            foreach (EGC egc in egcListBox.SelectedItems) deleteEGC.Add(egc);
            foreach (EGC egc in deleteEGC) egcManager.DeleteEGC(egc, type);
            nameEditTextBox.Text = "";
        }
        #endregion

        #region UpDownButtons
        private void UpButton_Click(object sender, RoutedEventArgs e) {
            switch (type) {
                case "edition":
                    if (settings.SortEditions == false) {
                        if (egcListBox.SelectedItem != null) {
                            int index = egcListBox.SelectedIndex;
                            if (index == 0)
                                return;
                            EGC buffer = (EGC)egcListBox.SelectedItem;
                            for (int i = 1; i < egcManager.editions.Count; i++) {
                                if (buffer == egcManager.editions[i]) {
                                    egcManager.editions[i] = egcManager.editions[i - 1];
                                    egcManager.editions[i - 1] = buffer;
                                    break;
                                }
                            }
                            egcManager.DuringAction("edition");
                            egcListBox.SelectedIndex = index - 1;
                        }
                    }
                    break;
                case "genre":
                    if (settings.SortGenres == false) {
                        if (egcListBox.SelectedItem != null) {
                            int index = egcListBox.SelectedIndex;
                            if (index == 0)
                                return;
                            EGC buffer = (EGC)egcListBox.SelectedItem;
                            for (int i = 1; i < egcManager.genres.Count; i++) {
                                if (buffer == egcManager.genres[i]) {
                                    egcManager.genres[i] = egcManager.genres[i - 1];
                                    egcManager.genres[i - 1] = buffer;
                                    break;
                                }
                            }
                            egcManager.DuringAction("genre");
                            egcListBox.SelectedIndex = index - 1;
                        }
                    }
                    break;           
            }
        }
        private void DownButton_Click(object sender, RoutedEventArgs e) {
            switch (type) {
                case "edition":
                    if (settings.SortEditions == false) {
                        if (egcListBox.SelectedItem != null) {
                            int index = egcListBox.SelectedIndex;
                            if (index == egcManager.editions.Count - 1)
                                return;
                            EGC buffer = (EGC)egcListBox.SelectedItem;
                            for (int i = 0; i < egcManager.editions.Count - 1; i++) {
                                if (buffer == egcManager.editions[i]) {
                                    egcManager.editions[i] = egcManager.editions[i + 1];
                                    egcManager.editions[i + 1] = buffer;
                                    break;
                                }
                            }
                            egcManager.DuringAction("edition");
                            egcListBox.SelectedIndex = index + 1;
                        }
                    }
                    break;
                case "genre":
                    if (settings.SortGenres == false) {
                        if (egcListBox.SelectedItem != null) {
                            int index = egcListBox.SelectedIndex;
                            if (index == egcManager.editions.Count - 1)
                                return;
                            EGC buffer = (EGC)egcListBox.SelectedItem;
                            for (int i = 0; i < egcManager.genres.Count - 1; i++) {
                                if (buffer == egcManager.genres[i]) {
                                    egcManager.genres[i] = egcManager.genres[i + 1];
                                    egcManager.genres[i + 1] = buffer;
                                    break;
                                }
                            }
                            egcManager.DuringAction("genre");
                            egcListBox.SelectedIndex = index + 1;
                        }
                    }
                    break;              
            }
        }
        #endregion



    }
}
