namespace MenuGenerator
{
    using System.Windows;
    using System.Windows.Controls;

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

            this.Menu.SubMenus.Add(
                new Menu() { DisplayName = "Test1" }.AddMenuItem(new MenuItem() { DisplayName = "Item1" }));
            this.Menu.Items.Add(new MenuItem() { DisplayName = "Item2" });
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
        public Menu Menu { get; set; } = new Menu() { Name = "Menu", DisplayName = "Menu" };

        #endregion

        #region Methods

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

            foreach (var item in menu.Items)
            {
                var treeItem = new TreeViewItem();
                treeItem.Header = item.DisplayName;
                treeItem.Tag = item;

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
                MessageBox.Show("Please select a menu!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var selectedItem = (TreeViewItem)this.TreeView.SelectedItem;

            if (selectedItem.Tag is MenuItem)
            {
                MessageBox.Show("Please select a menu!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var menu = (Menu)selectedItem.Tag;
            menu.SubMenus.Add(new Menu() { DisplayName = "New Menu", Name = "New Menu" });

            this.UpdateTree();
        }

        /// <summary>
        ///     Updates the tree.
        /// </summary>
        private void UpdateTree()
        {
            this.TreeView.Items.Clear();

            // Add main menu
            var mainMenuItem = new TreeViewItem { Header = this.Menu.DisplayName, IsExpanded = true, Tag = this.Menu };

            this.AddMenu(this.Menu, mainMenuItem);

            this.TreeView.Items.Add(mainMenuItem);
        }

        #endregion
    }
}