using System.Collections.Generic;

namespace Entitas {
    public partial class Entity {
        public Assets.Sources.GameLogic.Components.AirframeComponent airframe { get { return (Assets.Sources.GameLogic.Components.AirframeComponent)GetComponent(ComponentIds.Airframe); } }

        public bool hasAirframe { get { return HasComponent(ComponentIds.Airframe); } }

        static readonly Stack<Assets.Sources.GameLogic.Components.AirframeComponent> _airframeComponentPool = new Stack<Assets.Sources.GameLogic.Components.AirframeComponent>();

        public static void ClearAirframeComponentPool() {
            _airframeComponentPool.Clear();
        }

        public Entity AddAirframe(int newMaxAirSpeed) {
            var component = _airframeComponentPool.Count > 0 ? _airframeComponentPool.Pop() : new Assets.Sources.GameLogic.Components.AirframeComponent();
            component.MaxAirSpeed = newMaxAirSpeed;
            return AddComponent(ComponentIds.Airframe, component);
        }

        public Entity ReplaceAirframe(int newMaxAirSpeed) {
            var previousComponent = hasAirframe ? airframe : null;
            var component = _airframeComponentPool.Count > 0 ? _airframeComponentPool.Pop() : new Assets.Sources.GameLogic.Components.AirframeComponent();
            component.MaxAirSpeed = newMaxAirSpeed;
            ReplaceComponent(ComponentIds.Airframe, component);
            if (previousComponent != null) {
                _airframeComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveAirframe() {
            var component = airframe;
            RemoveComponent(ComponentIds.Airframe);
            _airframeComponentPool.Push(component);
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherAirframe;

        public static IMatcher Airframe {
            get {
                if (_matcherAirframe == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.Airframe);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherAirframe = matcher;
                }

                return _matcherAirframe;
            }
        }
    }
}
