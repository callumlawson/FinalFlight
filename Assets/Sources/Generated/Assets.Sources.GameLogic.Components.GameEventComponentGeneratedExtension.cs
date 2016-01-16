using System.Collections.Generic;

namespace Entitas {
    public partial class Entity {
        public Assets.Sources.GameLogic.Components.GameEventComponent gameEvent { get { return (Assets.Sources.GameLogic.Components.GameEventComponent)GetComponent(ComponentIds.GameEvent); } }

        public bool hasGameEvent { get { return HasComponent(ComponentIds.GameEvent); } }

        static readonly Stack<Assets.Sources.GameLogic.Components.GameEventComponent> _gameEventComponentPool = new Stack<Assets.Sources.GameLogic.Components.GameEventComponent>();

        public static void ClearGameEventComponentPool() {
            _gameEventComponentPool.Clear();
        }

        public Entity AddGameEvent(string newTitle, string newDescription, Assets.Sources.GameLogic.Components.EventState newEventState, System.Collections.Generic.List<Assets.Sources.GameLogic.Components.EventOption> newEventOptions) {
            var component = _gameEventComponentPool.Count > 0 ? _gameEventComponentPool.Pop() : new Assets.Sources.GameLogic.Components.GameEventComponent();
            component.Title = newTitle;
            component.Description = newDescription;
            component.EventState = newEventState;
            component.EventOptions = newEventOptions;
            return AddComponent(ComponentIds.GameEvent, component);
        }

        public Entity ReplaceGameEvent(string newTitle, string newDescription, Assets.Sources.GameLogic.Components.EventState newEventState, System.Collections.Generic.List<Assets.Sources.GameLogic.Components.EventOption> newEventOptions) {
            var previousComponent = hasGameEvent ? gameEvent : null;
            var component = _gameEventComponentPool.Count > 0 ? _gameEventComponentPool.Pop() : new Assets.Sources.GameLogic.Components.GameEventComponent();
            component.Title = newTitle;
            component.Description = newDescription;
            component.EventState = newEventState;
            component.EventOptions = newEventOptions;
            ReplaceComponent(ComponentIds.GameEvent, component);
            if (previousComponent != null) {
                _gameEventComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveGameEvent() {
            var component = gameEvent;
            RemoveComponent(ComponentIds.GameEvent);
            _gameEventComponentPool.Push(component);
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherGameEvent;

        public static IMatcher GameEvent {
            get {
                if (_matcherGameEvent == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.GameEvent);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherGameEvent = matcher;
                }

                return _matcherGameEvent;
            }
        }
    }
}
