using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace DataAccess.Entities
{
    [Table("Persons")]
    public class Person : Base.BaseIdEntity
    {
        [Column(TypeName = "nvarchar")]
        [MaxLength(50)]
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [Display(Name = "1. Имя")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar")]
        [MaxLength(50)]
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [Display(Name = "3. Фамилия")]
        public string Surname { get; set; }

        [Column(TypeName = "nvarchar")]
        [MaxLength(50)]
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [Display(Name = "2. Отчество")]
        public string Patronymic { get; set; }

        [Display(Name = "4. Дата рождения")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? BirthDate { get; set; }

        [Column(TypeName = "nvarchar")]
        [MaxLength(50)]
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [Display(Name = "5. Страна проживания")]
        public string Country { get; set; }

        [Column(TypeName = "nvarchar")]
        [MaxLength(50)]
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [Display(Name = "6. Город")]
        public string City { get; set; }

        [Column(TypeName = "nvarchar")]
        [MaxLength(50)]
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [Display(Name = "7. Улица")]
        public string Street { get; set; }

        public override string ToString()
        {
            return $"{Surname} {Name} {Patronymic}";
        }
    }
}
