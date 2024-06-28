using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabDenpendencyInjection.Interfaces
{
    public interface IMyService
    {
        string InstanceId { get; }
    }
}