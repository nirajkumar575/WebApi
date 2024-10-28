using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

public class CustomAsyncActionFilter : IAsyncActionFilter
{
    private readonly ILogger<CustomAsyncActionFilter> _logger;

    public CustomAsyncActionFilter(ILogger<CustomAsyncActionFilter> logger)
    {
        _logger = logger;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        // Code to execute before the action method is called
        _logger.LogInformation("Action is executing: {ActionName}", context.ActionDescriptor.DisplayName);

        // Call the action method
        var resultContext = await next();

        // Code to execute after the action method is called
        if (resultContext.Exception != null)
        {
            _logger.LogError(resultContext.Exception, "An error occurred in action: {ActionName}", context.ActionDescriptor.DisplayName);
        }
        else
        {
            _logger.LogInformation("Action executed successfully: {ActionName}", context.ActionDescriptor.DisplayName);
        }
    }
}
