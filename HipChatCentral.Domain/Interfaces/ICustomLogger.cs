using System;

namespace HipChatCentral.Domain.Interfaces
{
    public interface ICustomLogger <T>
    {
        void DebugLog (string logmessage, params object[] parameters);
        void InfoLog  (string logmessage, params object [] prameters);
    }
}