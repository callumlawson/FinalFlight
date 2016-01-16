using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Assets.Sources.GameLogic.Components;
using Assets.Sources.GameLogic.Mood;
using Assets.Sources.GameLogic.Meta;
using Entitas;

namespace Assets.Sources.Init
{
    class CreateEventsSystem : IInitializeSystem, ISetPool
    {
        private Pool systemPool;

        public void SetPool(Pool pool)
        {
            systemPool = pool;
        }

        public void Initialize()
        {
            for (int i = 0; i < 5; i++)
            {
                systemPool.CreateEntity().AddGameEvent("My first event", "HEre is the nice description", EventState.Dormant, new List<EventOption>());
            }

            systemPool.CreateEntity().AddGameEvent("My first event that is presented", "HEre is the nice description", EventState.Presented, new List<EventOption>());
        }
    }
}
