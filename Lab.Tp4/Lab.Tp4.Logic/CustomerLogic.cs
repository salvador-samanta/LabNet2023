using Lab.Tp4.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lab.Tp4.Logic.Model;

namespace Lab.Tp4.Logic
{
    public class CustomerLogic : BaseLogic
    {
        public List<Customers> CustomerList()
        {
            var queryAllCustomers = from customers in context.Customers
                                    select customers;

            return queryAllCustomers.ToList();

        }


        public List<Customers> CustomersFromWA()
        {
            var queryCustomersFromWA = from customers in context.Customers
                                       where customers.Region == "WA"
                                       select customers;


            return queryCustomersFromWA.ToList();

        }

        public List<Customers> Primeros3()
        {
            var query3customers = context.Customers.Where(r => r.Region == "WA").Take(3);
            return query3customers.ToList();

        }
        public List<(Customers Customer, int OrderCount)> GetCustomersWithOrderCounts()
        {
            var customersWithOrderCounts = context.Customers
                .Where(customer => customer.Orders.Any())
                .GroupBy(customer => customer.CustomerID)
                .Select(group => new
                {
                    Customer = group.FirstOrDefault(),
                    OrderCount = group.Count()
                })
                .ToList();

            return customersWithOrderCounts
                .Select(item => (item.Customer, item.OrderCount))
                .ToList();
        }

    }
}
