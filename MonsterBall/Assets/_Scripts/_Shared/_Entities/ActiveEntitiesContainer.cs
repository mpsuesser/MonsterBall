using System.Collections.Generic;
using UnityEngine;

namespace MonsterBall
{
    public abstract class ActiveEntitiesContainer : MonoBehaviour
    {
        private Dictionary<int, Monster> _monstersByEntID;
        
        protected virtual void Awake()
        {
            _monstersByEntID = new Dictionary<int, Monster>();
        }
        
        public void AddMonster(Monster monster)
        {
            Logger.Log("[" + this.GetType().Name + "] Adding entity");
            _monstersByEntID.Add(monster.EntID, monster);
        }
        
        public void RemoveMonster(Monster monster)
        {
            _monstersByEntID.Remove(monster.EntID);
        }

        public bool GetMonster(int entID, out Monster monster)
        {
            return _monstersByEntID.TryGetValue(entID, out monster);
        }

        public IEnumerable<Monster> GetAllMonsters()
        {
            return _monstersByEntID.Values;
        }
    }
}
