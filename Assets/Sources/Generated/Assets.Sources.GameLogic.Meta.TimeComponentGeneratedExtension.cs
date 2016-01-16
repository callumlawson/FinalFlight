using System.Collections.Generic;

namespace Entitas {
    public partial class Entity {
        public Assets.Sources.GameLogic.Meta.TimeComponent time { get { return (Assets.Sources.GameLogic.Meta.TimeComponent)GetComponent(ComponentIds.Time); } }

        public bool hasTime { get { return HasComponent(ComponentIds.Time); } }

        static readonly Stack<Assets.Sources.GameLogic.Meta.TimeComponent> _timeComponentPool = new Stack<Assets.Sources.GameLogic.Meta.TimeComponent>();

        public static void ClearTimeComponentPool() {
            _timeComponentPool.Clear();
        }

        public Entity AddTime(int newDay) {
            var component = _timeComponentPool.Count > 0 ? _timeComponentPool.Pop() : new Assets.Sources.GameLogic.Meta.TimeComponent();
            component.Day = newDay;
            return AddComponent(ComponentIds.Time, component);
        }

        public Entity ReplaceTime(int newDay) {
            var previousComponent = hasTime ? time : null;
            var component = _timeComponentPool.Count > 0 ? _timeComponentPool.Pop() : new Assets.Sources.GameLogic.Meta.TimeComponent();
            component.Day = newDay;
            ReplaceComponent(ComponentIds.Time, component);
            if (previousComponent != null) {
                _timeComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveTime() {
            var component = time;
            RemoveComponent(ComponentIds.Time);
            _timeComponentPool.Push(component);
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherTime;

        public static IMatcher Time {
            get {
                if (_matcherTime == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.Time);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherTime = matcher;
                }

                return _matcherTime;
            }
        }
    }
}
