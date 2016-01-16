namespace Entitas {
    public partial class Entity {
        static readonly Assets.Sources.GameLogic.Components.EventQueueComponent eventQueueComponent = new Assets.Sources.GameLogic.Components.EventQueueComponent();

        public bool isEventQueue {
            get { return HasComponent(ComponentIds.EventQueue); }
            set {
                if (value != isEventQueue) {
                    if (value) {
                        AddComponent(ComponentIds.EventQueue, eventQueueComponent);
                    } else {
                        RemoveComponent(ComponentIds.EventQueue);
                    }
                }
            }
        }

        public Entity IsEventQueue(bool value) {
            isEventQueue = value;
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
