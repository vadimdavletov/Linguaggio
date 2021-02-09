using Editor.Api.Models;
using Editor.Core.Entities;
using Editor.Domain.Interfaces.Storages;
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
            [FromRoute] Guid wordId,
            [FromServices] IWordStorage wordStorage
        )
        {
            if (wordId == Guid.Empty)
            {
                return NotFound("Идентификатор слова не задан.");
            }

            var word = await wordStorage.GetAsync(wordId);

            if (word == null)
            {
                return NotFound();
            }

            var wordResourceModel = new WordResourceModel
            {
                WordId = word.WordId,
                WordValue = word.WordValue,
                Language = word.Language,
                Transcription = word.Transcription
            };

            return Ok(wordResourceModel);
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
            [FromBody] WordResourceModel wordResourceModel,
            [FromServices] IWordStorage wordStorage
        )
        {
            if (wordResourceModel == null)
            {
                return BadRequest("Передана пустая модель с информацией о слове.");
            }

            var word = new Word
            {
                WordId = wordResourceModel.WordId,
                WordValue = wordResourceModel.WordValue,
                Language = wordResourceModel.Language,
                Transcription = wordResourceModel.Transcription

            };

            await wordStorage.CreateOrUpdateAsync(word);

            return Ok(wordResourceModel);
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
            [FromRoute] Guid wordId,
            [FromServices] IWordStorage wordStorage
        )
        {
            if (wordId == Guid.Empty)
            {
                return NotFound("Идентификатор слова не задан.");
            }

            await wordStorage.DeleteAsync(wordId);

            return Ok($"Информация о слове с идентификатором {wordId} успешно удалена");
        }

        #endregion REST ресурсы
    }
}