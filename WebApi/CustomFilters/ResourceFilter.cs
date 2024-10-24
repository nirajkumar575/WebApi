using Microsoft.AspNetCore.Mvc.Filters;

public class CustomResourceFilter : IResourceFilter
{
    public void OnResourceExecuted(ResourceExecutedContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnResourceExecuting(ResourceExecutingContext context)
    {
        throw new System.NotImplementedException();
    }
}
