using System.Collections.Generic;

namespace Entitas {
    public partial class Entity {
        public Assets.Sources.GameLogic.Components.EventQueueComponent eventQueue { get { return (Assets.Sources.GameLogic.Components.EventQueueComponent)GetComponent(ComponentIds.EventQueue); } }

        public bool hasEventQueue { get { return HasComponent(ComponentIds.EventQueue); } }

        static readonly Stack<Assets.Sources.GameLogic.Components.EventQueueComponent> _eventQueueComponentPool = new Stack<Assets.Sources.GameLogic.Components.EventQueueComponent>();

        public static void ClearEventQueueComponentPool() {
            _eventQueueComponentPool.Clear();
        }

        public Entity AddEventQueue(System.Collections.Generic.Queue<Assets.Sources.GameLogic.Components.GameEventComponent> newPendingEventQueue) {
            var component = _eventQueueComponentPool.Count > 0 ? _eventQueueComponentPool.Pop() : new Assets.Sources.GameLogic.Components.EventQueueComponent();
            component.PendingEventQueue = newPendingEventQueue;
            return AddComponent(ComponentIds.EventQueue, component);
        }

        public Entity ReplaceEventQueue(System.Collections.Generic.Queue<Assets.Sources.GameLogic.Components.GameEventComponent> newPendingEventQueue) {
            var previousComponent = hasEventQueue ? eventQueue : null;
            var component = _eventQueueComponentPool.Count > 0 ? _eventQueueComponentPool.Pop() : new Assets.Sources.GameLogic.Components.EventQueueComponent();
            component.PendingEventQueue = newPendingEventQueue;
            ReplaceComponent(ComponentIds.EventQueue, component);
            if (previousComponent != null) {
                _eventQueueComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveEventQueue() {
            var component = eventQueue;
            RemoveComponent(ComponentIds.EventQueue);
            _eventQueueComponentPool.Push(component);
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherEventQueue;

        public static IMatcher EventQueue {
            get {
                if (_matcherEventQueue == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.EventQueue);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherEventQueue = matcher;
                }

                return _matcherEventQueue;
            }
        }
    }
}
