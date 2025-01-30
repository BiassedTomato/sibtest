using System;

public class Repair
{
    public Guid Id { get; set; }

    /// <summary>
    /// Клиент
    /// </summary>
    public Client Client { get; set; }

    /// <summary>
    /// Исполнитель
    /// </summary>
    public Shop Service { get; set; }

    /// <summary>
    /// Транспортное средство
    /// </summary>
    public Vehicle Vehicle { get; set; }

    /// <summary>
    /// Вид ремонта
    /// </summary>
    public RepairType RepairType { get; set; }

    /// <summary>
    /// Стоимость, руб
    /// </summary>
    public float Cost { get; set; }

    /// <summary>
    /// Статус услуги
    /// </summary>
    public RepairStatus RepairStatus { get; set; }

    public DateTime? FinishedDate { get; set; }

    /// <summary>
    /// Пробег, км
    /// </summary>
    public float Mileage { get; set; }
}