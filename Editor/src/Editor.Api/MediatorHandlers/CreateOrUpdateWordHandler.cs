using Editor.Api.Commands;
using Editor.Core.Entities;
using Editor.Domain.Interfaces.Storages;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Editor.Api.MediatorHandlers
{
    /// <summary>
    /// Обработчик команды на добавление/обновление слова.
    /// </summary>
    public class CreateOrUpdateWordHandler : WordHandlerBase, IRequestHandler<CreateOrUpdateWordCommand>
    {
        #region Конструктор

        /// <summary>
        /// Создает экземпляр <see cref="CreateOrUpdateWordHandler"/>.
        /// </summary>
        /// <param name="wordStorage">Хранилище слов.</param>
        public CreateOrUpdateWordHandler(IWordStorage wordStorage) : base(wordStorage)
        {
        }

        #endregion Конструктор

        #region Методы (public)

        /// <summary>
        /// Обработать запрос.
        /// </summary>
        /// <param name="request">Запрос на получение слова.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        public async Task<Unit> Handle(
            CreateOrUpdateWordCommand request,
            CancellationToken cancellationToken
        )
        {
            var word = new Word
            {
                WordId = request.WordId,
                WordValue = request.WordValue,
                Language = request.Language,
                Transcription = request.Transcription

            };

            await _wordStorage.CreateOrUpdateAsync(word);

            return Unit.Value;
        }

        #endregion Методы (public)
    }
}