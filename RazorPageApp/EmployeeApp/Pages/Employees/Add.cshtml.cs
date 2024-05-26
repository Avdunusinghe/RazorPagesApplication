using EmployeeApp.Data;
using EmployeeApp.Models.Domain;
using EmployeeApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeeApp.Pages.Employees
{
    public class AddModel : PageModel
    {
        private readonly EmployeeDbContext _db;
        public AddModel(EmployeeDbContext _db)
        {
            this._db = _db;
        }
        [BindProperty]
        public EmployeeViewModel EmployeeViewModel { get; set; }
        public void OnGet()
        {
        }

        public void OnPost()
        {
            try
            {
                var employee = new Employee()
                {
                    Name = EmployeeViewModel.Name,
                    Email = EmployeeViewModel.Email,
                    Salary = EmployeeViewModel.Salary,
                    DateOfBirth = EmployeeViewModel.DateOfBirth,
                    Department = EmployeeViewModel.Department,
                };
                _db.Employees.Add(employee);
                _db.SaveChanges();

                ViewData["Message"] = "Employee has been saved successfully.";
                EmployeeViewModel = new EmployeeViewModel();
            }
            catch (Exception ex)
            {
                ViewData["Message"] = "Error has been occurred please try again.";
                throw;
            }

        }
    }
}
