using System.Collections.Generic;
using System.Linq;
using A5.Models;
using A5.Data.Base;
using A5.Data.Service.Interfaces;

namespace A5.Data.Service
{
    public class EmployeeService : EntityBaseRepository<Employee>, IEmployeeService
    {
        private readonly AppDbContext _context;
        public EmployeeService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Employee> GetByHR(int id)
        {
            try
            {
                return _context.Set<Employee>().Where(nameof => nameof.HRId == id && nameof.IsActive == true).ToList();
            }
            catch(Exception exception)
            {
                throw exception;
            }
            
        }

        public IEnumerable<Employee> GetByReportingPerson(int id)
        {
            try
            {
                return _context.Set<Employee>().Where(nameof => nameof.ReportingPersonId == id).ToList();
            }
            catch(Exception exception)
            {
                throw exception;
            }
            
        }

        public IEnumerable<Employee> GetEmployeeByDepartmentId(int id)
        {
            try
            {
                return _context.Set<Employee>().Where(nameof => nameof.DepartmentId == id).ToList();
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }
         public IEnumerable<Employee> GetEmployeeByRequesterId(int id)
        {
            try
            {
                return _context.Set<Employee>().Where(nameof => nameof.ReportingPersonId == id).ToList();
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }
        public IEnumerable<Employee> GetEmployeeByOrganisation(int id)
        {
            try
            {
                var result = _context.Set<Employee>().Where(nameof =>nameof.IsActive == true && nameof.OrganisationId == id).ToList();
                return result;
            }
            catch(Exception exception)
            {
                throw exception;
            }
            
        }

    }
}