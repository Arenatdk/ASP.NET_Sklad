using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sklad.Models
{
    public class Employee
    {//Сотрудник
        public int Id { get; set; }
        [Display(Name = "Имя"), Required]
        public string Name { get; set; }
        [Display(Name = "Должность"), Required]
        public string Position { get; set; }
        [Display(Name = "Дата рождения"), DataType(DataType.Date)]
        public DateTime BDay { get; set; }
        [Display(Name = "Адрес"), Required]
        public string Adress { get; set; }
        [Display(Name = "Телефон"), Required, DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [Display(Name = "Почта"), DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public virtual ICollection<Order> Order { get; set; }
        public Employee()
        {
            Order = new List<Order>();
        }

    }
}