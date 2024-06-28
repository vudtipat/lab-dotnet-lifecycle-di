using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LabDenpendencyInjection.Interfaces;

namespace LabDenpendencyInjection.Middleware
{
    
    public class Mymiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;                    
        public Mymiddleware(ILogger<Mymiddleware> logger,RequestDelegate next)
        {
            _logger = logger;            
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context,
        IMyScopedService myScopedService, IMyTransientService myTransientService, IMySingletonService mySingletonService)
    {
        _logger.LogInformation("Transient(Middleware): " + myTransientService.InstanceId);
        _logger.LogInformation("Scoped(Middleware): " + myScopedService.InstanceId);
        _logger.LogInformation("Singleton(Middleware): " + mySingletonService.InstanceId);
        await _next(context);
    }
    }
}