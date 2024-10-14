using System;
using System.Collections.Generic;

namespace GAME
{
    [Serializable]
    public class NetworkSystemData
    {
        public ConnectType ConnectType;
        public List<NetworkConnect> Connects;
    }

    public enum ConnectType
    {
        None = 0,
        Host = 1,
        Client = 2
    }
}
