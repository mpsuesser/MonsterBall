namespace MonsterBall.Client.Networking
{
    public class LocalNetworkBridge : NetworkBridge
    {
        public LocalNetworkBridge() : base()
        {
            
        }

        public override void SendMessageToServer(string message)
        {
            Logger.Log($"TO LOCAL SERVER: {message}");
        }
    }
}
