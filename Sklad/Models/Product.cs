using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sklad.Models
{
    public class Product
    {//Товары
        public int Id { get; set; }
        [Display(Name = "Марка"),Required]
        public string Mark { get; set; }
        [Display(Name = "Цена"),Required, Range(0, 99999999, ErrorMessage = "Недопустимая цена")]
        public int Price { get; set; }
        [Display(Name = "Доступно")]
        public bool isAvailable { get; set; }
        [Display(Name = "Единица измерения")]
        public string Measure{ get; set; }

        public virtual ICollection<Order> Order { get; set; }
        public Product()
        {
            Order = new List<Order>();
        }

        public int? ProviderId { get; set; }
        public Provider Provider { get; set; }

        public int? TipId { get; set; }
        public Tip Tip { get; set; }
    }
}