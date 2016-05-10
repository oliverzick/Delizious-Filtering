# Delizious Filtering
## What?
Delizious Filtering is a .NET library entirely written in C# that simplifies matching of values as well as filtering of collections. It comes with a fluent and straightforward API and lets you define matches (conditions) the easy way.

## Features
Delizious Filtering provides the following features:
* Intuitive and fluent API design
* Implementation of matches is based on [immutability](https://blogs.msdn.microsoft.com/ericlippert/2007/11/13/immutability-in-c-part-one-kinds-of-immutability/) and value semantics (upcoming version)
* Enables separation of object graph construction (define matches) and application logic (match matches) as discussed [here](http://googletesting.blogspot.de/2008/08/by-miko-hevery-so-you-decided-to.html) (by the way a very interesting arcticle about writing testable code!)

## Matches

Match | What for
----- | --------
`Always` | Succeeds always and returns `true` no matter what value is matched
`Never` | Succeeds never and returns `false` no matter what value is matched
`Null` | Succeeds when the value to match is a `null` reference
`NotNull` | Succeeds when the value to match is not a `null` reference
`Same` | Succeeds when the value to match represents the same instance the match was initialized with
`NotSame` | Succeeds when the value to match does not represent the same instance the match was initialized with
`Equal` |
`NotEqual` |
`GreaterThan` |
`GreaterThanOrEqualTo` |
`LessThan` |
`LessThanOrEqualTo` |
`All` |
`Any` |
`None` |

## Getting started
To install Delizious-Filtering, run the following command in the [Package Manager Console](http://docs.nuget.org/docs/start-here/using-the-package-manager-console):

    PM> Install-Package Delizious-Filtering

## License
Apache License, Version 2.0 
[http://opensource.org/licenses/Apache-2.0](http://opensource.org/licenses/Apache-2.0)
