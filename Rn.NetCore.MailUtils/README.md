[Home](/README.md)

# Documentation
Starter documentation for `Rn.NetCore.MailUtils`.

Usage is as simple as:

- [Adding required configuration](/docs/configuration/RnMailConfig.md) to your application
- [Registering - Rn.NetCore.MailUtils](/docs/misc/ServiceRegistration.md)
- Injecting [ISmtpClientFactory](/docs/factories/SmtpClientFactory.md) and [IMailMessageBuilderFactory](/docs/factories/MailMessageBuilderFactory.md) to your class
- Building your message and sending it


## Builders
The following `builders` are exposed by **Rn.NetCore.MailUtils**.

- [MailMessageBuilder](/docs/builders/MailMessageBuilder.md) - utility for building [MailMessage](https://docs.microsoft.com/en-us/dotnet/api/system.net.mail.mailmessage?view=net-6.0).
- [MailTemplateBuilder](/docs/builders/MailTemplateBuilder.md) - used to generate `HTML` content using a mail template.

## Configuration
This section covers all the configuration objects exposed by **Rn.NetCore.MailUtils**.

- [RnMailConfig](/docs/configuration/RnMailConfig.md) - core mail client configuration.

## Factories
The following `factories` are exposed by **Rn.NetCore.MailUtils**.

- [SmtpClientFactory](/docs/factories/SmtpClientFactory.md) - used to create new instances of the [SmtpClientWrapper](/docs/wrappers/SmtpClientWrapper.md) wrapper class.
- [MailMessageBuilderFactory](/docs/factories/MailMessageBuilderFactory.md) - used to create pre-configured instances of the [MailMessageBuilder](/docs/builders/MailMessageBuilder.md) builder.


## Helpers
The following `helpers` are exposed by **Rn.NetCore.MailUtils**.

- [Mail Templates](/docs/misc/MailTemplates.md) - covers the usage of mail templates.
- [Mail Template Placeholders](/docs/misc/MailTemplatePlaceholders.md) - covers the usage of mail template placeholders.

## Misc
Covers everything else to do with **Rn.NetCore.MailUtils**.

- [Mail Templates](/docs/misc/MailTemplates.md) - covers the usage of mail templates.
- [Mail Template Placeholders](/docs/misc/MailTemplatePlaceholders.md) - covers the usage of mail template placeholders.
- [Service Registration](/docs/misc/ServiceRegistration.md) - details how to register **Rn.NetCore.MailUtils**.

## Providers
The following `providers` are exposed by **Rn.NetCore.MailUtils**.

- [RnMailConfigProvider](/docs/providers/RnMailConfigProvider.md) - used to provide instances of the [RnMailConfig](/docs/configuration/RnMailConfig.md) class.
- [MailTemplateProvider](/docs/providers/MailTemplateProvider.md) - used to resolve and provide instances of [MailTemplateBuilder](/docs/builders/MailTemplateBuilder.md).

## Wrappers
The following `wrappers` are exposed by **Rn.NetCore.MailUtils**.

- [SmtpClientWrapper](/docs/wrappers/SmtpClientWrapper.md) - basic wrapper for the `.net` **SmtpClient** class.


<!--(Rn.BuildScriptHelper){
	"version": "1.0.106",
	"replace": false
}(END)-->