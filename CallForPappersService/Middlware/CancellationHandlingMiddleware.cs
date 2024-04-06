namespace CallForPappersService.Middlware
{
    public class CancellationHandlingMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        public CancellationHandlingMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
   
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _requestDelegate(httpContext);
            }
            catch (Exception ex) when (ex is OperationCanceledException or TaskCanceledException) 
            { 
                //_logger.LogInformation("Task was cancelled");
            }         
        }
    }
}
