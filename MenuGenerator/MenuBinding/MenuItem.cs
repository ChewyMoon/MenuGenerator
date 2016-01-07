namespace MenuGenerator.MenuBinding
{
    class MenuItem
    {
        #region Public Properties

        public string DisplayName { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public MenuValue Value { get; set; }

        public MenuValueType ValueType { get; set; }

        #endregion
    }
}