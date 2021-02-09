using Editor.Core.Entities;
using Editor.Domain.Interfaces.Storages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Editor.Data.Storages
{
    /// <summary>
    /// Хранилище слов.
    /// </summary>
    public class WordStorage : IWordStorage
    {
        #region Поля

        /// <summary>
        /// БД.
        /// </summary>
        private readonly EditorContext _db;

        #endregion Поля

        #region Конструктор

        /// <summary>
        /// Создает экземпляр <see cref="WordStorage"/>.
        /// </summary>
        /// <param name="db">БД.</param>
        public WordStorage(EditorContext db)
        {
            _db = db;
        }

        #endregion Конструктор

        #region Методы (public)

        /// <summary>
        /// Добавляет/обновляет запись о слове.
        /// </summary>
        /// <param name="word">Информация о слове.</param>
        public async Task CreateOrUpdateAsync(Word word)
        {
            var wordFromDb = await _db.Words.FirstOrDefaultAsync(p => p.WordId == word.WordId);

            if (wordFromDb == null)
            {
                _db.Words.Add(word);
            }
            else
            {
                wordFromDb.WordValue = word.WordValue;
                wordFromDb.Transcription = word.Transcription;
                wordFromDb.Language = word.Language;

                _db.Words.Update(word);
            }

            await _db.SaveChangesAsync();
        }

        /// <summary>
        /// Удаляет запись о слове.
        /// </summary>
        /// <param name="wordId">Идентификатор слова.</param>
        public async Task DeleteAsync(Guid wordId)
        {
            var word = await _db.Words.FirstOrDefaultAsync(p => p.WordId == wordId);

            if (word != null)
            {
                _db.Words.Remove(word);
                await _db.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Возвращает слово.
        /// </summary>
        /// <param name="wordId">Идентификатор слова.</param>
        /// <returns>Слово.</returns>
        public async Task<Word> GetAsync(Guid wordId)
        {
            return await _db.Words.FirstOrDefaultAsync(p => p.WordId == wordId);
        }

        #endregion Методы (public)
    }
}