using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Test_Model.Model;

namespace DAL
{
    public interface IRepositoryEmployee:IDisposable
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync();
        Task<IEnumerable<Employee>> GetEmployeeAsync(int id);
    }
}
