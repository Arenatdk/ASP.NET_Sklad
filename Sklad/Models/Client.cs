using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sklad.Models
{
    public class Client
    {//Rkbtyn
        public int Id { get; set; }
        [Display(Name = "Название"), Required]
        public string Name { get; set; }
        [Display(Name = "Обращаться к")]
        public string Contact { get; set; }
        [Display(Name = "Должность")]
        public string Position { get; set; }
        [Display(Name = "Адрес")]
        public string Adress { get; set; }
        [Display(Name = "Номер телефона"), DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [Display(Name = "Почта"), DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name = "Номер договора")]
        public int NDogovor { get; set; }
        [Display(Name = "Описание")]
        public string Description { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}