using System.IO;

namespace WPF_Generating_Controls;
internal class Configuration
{
  static Configuration()
  {
    InitStudents();
    InitSubjects();
  }
  public static int[] Levels => new int[] { 1, 2, 3, 4, 5 };
  public static List<Student> Students { get; private set; } = [];
  public static List<string> Subjects { get; private set; } = [];

  private static void InitStudents()
  {
    string[] lines = File.ReadAllLines("145a_students.csv");
    foreach (string line in lines)
    {
      Students.Add(Student.Parse(line));
    }
  }
  private static void InitSubjects()
  {
    string[] lines = File.ReadAllLines("145a_subjects.csv");
    foreach (string line in lines[0].Split(";"))
    {
      Subjects.Add(line);
    }
  }
  public static void SaveServices()
  {
    List<string> services = new List<string>();
    foreach (Student student in Students)
    {
      foreach (var service in student.Services)
      {
        services.Add($"{student.Name};{service.Subject};{service.Level}");
      }
    }
    File.WriteAllLines("tutorings.csv", services);
  }

  public static void LoadServices()
  {
    string[] lines = File.ReadAllLines("tutorings.csv");
    foreach(var student in Students)
    {
      student.Services.Clear();
    }
    foreach (string line in lines)
    {
      var parts = line.Split(";");
      Student? studentCheck = Students.Find((Student student ) => student.Name==parts[0]);
      if (studentCheck == null) continue;
      Student student = (Student)studentCheck;
      student.Services.Add(Service.Parse(line));
    }
  }

}
