using Domain.Interfaces;

namespace Domain.Common;

/// <summary>
/// Базовая сущность
/// </summary>
public abstract class BaseModel : IBaseModel
{
    /// <summary>
    /// Идентификатор записи
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Удалена ли запись
    /// </summary>
    public bool IsDeleted { get; set; } = false;

    /// <summary>
    /// Версия
    /// </summary>
    public DateTime Version { get; set; } = DateTime.UtcNow;
}