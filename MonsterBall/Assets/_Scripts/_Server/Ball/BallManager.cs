using System;
using System.Collections.Generic;

namespace MonsterBall.Server
{
    public static class BallManager
    {
        private static BallState _ballState;
        
        // TODO

        public static void RemoveBallFromAllMonsters()
        {
            IEnumerable<Monster> monsters =
                ServerActiveEntitiesContainer.Instance.GetAllMonsters();
            foreach (Monster monster in monsters)
            {
                monster.SetBallOwnership(false);
            }
        }
    }
}
