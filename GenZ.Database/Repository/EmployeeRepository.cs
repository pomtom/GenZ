using GenZ.Framework;

namespace GenZ.Database.Repository
{
    public class EmployeeRepository : BaseRepository<GenZDbContext, Employee>, IEmployeeRepository
    {

        public IEnumerable<Employee> GetAllEmployee()
        {
            var query = GetAll().ToList();
            return query;
        }

        public void InsertEmployeeUsingEE(Employee emp)
        {
            AddEntity(emp);
            SaveEntity();
        }

        public void InsertEmployeeUsingSP(Employee emp)
        {
            //try
            //{
            //    SqlParameter[] sqlParams = new SqlParameter[]
            //       {
            //        new SqlParameter { ParameterName = "@Name",  Value =emp.Name , Direction = System.Data.ParameterDirection.Input},
            //        new SqlParameter { ParameterName = "@Email",  Value =emp.Age, Direction = System.Data.ParameterDirection.Input },
            //        new SqlParameter { ParameterName = "@Dob",  Value =emp.BirthDate, Direction = System.Data.ParameterDirection.Input },
            //        new SqlParameter { ParameterName = "@adress",  Value = emp.Gender, Direction = System.Data.ParameterDirection.Input }
            //       };

            //    this.Context.Database.ExecuteSqlCommand("USP_InsertEmploee @Name, @Email, @Dob, @adress", sqlParams);
            //}
            //catch (System.Exception)
            //{
            //    throw;
            //}
        }

        public Employee GetEmployeeById(int id)
        {
            var employee = FindByFunc(a => a.Id == id).FirstOrDefault();
            return employee;
        }

        public void UpdateEmployee(Employee emp)
        {
            EditEntity(emp);
            SaveEntity();
        }

        public void DeleteEmployee(int id)
        {
            var employee = GetEmployeeById(id);
            DeleteEntity(employee);
            SaveEntity();
        }
    }
}
