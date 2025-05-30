using MediatR;
using Ordering.Domain.Abstractions;
using Ordering.Domain.Models;

namespace Ordering.Domain.Events;

public record OrderUpdatedEvent(Order Order) : IDomainEvent;