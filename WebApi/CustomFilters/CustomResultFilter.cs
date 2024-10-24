using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

public class CustomResultFilter : IResultFilter
{
    public void OnResultExecuted(ResultExecutedContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnResultExecuting(ResultExecutingContext context)
    {
        throw new System.NotImplementedException();
    }
}
