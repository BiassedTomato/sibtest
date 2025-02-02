using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Client
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    [Required]
    public Shop Shop { get; set; }

    public ICollection<Vehicle> Vehicles { get; set; }

    /// <summary>
    /// Нав.свойство для получения всех ремонтных работ связанных с клиентом
    /// </summary>
    public IEnumerable<Repair> Repairs { get; set; }

    /// <summary>
    /// ИНН. Используется для идентификации
    /// </summary>
    public string IdNumber { get; set; }
}
