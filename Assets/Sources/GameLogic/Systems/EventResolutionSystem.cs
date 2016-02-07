using System.Collections.Generic;
using System.Linq;
using Assets.Sources.GameLogic.Components;
using Assets.Sources.GameLogic.Events;
using Entitas;
using Debug = UnityEngine.Debug;

namespace Assets.Sources.GameLogic.Systems
{
    class EventResolutionSystem : IReactiveSystem, IInitializeSystem
    {
        public TriggerOnEvent trigger
        {
            get { return Matcher.GameEventState.OnEntityAdded(); }
        }

        public void Initialize()
        {
            UiEventHandler.OptionSelectedEventReceived += OnOptionSelectedEventReceived;
        }

        public void Execute(List<Entity> entities)
        {
            var eventEntities = GetEventEntities();

            var nothingIsPresented = eventEntities.All(entity => entity.gameEventState.EventState != EventState.Presented);

            if (nothingIsPresented)
            {
                var possiblePendingEventEntity = eventEntities.FirstOrDefault(entity => entity.gameEventState.EventState == EventState.Pending);
                if (possiblePendingEventEntity != null)
                {
                    possiblePendingEventEntity.ReplaceGameEventState(EventState.Presented);
                    Debug.Log(string.Format("Event with title '{0}' is now presented", possiblePendingEventEntity.gameEvent.Title));
                }
            }
        }

        private void OnOptionSelectedEventReceived(EventOption eventOption)
        {
            Debug.Log("Event fired: " + eventOption.ToString());
            if (eventOption.EventResult != null)
            {
                eventOption.EventResult();
            }
            var eventEntities = GetEventEntities();
            var pendingEventEntity = eventEntities.First(entity => entity.gameEventState.EventState == EventState.Presented);
            pendingEventEntity.ReplaceGameEventState(EventState.Dormant);
        }

        private static Entity[] GetEventEntities()
        {
            return Pools.pool.GetEntities(Matcher.AllOf(Matcher.GameEvent, Matcher.GameEventState));
        }
    }
}
