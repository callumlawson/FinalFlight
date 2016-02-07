using System.Collections.Generic;
using Assets.Sources.GameLogic.Components;
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
            systemPool.CreateEntity().AddGameEvent("Event which never fires", "No description", () => false, new List<EventOption>()).AddGameEventState(EventState.Dormant);

            systemPool.CreateEntity().AddGameEvent("My first event that is presented", "No description", () => true, new List<EventOption>()).AddGameEventState(EventState.Dormant);

            systemPool.CreateEntity().AddGameEvent("Triggered on day 2", "No description", () => Pools.pool.day.Day == 2, new List<EventOption>()).AddGameEventState(EventState.Dormant);

            systemPool.CreateEntity().AddGameEvent("Triggered on day 2", "No description", () => Pools.pool.day.Day == 2, new List<EventOption>()).AddGameEventState(EventState.Dormant);

            systemPool.CreateEntity().AddGameEvent("Triggered on day 3", "No description", () => Pools.pool.day.Day == 3, new List<EventOption>()).AddGameEventState(EventState.Dormant);
        }
    }
}
