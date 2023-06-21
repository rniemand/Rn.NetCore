using System;

namespace Rn.NetCore.Common.Wrappers;

// DOCS: docs\wrappers\ConsoleWrapper.md
public interface IConsole
{
  ConsoleColor ForegroundColor { get; set; }
  void WriteLine(string? value);
  void ResetColor();
}

public class ConsoleWrapper : IConsole
{
  public ConsoleColor ForegroundColor
  {
    get => Console.ForegroundColor;
    set => Console.ForegroundColor = value;
  }

  public void WriteLine(string? value) => Console.WriteLine(value);
  public void ResetColor() => Console.ResetColor();
}
