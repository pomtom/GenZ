using GenZ.Business.Service;
using GenZ.Database;
using GenZ.Database.Repository;
using Moq;

namespace GenZ.UnitTest
{
    public class Tests
    {
        Mock<IEmployeeRepository> IEmployeeRepositorymock = new Mock<IEmployeeRepository>();

        [SetUp]
        public void Setup()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee { Id = 101, Name = "Pramod", BirthDate = DateTime.Now.AddYears(-30), City = "Mumbai", Phone = 123 });
            employees.Add(new Employee { Id = 102, Name = "Viay", BirthDate = DateTime.Now.AddYears(-20), City = "Mumbai", Phone = 123 });
            IEmployeeRepositorymock.Setup(p => p.GetAllEmployee()).Returns(employees);
        }

        [Test]
        public void BusinessGetAllEmployeeTest()
        {
            EmployeeService service = new EmployeeService(IEmployeeRepositorymock.Object);
            var response = service.GetAllEmployee();
            Assert.IsNotNull(response);
            Assert.AreEqual(2, response.Count());
        }
    }
}