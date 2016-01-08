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
        ///     Gets or sets the value.
        /// </summary>
        /// <value>
        ///     The value.
        /// </value>
        public MenuItemValue Value { get; set; }

        /// <summary>
        ///     Gets or sets the type of the value.
        /// </summary>
        /// <value>
        ///     The type of the value.
        /// </value>
        public MenuValueType ValueType { get; set; }

        #endregion
    }
}