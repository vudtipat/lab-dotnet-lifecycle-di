using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LabDenpendencyInjection.Interfaces;

namespace LabDenpendencyInjection.Services
{
    public class MainService
    {
        private readonly ILogger _logger;
        private readonly IMyTransientService _myTransientService;
        private readonly IMyScopedService _myScopedService;
        private readonly IMySingletonService _mySingletonService;
        private readonly SecondService _secondService;
        public MainService(
            IMyTransientService myTransientService,
            IMyScopedService myScopedService,
            IMySingletonService mySingletonService,
            SecondService secondService,
            ILogger<MainService> logger
        )
        {
            _logger = logger;
            _myTransientService = myTransientService ?? throw new ArgumentNullException(nameof(myTransientService));
            _myScopedService = myScopedService ?? throw new ArgumentNullException(nameof(myScopedService));
            _mySingletonService = mySingletonService ?? throw new ArgumentNullException(nameof(mySingletonService));
            _secondService = secondService ?? throw new ArgumentNullException(nameof(secondService));
        }

        public void RunMain()
        {
            _logger.LogInformation("First layer Transient: " + _myTransientService.InstanceId);
            _logger.LogInformation("First layer Scoped: " + _myScopedService.InstanceId);
            _logger.LogInformation("First layer Singleton: " + _mySingletonService.InstanceId);  
            _secondService.RunSecond();
        }
    }

    public class SecondService
    {
        private readonly ILogger _logger;
        private readonly IMyTransientService _myTransientService;
        private readonly IMyScopedService _myScopedService;
        private readonly IMySingletonService _mySingletonService;
        public SecondService(
            IMyTransientService myTransientService,
            IMyScopedService myScopedService,
            IMySingletonService mySingletonService,
            ILogger<SecondService> logger
        )
        {
            _logger = logger;
            _myTransientService = myTransientService ?? throw new ArgumentNullException(nameof(myTransientService));
            _myScopedService = myScopedService ?? throw new ArgumentNullException(nameof(myScopedService));
            _mySingletonService = mySingletonService ?? throw new ArgumentNullException(nameof(mySingletonService));
        }

        public void RunSecond()
        {
            _logger.LogInformation("Second layer Transient: " + _myTransientService.InstanceId);
            _logger.LogInformation("Second layer Scoped: " + _myScopedService.InstanceId);
            _logger.LogInformation("Second layer Singleton: " + _mySingletonService.InstanceId);    
        }
    }
}