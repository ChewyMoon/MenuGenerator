namespace MenuGenerator.MenuBinding
{
    using System.Collections.Generic;

    public class Menu
    {
        #region Public Properties

        public string DisplayName { get; set; } = string.Empty;

        public bool IsRootMenu { get; set; } = false;

        public List<MenuItem> Items { get; set; } = new List<MenuItem>();

        public string Name { get; set; } = string.Empty;

        public List<Menu> SubMenus { get; set; } = new List<Menu>();

        #endregion
    }
}