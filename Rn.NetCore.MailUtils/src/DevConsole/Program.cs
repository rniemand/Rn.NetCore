using DevConsole;
using Microsoft.Extensions.DependencyInjection;
using Rn.NetCore.MailUtils;

var rnMailConfig = DIContainer.Services
  .GetRequiredService<RnMailConfig>();

var smtpClient = DIContainer.Services
  .GetRequiredService<IRnMailUtilsFactory>()
  .CreateSmtpClient();

var messageBuilder = DIContainer.Services
  .GetRequiredService<IRnMailUtilsFactory>()
  .CreateMessageBuilder();

var templateHelper = DIContainer.Services
  .GetRequiredService<IMailTemplateHelper>();

var templateBuilder = templateHelper.GetTemplateBuilder("testing")
  .AddPlaceHolder("name", "Richard Niemand")
  .AddPlaceHolder("currentDate", DateTime.Now)
  .AddPlaceholders(new Dictionary<string, object>
  {
    {"hello", "World"},
    {"int", 23},
    {"long", (long) 12},
    {"bool", true},
    {"double", 12.2},
    {"float", (float) 12}
  });

var mailMessage = messageBuilder
  .WithTo(rnMailConfig.FromAddress)
  .WithHtmlBody(templateBuilder)
  .WithSubject("Hello world")
  .Build();

//await smtpClient.SendMailAsync(mailMessage);

Console.WriteLine();
Console.WriteLine();
