using System.Collections.Generic;

namespace Entitas {
    public partial class Entity {
        public Assets.Sources.GameLogic.Mood.MoodComponent mood { get { return (Assets.Sources.GameLogic.Mood.MoodComponent)GetComponent(ComponentIds.Mood); } }

        public bool hasMood { get { return HasComponent(ComponentIds.Mood); } }

        static readonly Stack<Assets.Sources.GameLogic.Mood.MoodComponent> _moodComponentPool = new Stack<Assets.Sources.GameLogic.Mood.MoodComponent>();

        public static void ClearMoodComponentPool() {
            _moodComponentPool.Clear();
        }

        public Entity AddMood(Assets.Sources.GameLogic.Mood.Mood newMood) {
            var component = _moodComponentPool.Count > 0 ? _moodComponentPool.Pop() : new Assets.Sources.GameLogic.Mood.MoodComponent();
            component.Mood = newMood;
            return AddComponent(ComponentIds.Mood, component);
        }

        public Entity ReplaceMood(Assets.Sources.GameLogic.Mood.Mood newMood) {
            var previousComponent = hasMood ? mood : null;
            var component = _moodComponentPool.Count > 0 ? _moodComponentPool.Pop() : new Assets.Sources.GameLogic.Mood.MoodComponent();
            component.Mood = newMood;
            ReplaceComponent(ComponentIds.Mood, component);
            if (previousComponent != null) {
                _moodComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveMood() {
            var component = mood;
            RemoveComponent(ComponentIds.Mood);
            _moodComponentPool.Push(component);
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherMood;

        public static IMatcher Mood {
            get {
                if (_matcherMood == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.Mood);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherMood = matcher;
                }

                return _matcherMood;
            }
        }
    }
}
