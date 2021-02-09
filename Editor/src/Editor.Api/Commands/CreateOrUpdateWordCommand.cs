using Editor.Core.Enums;
using MediatR;
using System;

namespace Editor.Api.Commands
{
    /// <summary>
    /// Команда на добавление/обновление записи о слове.
    /// </summary>
    public class CreateOrUpdateWordCommand : IRequest
    {
        /// <summary>
        /// Идентификатор слова.
        /// </summary>
        public Guid WordId { get; set; } = Guid.NewGuid();

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