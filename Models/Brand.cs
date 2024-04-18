using System.ComponentModel.DataAnnotations;

namespace Hw53.Models;

public class Brand
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Поле 'Наименование' обязательно для заполнения")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Поле 'Email' обязательно для заполнения")]
    [EmailAddress(ErrorMessage = "Некорректный адрес электронной почты")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Поле 'Дата основания' обязательно для заполнения")]
    [DataType(DataType.Date)]
    [Display(Name = "Дата основания")]
    [Range(typeof(DateTime), "1900-01-01", "2100-01-01", ErrorMessage = "Некорректная дата основания")]
    public DateTime FoundationDate { get; set; }
}