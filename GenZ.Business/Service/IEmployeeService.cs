using GenZ.Database;

namespace GenZ.Business.Service
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAllEmployee();

        void InsertEmployeeUsingSP(Employee emp);

        Employee GetEmployeeById(int id);

        void UpdateEmployee(Employee emp);

        void DeleteEmployee(int id);
    }
}
