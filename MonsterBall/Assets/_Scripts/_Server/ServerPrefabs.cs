using UnityEngine;

namespace MonsterBall.Server
{
    public class ServerPrefabs : MonoBehaviour
    {
        public static ServerPrefabs Instance = null;
        
        public ServerMonsterController pfQuarterbackController;
        public ServerMonsterController pfRunningbackController;
        public ServerMonsterController pfWideReceiverController;
        public ServerMonsterController pfTightEndController;
        public ServerMonsterController pfLinemanController;

        public ServerPlayClock pfPlayClock;
        public ServerGameClock pfGameClock;
        
        private void Awake()
        {
            if (Instance != null)
            {
                Logger.Log("ServerPrefabs already exists!");
                Destroy(this);
                return;
            }
            
            Instance = this;
        }
    }
}
