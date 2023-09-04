using MediatR;

namespace Application.Commands.CreateUser;

public class CreateUserCommand :IRequest
{
 
    public  string SecretKey { get; set; }
    public  string Email { get; set; }
    
    public  string Name { get; set; }
}