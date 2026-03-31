/// <summary>
///  Represents the data model for an employee.
/// </summary>
public class Employee
{
  public int Id { get; set; }
  public string Name { get; set; }

  public Employee(int id, string name)
  {
    Id = id;
    Name = name;
  }

  /// <summary>
  /// Provides a string representation of the Employee object.
  /// </summary>
  /// <returns>A formatted string with the employee's ID and name.</returns>
  public override string ToString()
  {
    return $"ID: {Id}, Name: {Name}";
  }
}