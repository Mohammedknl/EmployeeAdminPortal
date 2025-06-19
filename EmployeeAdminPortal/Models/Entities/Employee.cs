namespace EmployeeAdminPortal.Models.Entities
{
    public class Employee
    {
     // Adding new properties for creating table columns like ID,Name etc;
     public Guid Id { get; set; } //Global Unique Identifier  used in this project now made changes
     //public int Id { get; set; } // Primary Key (int, auto-increment by EF Core) this is not in use
     public required string Name { get; set; } //Here Name field is required not null
     public required string Email { get; set; } //required or not null

    public string? Phone { get; set; }// for phone we r making string or Nullable can contain Null values

    public decimal Salary { get; set; }


 
    }
}
