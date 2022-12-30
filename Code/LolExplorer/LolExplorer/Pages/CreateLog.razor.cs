﻿using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace LolExplorer.Pages
{
    public partial class CreateLog
    {
        [Inject]
        public ILogger<CreateLog> Logger { get; set; }


        [Inject]
        public IStringLocalizer<CreateLog> Localizer { get; set; }

        private void CreateLogs()
        {
            var logLevels = Enum.GetValues(typeof(LogLevel)).Cast<LogLevel>();

            foreach (var logLevel in logLevels.Where(l => l != LogLevel.None))
            {
                Logger.Log(logLevel, $"Log message for the level: {logLevel}");
            }
        }
    }
}
