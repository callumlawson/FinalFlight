using System.Collections.Generic;

namespace Entitas {
    public partial class Entity {
        public Assets.Sources.GameLogic.Components.DayComponent day { get { return (Assets.Sources.GameLogic.Components.DayComponent)GetComponent(ComponentIds.Day); } }

        public bool hasDay { get { return HasComponent(ComponentIds.Day); } }

        static readonly Stack<Assets.Sources.GameLogic.Components.DayComponent> _dayComponentPool = new Stack<Assets.Sources.GameLogic.Components.DayComponent>();

        public static void ClearDayComponentPool() {
            _dayComponentPool.Clear();
        }

        public Entity AddDay(int newDay) {
            var component = _dayComponentPool.Count > 0 ? _dayComponentPool.Pop() : new Assets.Sources.GameLogic.Components.DayComponent();
            component.Day = newDay;
            return AddComponent(ComponentIds.Day, component);
        }

        public Entity ReplaceDay(int newDay) {
            var previousComponent = hasDay ? day : null;
            var component = _dayComponentPool.Count > 0 ? _dayComponentPool.Pop() : new Assets.Sources.GameLogic.Components.DayComponent();
            component.Day = newDay;
            ReplaceComponent(ComponentIds.Day, component);
            if (previousComponent != null) {
                _dayComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveDay() {
            var component = day;
            RemoveComponent(ComponentIds.Day);
            _dayComponentPool.Push(component);
            return this;
        }
    }

    public partial class Pool {
        public Entity dayEntity { get { return GetGroup(Matcher.Day).GetSingleEntity(); } }

        public Assets.Sources.GameLogic.Components.DayComponent day { get { return dayEntity.day; } }

        public bool hasDay { get { return dayEntity != null; } }

        public Entity SetDay(int newDay) {
            if (hasDay) {
                throw new SingleEntityException(Matcher.Day);
            }
            var entity = CreateEntity();
            entity.AddDay(newDay);
            return entity;
        }

        public Entity ReplaceDay(int newDay) {
            var entity = dayEntity;
            if (entity == null) {
                entity = SetDay(newDay);
            } else {
                entity.ReplaceDay(newDay);
            }

            return entity;
        }

        public void RemoveDay() {
            DestroyEntity(dayEntity);
        }
    }

    public partial class Matcher {
        static IMatcher _matcherDay;

        public static IMatcher Day {
            get {
                if (_matcherDay == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.Day);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherDay = matcher;
                }

                return _matcherDay;
            }
        }
    }
}
