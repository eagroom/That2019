using System;

namespace UnitTestPres
{
    public class Logger : ILogger
    {
        public void infoMessage(string message) {
            //if runnin in debug write out to the console otherwise do nothing
        }

        public void errMessage(string message)
        {
            //write out to a log file
        }
        
    }
}
