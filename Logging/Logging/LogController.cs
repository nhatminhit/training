using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Logging
{
    public class LogController : Controller
    {
        private readonly ILogger<LogController> _logger;
       public LogController(ILogger<LogController> logger)
        {
            _logger = logger;
        }
        public void Method()
        {
            _logger.LogTrace("This is a Log Trace");
            _logger.LogDebug("debug log");
            _logger.LogInformation("Information log");
            _logger.LogCritical("Critical log");
            _logger.LogError("Error Log");
        }
    }
}
