using System.Collections.Concurrent;

/// <summary>
/// Manages the in-memory data store for employees, handling operations like adding, finding, and sorting.
/// </summary>
public class DataStore
{
  private CustomLinkedList employees = new CustomLinkedList();

  /// <summary>
  /// Adds a new employee to the data store.
  /// </summary>
  /// <param name="employee">The employee to add.</param>
  /// <returns>A confirmation message.</returns>
  public string AddEmployee(Employee employee)
  {
    employees.Add(employee);
    return $"Added: {employee}";
  }

  /// <summary>
  /// Finds an employee using a Serial (Linear) Search algorithm.
  /// </summary>
  /// <param name="id">The ID of the employee to find.</param>
  /// <returns>The found Employee object, or null if not found.</returns>
  public Employee? FindEmployeeById(int id)
  {
    foreach (var employee in employees)
    {
      if (employee.Id == id)
      {
        return employee; // Found
      }
    }
    return null; // Not found
  }

  /// <summary>
  /// Sorts the employees by ID using the QuickSort algorithm
  /// </summary>
  public void SortEmployeesById()
  {
    var empArray = employees.ToArray();
    if (empArray.Length > 1)
    {
      QuickSort(empArray, 0, empArray.Length - 1);
    }

    // Rebuild the linked list from the sorted array
    employees.Clear();
    foreach (var emp in empArray)
    {
      employees.Add(emp);
    }
  }

  /// <summary>
  /// The recursive core of the QuickSort algorithm.
  /// </summary>
  private void QuickSort(Employee[] array, int left, int right)
  {
    if (left < right)
    {
      int pivotIndex = Partition(array, left, right);
      QuickSort(array, left, pivotIndex - 1);
      QuickSort(array, pivotIndex + 1, right);
    }
  }

  /// <summary>
  /// Partitions the array for the QuickSort algorithm.
  /// </summary>
  private int Partition(Employee[] array, int left, int right)
  {
    int pivotId = array[right].Id;
    int i = (left - 1);

    for (int j = left; j < right; j++)
    {
      if (array[j].Id <= pivotId)
      {
        i++;
        (array[i], array[j]) = (array[j], array[i]);
      }
    }
    (array[i + 1], array[right]) = (array[right], array[i + 1]);
    return i + 1;
  }

  /// <summary>
  /// Retrieves all employees currently in the data store.
  /// </summary>
  public IEnumerable<Employee> GetAllEmployees()
  {
    return employees;
  }
}