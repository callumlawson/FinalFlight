using System.Collections.Generic;

namespace Entitas {
    public partial class Entity {
        public Assets.Sources.GameLogic.Components.TimeComponent time { get { return (Assets.Sources.GameLogic.Components.TimeComponent)GetComponent(ComponentIds.Time); } }

        public bool hasTime { get { return HasComponent(ComponentIds.Time); } }

        static readonly Stack<Assets.Sources.GameLogic.Components.TimeComponent> _timeComponentPool = new Stack<Assets.Sources.GameLogic.Components.TimeComponent>();

        public static void ClearTimeComponentPool() {
            _timeComponentPool.Clear();
        }

        public Entity AddTime(float newTime) {
            var component = _timeComponentPool.Count > 0 ? _timeComponentPool.Pop() : new Assets.Sources.GameLogic.Components.TimeComponent();
            component.Time = newTime;
            return AddComponent(ComponentIds.Time, component);
        }

        public Entity ReplaceTime(float newTime) {
            var previousComponent = hasTime ? time : null;
            var component = _timeComponentPool.Count > 0 ? _timeComponentPool.Pop() : new Assets.Sources.GameLogic.Components.TimeComponent();
            component.Time = newTime;
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

    public partial class Pool {
        public Entity timeEntity { get { return GetGroup(Matcher.Time).GetSingleEntity(); } }

        public Assets.Sources.GameLogic.Components.TimeComponent time { get { return timeEntity.time; } }

        public bool hasTime { get { return timeEntity != null; } }

        public Entity SetTime(float newTime) {
            if (hasTime) {
                throw new SingleEntityException(Matcher.Time);
            }
            var entity = CreateEntity();
            entity.AddTime(newTime);
            return entity;
        }

        public Entity ReplaceTime(float newTime) {
            var entity = timeEntity;
            if (entity == null) {
                entity = SetTime(newTime);
            } else {
                entity.ReplaceTime(newTime);
            }

            return entity;
        }

        public void RemoveTime() {
            DestroyEntity(timeEntity);
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
