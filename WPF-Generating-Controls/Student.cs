namespace WPF_Generating_Controls;
internal class Student
{
  private Student() { }
  public required string Clazz { get; init; }
  public required string Firstname { get; init; }
  public required string LastName { get; init; }
  public string Name => $"{LastName} {Firstname}";
  public override string ToString() => Name;

  public static Student Parse(string line)
  {
    string[] parts = line.Split(";");
    return parts.Length != 3
      ? throw new Exception($"Illegal Line: {line}") :
      new Student()
      {
        Clazz = parts[0],
        Firstname = parts[1],
        LastName = parts[2],
      };
  }
}
