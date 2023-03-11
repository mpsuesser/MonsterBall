using System;
using UnityEngine;

namespace MonsterBall.Server
{
    public class ServerPlayClock : MonoBehaviour
    {
        public event Action OnPlayClockExpiration;

        public int SecondsRemaining => (int) _secondsRemainingImpl;
        private float _secondsRemainingImpl;
        
        public static ServerPlayClock Create(int seconds)
        {
            ServerPlayClock clock = Instantiate(
                ServerPrefabs.Instance.pfPlayClock,
                ServerActiveEntitiesContainer.Instance.transform
            );
            clock._secondsRemainingImpl = seconds;

            return clock;
        }
        
        private void Update()
        {
            _secondsRemainingImpl -= Time.deltaTime;
            if (_secondsRemainingImpl <= 0)
            {
                OnPlayClockExpiration?.Invoke();
                Kill();
            }
        }

        public void Kill()
        {
            Destroy(gameObject);
        }
    }
}
