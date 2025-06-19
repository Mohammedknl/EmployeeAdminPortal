using EmployeeAdminPortal.UI.ClientModels;

namespace EmployeeAdminPortal.UI.Services
{
    public class EmployeeService
    {
        private readonly HttpClient _httpClient;

        public EmployeeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Employee>>("api/employees");
        }

        public async Task<Employee?> GetByIdAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<Employee>($"api/employees/{id}");
        }

        public async Task<bool> AddAsync(AddEmployeeDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/employees", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(Guid id, UpdateEmployeeDto dto)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/employees/{id}", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"api/employees/{id}");
            return response.IsSuccessStatusCode;
        }


    }
}
