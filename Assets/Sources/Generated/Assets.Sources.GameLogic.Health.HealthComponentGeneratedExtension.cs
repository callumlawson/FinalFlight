using System.Collections.Generic;

namespace Entitas {
    public partial class Entity {
        public Assets.Sources.GameLogic.Health.HealthComponent health { get { return (Assets.Sources.GameLogic.Health.HealthComponent)GetComponent(ComponentIds.Health); } }

        public bool hasHealth { get { return HasComponent(ComponentIds.Health); } }

        static readonly Stack<Assets.Sources.GameLogic.Health.HealthComponent> _healthComponentPool = new Stack<Assets.Sources.GameLogic.Health.HealthComponent>();

        public static void ClearHealthComponentPool() {
            _healthComponentPool.Clear();
        }

        public Entity AddHealth(float newHealth) {
            var component = _healthComponentPool.Count > 0 ? _healthComponentPool.Pop() : new Assets.Sources.GameLogic.Health.HealthComponent();
            component.Health = newHealth;
            return AddComponent(ComponentIds.Health, component);
        }

        public Entity ReplaceHealth(float newHealth) {
            var previousComponent = hasHealth ? health : null;
            var component = _healthComponentPool.Count > 0 ? _healthComponentPool.Pop() : new Assets.Sources.GameLogic.Health.HealthComponent();
            component.Health = newHealth;
            ReplaceComponent(ComponentIds.Health, component);
            if (previousComponent != null) {
                _healthComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveHealth() {
            var component = health;
            RemoveComponent(ComponentIds.Health);
            _healthComponentPool.Push(component);
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherHealth;

        public static IMatcher Health {
            get {
                if (_matcherHealth == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.Health);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherHealth = matcher;
                }

                return _matcherHealth;
            }
        }
    }
}
