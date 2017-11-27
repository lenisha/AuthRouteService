using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace Pivotal.Nlog.Extensions
{
    public class StartupConfiguration
    {
		private static String LOG_PREFIX = "LOG_MINLEVEL_";
		protected static Logger logger = LogManager.GetCurrentClassLogger();

		public static void ConfigureEnvironment()
		{
			Target console = LogManager.Configuration.AllTargets.Where(target => target.GetType().Name.Equals("ConsoleTarget")).First<Target>();
			if (console == null)
			{
				logger.Error("No Console Target is found to reconfigure");
				return;
			}

			// Find all configured levels
			Dictionary<string, string> variableLogs = new Dictionary<string, string>();
			foreach (DictionaryEntry variable in Environment.GetEnvironmentVariables().OfType<DictionaryEntry>())
			{
				if (variable.Key.ToString().StartsWith(LOG_PREFIX))
				{
					String logName = variable.Key.ToString().Substring(LOG_PREFIX.Length);
					variableLogs.Add(logName,variable.Value.ToString());
				}
			}
			logger.Debug(" Found overrides for log levels for {0} items", variableLogs.Count);

			foreach (string logName in variableLogs.Keys)
			{
				LoggingRule rule = LogManager.Configuration.LoggingRules.Where(logRule => logRule.LoggerNamePattern.Equals(logName)).FirstOrDefault<LoggingRule>();

				LogLevel minLevel = LogLevel.FromString(variableLogs[logName]);

				if (rule == null)
				{
					rule = new LoggingRule(logName, minLevel, console);
					LogManager.Configuration.LoggingRules.Add(rule);
				}
				foreach (LogLevel level in rule.Levels)
					if (level < minLevel) rule.DisableLoggingForLevel(level);

				logger.Debug("Setting rule {0} to logLevel {1}", rule.LoggerNamePattern, minLevel);

			}
			LogManager.ReconfigExistingLoggers();
		}
	}
}
