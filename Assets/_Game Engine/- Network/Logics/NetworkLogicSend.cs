using Photon.Chat;
using UnityEngine;

namespace  GAME
{
    public class NetworkLogicSend : MonoBehaviour
    {
        private ChatClient _chatClient;

        private void Awake()
        {
            NetworkSystem.Events.ConnectComplete += ConnectComplete;
            NetworkSystem.Events.SendCommand += SendCommand;
        }

        private void ConnectComplete()
        {
            _chatClient = NetworkSystem.Data.ChatClient;

            if (NetworkSystem.Data.ConnectMode == ConnectType.Client)
            {
                NetCommand command = new NetCommand { Name = nameof(ConnectType), ID = (int)ConnectType.Client };
                SendCommand(command);
            }
        }

        private void SendCommand(NetCommand command)
        {
            NetData netData = new NetData { host = NetworkSystem.Data.HostName, json = JsonUtility.ToJson(command) };
            string json = JsonUtility.ToJson(netData);
            Debug.Log("Send ===> [" + NetworkSystem.Data.UserName + "] " + json);

            _chatClient.PublishMessage(NetworkSystem.Data.HostName, json);
        }

    }
}

