namespace MenuGenerator.MenuBinding
{
    using System;

    [Flags]
    public enum MenuValueType
    {
        /// <summary>
        ///     No type.
        /// </summary>
        None = 1,

        /// <summary>
        ///     The boolean type.
        /// </summary>
        Boolean = 2,

        /// <summary>
        ///     The slider type.
        /// </summary>
        Slider = 4,

        /// <summary>
        ///     The keybind type.
        /// </summary>
        KeyBind = 8,

        /// <summary>
        ///     The integer type.
        /// </summary>
        Integer = 16,

        /// <summary>
        ///     The color type.
        /// </summary>
        Color = 32,

        /// <summary>
        ///     The circle type.
        /// </summary>
        Circle = 64,

        /// <summary>
        ///     The string list type.
        /// </summary>
        StringList = 128
    }
}