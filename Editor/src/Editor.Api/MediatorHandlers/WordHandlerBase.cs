using Editor.Domain.Interfaces.Storages;

namespace Editor.Api.MediatorHandlers
{
    public abstract class WordHandlerBase
    {
        #region Поля

        /// <summary>
        /// Хранилище слов.
        /// </summary>
        protected readonly IWordStorage _wordStorage;

        #endregion Поля

        #region Конструктор

        /// <summary>
        /// Создает экземпляр <see cref="WordHandlerBase"/>.
        /// </summary>
        /// <param name="wordStorage">Хранилище слов.</param>
        public WordHandlerBase(IWordStorage wordStorage)
        {
            _wordStorage = wordStorage;
        }

        #endregion Конструктор
    }
}