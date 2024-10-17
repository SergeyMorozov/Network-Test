using System;
using Photon.Chat;

namespace GAME
{
    [Serializable]
    public class NetworkSystemData
    {
        public ConnectType ConnectMode;
        public bool EnemyOnline;
        public ChatClient ChatClient;
        public string HostName;
        public string UserName;
    }

    public enum ConnectType
    {
        None = 0,
        Host = 1,
        Client = 2
    }

    [Serializable]
    public struct NetData
    {
        public string host;
        public string json;
    }

    [Serializable]
    public struct NetCommand
    {
        public string Name;
        public int ID;
        public float Value;
    }

}
