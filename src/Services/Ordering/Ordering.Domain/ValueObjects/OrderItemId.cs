﻿using Ordering.Domain.Exceptions;

namespace Ordering.Domain.ValueObjects;

public record OrderItemId
{
    public Guid Value { get; }
    
    public OrderItemId(Guid value) => Value = value;

    public static OrderItemId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        
        if (value == Guid.Empty)
        {
            throw new DomainException("Value cannot be empty.");
        }
        
        return new OrderItemId(value);
    }
}