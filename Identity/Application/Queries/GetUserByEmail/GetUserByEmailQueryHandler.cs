using System.Data;
using Dapper;
using Domain;
using MediatR;

namespace Application.Queries.GetUserByEmail;

public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, User>
{
    private IDbConnection _dbConnection;

    public GetUserByEmailQueryHandler(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    
    public async Task<User> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
    {
        var user = (await _dbConnection.QueryAsync<User>("Select * FROM Users WHERE Email = @Email",new { Email = request.Email })).FirstOrDefault();
        return user;
    }
}