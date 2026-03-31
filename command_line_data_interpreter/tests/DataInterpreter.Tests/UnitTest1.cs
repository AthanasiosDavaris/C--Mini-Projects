using System.Reflection;

namespace DataInterpreter;

public class DataStoreTests
{
    [Fact]
    public void FindEmployeeById_ShouldReturnCorrectEmployee_WhenExists()
    {
        var store = new DataStore();
        var employeeToAdd = new Employee(101, "Jane Doe");
        store.AddEmployee(employeeToAdd);

        var foundEmployee = store.FindEmployeeById(101);

        Assert.NotNull(foundEmployee);
        Assert.Equal(101, foundEmployee.Id);
        Assert.Equal("Jane Doe", foundEmployee.Name);
    }

    [Fact]
    public void FindEmployeeById_ShouldReturnNull_WhenNotExists()
    {
        var store = new DataStore();
        store.AddEmployee(new Employee(101, "Jane Doe"));

        var foundEmployee = store.FindEmployeeById(999);

        Assert.Null(foundEmployee);
    }

    [Fact]
    public void SortEmployeesById_ShouldOrderEmployeesCorrectly()
    {
        var store = new DataStore();
        store.AddEmployee(new Employee(200, "Charlie"));
        store.AddEmployee(new Employee(100, "Alice"));
        store.AddEmployee(new Employee(150, "Bob"));

        store.SortEmployeesById();
        var sortedEmployees = store.GetAllEmployees().ToList();

        Assert.Equal(100, sortedEmployees[0].Id);
        Assert.Equal(150, sortedEmployees[1].Id);
        Assert.Equal(200, sortedEmployees[2].Id);
    }
}