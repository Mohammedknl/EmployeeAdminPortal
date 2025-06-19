using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;
using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.Models;
using EmployeeAdminPortal.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAdminPortal.Controllers
{
    //localhost:xxx/api/Controller name which routes from controller ie Employees so default we use api/[controller] or simply [controller]
    [Route("api/[controller]")]  //Route Attribute which is accessing from controller and api/ is optional 
    [ApiController] //Api controller Attribute

    //Here EmployeesController class is inheriting from ControllerBase class
    public class EmployeesController : ControllerBase
    {
        //Here inside Controller we can add API end points or CRUD operations 


        private readonly ApplicationDbContext dbContext; //Here we are assigning a private field by name dbContext that can be used inside any methods instead of ApplicationDbContext
        

        

        //Here in below two lines we are going to inject DbContext file
        //to get the live results of employees table data inside the Controller same how we injected inside program.cs file 
        //using Constructor injection ctor and enter it will create EmployeesController constructor

        public EmployeesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        // This httpget  is the attribute
        //1.Reading all the employees from Employees table using Httpget method
        // and IActionResult is the name of the action method and GetAllEmp return list of employees from Db or statically

        [HttpGet]  //This is called restful resource or rstful practices
        //Structure of the Method starts here or defining the method to get the employees
        public IActionResult GetAllEmployees() //This GetAllEMployees method can return statically list of all employees or it can connect to DB using Dbcontext file to get the live result 
        {
            var allEmployees = dbContext.Employees.ToList(); //here we are using a private field dbContext inside Get method to fetch all data from Employees table with ToList property

            return Ok(allEmployees); // As it is a restful api's we need to send this as OK response like 200 by passing EMployees object as a result
        }

        //Here in the above Httpget end APi endpoint we are connecting to datase using dbContext and returning back the Ok response
        //In swagger url we check the api end point httpGet


        //S2.Let's create a new end point web api getpost ie adding action method for adding new employee

        [HttpPost]  //restful API Post for add operation here in below AddEmployee Method,
                    //AddEmployeeDTo is a parameter and addEmployeeDto is the name used  inside method
                    //Here we have created AddEmployeeDto class with only 4 properties and we can't use this directly in the ActionResult so we need to convert this in to Entity class called EMployees
        public IActionResult AddEmployee(AddEmployeeDto addEmployeeDto) // as it is a Action result we have to write return type at last
        { 
            
            //Add method of EMployees table will accept only Employee Entity so we have converted our AddEmployeeDto class to Employee Entity class
            var employeeEntity = new Employee() //creating object of Entity class and sending to var employeeEntity
            {
                Name = addEmployeeDto.Name,
                Email = addEmployeeDto.Email,
                Phone = addEmployeeDto.Phone,
                Salary = addEmployeeDto.Salary
            };
            //First we will map addEmployeeDto with the Employees Enity because DbContext class for DB will only accept Entities
            dbContext.Employees.Add(employeeEntity);

            //EFC wil not save the changes/transfers the data by itself we need to save it manually like below after adding the data
            dbContext.SaveChanges();

            return Ok(employeeEntity);
        
        }

        //3.If we want to fetch the information of only single employee by GUID from table without all employees using gethttp api
        [HttpGet]
        [Route("{id:guid}")]  //guid is a predefine keyword for GUID data type
        public IActionResult GetEmployeebyId(Guid id)  //Guid is the name of the Field inside Database Model
        {
            var employee = dbContext.Employees.Find(id);

            if (employee is null)
            {
                return NotFound();
            
            }

            return Ok(employee);// here instead of employee we can also write dbContext.employees.Find(id) without using var line in above code
        }

        //S4.Now we will write Restful Endpoint oe resource to update a particular record using httpPut
        //For updating particular record we use same Get operation based on id and also we need one more DTO to update the type of information
        [HttpPut]
        [Route("{id:guid}")]  //This Update method also need route to fetch the EMployee details first based on ID
        public IActionResult UpdateEmployee(Guid id, UpdateEmployeeDto updateEmployeedto) //This Method also need information to update similar to Get method based on ID
        { //This method contains 2 parameters like id and updateEmployeedto for performing action

            var employee = dbContext.Employees.Find(id);

            if (employee is null)
            {

                return NotFound();
            }
            
            //below lines are for updating the properties of updateEmployeedto
            employee.Name = updateEmployeedto.Name;
            employee.Email = updateEmployeedto.Email;
            employee.Phone = updateEmployeedto.Phone;
            employee.Salary = updateEmployeedto.Salary;

            dbContext.SaveChanges();



            return Ok(employee);
        }


        //S5 To delete a resource by its identifier id using httpDelete attribute in rstful practice

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var employee = dbContext.Employees.Find(id);

            if (employee is null)
            {
                return NotFound();
            }

            dbContext.Employees.Remove(employee);
            dbContext.SaveChanges();  //changes is required
            return Ok(); //Sending Ok response with an empty response back
        }
   
        
        
        
        
        
        
     }


 }
