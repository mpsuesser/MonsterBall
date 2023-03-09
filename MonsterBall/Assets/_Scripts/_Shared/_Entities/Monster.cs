using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace MonsterBall
{
    public abstract class Monster : MonoBehaviour
    {
        public event Action<bool> OnBallOwnershipChanged;
        
        public abstract MonsterType Type { get; }
        public abstract bool CanOwnBall { get; }
        
        public int EntID { get; private set; }
        
        protected HashSet<AbilityType> Abilities { get; private set; }
        
        public bool OwnsBall { get; private set; }

        public static Monster Spawn(
            MonsterType type,
            int entID,
            Vector3 position,
            Quaternion rotation,
            Transform parent
        )
        {
            Monster monster = Object.Instantiate(
                SharedPrefabs.Instance.BaseEntityPrefabsByMonsterType[type],
                position,
                rotation,
                parent
            );
            monster.SetEntID(entID);
            
            return monster;
        }
        
        private void SetEntID(int entID)
        {
            EntID = entID;
        }

        public void Despawn()
        {
            Destroy(gameObject);
        }

        public void SetBallOwnership(bool ownsBall)
        {
            if (OwnsBall == ownsBall)
            {
                return;
            }
            
            OwnsBall = ownsBall;
            OnBallOwnershipChanged?.Invoke(OwnsBall);
        }

        // TODO: Hook into PlayState change -- on update, repopulate active abilities
    }
}
