using Editor.Api.Commands;
using Editor.Domain.Interfaces.Storages;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Editor.Api.MediatorHandlers
{
    /// <summary>
    /// Обработчик команды на удаление слова.
    /// </summary>
    public class DeleteWordHandler : WordHandlerBase, IRequestHandler<DeleteWordCommand>
    {
        #region Конструктор

        /// <summary>
        /// Создает экземпляр <see cref="DeleteWordHandler"/>.
        /// </summary>
        /// <param name="wordStorage">Хранилище слов.</param>
        public DeleteWordHandler(IWordStorage wordStorage) : base(wordStorage)
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
            DeleteWordCommand request,
            CancellationToken cancellationToken
        )
        {
            await _wordStorage.DeleteAsync(request.WordId);

            return Unit.Value;
        }

        #endregion Методы (public)
    }
}