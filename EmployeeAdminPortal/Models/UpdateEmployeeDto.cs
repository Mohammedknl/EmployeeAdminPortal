//This Dto is to update the information of DB based on ID used in UpdateEmployee method as a parameter

namespace EmployeeAdminPortal.Models
{
    public class UpdateEmployeeDto //This Dto is used to update the fields of table during HttpPut Endpoint
    {
        //It contains all the properties like name email phone and sal to update as below
        public required string Name { get; set; } //Here Name field is required not null
        public required string Email { get; set; } //required or not null

        public string? Phone { get; set; }// for phone we r making string or Nullable can contain Null values

        public decimal Salary { get; set; }
    
    }
}
