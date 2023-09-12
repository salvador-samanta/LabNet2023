using Lab.Demo.Data;
using Lab.Demo.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Logic
{
    public class SuppliersLogic : BaseLogic, IABMLogic<Suppliers>
    {
        public async Task<List<Suppliers>> GetAllAsync()
        {
            return await context.Suppliers.ToListAsync();
        }
        public async Task AddAsync(Suppliers nuevoSupplier)
        {
            int ultimoSupplierID = context.Suppliers.Max(s => s.SupplierID);
            nuevoSupplier.SupplierID = ultimoSupplierID + 1;
            context.Suppliers.Add(nuevoSupplier);
            await context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var productosAEliminar = context.Products.Where(p => p.SupplierID == id).ToList();
            context.Products.RemoveRange(productosAEliminar);

            var shipperAEliminar = context.Suppliers.FirstOrDefault(s => s.SupplierID == id);
            if (shipperAEliminar != null)
            {
                context.Suppliers.Remove(shipperAEliminar);
            }

            await context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Suppliers suppliers)
        {
            try
            {
                
                    var suppliersUpdate = context.Suppliers.Find(suppliers.SupplierID);
                    suppliersUpdate.CompanyName = suppliers.CompanyName;
                    suppliersUpdate.ContactName = suppliers.ContactName;
                    suppliersUpdate.ContactTitle = suppliers.ContactTitle;
                    suppliersUpdate.Address = suppliers.Address;
                    suppliersUpdate.City = suppliers.City;
                    suppliersUpdate.Region = suppliers.Region;
                    suppliersUpdate.PostalCode = suppliers.PostalCode;
                    suppliersUpdate.Country = suppliers.Country;
                    suppliersUpdate.Phone = suppliers.Phone;
                    suppliersUpdate.Fax = suppliers.Fax;
                    suppliersUpdate.HomePage = suppliers.HomePage;
                    await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<Suppliers> checkExist(int id)
        {
            return await context.Suppliers.FirstOrDefaultAsync(e => e.SupplierID == id);
        }
    }
}
