using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DelegateDemo;



public interface IValidator
{
    bool Validate(object value);
}

public interface IStringValue<T>
{
    string Value { get; }
}

public partial struct LocalCode
{
    public required string Value { get; init; }

    public bool Validate(object? value)
    {
        return value is not null;
    }
    
}

public partial struct LocalCode : IStringValue<string>, IValidator;

