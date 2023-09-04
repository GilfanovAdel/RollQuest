using System.Data;
using Dapper;
using Domain;
using MediatR;

namespace Application.Commands.UpdateUser;

public class UpdateUserCommandHandler  : IRequestHandler<UpdateUserCommand>
{
    private IDbConnection _dbConnection;

    public UpdateUserCommandHandler(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }


    public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        await _dbConnection.ExecuteAsync("Update Users Set Email = @Email,Name = @Name,RefreshToken = @RefreshToken,Role = @Role WHERE Id = @Id;", new { Id = request.User.Id,Email = request.User.Email,Name = request.User.Name,RefreshToken = request.User.RefreshToken,Role = request.User.Role});
    }
}