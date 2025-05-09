using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using WaruSmart.API.Profiles.Domain.Services;
using WaruSmart.API.Profiles.Interfaces.REST.Resources;
using WaruSmart.API.Profiles.Interfaces.REST.Transform;

namespace WaruSmart.API.Profiles.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class SubscriptionController(ISubscriptionCommandService subscriptionCommandService)
    : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateSubscription (CreateSubscriptionResource resource)
    {
        var createSubscriptionCommand = CreateSubscriptionCommandFromResourceAssembler.ToCommandFromResource(resource);
        var subscription = await subscriptionCommandService.Handle(createSubscriptionCommand);
        if (subscription is null) return BadRequest();
        var subscriptionResource = SubscriptionResourceFromEntityAssembler.ToResourceFromEntity(subscription);
        return CreatedAtRoute(new {subscriptionId = subscriptionResource.Id}, subscriptionResource);
    }
}