using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Assets.Sources.GameLogic.Components;
using Entitas;
using Debug = UnityEngine.Debug;

namespace Assets.Sources.GameLogic.Systems
{
    class EventPredicateCheckingSystem : IReactiveSystem
    {
        public TriggerOnEvent trigger
        {
            get { return Matcher.Day.OnEntityAdded(); }
        }

        public void Execute(List<Entity> entities)
        {
            Debug.Log(string.Format("The start of day {0}", Pools.pool.day.Day));

            var eventEntities = Pools.pool.GetEntities(Matcher.AllOf(Matcher.GameEvent, Matcher.GameEventState));

            foreach (var entity in eventEntities)
            {
                var eventStateComponent = entity.gameEventState;
                var eventComponent = entity.gameEvent;
                if (eventComponent.Predicate() && eventStateComponent.EventState == EventState.Dormant)
                {
                    Debug.Log(string.Format("Event with name {0} is now pending", eventComponent.Title));
                    entity.ReplaceGameEventState(EventState.Pending);
                }
            }
        }
    }
}
