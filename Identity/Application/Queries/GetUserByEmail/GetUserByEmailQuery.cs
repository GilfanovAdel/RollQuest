using Domain;
using MediatR;

namespace Application.Queries.GetUserByEmail;

public class GetUserByEmailQuery : IRequest<User>
{
   

    public  string Email { get; set; }
}