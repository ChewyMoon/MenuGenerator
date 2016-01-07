namespace MenuGenerator.MenuBinding
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;

    class MenuValue
    {
        #region Constructors and Destructors

        public MenuValue(MenuValueType type)
        {
            this.ValueType = type;
        }

        public MenuValue()
        {
        }

        #endregion

        #region Public Properties

        public bool BooleanValue { get; set; }

        public Tuple<bool, Color, float> CircleValue { get; set; }

        public int IntegerValue { get; set; }

        public Tuple<int, KeybindType> KeybindValue { get; set; }

        public string NoneValue { get; set; }

        public Tuple<int, int, int> SliderValue { get; set; }

        public List<string> StringListValue { get; set; }

        public MenuValueType ValueType { get; set; } = MenuValueType.None;

        #endregion
    }
}