# Rn.NetCore.Common
Common C# abstractions for your code, installation is as simple as:

    Install-Package Rn.NetCore.Common

This is a `WIP` and may change between commits, however I will do my best to ensure that there is some backwards compatability between builds.

This package is used to abstract common `classes` and `interfaces` used in my applications and exposes the following:

# Documentation
More to come...

## Abstractions
- [AppDomainAbstraction](/docs/abstractions/AppDomainAbstraction.md) - via the `IAppDomainAbstraction` interface.
- [DateTimeAbstraction](/docs/abstractions/DateTimeAbstraction.md) - via the `IDateTimeAbstraction` interface.
- [DirectoryAbstraction](/docs/abstractions/DirectoryAbstraction.md) - via the `IDirectoryAbstraction` interface.
- [EnvironmentAbstraction](/docs/abstractions/EnvironmentAbstraction.md) - via the `IEnvironmentAbstraction` interface.
- [FileAbstraction](/docs/abstractions/FileAbstraction.md) - via the `IFileAbstraction` interface.
- [PathAbstraction](/docs/abstractions/PathAbstraction.md) - via the `IPathAbstraction` interface.
- [RuntimeInformationAbstraction](/docs/abstractions/RuntimeInformationAbstraction.md) - via the `IRuntimeInformationAbstraction` class.
- [StopwatchAbstraction](/docs/abstractions/StopwatchAbstraction.md) - via the `IStopwatchAbstraction` class.

## Exceptions
- [List of all Exceptions](/docs/exceptions/README.md)

## Extensions
- [DateExtensions](/docs/extensions/DateExtensions.md)
- [EnumerableExtensions](/docs/extensions/EnumerableExtensions.md)
- [RegexExtensions](/docs/extensions/RegexExtensions.md)
- [StringExtensions](/docs/extensions/StringExtensions.md)

## Factories
- [AppDomainFactory](/docs/factories/AppDomainFactory.md)
- [IOFactory](/docs/factories/IOFactory.md)
- [RandomFactory](/docs/factories/RandomFactory.md)
- [StopwatchFactory](/docs/factories/StopwatchFactory.md)

## Helpers
- [DateHelper](/docs/helpers/DateHelper.md)
- [JsonHelper](/docs/helpers/JsonHelper.md)
- [RandomHelper](/docs/helpers/RandomHelper.md)

## Logging
- [LoggerAdapter](/docs/logging/LoggerAdapter.md)
- [LoggerExtensions](/docs/logging/LoggerExtensions.md)

## Wrappers
- [AppDomainWrapper](/docs/wrappers/AppDomainWrapper.md) - via the `IAppDomain` interface.
- [ConsoleWrapper](/docs/wrappers/ConsoleWrapper.md) - via the `IConsole` interface.
- [DirectoryInfoWrapper](/docs/wrappers/DirectoryInfoWrapper.md) - via the `IDirectoryInfo` interface.
- [FileInfoWrapper](/docs/wrappers/FileInfoWrapper.md) - via the `IFileInfo` interface.
- [IFileSystemInfo](/docs/wrappers/IFileSystemInfo.md) - provides common `FileInfo` properties.
- [RandomWrapper](/docs/wrappers/RandomWrapper.md) - via the `IRandomWrapper` interface.
- [StopwatchWrapper](/docs/wrappers/StopwatchWrapper.md) - via the `IStopwatchWrapper` interface.

<!--(Rn.BuildScriptHelper){
	"version": "1.0.106",
	"replace": false
}(END)-->