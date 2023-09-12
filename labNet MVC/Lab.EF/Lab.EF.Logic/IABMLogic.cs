using Lab.Demo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Logic
{
    interface IABMLogic<T>
    {
        Task<List<T>> GetAllAsync();
        Task AddAsync(T newShippers);
        Task DeleteAsync(int id);
        Task UpdateAsync(T shippers);
        Task<T> checkExist(int id);
    }
}
