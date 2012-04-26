using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NAd.UI.ViewModels
{
    public class ClassifiedViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [DisplayName("Description")]
        [MaxLength(140)]
        public string Description { get; set; }

        [Required]
        [DisplayName("Name")]
        public string Name { get; set; }
    }
}