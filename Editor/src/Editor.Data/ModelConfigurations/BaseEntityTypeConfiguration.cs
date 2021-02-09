using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Editor.Data.ModelConfigurations
{
    /// <summary>
    /// Базовый класс для конфигураций моделей БД.
    /// </summary>
    public abstract class BaseEntityTypeConfiguration<T> : IEntityTypeConfiguration<T> where T : class
    {
        /// <summary>
        /// Настройка модели БД.
        /// </summary>
        /// <param name="builder">Билдер используемый для настройки модели.</param>
        public void Configure(EntityTypeBuilder<T> builder)
        {
            ConfigureIndexes(builder);
            ConfigureRelations(builder);
            ConfigureProperties(builder);
        }

        /// <summary>
        /// Настройка индексов БД для ускорения поиска.
        /// </summary>
        /// <param name="builder">Билдер используемый для настройки модели.</param>
        protected abstract void ConfigureIndexes(EntityTypeBuilder<T> builder);

        /// <summary>
        /// Настройка связей БД.
        /// </summary>
        /// <param name="builder">Билдер используемый для настройки модели.</param>
        protected abstract void ConfigureRelations(EntityTypeBuilder<T> builder);

        /// <summary>
        /// Настройка ограничений и стандартных значений свойств БД.
        /// </summary>
        /// <param name="builder">Билдер используемый для настройки модели.</param>
        protected abstract void ConfigureProperties(EntityTypeBuilder<T> builder);
    }
}