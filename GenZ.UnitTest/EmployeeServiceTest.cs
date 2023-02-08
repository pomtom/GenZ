using Castle.Components.DictionaryAdapter.Xml;
using GenZ.Business.Service;
using GenZ.Database;
using GenZ.Database.Repository;
using Moq;

namespace GenZ.UnitTest
{
    [TestFixture]
    public class EmployeeServiceTest
    {
        Mock<IEmployeeRepository> employeeRepositorymock = new Mock<IEmployeeRepository>();
        private EmployeeService employeeservice;

        [SetUp]
        public void Setup()
        {
            employeeservice = new EmployeeService(employeeRepositorymock.Object);
        }

        [Test]
        public void GetAllEmployeeTest()
        {
            List<Employee> employees = getEmployees();
            employeeRepositorymock.Setup(p => p.GetAllEmployee()).Returns(employees);

            var response = employeeservice.GetAllEmployee();
            Assert.IsNotNull(response);
            Assert.That(response.Count(), Is.EqualTo(2));
        }

        [Test]
        public void GetEmployeeByIdTest()
        {
            Employee emp = GetEmployee();
            employeeRepositorymock.Setup(p => p.GetEmployeeById(emp.Id)).Returns(emp);

            var response = employeeservice.GetEmployeeById(emp.Id);
            Assert.IsNotNull(response);
            Assert.That(emp, Is.EqualTo(response));
        }

        [Test]
        public void InsertEmployeeUsingEETest()
        {
            Employee emp = GetEmployee();
            employeeRepositorymock.Setup(a => a.InsertEmployeeUsingEE(emp));
            employeeservice.InsertEmployeeUsingEE(emp);
            employeeRepositorymock.Verify(a => a.InsertEmployeeUsingEE(emp), Times.Once);
        }

        [Test]
        public void UpdateEmployeeTest()
        {
            Employee emp = GetEmployee();
            employeeRepositorymock.Setup(a => a.UpdateEmployee(emp));
            employeeservice.UpdateEmployee(emp);
            employeeRepositorymock.Verify(a => a.UpdateEmployee(emp), Times.Once);
        }

        [Test]
        public void DeleteEmployeeTest()
        {
            Employee emp = GetEmployee();
            employeeRepositorymock.Setup(a => a.DeleteEmployee(emp.Id));
            employeeservice.DeleteEmployee(emp.Id);
            employeeRepositorymock.Verify(a => a.DeleteEmployee(emp.Id), Times.Once);
        }

        private static Employee GetEmployee()
        {
            return new Employee { Id = 102, Name = "Sadhna", BirthDate = DateTime.Now.AddYears(-20), Phone = 321456, City = "Chambal" };
        }
        private static List<Employee> getEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee { Id = 101, Name = "Pramod", BirthDate = DateTime.Now.AddYears(-30), City = "Mumbai", Phone = 123 });
            employees.Add(new Employee { Id = 102, Name = "Viay", BirthDate = DateTime.Now.AddYears(-20), City = "Mumbai", Phone = 123 });
            return employees;
        }

    }
}