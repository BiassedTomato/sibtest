using System;

public class Shop
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    /// <summary>
    /// ИНН. Используется для идентификации
    /// </summary>
    public string IdNumber { get; set; }
}