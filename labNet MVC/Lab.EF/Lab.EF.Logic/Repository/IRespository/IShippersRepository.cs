using Lab.Demo.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab.EF.Logic.Repository.IRespository
{
    public interface IShippersRepository
    {
        Task<List<Shippers>> GetAllAsync();
        Task AddAsync(Shippers newShippers);
        Task DeleteAsync(int id);
        Task UpdateAsync(int id,Shippers shippers);
        Task<Shippers> CheckExist(int id);
        Task<Shippers> GetById(int id);
    }
}
