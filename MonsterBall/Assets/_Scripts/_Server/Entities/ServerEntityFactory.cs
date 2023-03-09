using UnityEngine;

namespace MonsterBall.Server
{
    public static class ServerEntityFactory
    {
        private static int _nextEntID = 1;
        private static int GetNextEntID()
        {
            return _nextEntID++;
        }
        
        public static Monster SpawnMonster(
            MonsterType type,
            Vector3 position,
            Quaternion rotation
        )
        {
            Monster monster = Monster.Spawn(
                type,
                GetNextEntID(),
                position,
                rotation,
                ServerActiveEntitiesContainer.Instance.transform
            );
            monster.gameObject.AddComponent<ServerMonsterController>();
            ServerActiveEntitiesContainer.Instance.AddMonster(monster);
            
            return monster;
        }
    }
}
