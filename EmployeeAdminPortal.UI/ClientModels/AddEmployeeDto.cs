namespace EmployeeAdminPortal.UI.ClientModels
{
    public class AddEmployeeDto
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public decimal Salary { get; set; }
    }
}
