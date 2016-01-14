namespace MenuGenerator
{
    using System.IO;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    using MenuGenerator.Utility;

    using Microsoft.Win32;

    using Newtonsoft.Json;

    using Menu = MenuGenerator.MenuBinding.Menu;
    using MenuItem = MenuGenerator.MenuBinding.MenuItem;

    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="MainWindow" /> class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();

            Updater.CheckForUpdates();

            this.Menu.AddSubMenu(new Menu { DisplayName = "Test1" }.AddMenuItem(new MenuItem { DisplayName = "Item1" }));
            this.Menu.AddMenuItem(new MenuItem { DisplayName = "Item2" });
            this.Menu.IsRootMenu = true;

            this.UpdateTree();
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets or sets the menu.
        /// </summary>
        /// <value>
        ///     The menu.
        /// </value>
        public Menu Menu { get; set; } = new Menu { Name = "Menu", DisplayName = "Menu" };

        #endregion

        #region Methods

        /// <summary>
        ///     Handles the Click event of the AddItemButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs" /> instance containing the event data.</param>
        private void AddItemButtonClick(object sender, RoutedEventArgs e)
        {
            if (this.TreeView.SelectedItem == null)
            {
                this.Menu.AddMenuItem(new MenuItem { DisplayName = "New MenuItem", Name = "New MenuItem" });
                this.UpdateTree();
                return;
            }

            var selectedItem = (TreeViewItem)this.TreeView.SelectedItem;

            var menu = selectedItem.Tag as Menu ?? ((MenuItem)selectedItem.Tag).Owner;
            menu.AddMenuItem(new MenuItem { DisplayName = "New MenuItem", Name = "New MenuItem" });

            this.UpdateTree();
        }

        /// <summary>
        ///     Adds the menu.
        /// </summary>
        /// <param name="menu">The menu.</param>
        /// <param name="parent">The parent.</param>
        private void AddMenu(Menu menu, ItemsControl parent)
        {
            // Prevent infinite loop
            if (menu.SubMenus.Count > 0)
            {
                foreach (var submenu in menu.SubMenus)
                {
                    var item = new TreeViewItem { Header = submenu.DisplayName, IsExpanded = true, Tag = submenu };

                    // GOOD OL' RECURSION
                    this.AddMenu(submenu, item);

                    parent.Items.Add(item);
                }
            }

            foreach (
                var treeItem in menu.Items.Select(item => new TreeViewItem { Header = item.DisplayName, Tag = item }))
            {
                parent.Items.Add(treeItem);
            }
        }

        /// <summary>
        ///     Handles the Click event of the AddMenuButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs" /> instance containing the event data.</param>
        private void AddMenuButtonClick(object sender, RoutedEventArgs e)
        {
            if (this.TreeView.SelectedItem == null)
            {
                this.Menu.AddSubMenu(new Menu { DisplayName = "New Menu", Name = "New Menu" });
                this.UpdateTree();
                return;
            }

            var selectedItem = (TreeViewItem)this.TreeView.SelectedItem;

            var menu = selectedItem.Tag as Menu ?? ((MenuItem)selectedItem.Tag).Owner;
            menu.AddSubMenu(new Menu { DisplayName = "New Menu", Name = "New Menu" });

            this.UpdateTree();
        }

        /// <summary>
        ///     Handles the Click event of the LoadButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs" /> instance containing the event data.</param>
        private void LoadButtonClick(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog { DefaultExt = ".json", Filter = "JSON File (*.json}|*.json" };

            var result = dialog.ShowDialog(this);

            if (result != true)
            {
                return;
            }

            this.Menu = JsonConvert.DeserializeObject<Menu>(
                File.ReadAllText(dialog.FileName),
                new JsonSerializerSettings()
                    {
                        PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                        ReferenceLoopHandling = ReferenceLoopHandling.Serialize
                    });
            this.UpdateTree();
        }

        /// <summary>
        ///     Handles the Click event of the RemoveObjectButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs" /> instance containing the event data.</param>
        private void RemoveObjectButtonClick(object sender, RoutedEventArgs e)
        {
            if (this.TreeView.SelectedItem == null)
            {
                return;
            }

            var item = ((TreeViewItem)this.TreeView.SelectedItem).Tag;

            if (item is Menu)
            {
                var menu = (Menu)item;

                if (menu == this.Menu)
                {
                    return;
                }

                menu.Parent.SubMenus.Remove(menu);
            }
            else if (item is MenuItem)
            {
                var menuItem = (MenuItem)item;
                menuItem.Owner.Items.Remove(menuItem);
            }

            this.UpdateTree();
        }

        /// <summary>
        ///     Handles the Click event of the SaveButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs" /> instance containing the event data.</param>
        private void SaveButtonClick(object sender, RoutedEventArgs e)
        {
            var dialog = new SaveFileDialog { DefaultExt = ".json", Filter = "JSON File (*.json}|*.json" };

            var result = dialog.ShowDialog(this);
            if (result == true)
            {
                File.WriteAllText(
                    dialog.FileName,
                    JsonConvert.SerializeObject(
                        this.Menu,
                        Formatting.Indented,
                        new JsonSerializerSettings()
                            {
                                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                                ReferenceLoopHandling = ReferenceLoopHandling.Serialize
                            }));
            }
        }

        /// <summary>
        ///     Handles the OnKeyUp event of the TreeView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Input.KeyEventArgs" /> instance containing the event data.</param>
        private void TreeViewOnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete || e.Key == Key.Back)
            {
                this.RemoveObjectButtonClick(sender, e);
            }
        }

        /// <summary>
        ///     Updates the tree.
        /// </summary>
        private void UpdateTree()
        {
            this.TreeView.Items.Clear();

            var mainMenuItem = new TreeViewItem { Header = this.Menu.DisplayName, IsExpanded = true, Tag = this.Menu };
            this.AddMenu(this.Menu, mainMenuItem);
            this.TreeView.Items.Add(mainMenuItem);
        }

        #endregion
    }
}