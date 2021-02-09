using Editor.Api.Models;
using Editor.Api.Queries;
using Editor.Domain.Interfaces.Storages;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Editor.Api.MediatorHandlers
{
    /// <summary>
    /// Обработчик для получения слова.
    /// </summary>
    public class GetWordHandler : WordHandlerBase, IRequestHandler<GetWordQuery, WordResourceModel>
    {
        #region Конструктор

        /// <summary>
        /// Создает экземпляр <see cref="GetWordHandler"/>.
        /// </summary>
        /// <param name="wordStorage">Хранилище слов.</param>
        public GetWordHandler(IWordStorage wordStorage) : base(wordStorage)
        {
        }

        #endregion Конструктор

        #region Методы (public)

        /// <summary>
        /// Обработать запрос.
        /// </summary>
        /// <param name="request">Запрос на получение слова.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        public async Task<WordResourceModel> Handle(
            GetWordQuery request,
            CancellationToken cancellationToken
        )
        {
            var word = await _wordStorage.GetAsync(request.WordId);

            var wordResourceModel = new WordResourceModel
            {
                WordId = word.WordId,
                WordValue = word.WordValue,
                Language = word.Language,
                Transcription = word.Transcription
            };

            return wordResourceModel;
        }

        #endregion Методы (public)
    }
}