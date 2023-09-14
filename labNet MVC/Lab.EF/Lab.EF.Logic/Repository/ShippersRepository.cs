using Lab.Demo.Entities;
using Lab.EF.Logic.Repository.IRespository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Logic.Repository
{
    public class ShippersRepository : BaseLogic, IShippersRepository
    {
        public async Task<List<Shippers>> GetAllAsync()
        {
            try
            {
                return await context.Shippers.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar obtener la lista");
            }
        }
        public async Task AddAsync(Shippers nuevoShipper)
        {
            try
            {
                int ultimoShipperID = context.Shippers.Max(s => s.ShipperID);
                nuevoShipper.ShipperID = ultimoShipperID + 1;
                context.Shippers.Add(nuevoShipper);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var referenciasAEliminarEnOrderDetails = context.Order_Details.Where(od => od.Orders.ShipVia == id).Select(od => od.OrderID).ToList();

                var referenciasAEliminar = context.Order_Details.Where(od => referenciasAEliminarEnOrderDetails.Contains(od.OrderID)).ToList();
                context.Order_Details.RemoveRange(referenciasAEliminar);

                var ordersAEliminar = context.Orders.Where(o => o.ShipVia == id).ToList();
                context.Orders.RemoveRange(ordersAEliminar);

                var shipperAEliminar = context.Shippers.FirstOrDefault(s => s.ShipperID == id);
                if (shipperAEliminar != null)
                {
                    context.Shippers.Remove(shipperAEliminar);
                }

                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task UpdateAsync(int id, Shippers shippers)
        {
            try
            {
                var shipperUpdate = context.Shippers.Find(id);
                shipperUpdate.CompanyName = shippers.CompanyName;
                shipperUpdate.Phone = shippers.Phone;
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Shippers> CheckExist(int id)
        {
            return await context.Shippers.FirstOrDefaultAsync(e => e.ShipperID == id);
        }

        public async Task<Shippers> GetById(int id)
        {
            return await context.Shippers.FindAsync(id);
        }
    }
}
