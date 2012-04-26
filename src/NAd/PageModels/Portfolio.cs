
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using NAd.Framework;
using NAd.UI.Controllers;

namespace NAd.UI.PageModels
{
    /// <summary>
    /// 
    /// </summary>
    [PageModel(Name = "Portfolio", ControllerType = typeof(PortfolioController))]
    public class Portfolio : BaseEditorial {

        //public Guid Id { get; set; }

        [Required]
        [DisplayName("Description")]
        [MaxLength(140)]
        public string Description { get; set; }

        [Required]
        [DisplayName("Name")]
        public string Name { get; set; }

        [DataType(DataType.ImageUrl)]
        public string Image { get; set; }
    }
}