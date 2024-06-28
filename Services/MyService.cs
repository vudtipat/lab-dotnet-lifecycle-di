using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LabDenpendencyInjection.Interfaces;

namespace LabDenpendencyInjection.Services
{
    public class MyService : IMyTransientService, IMyScopedService, IMySingletonService
    {
        public string InstanceId { get; } = Guid.NewGuid().ToString();
    }
}