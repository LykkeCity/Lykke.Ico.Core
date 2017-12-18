using System;
using System.Collections.Generic;
using System.Text;
using Lykke.Logs;
using Lykke.Logs.Slack;
using Lykke.SlackNotifications;

namespace Common.Log
{
    public static class AggregateLoggerExxtensions
    {
        /// <summary>
        /// Adds logger which writes ICO messages to personal Slack channel.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="slackNotificationsSender">Service which sends notifications to Slack</param>
        /// <param name="channel">Name of channel in SlackIntegration settings section ("Ico" by default)</param>
        /// <param name="logLevel">Level of message to log (Error | FatalError by default)</param>
        public static void AddIcoSlackLog(this AggregateLogger self, ISlackNotificationsSender slackNotificationsSender, 
            string channel = "Ico", 
            LogLevel logLevel = LogLevel.Error | LogLevel.FatalError)
        {
            self.AddLog(LykkeLogToSlack.Create(slackNotificationsSender, channel, logLevel));
        }
    }
}
