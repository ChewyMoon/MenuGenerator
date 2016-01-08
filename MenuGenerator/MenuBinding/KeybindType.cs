namespace MenuGenerator.MenuBinding
{
    /// <summary>
    ///     Represents settings for a keybind.
    /// </summary>
    public enum KeybindType
    {
        /// <summary>
        ///     The keybind is active when the key is pressed.
        /// </summary>
        Press,

        /// <summary>
        ///     The keybind works as a switch, and is active only when it's toggled.
        /// </summary>
        Toggle
    }
}