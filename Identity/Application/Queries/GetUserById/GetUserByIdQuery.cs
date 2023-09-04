using Domain;
using MediatR;

namespace Application.Queries.GetUserById;

public class GetUserByIdQuery : IRequest<User>
{
    public GetUserByIdQuery(Guid id)
    {
        Id = id;
    }

    public  Guid Id { get; set; }
}