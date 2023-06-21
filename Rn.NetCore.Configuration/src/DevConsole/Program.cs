using System;
using DevConsole.DevTesting;

namespace DevConsole;

class Program
{
  static void Main(string[] args)
  {
    new ServiceDev(DIContainer.Services)
      .TestConfigService();

    Console.WriteLine("Hello World!");
  }
}
