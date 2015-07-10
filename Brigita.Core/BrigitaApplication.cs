using Nop.Core.Infrastructure;
using Nop.Services.Logging;
using Nop.Services.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.Core
{
    public class BrigitaApplication
    {
        ILogger _logger;
        TaskManager _taskManager;

        public BrigitaApplication(ILogger logger, TaskManager taskManager) {
            _logger = logger;
            _taskManager = taskManager;
        }

        public void Initialize() {
            EngineContext.Initialize(false);

            _taskManager.Initialize();
            _taskManager.Start();
            
            _logger.Information("BrigitaApplication started", null, null);
        }

    }
}
