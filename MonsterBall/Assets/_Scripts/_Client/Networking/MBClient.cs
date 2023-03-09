using Riptide;
using UnityEngine;

namespace MonsterBall.Client.Networking
{
    public class MBClient : MonoBehaviour
    {
        public static MBClient ActiveInstance { get; private set; }

        private Riptide.Client _riptideClient;

        private void Awake()
        {
            Logger.Log("Awake called");
            if (ActiveInstance != null)
            {
                throw new System.Exception(
                    "Only one instance of MBClient can exist at a time."
                );
            }

            ActiveInstance = this;
        }

        public void InitializeLocalConnection()
        {
            InitializeConnection("127.0.0.1", "7777");
        }

        private void InitializeConnection(string ip, string port)
        {
            _riptideClient = new Riptide.Client();
            _riptideClient.Connect(ip + ':' + port);
        }

        private void FixedUpdate()
        {
            _riptideClient.Update();
        }
        
        public void SendMessageToServer(Message message)
        {
            _riptideClient.Send(message);
        }

        public void ReceiveMessageFromServer(Message message)
        {
            Logger.Log("Message received in LocalNetworkBridge");
        }
    }
}
