# Rn.NetCore.DbCommon
Common DB abstractions \ utilities for your code

Source code for the project can be found [here](https://github.com/rniemand/Rn.NetCore.DbCommon).

# Core Components
- [BaseRepo\<T\>](/docs/BaseRepo.md) - all your repositories should make use of this class.
- [ConnectionResolver](/docs/ConnectionResolver.md) - used to resolve the appropriate connection string to use for a given repository
- [Metrics](/docs/Metrics.md) - covers metrics logged by the [BaseRepo\<T\>](/docs/BaseRepo.md).

## Config
- [RnDbConfig](/docs/config/RnDbConfig.md) - base configuration for `Rn.NetCore.DbCommon`.

## Helpers
- [MSSqlConnectionHelper](/docs/helpers/MSSqlConnectionHelper.md)
- [MySqlConnectionHelper](/docs/helpers/MySqlConnectionHelper.md)

## Misc.
- [ServiceExtensions](/docs/misc/ServiceExtensions.md) - details on how services are registered using the `.AddRnDbCommon()` extension method.

<!--(Rn.BuildScriptHelper){
	"version": "1.0.106",
	"replace": false
}(END)-->