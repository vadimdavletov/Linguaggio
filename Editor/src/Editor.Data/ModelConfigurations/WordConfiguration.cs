using Editor.Core.Entities;
using Editor.Data.ModelConfigurations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RoMigrator.Data.ModelConfigurations
{
    /// <summary>
    /// Конфигуратор для модели <see cref="Word"/>.
    /// </summary>
    public class WordConfiguration : BaseEntityTypeConfiguration<Word>
    {
        #region Методы (protected)

        /// <summary>
        /// Настройка индексов БД для ускорения поиска.
        /// </summary>
        /// <param name="builder">Билдер используемый для настройки модели.</param>
        protected override void ConfigureIndexes(EntityTypeBuilder<Word> builder)
        {
            builder.HasIndex(x => x.WordId).IsUnique();
        }

        /// <summary>
        /// Настройка ограничений и стандартных значений свойств БД.
        /// </summary>
        /// <param name="builder">Билдер используемый для настройки модели.</param>
        protected override void ConfigureProperties(EntityTypeBuilder<Word> builder)
        {
            builder.HasKey(x => x.WordId);
            builder.Property(x => x.WordValue);
            builder.Property(x => x.Language);
        }

        /// <summary>
        /// Настройка связей БД.
        /// </summary>
        /// <param name="builder">Билдер используемый для настройки модели.</param>
        protected override void ConfigureRelations(EntityTypeBuilder<Word> builder)
        {
        }

        #endregion Методы (protected)
    }
}