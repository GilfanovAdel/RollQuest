using System.Data;
using System.Security.Cryptography;
using Dapper;
using Domain;
using MediatR;
using OtpNet;

namespace Application.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
{
    private IDbConnection _dbConnection;

    public CreateUserCommandHandler(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }
    
   

    public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        await _dbConnection.ExecuteAsync("INSERT INTO Users  (email,name,id,secretkey,role) VALUES ( @Email, @Name,@Id,@SecretKey,@Role);",new {Name = request.Name,Email = request.Email,Id = Guid.NewGuid(),SecretKey =request.SecretKey,@Role ="NoConfirmed"});
    }
}