using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LapTopShop.Models.DataModels
{
    public class ConfigurationType
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        public virtual List<Configuration> Configurations { get; set; }
    }
}
