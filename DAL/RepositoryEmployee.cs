using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Test_Model.Model;

namespace DAL
{
    public class RepositoryEmployee : IRepositoryEmployee
    {
        #region Fields
        private readonly HttpClient httpClient;
        private bool _disposed;
        #endregion

        #region Constructor
        public RepositoryEmployee()
        {
            httpClient = new HttpClient();
        } 
        #endregion

        #region GetEmployeesAsync
        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            var data = await httpClient.GetAsync("http://masglobaltestapi.azurewebsites.net/api/Employees");
            var result = JsonConvert.DeserializeObject<IEnumerable<Employee>>(await data.Content.ReadAsStringAsync());




            return result;

        } 
        #endregion

        #region Dispose
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    httpClient.Dispose();
                }
            }
            _disposed = true;

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        #region GetEmployeeAsync
        public async Task<IEnumerable<Employee>> GetEmployeeAsync(int id)
        {
            var data = await httpClient.GetAsync("http://masglobaltestapi.azurewebsites.net/api/Employees");
            var result = JsonConvert.DeserializeObject<IEnumerable<Employee>>(await data.Content.ReadAsStringAsync());

            var employee = result.Where(x => x.Id == id).ToList();

            return employee;

        } 
        #endregion
    }
}
