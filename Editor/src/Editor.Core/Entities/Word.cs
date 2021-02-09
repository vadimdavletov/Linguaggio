using Editor.Core.Enums;
using System;

namespace Editor.Core.Entities
{
    /// <summary>
    /// Информация о слове
    /// </summary>
    public class Word
    {
        /// <summary>
        /// Идентификатор слова.
        /// </summary>
        public Guid WordId { get; set; }

        /// <summary>
        /// Слово.
        /// </summary>
        public string WordValue { get; set; }

        /// <summary>
        /// Транскрипция.
        /// </summary>
        public string Transcription { get; set; }

        /// <summary>
        /// Язык.
        /// </summary>
        public Language Language { get; set; }
    }
}