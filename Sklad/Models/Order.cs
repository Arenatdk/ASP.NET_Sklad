using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sklad.Models
{
    public class Order
    {//Заказы 
        public int Id { get; set; }
        [Display(Name = "Клиент")]
        public int? ClientID { get; set; }
        [Display(Name = "Клиент")]
        public Client Client { get; set; }
        [Display(Name = "Сотрудник")]
        public int? EmployeeId { get; set; }
        [Display(Name = "Сотрудник")]
        public Employee Employee { get; set; }
        [Display(Name = "Товары")]

        public virtual ICollection<Product> Product { get; set; }
        [Display(Name = "Дата Добавления"), Required, DataType(DataType.Date)]
        public DateTime DateAdd { get; set; } = DateTime.Now;

        [Display(Name = "Адрес получателя"), Required]
        public String Adress { get; set; }

        public Order()
        {
            Product = new List<Product>();
        }

    }
}