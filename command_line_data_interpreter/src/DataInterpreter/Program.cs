public class Program
{
  public static void Main(string[] args)
  {
    var dataStore = new DataStore();
    Console.WriteLine("--- Command-Line Data Interpreter ---");
    Console.WriteLine("Available commands: ADD <id> \"<name>\", FIND <id>, SORT, LIST, EXIT");

    while (true)
    {
      Console.Write("> ");
      var input = Console.ReadLine();

      if (string.IsNullOrWhiteSpace(input)) continue;
      if (input.ToUpper() == "EXIT") break;

      var command = CommandInterpreter.Parse(input, dataStore);

      if (command != null)
      {
        var result = command.Execute();
        Console.WriteLine(result);
      }
      else
      {
        Console.WriteLine("Error: Unknown command.");
      }
    }
  }
}