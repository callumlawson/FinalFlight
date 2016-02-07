using System;
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
            CreateGameEvent("Event which never fires");

            CreateGameEvent("Every day things get worse...", "We might be cursed.", () => true, new List<EventOption> { new EventOption { OptionDescription = "Nonetheless we must continue." }});

            CreateGameEvent("The dawn of the second day.", "Perhaps today will be a good day.", () => Pools.pool.day.Day == 2, new List<EventOption> { new EventOption { OptionDescription = "Fine!" }});

            CreateGameEvent("A horrible crash!", "A Graphic description.", () => Pools.pool.day.Day == 2, new List<EventOption> { new EventOption { OptionDescription = "We will have to pick up the peices." } });

            CreateGameEvent("The dawn of the third day.", "At least some the runway isn't holes.", () => Pools.pool.day.Day == 3, new List<EventOption> { new EventOption { OptionDescription = "Yet." } });
        }

        private void CreateGameEvent(string title, string description = "No description", Func<bool> predicate = null, List<EventOption> eventOptions = null)
        {
            if (eventOptions == null)
            {
                eventOptions = new List<EventOption> {new EventOption {OptionDescription = "Fine."}};
            }

            if (predicate == null)
            {
                predicate = () => false;
            }

            systemPool.CreateEntity()
               .AddGameEvent(title, description, predicate, eventOptions)
               .AddGameEventState(EventState.Dormant);
        }
    }
}
