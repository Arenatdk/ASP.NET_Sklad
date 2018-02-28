using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sklad.Models
{
    [DisplayName("Поставщики")]
    public class Provider
    {
        public int Id { get; set; }
        [Display(Name = "Поставщик"), Required]
        public string Name { get; set; }
        [Display(Name = "Обращаться к")]
        public string Contact { get; set; }
        [Display(Name = "Адрес")]
        public string Adress { get; set; }
        [Display(Name = "Номер телефона"), DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [Display(Name = "Почта"),DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public ICollection<Product> Product { get; set; }
    }
}