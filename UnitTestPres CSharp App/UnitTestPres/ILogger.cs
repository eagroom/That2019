using System;

namespace UnitTestPres
{
    public interface ILogger
    {
        void infoMessage(string message);

        void errMessage(string message);        
    }
}
