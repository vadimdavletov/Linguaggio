using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Editor.Core.Enums
{
    /// <summary>
    /// Язык.
    /// </summary>
    public enum Language
    {
        /// <summary>
        /// Неизвестный язык.
        /// </summary>
        [Description("Неизвестный язык")]
        Unknown = 0,

        /// <summary>
        /// Русский.
        /// </summary>
        [Description("Русский")]
        Ru = 1,

        /// <summary>
        /// Башкирский.
        /// </summary>
        [Description("Башкирский")]
        Bash = 2,
    }
}