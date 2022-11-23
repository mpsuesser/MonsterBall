namespace MonsterBall.Client.Networking
{
    public abstract class NetworkBridge
    {
        protected NetworkBridge()
        {
            
        }

        /**
         * string param will be replaced with networking message format in
         * future. Just for testing atm
         */
        public abstract void SendMessageToServer(string message);
    }
}
