using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Controllers;
using Server.Models;

namespace Server.Helpers
{
    public class LogFile
    {
        public readonly ILogger<AccountController> _logger;

        public LogFile(ILogger<AccountController> logger)
        {
            _logger = logger;
        }

        public void GetNotificationWithDeleget()
        {
            Console.BackgroundColor = ConsoleColor.Red;

            _logger.LogInformation("new User Is loged in");
        }

        public void GetNotificationWithEventHandler()
        {
            Console.BackgroundColor = ConsoleColor.Green;

            _logger.LogInformation("new User Is loged in ");
        }
    }
}