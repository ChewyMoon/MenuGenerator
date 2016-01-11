namespace MenuGenerator.MenuBinding
{
    public class MenuItem
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
        ///     Gets or sets the name.
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        ///     Gets or sets the owner.
        /// </summary>
        /// <value>
        ///     The owner.
        /// </value>
        public Menu Owner { get; set; }

        /// <summary>
        ///     Gets or sets the value.
        /// </summary>
        /// <value>
        ///     The value.
        /// </value>
        public MenuItemValue Value { get; set; } = new MenuItemValue(MenuValueType.None);

        #endregion
    }
}