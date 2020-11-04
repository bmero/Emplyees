using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace EmpleadosData
{
    public class EmployeesDbContext
    {
        private const string urlApi = "http://masglobaltestapi.azurewebsites.net/api/Employees";
        static HttpClient client = new HttpClient();
        public async Task<Employee> GetEmployee(int id)
        {
            var data = await GetEmployees();
            return data.Where(x => x.ID == id).FirstOrDefault();
        }
        public async Task<List<Employee>> GetEmployees()
        {
            var data = await RequestApi();
            return JsonConvert.DeserializeObject<List<Employee>>(data);
        }
        private async Task<string> RequestApi()
        {
            var response = string.Empty;
                
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlApi);
                //HTTP GET
                var result = await client.GetAsync(urlApi);

                if (result.IsSuccessStatusCode)
                {

                    response = await result.Content.ReadAsStringAsync();

                }
            };
            return response;
        }
    }
}
