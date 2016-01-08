namespace MenuGenerator.MenuBinding
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;

    /// <summary>
    ///     Represents a value a <see cref="MenuItem" /> can have.
    /// </summary>
    public class MenuItemValue
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="MenuValue" /> class.
        /// </summary>
        /// <param name="type">The type.</param>
        public MenuItemValue(MenuValueType type)
        {
            this.ValueType = type;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="MenuValue" /> class.
        /// </summary>
        public MenuItemValue()
        {
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets or sets the boolean value.
        /// </summary>
        /// <value>
        ///     The boolean value.
        /// </value>
        public bool BooleanValue { get; set; }

        /// <summary>
        ///     Gets or sets the circle value.
        /// </summary>
        /// <value>
        ///     The circle value.
        /// </value>
        public Tuple<bool, Color, float> CircleValue { get; set; }

        /// <summary>
        ///     Gets or sets the integer value.
        /// </summary>
        /// <value>
        ///     The integer value.
        /// </value>
        public int IntegerValue { get; set; }

        /// <summary>
        ///     Gets or sets the keybind value.
        /// </summary>
        /// <value>
        ///     The keybind value.
        /// </value>
        public Tuple<int, KeybindType> KeybindValue { get; set; }

        /// <summary>
        ///     Gets or sets the none value.
        /// </summary>
        /// <value>
        ///     The none value.
        /// </value>
        public string NoneValue { get; set; }

        /// <summary>
        ///     Gets or sets the slider value.
        /// </summary>
        /// <value>
        ///     The slider value.
        /// </value>
        public Tuple<int, int, int> SliderValue { get; set; }

        /// <summary>
        ///     Gets or sets the string list value.
        /// </summary>
        /// <value>
        ///     The string list value.
        /// </value>
        public List<string> StringListValue { get; set; }

        /// <summary>
        ///     Gets or sets the type of the value.
        /// </summary>
        /// <value>
        ///     The type of the value.
        /// </value>
        public MenuValueType ValueType { get; set; } = MenuValueType.None;

        #endregion
    }
}