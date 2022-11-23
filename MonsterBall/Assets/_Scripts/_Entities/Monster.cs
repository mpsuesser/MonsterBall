using System.Collections.Generic;
using UnityEngine;

namespace MonsterBall
{
    public abstract class Monster : MonoBehaviour
    {
        protected HashSet<AbilityType> Abilities { get; private set; }

        private void Start()
        {
            
        }

        // TODO: Hook into PlayState change -- on update, repopulate active abilities
    }
}
