using System.Collections.Generic;

namespace Entitas {
    public partial class Entity {
        public Assets.Sources.GameLogic.Meta.DescriptionComponent description { get { return (Assets.Sources.GameLogic.Meta.DescriptionComponent)GetComponent(ComponentIds.Description); } }

        public bool hasDescription { get { return HasComponent(ComponentIds.Description); } }

        static readonly Stack<Assets.Sources.GameLogic.Meta.DescriptionComponent> _descriptionComponentPool = new Stack<Assets.Sources.GameLogic.Meta.DescriptionComponent>();

        public static void ClearDescriptionComponentPool() {
            _descriptionComponentPool.Clear();
        }

        public Entity AddDescription(string newDescription) {
            var component = _descriptionComponentPool.Count > 0 ? _descriptionComponentPool.Pop() : new Assets.Sources.GameLogic.Meta.DescriptionComponent();
            component.Description = newDescription;
            return AddComponent(ComponentIds.Description, component);
        }

        public Entity ReplaceDescription(string newDescription) {
            var previousComponent = hasDescription ? description : null;
            var component = _descriptionComponentPool.Count > 0 ? _descriptionComponentPool.Pop() : new Assets.Sources.GameLogic.Meta.DescriptionComponent();
            component.Description = newDescription;
            ReplaceComponent(ComponentIds.Description, component);
            if (previousComponent != null) {
                _descriptionComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveDescription() {
            var component = description;
            RemoveComponent(ComponentIds.Description);
            _descriptionComponentPool.Push(component);
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherDescription;

        public static IMatcher Description {
            get {
                if (_matcherDescription == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.Description);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherDescription = matcher;
                }

                return _matcherDescription;
            }
        }
    }
}
