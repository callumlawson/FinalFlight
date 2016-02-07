using Entitas;
using UnityEngine;

namespace Assets.Sources.GameLogic.Systems
{
    class KeybindingSystem : IExecuteSystem
    {
        public void Execute()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Pools.pool.isPaused = !Pools.pool.isPaused;
            }
        }
    }
}
