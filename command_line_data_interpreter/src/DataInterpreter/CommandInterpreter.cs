using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

public interface ICommand
{
  string Execute();
}

public class CommandContext
{
  public DataStore Store { get; }
  public string[] Args { get; }

  public CommandContext(DataStore store, string[] args)
  {
    Store = store;
    Args = args;
  }
}

public class AddCommand : ICommand
{
  private readonly CommandContext _context;
  public AddCommand(CommandContext context) { _context = context; }

  public string Execute()
  {
    if (_context.Args.Length != 3) return "Error: ADD command requires an ID and a name.";
    if (!int.TryParse(_context.Args[1], out int id)) return "Error: Invalid ID format.";

    var employee = new Employee(id, _context.Args[2]);
    return _context.Store.AddEmployee(employee);
  }
}

public class FindCommand : ICommand
{
  private readonly CommandContext _context;
  public FindCommand(CommandContext context) { _context = context; }

  public string Execute()
  {
    if (_context.Args.Length != 2) return "Error: FIND command requires an ID.";
    if (!int.TryParse(_context.Args[1], out int id)) return "Error: Invalid ID format.";

    var employee = _context.Store.FindEmployeeById(id);
    return employee?.ToString() ?? $"Employee with ID {id} not found.";
  }
}

public class ListCommand : ICommand
{
  private readonly CommandContext _context;
  public ListCommand(CommandContext context) { _context = context; }

  public string Execute()
  {
    var employees = _context.Store.GetAllEmployees();
    if (!employees.Any()) return "No employees in the database.";
    return string.Join("\n", employees.Select(e => e.ToString()));
  }
}

public class SortCommand : ICommand
{
  private readonly CommandContext _context;
  public SortCommand(CommandContext context) { _context = context; }

  public string Execute()
  {
    _context.Store.SortEmployeesById();
    return "Employees sorted by ID.";
  }
}

public static class CommandInterpreter
{
  public static ICommand? Parse(string input, DataStore store)
  {
    var parts = new List<string>();

    var regex = new System.Text.RegularExpressions.Regex("\"[^\"]*\"|\\S+");

    foreach (System.Text.RegularExpressions.Match m in regex.Matches(input))
    {
      parts.Add(m.Value.Trim('"'));
    }

    if (parts.Count == 0) return null;

    var commandName = parts[0].ToUpper();
    var context = new CommandContext(store, parts.ToArray());

    return commandName switch
    {
      "ADD" => new AddCommand(context),
      "FIND" => new FindCommand(context),
      "LIST" => new ListCommand(context),
      "SORT" => new SortCommand(context),
      _ => null,
    };
  }
}