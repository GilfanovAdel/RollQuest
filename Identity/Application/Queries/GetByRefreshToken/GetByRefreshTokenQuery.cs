using Domain;
using MediatR;

namespace Application.Queries.GetByRefreshToken;

public class GetByRefreshTokenQuery: IRequest<User>
{
    public  string RefreshToken { get; set; }
}