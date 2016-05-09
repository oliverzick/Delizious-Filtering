# Delizious Filtering
A flexible and easy to use .NET library that simplifies matching of values (definition of conditions) and filtering.

## Getting started
To install Delizious-Filtering, run the following command in the [Package Manager Console](http://docs.nuget.org/docs/start-here/using-the-package-manager-console):

    PM> Install-Package Delizious-Filtering

## License
Apache License, Version 2.0 
[http://opensource.org/licenses/Apache-2.0](http://opensource.org/licenses/Apache-2.0)

## Tutorial
#### `Always` match
Succeeds always and returns `true` no matter what value is matched:
        
    var match = Match.Always<int>();

    // Always true
    var matches = match.Matches(123);
        
#### `Never` match
Succeeds never and returns `false` no matter what value is matched:

    var match = Match.Never<int>();

    // Never true - always false ;-)
    var matches = match.Matches(123);

### `Null` match
Succeeds when the value to match is a `null` reference:

    var match = Match.Null<string>();
    
    // true, null matches null (surprise!)
    var successful = match.Matches(null);
    
    // false, "Some" is not a null reference (surprise too!)
    var failed = match.Matches("Some");

### `NotNull` match
Succeeds when the value to match is not a `null` reference:
    
    var match = Match.NotNull<string>();
    
    // true, "Some" is not a null reference
    var successful = match.Matches("Some");
    
    // false, null is null - and not 'not null' ;-)
    var failed = match.Matches(null);

### `Same` match
Succeeds when the value to match represents the same instance the match was initialized with:

    var some = new object();
    var other = new object();
    
    var match = Match.Same(some);
    
    // true, "some" is the same reference the match was initialized with
    var areSame = match.Matches(some);
    
    // false, "other" is not the same reference the match was initialized with
    var areNotSame = match.Matches(other);
