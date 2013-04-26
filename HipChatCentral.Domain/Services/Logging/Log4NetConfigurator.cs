using System.IO;
using System.Reflection;
using log4net;
using log4net.Appender;
using log4net.Core;
using log4net.Layout;
using log4net.Repository.Hierarchy;

namespace HipChatCentral.Domain.Services.Logging
{
    public class Log4NetConfigurator : ILogConfigurator
    {
         public void Configure ()
         {
             var root = ((Hierarchy)LogManager.GetRepository()).Root;
             var directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase).Substring(6) + "\\logging";
             root.AddAppender( GetFileAppender(directory, "debug.txt", Level.Debug));
             root.AddAppender( GetFileAppender(directory, "info.txt", Level.Info));
             root.Repository.Configured = true;
         }


        public FileAppender GetFileAppender (string directory, string filename, Level threshold)
        {
            var appender = new RollingFileAppender()
                               {
                                   Name = "File",
                                   AppendToFile = true,
                                   File = directory + "\\" + filename,
                                   Layout = new PatternLayout("[%-5level] - [%date] - [%-25logger{1}]: %message %newline"),
                                   Threshold = threshold,
                                   MaxFileSize = 1000000*1,
                                   MaxSizeRollBackups = 2                                   
                               };
            appender.ActivateOptions();
            return appender;
        }
    }
}