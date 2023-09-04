using Domain;
using MediatR;

namespace Application.Commands.UpdateUser;

public class UpdateUserCommand : IRequest
{
  public  User User { get; set; }
}