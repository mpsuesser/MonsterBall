using Riptide;
using UnityEngine;

namespace MonsterBall.Networking
{
    public class MBServer : MonoBehaviour
    {
        public static MBServer ActiveInstance { get; private set; }
        
        private Riptide.Server RiptideServer { get; set; }
        
        private void Awake()
        {
            if (ActiveInstance != null)
            {
                throw new System.Exception(
                    "Only one instance of MBServer can exist at a time."
                );
            }

            Initialize();

            ActiveInstance = this;
        }

        private void FixedUpdate()
        {
            RiptideServer.Update();
        }

        private void Initialize()
        {
            RiptideServer = new Riptide.Server();
            
            // TODO: Make this configurable
            // There should be a config file that indicates whether this server
            // is a local server or a network server. Based on this config file,
            // we will either use the default port/ip or a custom port/ip.
            RiptideServer.Start(7777, 10);
        }

        public void SendToAll(Message message)
        {
            RiptideServer.SendToAll(message);
        }
    }
}
