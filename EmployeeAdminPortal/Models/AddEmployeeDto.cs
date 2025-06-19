namespace EmployeeAdminPortal.Models
{
    public class AddEmployeeDto  //This Dto class used to transfer data from one operation to another
    {
        //Here we will have same 4 properties of Entity Employee.cs class to accept name email phone and salary from user
        //Here we are not adding id as EFC will automatically generates ID as it is Unique
        public required string Name { get; set; } //Here Name field is required not null
        public required string Email { get; set; } //required or not null

        public string? Phone { get; set; }// for phone we r making string or Nullable can contain Null values

        public decimal Salary { get; set; }

    }
}
