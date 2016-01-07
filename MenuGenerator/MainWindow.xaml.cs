namespace MenuGenerator
{
    using System.Windows;
    using System.Windows.Controls;

    using Menu = MenuGenerator.MenuBinding.Menu;

    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Constructors and Destructors

        public MainWindow()
        {
            this.InitializeComponent();

            Updater.CheckForUpdates();
        }

        #endregion

        #region Public Properties

        public Menu Menu { get; set; } = new Menu() { Name = "Menu", DisplayName = "Menu" };

        #endregion

        #region Methods

        private void AddSubmenu(Menu menu, TreeViewItem root, TreeViewItem parent)
        {
            
        }

        private void UpdateTree()
        {
            this.TreeView.Items.Clear();

            // Add main menu
            var mainMenuItem = new TreeViewItem();
            mainMenuItem.Header = this.Menu.DisplayName;
            mainMenuItem.IsExpanded = true;

            foreach (var submenu in this.Menu.SubMenus)
            {
                this.AddSubmenu(submenu, mainMenuItem, null);
            }
        }

        #endregion
    }
}