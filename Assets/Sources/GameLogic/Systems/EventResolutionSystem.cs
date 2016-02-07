using System.Collections.Generic;
using System.Linq;
using Assets.Sources.GameLogic.Components;
using Entitas;
using Debug = UnityEngine.Debug;

namespace Assets.Sources.GameLogic.Systems
{
    class EventResolutionSystem : IReactiveSystem
    {
        public TriggerOnEvent trigger
        {
            get { return Matcher.GameEventState.OnEntityAdded(); }
        }

        public void Execute(List<Entity> entities)
        {
            var eventEntities = Pools.pool.GetEntities(Matcher.AllOf(Matcher.GameEvent, Matcher.GameEventState));

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
    }
}
