using System.Linq;
using Assets.Sources.GameLogic.Components;
using Entitas;
using UnityEngine;

namespace Assets.Sources.GameLogic.Systems
{
    class PauseSystem : IExecuteSystem
    {
        private bool userPaused = false;

        public void Execute()
        {
            var isInModalDialogue =
                Pools.pool.GetEntities(Matcher.AllOf(Matcher.GameEvent, Matcher.GameEventState))
                    .Any(entity => entity.gameEventState.EventState == EventState.Presented);

            if (isInModalDialogue)
            {
                Pools.pool.isPaused = true;
            }
            else
            {
                Pools.pool.isPaused = userPaused;
            }

            if (!isInModalDialogue && Input.GetKeyDown(KeyCode.Space))
            {
                userPaused = !userPaused;
            }
        }
    }
}
