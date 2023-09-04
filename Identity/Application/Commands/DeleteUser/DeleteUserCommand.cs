using MediatR;

namespace Application.Commands.DeleteUser;

public class DeleteUserCommand : IRequest
{
    public  Guid Id { get; set; }
}