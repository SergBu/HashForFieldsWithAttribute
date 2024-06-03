using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashForFieldsAttribute;

public sealed class AbonentDto
{
    /// <summary>
    /// Фамилия абонента
    /// </summary>
    [HashField(0)]
    [Required]
    [MaxLength(100)]
    [JsonProperty("lastName")]
    public required string LastName { get; set; }

    /// <summary>
    /// Имя абонента
    /// </summary>
    [HashField(1)]
    [Required]
    [MaxLength(100)]
    [JsonProperty("firstName")]
    public required string FirstName { get; set; }

    /// <summary>
    /// Отчество
    /// </summary>
    [HashField(2)]
    [MaxLength(100)]
    [JsonProperty("middleName")]
    public string? MiddleName { get; set; }

    /// <summary>
    /// Почта абонента
    /// </summary>
    [HashField(3)]
    [Required]
    [MaxLength(200)]
    [JsonProperty("mail")]
    public required string Mail { get; set; }

    /// <summary>
    /// Телефона абонента
    /// </summary>
    [HashField(4)]
    [Required]
    [MaxLength(50)]
    [JsonProperty("phone")]
    public required string Phone { get; set; }

    /// <summary>
    /// ИНН
    /// </summary>
    [MaxLength(20)]
    [JsonProperty("inn")]
    public string? Inn { get; set; }
}
