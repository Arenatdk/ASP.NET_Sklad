using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Sklad.Models
{
    public class SkladContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public SkladContext() : base("name=SkladContext")
        {
            Database.SetInitializer<SkladContext>(new MyDbInitializer());
        }

    //    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<Order>().HasMany(c => c.Product)
    //        .WithMany(s => s.Order)
    //        .Map(t => t.MapLeftKey("OrderId")
    //        .MapRightKey("ProductId")
    //        .ToTable("OrderProduct"));
    //}

        public System.Data.Entity.DbSet<Sklad.Models.Employee> Employees { get; set; }

        public System.Data.Entity.DbSet<Sklad.Models.Tip> Tips { get; set; }

        public System.Data.Entity.DbSet<Sklad.Models.Product> Products { get; set; }

        public System.Data.Entity.DbSet<Sklad.Models.Provider> Providers { get; set; }

        public System.Data.Entity.DbSet<Sklad.Models.Order> Orders { get; set; }

        public System.Data.Entity.DbSet<Sklad.Models.Client> Clients { get; set; }
    }


    public class MyDbInitializer : DropCreateDatabaseAlways<SkladContext>
    {
        protected override void Seed(SkladContext context)
        {
            Provider p1 = new Provider { Name = "Roshen1", Contact = "Petya1", Email = "asd1@asd.asd",Adress="Kiev1",PhoneNumber="8008088080"};
            Provider p2 = new Provider { Name = "Roshen2", Contact = "Petya2", Email = "asd2@asd.asd", Adress = "Kiev2", PhoneNumber = "8008088080" };
            Provider p3 = new Provider { Name = "Roshen3", Contact = "Petya3", Email = "asd3@asd.asd", Adress = "Kiev3", PhoneNumber = "8008088080" };

            Tip t1 = new Tip { Category="Shokolad",Description="Petya's shokolad"};

            Employee e1 = new Employee { Name = "Alex Filinsky", Phone = "1488" ,Adress="Kiev1",BDay=DateTime.Now,Email="asd@asd.asd",Position="unior" };
            Employee e2 = new Employee { Name = "Alex Bukovskiy", Phone = "1488", Adress = "Kiev1", BDay = DateTime.Now, Email = "asd@asd.asd", Position = "unior" };

            Product Prod1 = new Product { isAvailable = true, Mark = "Korona", Provider = p1, Price = 1222, Tip = t1,Measure="Stuk" };
            Product Prod2 = new Product { isAvailable = true, Mark = "Rafaela", Provider = p1, Price = 1222, Tip = t1, Measure = "Stuk" };
            Product Prod3 = new Product { isAvailable = true, Mark = "Kontik", Provider = p1, Price = 1222, Tip = t1, Measure = "Stuk" };

            Client c1 = new Client { Name = "Katran", Adress = "Odessa", Email = "asd@asd.asd", Contact = "Jora", NDogovor = 112332123, PhoneNumber = "434234234", Position = "Selor" };
            Client c2 = new Client { Name = "Tavria", Adress = "Odessa", Email = "asd@asd.asd", Contact = "Vika", NDogovor = 112332123, PhoneNumber = "434234234", Position = "Selor" };
            Client c3 = new Client { Name = "Virtus", Adress = "Odessa", Email = "asd@asd.asd", Contact = "Tanya", NDogovor = 112332123, PhoneNumber = "434234234", Position = "Selor" };
            Client c4 = new Client { Name = "Badega", Adress = "Odessa", Email = "asd@asd.asd", Contact = "Masha", NDogovor = 112332123, PhoneNumber = "434234234", Position = "Selor" };

            Order o1 = new Order { Adress = "asdssssss",  DateAdd = DateTime.Now,Client=c1 ,Employee = e1 , Product = new List<Product>() { Prod2, Prod3 } };

            context.Providers.Add(p1);
            context.Providers.Add(p2);
            context.Providers.Add(p3);
            context.Tips.Add(t1);
            context.Employees.Add(e1);
            context.Employees.Add(e2);
            context.Products.Add(Prod1);
            context.Products.Add(Prod2);
            context.Products.Add(Prod3);
            context.Clients.Add(c1);
            context.Clients.Add(c2);
            context.Clients.Add(c3);
            context.Clients.Add(c4);

            
            Order o2 = new Order { Adress = "asd", Client = c1, DateAdd = DateTime.Now, Employee = e1, Product = new List<Product>() { Prod2, Prod3 } };
            Order o3 = new Order { Adress = "asd", Client = c1, DateAdd = DateTime.Now, Employee = e1, Product = new List<Product>() { Prod1 } };

            context.Orders.Add(o1);
            context.Orders.Add(o2);
            context.Orders.Add(o3);

            

            base.Seed(context);
        }
    }


}
