namespace MenuGenerator.MenuBinding
{
    using System.Collections.Generic;

    /// <summary>
    ///     Represents a L# menu.
    /// </summary>
    public class Menu
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the display name.
        /// </summary>
        /// <value>
        ///     The display name.
        /// </value>
        public string DisplayName { get; set; } = string.Empty;

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is root menu.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is root menu; otherwise, <c>false</c>.
        /// </value>
        public bool IsRootMenu { get; set; } = false;

        /// <summary>
        ///     Gets or sets the items.
        /// </summary>
        /// <value>
        ///     The items.
        /// </value>
        public List<MenuItem> Items { get; set; } = new List<MenuItem>();

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        ///     Gets or sets the sub menus.
        /// </summary>
        /// <value>
        ///     The sub menus.
        /// </value>
        public List<Menu> SubMenus { get; set; } = new List<Menu>();

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Adds the menu item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public Menu AddMenuItem(MenuItem item)
        {
            this.Items.Add(item);
            return this;
        }

        /// <summary>
        ///     Adds the sub menu.
        /// </summary>
        /// <param name="menu">The menu.</param>
        /// <returns></returns>
        public Menu AddSubMenu(Menu menu)
        {
            this.SubMenus.Add(menu);
            return this;
        }

        #endregion
    }
}