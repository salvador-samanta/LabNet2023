using Lab.Tp4.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab.Tp4.Logic
{
    public class Model : BaseLogic
    {
        CustomerLogic customerlogic = new CustomerLogic();
        ProductsLogic productslogic = new ProductsLogic();

        public void Customers()
        {
            foreach (Customers customer in customerlogic.CustomerList())
            {
                Console.WriteLine($"{customer.CustomerID} - {customer.CompanyName} - {customer.ContactName}");


            }
        }
        public List<Products> ProductsWithoutStock()
        {
            var productsWithoutStock = from products in context.Products
                                       where products.UnitsInStock == 0
                                       select products;


            return productsWithoutStock.ToList();

        }

        public List<Products> ProductsMoreThan3()
        {
            var productsValeMasDe3 = from products in context.Products
                                     where products.UnitPrice > 3
                                     && products.UnitsInStock > 0
                                     orderby products.UnitPrice ascending
                                     select products;


            return productsValeMasDe3.ToList();
        }
        public void AllWACustomers()
        {
            foreach (Customers customer in customerlogic.CustomersFromWA())
            {
                Console.WriteLine($"{customer.CustomerID} - {customer.CompanyName} - {customer.ContactName}");

                Console.ReadKey();
            }
        }
        public void ProductId789()
        {

            var productsId789 = context.Products.FirstOrDefault(p => p.ProductID == 789);
            if (productsId789 != null)
            {
                Console.WriteLine($"Producto encontrado: {productsId789.ProductName}");
            }
            else
            {
                Console.WriteLine("No se encontró ningún producto con el ID 789.");
            }
        }
        public void CustomersNames()
        {
            CustomerLogic customerLogic = new CustomerLogic();
            foreach (Customers customer in customerLogic.CustomerList())
            {
                Console.WriteLine($"{customer.ContactName.ToUpper()} - {customer.ContactName.ToLower()}");

            }
        }
        public void OrderAndCustomer()
        {
            var date = new DateTime(1997, 01, 01);

            var orderAndCustomer = from customers in context.Customers
                                   join order in context.Orders on
                                   customers.CustomerID equals order.CustomerID
                                   where customers.Region == "WA"
                                   && order.OrderDate > date
                                   orderby order.OrderDate
                                   select new { customers, order };

            foreach (var item in orderAndCustomer)
            {
                Console.WriteLine($"{item.customers.CompanyName} - {item.customers.Region} - {item.order.OrderDate}");
            }
        }
        public void FirstThreeCustomersWA()
        {
            foreach (var item in customerlogic.Primeros3())
            {
                Console.WriteLine($"{item.CompanyName} - {item.Region}");
            }
        }
        public void OrderedByNameProducts()
        {
            foreach (var item in productslogic.ProductsOrderByName())
            {
                Console.WriteLine($"{item.ProductName}");
            }
        }
        public void OrderedByStockProducts()
        {
            foreach (var item in productslogic.ProductsOrderByStock())
            {
                Console.WriteLine($"{item.ProductName} - {item.UnitsInStock}");
            }
        }
        public void ProductsCategories()
        {
            var productscategories = from categories in context.Categories
                                     join products in context.Products
                                     on categories.CategoryID equals products.CategoryID
                                     select new { categories, products };

            foreach (var item in productscategories)
            {
                Console.WriteLine($"{item.categories.CategoryName} - {item.products.ProductName}");
            }
        }
        public void FirstProductOfTheList()
        {
            Console.WriteLine(productslogic.FirstProduct().ProductName);
        }
        public void CustomersWithOrderCounts()
        {
            var customersWithOrderCounts = this.customerlogic.GetCustomersWithOrderCounts();

            foreach (var (customer, orderCount) in customersWithOrderCounts)
            {
                Console.WriteLine($"Customer: {customer.CustomerID} - Cantidad: {orderCount}");
            }
        }
    }
}
