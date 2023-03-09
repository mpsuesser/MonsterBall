using System.Collections.Generic;
using UnityEngine;

namespace MonsterBall
{
    public class SharedPrefabs : MonoBehaviour
    {
        public static SharedPrefabs Instance = null;
        
        public Dictionary<MonsterType, Monster> BaseEntityPrefabsByMonsterType
        {
            get;
            private set;
        }

        [SerializeField] private Quarterback pfQuarterbackBaseEntity; 
        [SerializeField] private Runningback pfRunningbackBaseEntity;
        [SerializeField] private WideReceiver pfWideReceiverBaseEntity;
        [SerializeField] private TightEnd pfTightEndBaseEntity;
        [SerializeField] private Lineman pfLinemanBaseEntity;

        private void Awake()
        {
            if (Instance != null)
            {
                Logger.Log("SharedPrefabs already exists!");
                Destroy(this);
                return;
            }
            
            Instance = this;
        }

        private void Start()
        {
            BaseEntityPrefabsByMonsterType =
                new Dictionary<MonsterType, Monster>()
                {
                    { MonsterType.Quarterback, pfQuarterbackBaseEntity },
                    { MonsterType.Runningback, pfRunningbackBaseEntity },
                    { MonsterType.WideReceiver, pfWideReceiverBaseEntity },
                    { MonsterType.TightEnd, pfTightEndBaseEntity },
                    { MonsterType.Lineman, pfLinemanBaseEntity },
                };
        }
    }
}
