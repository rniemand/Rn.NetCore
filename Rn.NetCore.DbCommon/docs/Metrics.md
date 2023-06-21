[Home](/README.md) / Metrics

# Metrics
The following metrics are logged by the various methods found under the [BaseRepo\<T\>](/docs/BaseRepo.md) class.

## Core metric fields
The following core metric values are logged:

| | Repo | Method | Type | Connection | Params | Model | Success | Exception |
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| `GetList<T>` | ✔️ | ✔️ | ✔️ | ✔️ | ✔️ | ✔️ | ✔️ | ✔️ |
| `GetSingle<T>` | ✔️ | ✔️ | ✔️ | ✔️ | ✔️ | ✔️ | ✔️ | ✔️ |
| `ExecuteAsync` | ✔️ | ✔️ | ✔️ | ✔️ | ✔️ | ✔️ | ✔️ | ✔️ |

They are represented as the following Tags and Fields:

- **Repo** (🏷️) `repo_name` - the name of the repo wrapping [BaseRepo\<T\>](/docs/BaseRepo.md).
- **Method** (🏷️) `repo_method` - the method name passed into the helper method call.
- **Type** (🏷️) `command_type` - SQL query method type.
- **Connection** (🏷️) `connection` - the name of the connection being used.
- **Params** (🏷️) `has_params` - boolen representing that parameters were present.
- **Model** (🏷️) `model` - type name of the model (if any) used for the query.
- **Success** (🏷️) `success` - boolean indicating the cuccess of the command.
- **Exception** (🏷️) `has_ex` - boolean indicating if an exception was thrown.
- **Exception** (🏷️) `ex_name` - the type name of the thrown exception (when `has_ex` is **true**).

## Query and result fields
The following query and result related metric values are logged:

| | Query Count | Results Count |
| --- | --- | --- |
| `GetList<T>` | ✔️ | ✔️ |
| `GetSingle<T>` |  ✔️ | ✔️ |
| `ExecuteAsync` | ✔️ | ✔️ |

They are represented as the following Tags and Fields:

- **Query Count** (#️⃣) `query_count` - amount of SQL queries executed.
- **Results Count** (#️⃣) `results_count` - amount of results \ affected rows.

## Timing Fields
The following timing metric values are logged:

| | Base Timing | 
| --- | --- |
| `GetList<T>` | ✔️ |
| `GetSingle<T>` |  ✔️ |
| `ExecuteAsync` | ✔️ |

They are represented as the following Tags and Fields:

- **Base Timing** (🕒) `value` - overall execution time of the request.