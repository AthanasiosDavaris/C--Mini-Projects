using System.Collections;

/// <summary>
/// Represents a single node in the CustomLinkedList.
/// </summary>
public class Node
{
  public Employee Data { get; set; }
  public Node? Next { get; set; }

  public Node(Employee data)
  {
    Data = data;
    Next = null;
  }
}

/// <summary>
/// A custom implementation of a singly linked list for storing Employee objects.
/// </summary>
public class CustomLinkedList : IEnumerable<Employee>
{
  private Node? head;

  /// <summary>
  /// Adds a new employee to the end of the list.
  /// </summary>
  /// <param name="employee">The employee to add.</param>
  public void Add(Employee employee)
  {
    Node newNode = new Node(employee);
    if (head == null)
    {
      head = newNode;
    }
    else
    {
      // Traverse to the end of the list
      Node current = head;
      while (current.Next != null)
      {
        current = current.Next;
      }
      current.Next = newNode;
    }
  }

  /// <summary>
  /// Clears all nodes from the list.
  /// </summary>
  public void Clear()
  {
    head = null;
  }

  /// <summary>
  /// Returns an enumerator that iterates through the linked list.
  /// This allows the use of 'foreach' loops.
  /// </summary>
  public IEnumerator<Employee> GetEnumerator()
  {
    Node? current = head;
    while (current != null)
    {
      yield return current.Data;
      current = current.Next;
    }
  }

  IEnumerator IEnumerable.GetEnumerator()
  {
    return GetEnumerator();
  }
}