namespace GenZ.Database.Repository
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployee();

        void InsertEmployeeUsingEE(Employee emp);
        void InsertEmployeeUsingSP(Employee emp);

        Employee GetEmployeeById(int id);

        void UpdateEmployee(Employee emp);

        void DeleteEmployee(int id);
    }
}
