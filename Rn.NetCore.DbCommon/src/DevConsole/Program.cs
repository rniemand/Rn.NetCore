using System;
using System.Threading.Tasks;
using DevConsole.DatabaseTesting;
using Microsoft.Extensions.DependencyInjection;

namespace DevConsole;

class Program
{
  private static readonly IServiceProvider Services = DIContainer.GetContainer();

  static async Task Main()
  {
    var userRepo = Services.GetRequiredService<IUserRepo>();
    var userEntity = await userRepo.GetUser();

    Console.WriteLine(userEntity?.Username ?? "NULL");
    Console.WriteLine();
  }
}
