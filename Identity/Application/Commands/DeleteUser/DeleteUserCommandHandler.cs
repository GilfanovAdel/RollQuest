using System.Data;
using Dapper;
using MediatR;

namespace Application.Commands.DeleteUser;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
{
    private IDbConnection _dbConnection;

    public DeleteUserCommandHandler(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }


    public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        await _dbConnection.ExecuteAsync("DELETE FROM Users WHERE Id = @Id;", new { Id = request.Id });
    }
}