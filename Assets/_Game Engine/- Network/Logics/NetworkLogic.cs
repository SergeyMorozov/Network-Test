using ExitGames.Client.Photon;
using Photon.Chat;
using UnityEngine;

namespace  GAME
{
    public class NetworkLogic : MonoBehaviour, IChatClientListener
    {
        private const string _appID = "cd995e0e-9b47-4a87-9fd4-9e4bdb90430a";
        
        private ChatClient _chatClient;
        private string[] _channel;
        
#if !PHOTON_UNITY_NETWORKING
        public ChatAppSettings ChatAppSettings
        {
            get { return chatAppSettings; }
        }

        [SerializeField]
#endif
        protected internal ChatAppSettings chatAppSettings;
        
        private void Awake()
        {
            NetworkSystem.Events.Connect += Connect;
        }

        private void Connect()
        {
            _channel = new string[1];
            _channel[0] = NetworkSystem.Data.HostName;
            chatAppSettings.AppIdChat = _appID;
            
            NetworkSystem.Data.ChatClient = new ChatClient(this);
            _chatClient = NetworkSystem.Data.ChatClient;
            _chatClient.AuthValues = new AuthenticationValues(NetworkSystem.Data.UserName);
            _chatClient.ConnectUsingSettings(chatAppSettings);
            Debug.Log("Connecting as: " + NetworkSystem.Data.UserName);
        }

        public void Update()
        {
            if (_chatClient == null) return;

            _chatClient.Service(); // make sure to call this regularly! it limits effort internally, so calling often is ok!

        }

        // ================================

        public void DebugReturn(DebugLevel level, string message)
        {
            if (level == DebugLevel.ERROR)
            {
                Debug.LogError(message);
            }
            else if (level == DebugLevel.WARNING)
            {
                Debug.LogWarning(message);
            }
            else
            {
                Debug.Log(message);
            }
        }

        public void OnDisconnected()
        {
        }

        public void OnConnected()
        {
            if (_channel != null && _channel.Length > 0)
            {
                _chatClient.Subscribe(_channel, 0);
            }

            Debug.Log("Connected as: " + NetworkSystem.Data.UserName);
            
            _chatClient.SetOnlineStatus(ChatUserStatus.Online); // You can set your online state (without a mesage).
            
            NetworkSystem.Events.ConnectComplete?.Invoke();
        }

        public void OnChatStateChange(ChatState state)
        {
        }

        public void OnGetMessages(string channelName, string[] senders, object[] messages)
        {
            Debug.Log("Get ===> [" + senders[0] + "] " + messages[0]);
            NetworkSystem.Events.OnGetCommand?.Invoke(senders[0], messages[0].ToString());
        }

        public void OnPrivateMessage(string sender, object message, string channelName)
        {
        }

        public void OnSubscribed(string[] channels, bool[] results)
        {
        }

        public void OnUnsubscribed(string[] channels)
        {
        }

        public void OnStatusUpdate(string user, int status, bool gotMessage, object message)
        {
        }

        public void OnUserSubscribed(string channel, string user)
        {
        }

        public void OnUserUnsubscribed(string channel, string user)
        {
        }
    }
}

