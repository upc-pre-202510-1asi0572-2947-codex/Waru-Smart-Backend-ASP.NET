using WaruSmart.API.IAM.Domain.Model.Commands;
using WaruSmart.API.IAM.Interfaces.REST.Resources;

namespace WaruSmart.API.IAM.Interfaces.REST.Transform;

public static class SignUpCommandFromResourceAssembler
{
    public static SignUpCommand ToCommandFromResource(SignUpResource resource)
    {
        return new SignUpCommand(resource.Username, resource.Password);
    }

}