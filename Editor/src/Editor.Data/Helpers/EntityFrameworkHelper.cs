using Microsoft.EntityFrameworkCore;
using Npgsql.NameTranslation;

namespace Editor.Helpers
{
    /// <summary>
    /// Вспомогательные методы для работы с EF.
    /// </summary>
    public static class EntityFrameworkHelper
    {
        #region Методы (public)

        /// <summary>
        /// Добавление Map названии таблиц и столбцов 
        /// (Конвертация любого имени из PascalCase нотации в under_score нотацию).
        /// </summary>
        /// <param name="modelBuilder">Сопоставление классов со схемой базы данных.</param>
        public static void ApplyPostgresNamingConvention(this ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                // Таблицы
                if (entity.BaseType == null)
                {
                    entity.SetTableName(entity.GetTableName().TableNameToSnakeCase());
                }

                // Поля (колонки)
                foreach (var property in entity.GetProperties())
                {
                    property.SetColumnName(property.Name.ToSnakeCase());
                }

                // Перв. ключи
                foreach (var key in entity.GetKeys())
                {
                    key.SetName(key.GetName().ToSnakeCase());
                }

                // Вн. ключи
                foreach (var key in entity.GetForeignKeys())
                {
                    key.SetConstraintName(key.GetConstraintName().ToSnakeCase());
                }

                // Индексы
                foreach (var index in entity.GetIndexes())
                {
                    index.SetDatabaseName(index.GetDatabaseName().ToSnakeCase());
                }
            }
        }

        #endregion Методы (public)

        #region Методы (private)

        /// <summary>
        /// Конвертация любого имени из PascalCase нотации в under_score нотацию (удобную для работы
        /// с postgresql).
        /// </summary>
        /// <param name="entityName">Любой текст использующий PascalCase.</param>
        private static string ToSnakeCase(this string entityName)
        {
            var mapper = new NpgsqlSnakeCaseNameTranslator();

            return mapper.TranslateMemberName(entityName);
        }

        /// <summary>
        /// Конвертация любого имени из PascalCase нотации в under_score нотацию (удобную для работы
        /// с postgresql).
        /// </summary>
        /// <param name="entityName">Любой текст использующий PascalCase.</param>
        private static string TableNameToSnakeCase(this string entityName)
        {
            var mapper = new NpgsqlSnakeCaseNameTranslator();

            return mapper.TranslateTypeName(entityName);
        }

        #endregion Методы (private)
    }
}