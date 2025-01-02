using MediatR;

namespace BuildingBlocks.CQRS;

public interface IQueryHandler <in Tquery, Tresponse> : IRequestHandler<Tquery, Tresponse>
    where Tquery : IQuery<Tresponse>
    where Tresponse : notnull
{
}