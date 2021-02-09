using Editor.Api.Commands;
using Editor.Api.Models;
using Editor.Api.Queries;
using Editor.Core.Entities;
using Editor.Domain.Interfaces.Storages;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Editor.Api.Controllers
{
    /// <summary>
    /// Контроллер для работы со словами.
    /// </summary>
    [ApiController]
    [Route("api/words")]
    public class WordsController : ControllerBase
    {
        #region Поля

        /// <summary>
        /// Медиатор.
        /// </summary>
        private readonly IMediator _mediator;

        #endregion Поля

        #region Конструктор

        /// <summary>
        /// Создает экземпляр <see cref="WordsController"/>.
        /// </summary>
        /// <param name="mediator">Медиатор.</param>
        public WordsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion Конструктор

        #region REST ресурсы

        /// <summary>
        /// Возвращает информацию о слове.
        /// </summary>
        /// <param name="wordId">Идентификатор слова.</param>
        /// <param name="wordStorage">Хранилище слов.</param>
        /// <returns>Информация о слове.</returns>
        [HttpGet("{wordId}")]
        [ProducesResponseType(typeof(WordResourceModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetWordAsync(
            [FromRoute] Guid wordId
        )
        {
            if (wordId == Guid.Empty)
            {
                return NotFound("Идентификатор слова не задан.");
            }

            var word = await _mediator.Send(new GetWordQuery(wordId));

            if (word == null)
            {
                return NotFound();
            }

            return Ok(word);
        }

        /// <summary>
        /// Добавляет/обновляет запись о слове.
        /// </summary>
        /// <param name="wordResourceModel">Информация о слове.</param>
        /// <param name="wordStorage">Хранилище слов.</param>
        /// <returns>Информация о слове.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateOrUpdateWordAsync(
            [FromBody] CreateOrUpdateWordCommand createOrUpdateWordCommand
        )
        {
            if (createOrUpdateWordCommand == null)
            {
                return BadRequest("Передана пустая модель с информацией о слове.");
            }

            await _mediator.Send(createOrUpdateWordCommand);

            return Ok($"Информация о слове с идентификатором {createOrUpdateWordCommand.WordId} успешно добавлена/обновлена");
        }

        /// <summary>
        /// Удаляет информацию о слове.
        /// </summary>
        /// <param name="wordId">Идентификатор слова.</param>
        /// <param name="wordStorage">Хранилище слов.</param>
        /// <returns>Информация о слове.</returns>
        [HttpDelete("{wordId}")]
        [ProducesResponseType(typeof(WordResourceModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteWordAsync(
            [FromRoute] Guid wordId
        )
        {
            if (wordId == Guid.Empty)
            {
                return NotFound("Идентификатор слова не задан.");
            }

            await _mediator.Send(new DeleteWordCommand(wordId));

            return Ok($"Информация о слове с идентификатором {wordId} успешно удалена");
        }

        #endregion REST ресурсы
    }
}