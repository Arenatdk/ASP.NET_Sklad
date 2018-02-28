using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sklad.Models
{
    public class Tip
    {
        public int Id { get; set; }
        [Display(Name = "Категория"), Required]
        public string Category { get; set; }
        [Display(Name = "Описание")]
        public string Description { get; set; }

        public ICollection<Product> Product { get; set; }
    }
}