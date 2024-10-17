using System;

namespace GAME
{
    [Serializable]
    public class NetworkSystemEvents
    {
        public Action Connect;
        public Action ConnectComplete;
        public Action<NetCommand> SendCommand;
        public Action<string, string> OnGetCommand;
        
        public Action<string> StartHost;
        public Action<string> StartClient;
    }
}
