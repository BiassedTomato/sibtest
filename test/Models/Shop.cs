using System;
using System.Collections.Generic;

public class Shop
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    /// <summary>
    /// ИНН. Используется для идентификации
    /// </summary>
    public string IdNumber { get; set; }

    public IEnumerable<Repair> Repairs { get; set; }
}