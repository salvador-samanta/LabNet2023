using Lab.Tp4.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Tp4.Logic
{
    public class ProductsLogic : BaseLogic
    {

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
        public List<Products> ProductsOrderByName()
        {
            var productsOrderByName = context.Products
                .OrderBy(product => product.ProductName)
                .ToList();

            return productsOrderByName;
        }
        public List<Products> ProductsOrderByStock()
        {
            var productsOrderByName = context.Products.OrderByDescending(p => p.UnitsInStock);
            return productsOrderByName.ToList();
        }
        public Products FirstProduct()
        {
            var firstProduct = context.Products.First();
            return firstProduct;
        }        
    }
}
