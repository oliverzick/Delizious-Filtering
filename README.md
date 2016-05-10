# Delizious Filtering
## What?
Delizious Filtering is a flexible and easy to use .NET library entirely written in C# that simplifies matching of values as well as filtering of collections. It comes with a fluent and straightforward API and lets you define matches (conditions) the easy way.

## Features
Delizious Filtering provides the following features:
* Intuitive and fluent API design
* Enables separation of object graph construction (define matches) and application logic (match matches) as discussed [here](http://googletesting.blogspot.de/2008/08/by-miko-hevery-so-you-decided-to.html) (by the way a very interesting arcticle about writing testable code!)

Upcoming features:
* Implementation of matches is based on [immutability](https://blogs.msdn.microsoft.com/ericlippert/2007/11/13/immutability-in-c-part-one-kinds-of-immutability/) and value semantics
* Enable custom matches
* Simplified use with LINQ

## Matches

Match | What for
----- | --------
`Always` | Succeeds always no matter what value is matched
`Never` | Succeeds never no matter what value is matched
`Null` | Succeeds when a value is a `null` reference
`NotNull` | Succeeds when a value is not a `null` reference
`Same` | Succeeds when a value represents the same instance the match was initialized with
`NotSame` | Succeeds when a value does not represent the same instance the match was initialized with
`Equal` | Succeeds when a value is equal to the instance the match was initialized with
`NotEqual` | Succeeds when a value is not equal to the instance the match was initialized with
`GreaterThan` | Succeeds when a value is greater than the instance the match was initialized with
`GreaterThanOrEqualTo` | Succeeds when a value is greater than or equal to the instance the match was initialized with
`LessThan` | Succeeds when a value is less than the instance the match was initialized with
`LessThanOrEqualTo` | Succeeds when a value is less than or equal to the instance the match was initialized with
`All` | Succeeds when a value matches all of the given matches
`Any` | Succeeds when a value matches any of the given matches
`None` | Succeeds when a value matches none of the given matches

## Getting started
To install Delizious-Filtering, run the following command in the [Package Manager Console](http://docs.nuget.org/docs/start-here/using-the-package-manager-console):

    PM> Install-Package Delizious-Filtering

## License
Apache License, Version 2.0 
[http://opensource.org/licenses/Apache-2.0](http://opensource.org/licenses/Apache-2.0)
