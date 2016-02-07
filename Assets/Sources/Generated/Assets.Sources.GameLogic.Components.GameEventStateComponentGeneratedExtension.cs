using System.Collections.Generic;

namespace Entitas {
    public partial class Entity {
        public Assets.Sources.GameLogic.Components.GameEventStateComponent gameEventState { get { return (Assets.Sources.GameLogic.Components.GameEventStateComponent)GetComponent(ComponentIds.GameEventState); } }

        public bool hasGameEventState { get { return HasComponent(ComponentIds.GameEventState); } }

        static readonly Stack<Assets.Sources.GameLogic.Components.GameEventStateComponent> _gameEventStateComponentPool = new Stack<Assets.Sources.GameLogic.Components.GameEventStateComponent>();

        public static void ClearGameEventStateComponentPool() {
            _gameEventStateComponentPool.Clear();
        }

        public Entity AddGameEventState(Assets.Sources.GameLogic.Components.EventState newEventState) {
            var component = _gameEventStateComponentPool.Count > 0 ? _gameEventStateComponentPool.Pop() : new Assets.Sources.GameLogic.Components.GameEventStateComponent();
            component.EventState = newEventState;
            return AddComponent(ComponentIds.GameEventState, component);
        }

        public Entity ReplaceGameEventState(Assets.Sources.GameLogic.Components.EventState newEventState) {
            var previousComponent = hasGameEventState ? gameEventState : null;
            var component = _gameEventStateComponentPool.Count > 0 ? _gameEventStateComponentPool.Pop() : new Assets.Sources.GameLogic.Components.GameEventStateComponent();
            component.EventState = newEventState;
            ReplaceComponent(ComponentIds.GameEventState, component);
            if (previousComponent != null) {
                _gameEventStateComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveGameEventState() {
            var component = gameEventState;
            RemoveComponent(ComponentIds.GameEventState);
            _gameEventStateComponentPool.Push(component);
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherGameEventState;

        public static IMatcher GameEventState {
            get {
                if (_matcherGameEventState == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.GameEventState);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherGameEventState = matcher;
                }

                return _matcherGameEventState;
            }
        }
    }
}
