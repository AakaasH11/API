using A5.Models;

namespace A5.Data.Repository.Interface
{
    public interface IEmployeeRepository
        {
        public bool CreateEmployee(Employee employee,int employeeId);
        public bool DisableEmployee(int id,int employeeId);
        public bool UpdateEmployee(Employee employee,int employeeId);
        public Employee? GetEmployeeById(int id);
        public IEnumerable<Employee> GetAllEmployees();
        public IEnumerable<Employee> GetByHR(int id);
        public IEnumerable<Employee> GetByReportingPerson(int id);
        public IEnumerable<Employee> GetEmployeeByDepartmentId(int id);
        public IEnumerable<Employee> GetReportingPersonByDepartmentId(int id);
        public IEnumerable<Employee> GetHrByDepartmentId(int id);
        public IEnumerable<Employee> GetEmployeeByRequesterId(int id);
        public IEnumerable<Employee> GetEmployeeByOrganisation(int id);
        public Employee GetEmployee(string Email, string Password);        
        public int GetEmployeeCount(int id);




    }
}