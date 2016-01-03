using System.Collections.Generic;

namespace Entitas {
    public partial class Entity {
        public Assets.Sources.GameLogic.Name.NameComponent name { get { return (Assets.Sources.GameLogic.Name.NameComponent)GetComponent(ComponentIds.Name); } }

        public bool hasName { get { return HasComponent(ComponentIds.Name); } }

        static readonly Stack<Assets.Sources.GameLogic.Name.NameComponent> _nameComponentPool = new Stack<Assets.Sources.GameLogic.Name.NameComponent>();

        public static void ClearNameComponentPool() {
            _nameComponentPool.Clear();
        }

        public Entity AddName(string newName) {
            var component = _nameComponentPool.Count > 0 ? _nameComponentPool.Pop() : new Assets.Sources.GameLogic.Name.NameComponent();
            component.Name = newName;
            return AddComponent(ComponentIds.Name, component);
        }

        public Entity ReplaceName(string newName) {
            var previousComponent = hasName ? name : null;
            var component = _nameComponentPool.Count > 0 ? _nameComponentPool.Pop() : new Assets.Sources.GameLogic.Name.NameComponent();
            component.Name = newName;
            ReplaceComponent(ComponentIds.Name, component);
            if (previousComponent != null) {
                _nameComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveName() {
            var component = name;
            RemoveComponent(ComponentIds.Name);
            _nameComponentPool.Push(component);
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherName;

        public static IMatcher Name {
            get {
                if (_matcherName == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.Name);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherName = matcher;
                }

                return _matcherName;
            }
        }
    }
}
