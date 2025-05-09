using WaruSmart.API.IAM.Domain.Model.Commands;
using WaruSmart.API.IAM.Interfaces.REST.Resources;

namespace WaruSmart.API.IAM.Interfaces.REST.Transform;

public static class SignInCommandFromResourceAssembler
{
    public static SignInCommand ToCommandFromResource(SignInResource resource)
    {
        return new SignInCommand(resource.Username, resource.Password);
    }
}