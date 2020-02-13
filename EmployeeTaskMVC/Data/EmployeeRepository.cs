using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace EmployeeTaskMVC.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public readonly DataContext _context;

        public EmployeeRepository(DataContext dataContext)
        {
            _context = dataContext;
        }
        public async Task<Employee> GetEmployee(int? id)
        {   
            return await _context.Employees.FindAsync(id);
        }

        public async Task<List<Employee>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }
    }
}