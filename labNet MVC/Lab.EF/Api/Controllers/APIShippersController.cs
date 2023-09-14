using Lab.Demo.Entities;
using Lab.EF.Logic.DTO;
using Lab.EF.Logic.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Api.Controllers
{
    public class APIShippersController : ApiController
    {
        private readonly ShippersRepository _shippers = new ShippersRepository();

        // GET: api/GetShippers
        public async Task<List<ShippersDto>> GetAllAsync()
        {
            List<Shippers> shippers = await _shippers.GetAllAsync();
            List<ShippersDto> shippersModel = shippers.Select(s => new ShippersDto
            {
                ShipperID = s.ShipperID,
                Phone = s.Phone,
                CompanyName = s.CompanyName,
            }).ToList();

            return shippersModel;
        }

        //GET: api/GetShippers/5
        [ResponseType(typeof(ShippersDto))]
        public async Task<IHttpActionResult> GetById(int id)
        {
            Shippers shippers = await _shippers.GetById(id);

            if (shippers == null) return NotFound();

            ShippersDto shippersModel = new ShippersDto()
            {
                ShipperID = shippers.ShipperID,
                Phone = shippers.Phone,
                CompanyName = shippers.CompanyName,
            };

            return Ok(shippersModel);
        }

        // POST: api/PostShippers
        [ResponseType(typeof(ShippersDto))]
        public async Task<IHttpActionResult> Post(ShippersDto shippers)
        {
            Shippers shippersModel = new Shippers()
            {
                Phone = shippers.Phone,
                CompanyName = shippers.CompanyName,
            };

            await _shippers.AddAsync(shippersModel);

            return Ok(shippersModel);
        }

        //PUT: api/PutShippers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> UpdateShippers(int id, ShippersDto shippers)
        {
            var check = await _shippers.CheckExist(id);

            if (check == null) return BadRequest();

            Shippers shippersModel = new Shippers
            {
                Phone = shippers.Phone,
                CompanyName = shippers.CompanyName,
            };

            await _shippers.UpdateAsync(id, shippersModel);

            return Ok(shippersModel);
        }

        //DELETE: api/Shippers/5
        [ResponseType(typeof(ShippersDto))]
        public async Task<IHttpActionResult> DeleteShipper(int id)
        {
            Shippers shipper = await _shippers.GetById(id);

            if (shipper == null) return NotFound();

            await _shippers.DeleteAsync(id);

            return Ok(shipper);
        }
    }
}