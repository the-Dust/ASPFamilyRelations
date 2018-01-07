using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;


namespace DataAccess.Entities
{
    [Table("Relations")]
    public class Relation : Base.BaseIdEntity
    {
        [Required]
        [HiddenInput(DisplayValue = false)]
        public int SourceId { get; set; }

        [Required]
        [HiddenInput(DisplayValue = false)]
        public int TargetId { get; set; }

        [ForeignKey("TargetId")]
        public virtual Person TargetPerson { get; set; }

        [Required]
        [HiddenInput(DisplayValue = false)]
        public int RelationNameId { get; set; }

        [ForeignKey("RelationNameId")]
        public virtual RelationName RelationName { get; set; }
    }
}