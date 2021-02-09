using Editor.Core.Entities;
using Editor.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Editor.Data
{
    /// <summary>
    /// Контекст работы с БД PostgreSQL.
    /// </summary>
    public class EditorContext : DbContext
    {
        #region Свойства (Таблицы)

        /// <summary>
        /// Таблица "Слова".
        /// </summary>
        public DbSet<Word> Words { get; set; }

        #endregion Свойства (Таблицы)

        #region Конструктор

        /// <summary>
        /// Контекст для работы с базой данных.
        /// </summary>
        public EditorContext(DbContextOptions<EditorContext> options) : base(options)
        {
        }

        #endregion Конструктор

        #region Методы (protected)

        /// <summary>
        /// Обработка создания модели.
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyPostgresNamingConvention();

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EditorContext).Assembly);
        }

        #endregion Методы (protected)
    }
}