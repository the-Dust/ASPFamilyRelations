using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace DataAccess.Entities
{
    [Table("RelationNames")]
    public class RelationName : Base.BaseIdEntity
    {
        [Column(TypeName = "nvarchar")]
        [MaxLength(50)]
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar")]
        [MaxLength(50)]
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string MirrorName { get; set; }
    }
}
