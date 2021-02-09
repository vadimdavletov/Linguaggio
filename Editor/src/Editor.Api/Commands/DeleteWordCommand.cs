using MediatR;
using System;

namespace Editor.Api.Commands
{
    /// <summary>
    /// Команда на удаление записи о слове.
    /// </summary>
    public class DeleteWordCommand : IRequest
    {
        #region Свойства

        /// <summary>
        /// Идентификатор слова.
        /// </summary>
        public Guid WordId { get; }

        #endregion Свойства

        #region Конструктор

        /// <summary>
        /// Созадет экземпляр <see cref="DeleteWordCommand"/>.
        /// </summary>
        /// <param name="wordId">Идентификатор слова.</param>
        public DeleteWordCommand(Guid wordId)
        {
            WordId = wordId;
        }

        #endregion Конструктор
    }
}