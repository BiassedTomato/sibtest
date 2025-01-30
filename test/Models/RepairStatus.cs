public enum RepairStatus
{
    /// <summary>
    /// В обработке: создано администратором, но еще нет подтверждения готовности
    /// </summary>
    Processing,

    /// <summary>
    /// Запланировано
    /// </summary>
    Scheduled,

    /// <summary>
    /// В процессе
    /// </summary>
    InProgress,

    /// <summary>
    /// Успешно завершено
    /// </summary>
    Finished,

    /// <summary>
    /// Отменено клиентом/невозможно оказать услугу
    /// </summary>
    Cancelled
}