using Serviciu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Serviciu.Data
{
    public class DBInitializer
    {
        public static void Initialize(ShopContext context)
        {
            context.Database.EnsureCreated();
            if (context.Bags.Any())
            {
                return; // BD a fost creata anterior
            }
            var Bags = new Bag[]
            {
                new Bag{Name="Baltagul",Producer="Mihail Sadoveanu",Price=Decimal.Parse("22")},
                new Bag{Name="Enigma Otiliei",Producer="George Calinescu",Price=Decimal.Parse("18")},
                new Bag{Name="Maytrei",Producer="Mircea Eliade",Price=Decimal.Parse("27")}
            };
            foreach (Bag s in Bags)
            {
                context.Bags.Add(s);
            }
            context.SaveChanges();
            var customers = new Customer[]
            {

                new Customer{CustomerID=1050,Name="Popescu Marcela",BirthDate=DateTime.Parse("1979-09-01")},
                new Customer{CustomerID=1045,Name="Mihailescu Cornel",BirthDate=DateTime.Parse("1969-07-08")},

            };
            foreach (Customer c in customers)
            {
                context.Customers.Add(c);
            }
            context.SaveChanges();
            var orders = new Order[]
            {
                new Order{BagID=1,CustomerID=1050},
                new Order{BagID=3,CustomerID=1045},
                new Order{BagID=1,CustomerID=1045},
                new Order{BagID=2,CustomerID=1050},
            };
            foreach (Order e in orders)
            {
                context.Orders.Add(e);
            }
            context.SaveChanges();
        }
    }
}
