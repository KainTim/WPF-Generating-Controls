using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Generating_Controls;
internal class Service
{
  public required int Level { get; init; }
  public required string Subject { get; init; }

  internal static Service Parse(string line)
  {
    var parts = line.Split(";");
    return new Service()
    {
      Subject = parts[1],
      Level = int.Parse(parts[2]),
    };
  }
  public override string ToString() => $"{Subject} in den {Level}. Klassen";
}
