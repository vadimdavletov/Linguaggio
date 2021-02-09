using Editor.Api.Models;
using MediatR;
using System;

namespace Editor.Api.Queries
{
    /// <summary>
    /// Запрос на получение слова.
    /// </summary>
    public class GetWordQuery : IRequest<WordResourceModel>
    {
        #region Свойства

        /// <summary>
        /// Идентификатор слова.
        /// </summary>
        public Guid WordId { get; }

        #endregion Свойства

        #region Конструктор

        /// <summary>
        /// Создает экземпляр <see cref=GetWordQuery"/>.
        /// </summary>
        /// <param name="wordId">Идентификатор слова.</param>
        public GetWordQuery(Guid wordId)
        {
            WordId = wordId;
        }

        #endregion Конструктор
    }
}