namespace MenuGenerator.Utility
{
    using System;
    using System.Windows.Markup;

    /// <summary>
    ///     Provides a markup extension to get the values of an enum.
    /// </summary>
    public class EnumValuesExtension : MarkupExtension
    {
        #region Fields

        /// <summary>
        ///     The enum type.
        /// </summary>
        private readonly Type enumType;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="EnumValuesExtension" /> class.
        /// </summary>
        /// <param name="enumType">Type of the enum.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException">Argument enumType must derive from type Enum.</exception>
        public EnumValuesExtension(Type enumType)
        {
            if (enumType == null)
            {
                throw new ArgumentNullException(nameof(enumType));
            }

            if (!enumType.IsEnum)
            {
                throw new ArgumentException("Argument enumType must derive from type Enum.");
            }

            this.enumType = enumType;
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Provides the value.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns></returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Enum.GetValues(this.enumType);
        }

        #endregion
    }
}