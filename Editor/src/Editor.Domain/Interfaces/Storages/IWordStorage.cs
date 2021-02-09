using Editor.Core.Entities;
using System;
using System.Threading.Tasks;

namespace Editor.Domain.Interfaces.Storages
{
    /// <summary>
    /// Интерфейс хранилища слов.
    /// </summary>
    public interface IWordStorage
    {
        /// <summary>
        /// Возвращает слово.
        /// </summary>
        /// <param name="wordId">Идентификатор слова.</param>
        /// <returns>Слово.</returns>
        Task<Word> GetAsync(Guid wordId);

        /// <summary>
        /// Добавляет/обновляет запись о слове.
        /// </summary>
        /// <param name="word">Информация о слове.</param>
        Task CreateOrUpdateAsync(Word word);

        /// <summary>
        /// Удаляет запись о слове.
        /// </summary>
        /// <param name="wordId">Идентификатор слова.</param>
        Task DeleteAsync(Guid wordId);
    }
}