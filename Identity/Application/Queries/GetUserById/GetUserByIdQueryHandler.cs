using System.Data;
using Dapper;
using Domain;
using MediatR;

namespace Application.Queries.GetUserById;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery,User>
{
    private IDbConnection _dbConnection;

    public GetUserByIdQueryHandler(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = (await _dbConnection.QueryAsync<User>("Select * FROM Users WHERE Id = @Id", new { Id = request.Id })).FirstOrDefault();
        return user;
    }
}