using UnityEngine;

namespace MonsterBall.Client
{
    public static class ClientEntityFactory
    {
        public static Monster SpawnMonster(
            int entID,
            MonsterType type,
            Vector3 position,
            Quaternion rotation
        )
        {
            Monster monster = Monster.Spawn(
                type,
                entID,
                position,
                rotation,
                ClientActiveEntitiesContainer.Instance.transform
            );
            monster.gameObject.AddComponent<ClientMonsterController>();
            ClientActiveEntitiesContainer.Instance.AddMonster(monster);
        
            return monster;
        }
    }
}
