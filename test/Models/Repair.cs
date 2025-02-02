using System;
using System.ComponentModel.DataAnnotations;

public class Repair
{
    public Guid Id { get; set; }

    /// <summary>
    /// Клиент
    /// </summary>
    [Required]
    public Client Client { get; set; }

    /// <summary>
    /// Исполнитель
    /// </summary>
    [Required]
    public Shop Shop { get; set; }

    /// <summary>
    /// Транспортное средство
    /// </summary>
    [Required]
    public Vehicle Vehicle { get; set; }

    /// <summary>
    /// Вид ремонта
    /// </summary>
    [Required]
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