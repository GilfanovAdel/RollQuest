using System.Data;
using Application.Queries.GetUserById;
using Dapper;
using Domain;
using MediatR;

namespace Application.Queries.GetByRefreshToken;

public class GetUserIdByRefreshTokenQueryHandler : IRequestHandler<GetByRefreshTokenQuery,User>
{
    private IDbConnection _dbConnection;

    public GetUserIdByRefreshTokenQueryHandler(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<User> Handle(GetByRefreshTokenQuery request, CancellationToken cancellationToken)
    {
        var result = (await _dbConnection.QueryAsync<User>("Select * FROM Users WHERE refreshtoken = @RefreshToken", new { RefreshToken = request.RefreshToken })).FirstOrDefault();
        return result;
    }
}