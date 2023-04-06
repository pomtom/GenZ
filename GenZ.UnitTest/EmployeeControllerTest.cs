using GenZ.Business.Service;
using GenZ.Database;
using GenZ.WebApi.Controllers;
using Moq;

namespace GenZ.UnitTest
{
    public class EmployeeControllerTest
    {
        [Test]
        public void Get_ShouldReturnAllEmployees()
        {
            // Arrange
            var mockEmployeeService = new Mock<IEmployeeService>();
            mockEmployeeService.Setup(x => x.GetAllEmployee()).Returns(new List<Employee> { new Employee { Id = 1, Name = "John" }, new Employee { Id = 2, Name = "Jane" } });
            var controller = new EmployeeController(mockEmployeeService.Object);

            // Act
            var result = controller.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual(1, result.ElementAt(0).Id);
            Assert.AreEqual("John", result.ElementAt(0).Name);
            Assert.AreEqual(2, result.ElementAt(1).Id);
            Assert.AreEqual("Jane", result.ElementAt(1).Name);
        }

        [Test]
        public void Get_ShouldThrowException()
        {
            // Arrange
            var mockEmployeeService = new Mock<IEmployeeService>();
            mockEmployeeService.Setup(x => x.GetAllEmployee()).Throws(new Exception());
            var controller = new EmployeeController(mockEmployeeService.Object);

            // Act & Assert
            Assert.Throws<Exception>(() => controller.Get());
        }

        [Test]
        public void Get_ValidId_ReturnsEmployee()
        {
            // Arrange
            var employeeService = new Mock<IEmployeeService>();
            employeeService.Setup(x => x.GetEmployeeById(It.IsAny<int>())).Returns(new Employee());
            var controller = new EmployeeController(employeeService.Object);

            // Act
            var result = controller.Get(1);

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void Get_InvalidId_ThrowsException()
        {
            // Arrange
            var employeeService = new Mock<IEmployeeService>();
            employeeService.Setup(x => x.GetEmployeeById(It.IsAny<int>())).Throws(new Exception());
            var controller = new EmployeeController(employeeService.Object);

            // Act & Assert
            Assert.Throws<Exception>(() => controller.Get(1));
        }

        [Test]
        public void Post_ShouldInsertEmployeeUsingEE()
        {
            // Arrange
            var employee = new Employee();
            var mockEmployeeService = new Mock<IEmployeeService>();
            mockEmployeeService.Setup(x => x.InsertEmployeeUsingEE(employee)).Verifiable();
            var controller = new EmployeeController(mockEmployeeService.Object);

            // Act
            controller.Post(employee);

            // Assert
            mockEmployeeService.Verify();
        }

        [Test]
        public void Put_WhenIdDoesNotMatch_ShouldThrowArgumentException()
        {
            // Arrange
            var employeeService = new Mock<IEmployeeService>();
            var controller = new EmployeeController(employeeService.Object);
            var employee = new Employee { Id = 1 };

            // Act
            var exception = Assert.Throws<ArgumentException>(() => controller.Put(2, employee));

            // Assert
            Assert.AreEqual("argument not matched", exception.Message);
        }

        [Test]
        public void Put_WhenIdMatches_ShouldCallUpdateEmployee()
        {
            // Arrange
            var employeeService = new Mock<IEmployeeService>();
            var controller = new EmployeeController(employeeService.Object);
            var employee = new Employee { Id = 1 };

            // Act
            controller.Put(1, employee);

            // Assert
            employeeService.Verify(x => x.UpdateEmployee(employee), Times.Once);
        }

        [Test]
        public void Delete_ValidId_ShouldDeleteEmployee()
        {
            // Arrange
            int id = 1;
            var employeeServiceMock = new Mock<IEmployeeService>();
            employeeServiceMock.Setup(x => x.DeleteEmployee(id)).Verifiable();
            var controller = new EmployeeController(employeeServiceMock.Object);

            // Act
            controller.Delete(id);

            // Assert
            employeeServiceMock.Verify(x => x.DeleteEmployee(id), Times.Once);
        }

        [Test]
        public void Delete_InvalidId_ShouldThrowException()
        {
            // Arrange
            int id = 0;
            var employeeServiceMock = new Mock<IEmployeeService>();
            employeeServiceMock.Setup(x => x.DeleteEmployee(id)).Throws<Exception>();
            var controller = new EmployeeController(employeeServiceMock.Object);

            // Act & Assert
            Assert.Throws<Exception>(() => controller.Delete(id));
        }
    }
}
